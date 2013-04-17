
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_PrjDailyPaperSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/3
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using System.Data;
using System.Data.Common;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
	public partial class Vi_PrjDailyPaperSqlPrivider : Vi_PrjDailyPaperProvider
	{
        public override IList<Vi_PrjDailyPaperModel> GetPrjDailyPaper(int prjId,int userId, int top)
        {
            IList<Vi_PrjDailyPaperModel> _Entity = new List<Vi_PrjDailyPaperModel>();
            string commandString = "SELECT TOP " + top + " [ID],[PrjID],[State],[Summarize],[UserID],[CreateTime],[UpdateTime] FROM [Vi_PrjDailyPaper] where PrjID = @prjId and UserID = @userId order by CreateTime desc";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@userId", DbType.Int32, userId);
            db.AddInParameter(command, "@prjId", DbType.Int32, prjId);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_PrjDailyPaperEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 获取日报信息，根据项目ID和用户ID
        /// </summary>
        /// <param name="prjId"></param>
        /// <param name="userId"></param>
        /// <param name="dt">某天的日报，null 取最新的一条日报信息</param>
        /// <returns></returns>
        public override Vi_PrjDailyPaperModel GetPrjDailyPaperInfo(int prjId, int userId, DateTime dt)
        {
            Vi_PrjDailyPaperModel _Entity = null;
            string commandString = "SELECT [ID],[PrjID],[State],[Summarize],[UserID],[CreateTime],[UpdateTime] FROM [Vi_PrjDailyPaper] where PrjID = @prjId and UserID = @userId order by CreateTime desc";
            DbCommand command = db.GetSqlStringCommand(commandString);
            if (dt != null)
            {
                DateTime dt1 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                commandString = "SELECT [ID],[PrjID],[State],[Summarize],[UserID],[CreateTime],[UpdateTime] FROM [Vi_PrjDailyPaper] where PrjID = @prjId and UserID = @userId and CreateTime between @createTime and @createTime1 order by CreateTime desc";
                command = db.GetSqlStringCommand(commandString);
                db.AddInParameter(command, "@createTime", DbType.DateTime, dt1);
                db.AddInParameter(command, "@createTime1", DbType.DateTime, dt2);
            }            
            db.AddInParameter(command, "@userId", DbType.Int32, userId);
            db.AddInParameter(command, "@prjId", DbType.Int32, prjId);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                if (dr.Read())
                    _Entity = Populate_Vi_PrjDailyPaperEntity_FromDr(dr);
            }
            return _Entity;
        }
        /// <summary>
        /// 获取某用户某月的日报记录情况
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public override DataTable GetMonthDataTable(int userID, int month,int year)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select d.ID,d.UserID,s.RealName,j.citemname,d.State,d.CreateTime from Vi_PrjDailyPaper as d left join Vi_ProjectInfo as j on d.PrjID = j.ID left join Vi_SysUser as s on d.UserID = s.ID ");
            
            DataTable result = new DataTable();
            DateTime dt = DateTime.Now;
            if (userID > 0 && month > 0 && year >0)
            {
                try
                {
                    DateTime dt1 = new DateTime(year, month, 1, 0, 0, 0);
                    DateTime dt2 = new DateTime(year, month, dt1.AddMonths(1).AddDays(-1).Day, 23, 59, 59);
                    sqlStr.AppendFormat("where d.UserID = {0} and d.CreateTime between '{1}' and '{2}' ", userID, dt1, dt2);
                    result = this.GetDataTable(sqlStr.ToString());
                }
                catch (Exception)
                {

                 
                }
            }

            return result;
        }
    }
}
