
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
using System.Data;
using System.Data.Common;
using ProjectManage.Model;
using ProjectManage.Provider;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
    public partial class Vi_PrjDailyPaperSqlPrivider : Vi_PrjDailyPaperProvider
    {
        #region Vi_PrjDailyPaper

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int SaveVi_PrjDailyPaper(Vi_PrjDailyPaperModel Model)
        {
            Model.CreateTime = DateTime.Now;
            string commandString = "INSERT INTO [Vi_PrjDailyPaper] ([PrjID],[State],[Summarize],[UserID],[CreateTime]) values( @PrjID, @State, @Summarize, @UserID, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
            db.AddInParameter(command, "@PrjID", DbType.Int32, Model.PrjID);
            db.AddInParameter(command, "@State", DbType.Int32, Model.State);
            db.AddInParameter(command, "@Summarize", DbType.String, Model.Summarize);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            //db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_PrjDailyPaper(Vi_PrjDailyPaperModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_PrjDailyPaper] set [PrjID]=@PrjID,[State]=@State,[Summarize]=@Summarize,[UserID]=@UserID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@PrjID", DbType.Int32, Model.PrjID);
            db.AddInParameter(command, "@State", DbType.Int32, Model.State);
            db.AddInParameter(command, "@Summarize", DbType.String, Model.Summarize);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            //db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///删除数据库一条数据
        ///</summary>
        /// <param name="ID">ID</param>
        /// <returns>影响的条数</returns>
        public override int DeleteVi_PrjDailyPaper(int ID)
        {
            string commandString = "delete from Vi_PrjDailyPaper where dbo.Vi_PrjDailyPaper.ID=@dbo.Vi_PrjDailyPaper.ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_PrjDailyPaper.ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_PrjDailyPaper返回的查询dateset创建一个Vi_PrjDailyPaper对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_PrjDailyPaper对象</returns>
        private Vi_PrjDailyPaperModel Populate_Vi_PrjDailyPaperEntity_FromDr(DataSet ds)
        {
            Vi_PrjDailyPaperModel nObject = new Vi_PrjDailyPaperModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.PrjID = ((ds.Tables[0].Rows[0]["PrjID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["PrjID"]);
                nObject.State = ((ds.Tables[0].Rows[0]["State"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["State"]);
                nObject.Summarize = ds.Tables[0].Rows[0]["Summarize"].ToString();
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                nObject.CreateTime = ((ds.Tables[0].Rows[0]["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]);
                nObject.UpdateTime = ((ds.Tables[0].Rows[0]["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateTime"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
        /// <summary>
        /// 得到  vi_prjdailypaper 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_prjdailypaper 数据实体</returns>
        private Vi_PrjDailyPaperModel Populate_Vi_PrjDailyPaperEntity_FromDr(IDataReader dr)
        {
            Vi_PrjDailyPaperModel Obj = new Vi_PrjDailyPaperModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.PrjID = ((dr["PrjID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrjID"]);
            Obj.State = ((dr["State"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["State"]);
            Obj.Summarize = dr["Summarize"].ToString();
            Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_prjdailypaper 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_prjdailypaper 数据实体</returns>
        private Vi_PrjDailyPaperModel Populate_Vi_PrjDailyPaperEntity_FromDr(DataRow dr)
        {
            Vi_PrjDailyPaperModel Obj = new Vi_PrjDailyPaperModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.PrjID = ((dr["PrjID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrjID"]);
                Obj.State = ((dr["State"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["State"]);
                Obj.Summarize = dr["Summarize"].ToString();
                Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_PrjDailyPaper对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_PrjDailyPaper对象</returns>
        public override Vi_PrjDailyPaperModel Get_Vi_PrjDailyPaperModel(Int32 ID)
        {
            Vi_PrjDailyPaperModel _Entity = null;
            string commandString = "select * from Vi_PrjDailyPaper where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_PrjDailyPaperEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_PrjDailyPaper所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_PrjDailyPaperModel> GetVi_PrjDailyPaperAll()
        {
            IList<Vi_PrjDailyPaperModel> _Entity = new List<Vi_PrjDailyPaperModel>();
            string commandString = "select * from Vi_PrjDailyPaper";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_PrjDailyPaperEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
    }
}
