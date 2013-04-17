
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysLogSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
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
	public partial class Vi_SysLogSqlPrivider
	{
        public override IList<Vi_SysLogModel> getAllLogByUserId(int userId,int limit)
        {
            //throw new NotImplementedException();
            IList<Vi_SysLogModel> _Entity = new List<Vi_SysLogModel>();
            string commandString = "select * from Vi_SysLog where UserID = @userId and SysType = @limit order by CreateTime desc";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@userId", DbType.Int32,userId);
            db.AddInParameter(command, "@limit", DbType.Int32, limit);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                    while (dr.Read())
                    {
                        _Entity.Add(Populate_Vi_SysLogEntity_FromDr(dr));
                    }
            }
            return _Entity;
        }
        /// <summary>
        /// 根据用户ID和用户类型得到用户上次登录信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public override Vi_SysLogModel getLastLogInfo(int userId, int limit)
        {
            //throw new NotImplementedException();
            Vi_SysLogModel _Entity = new Vi_SysLogModel();
            string commandString = "select top 1 * from Vi_SysLog where UserID = @userId and SysType = @limit order by CreateTime desc";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@userId", DbType.Int32, userId);
            db.AddInParameter(command, "@limit", DbType.Int32, limit);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysLogEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
	}
}
