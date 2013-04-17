
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysModulesSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/24
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
    public partial class Vi_SysModulesSqlPrivider : Vi_SysModulesProvider
    {
        #region Vi_SysModules

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int SaveVi_SysModules(Vi_SysModulesModel Model)
        {
            string commandString = "INSERT INTO [Vi_SysModules] ([ModuleName],[URL],[ModuleLevel],[ModuleNum],[UserID],[CreateTime]) values( @ModuleName, @URL, @ModuleLevel, @ModuleNum, @UserID, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@ModuleName", DbType.String, Model.ModuleName);
            db.AddInParameter(command, "@URL", DbType.String, Model.URL);
            db.AddInParameter(command, "@ModuleLevel", DbType.String, Model.ModuleLevel);
            db.AddInParameter(command, "@ModuleNum", DbType.String, Model.ModuleNum);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            Model.CreateTime = DateTime.Now;
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            //db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_SysModules(Vi_SysModulesModel Model)
        {

            string commandString = "update [Vi_SysModules] set [ModuleName]=@ModuleName,[URL]=@URL,[ModuleLevel]=@ModuleLevel,[ModuleNum]=@ModuleNum,[UserID]=@UserID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@ModuleName", DbType.String, Model.ModuleName);
            db.AddInParameter(command, "@URL", DbType.String, Model.URL);
            db.AddInParameter(command, "@ModuleLevel", DbType.String, Model.ModuleLevel);
            db.AddInParameter(command, "@ModuleNum", DbType.String, Model.ModuleNum);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            //db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
            Model.UpdateTime = DateTime.Now;
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///删除数据库一条数据
        ///</summary>
        /// <param name="ID">ID</param>
        /// <returns>影响的条数</returns>
        public override int DeleteVi_SysModules(int ID)
        {
            string commandString = "delete from Vi_SysModules where dbo.Vi_SysModules.ID=@dbo.Vi_SysModules.ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_SysModules.ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_SysModules返回的查询dateset创建一个Vi_SysModules对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysModules对象</returns>
        private Vi_SysModulesModel Populate_Vi_SysModulesEntity_FromDr(DataSet ds)
        {
            Vi_SysModulesModel nObject = new Vi_SysModulesModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                nObject.URL = ds.Tables[0].Rows[0]["URL"].ToString();
                nObject.ModuleLevel = ds.Tables[0].Rows[0]["ModuleLevel"].ToString();
                nObject.ModuleNum = ds.Tables[0].Rows[0]["ModuleNum"].ToString();
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
        /// 得到  vi_sysmodules 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_sysmodules 数据实体</returns>
        private Vi_SysModulesModel Populate_Vi_SysModulesEntity_FromDr(IDataReader dr)
        {
            Vi_SysModulesModel Obj = new Vi_SysModulesModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.ModuleName = dr["ModuleName"].ToString();
            Obj.URL = dr["URL"].ToString();
            Obj.ModuleLevel = dr["ModuleLevel"].ToString();
            Obj.ModuleNum = dr["ModuleNum"].ToString();
            Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_sysmodules 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_sysmodules 数据实体</returns>
        private Vi_SysModulesModel Populate_Vi_SysModulesEntity_FromDr(DataRow dr)
        {
            Vi_SysModulesModel Obj = new Vi_SysModulesModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.ModuleName = dr["ModuleName"].ToString();
                Obj.URL = dr["URL"].ToString();
                Obj.ModuleLevel = dr["ModuleLevel"].ToString();
                Obj.ModuleNum = dr["ModuleNum"].ToString();
                Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_SysModules对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysModules对象</returns>
        public override Vi_SysModulesModel Get_Vi_SysModulesModel(Int32 ID)
        {
            Vi_SysModulesModel _Entity = null;
            string commandString = "select * from Vi_SysModules where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysModulesEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_SysModules所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_SysModulesModel> GetVi_SysModulesAll()
        {
            IList<Vi_SysModulesModel> _Entity = new List<Vi_SysModulesModel>();
            string commandString = "select * from Vi_SysModules";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysModulesEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
    }
}
