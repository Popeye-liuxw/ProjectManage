
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiPermSqlPrivider.cs
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
    public partial class Vi_SysPosiPermSqlPrivider : Vi_SysPosiPermProvider
    {
        #region Vi_SysPosiPerm

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int SaveVi_SysPosiPerm(Vi_SysPosiPermModel Model)
        {
            string commandString = "INSERT INTO [Vi_SysPosiPerm] ([PosiID],[PosiName],[SysModuleID],[Permissions],[UserID],[CreateTime]) values( @PosiID, @PosiName, @SysModuleID, @Permissions, @UserID, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
            db.AddInParameter(command, "@PosiID", DbType.Int32, Model.PosiID);
            db.AddInParameter(command, "@PosiName", DbType.String, Model.PosiName);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, Model.SysModuleID);
            db.AddInParameter(command, "@Permissions", DbType.Int32, Model.Permissions);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            Model.CreateTime = DateTime.Now;
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            //db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_SysPosiPerm(Vi_SysPosiPermModel Model)
        {
            string commandString = "update [Vi_SysPosiPerm] set [PosiID]=@PosiID,[PosiName]=@PosiName,[SysModuleID]=@SysModuleID,[Permissions]=@Permissions,[UserID]=@UserID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@PosiID", DbType.Int32, Model.PosiID);
            db.AddInParameter(command, "@PosiName", DbType.String, Model.PosiName);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, Model.SysModuleID);
            db.AddInParameter(command, "@Permissions", DbType.Int32, Model.Permissions);
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
        public override int DeleteVi_SysPosiPerm(int ID)
        {
            string commandString = "delete from Vi_SysPosiPerm where dbo.Vi_SysPosiPerm.ID=@dbo.Vi_SysPosiPerm.ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_SysPosiPerm.ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_SysPosiPerm返回的查询dateset创建一个Vi_SysPosiPerm对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysPosiPerm对象</returns>
        private Vi_SysPosiPermModel Populate_Vi_SysPosiPermEntity_FromDr(DataSet ds)
        {
            Vi_SysPosiPermModel nObject = new Vi_SysPosiPermModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.PosiID = ((ds.Tables[0].Rows[0]["PosiID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["PosiID"]);
                nObject.PosiName = ds.Tables[0].Rows[0]["PosiName"].ToString();
                nObject.SysModuleID = ((ds.Tables[0].Rows[0]["SysModuleID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["SysModuleID"]);
                nObject.Permissions = ((ds.Tables[0].Rows[0]["Permissions"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["Permissions"]);
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
        /// 得到  vi_sysposiperm 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_sysposiperm 数据实体</returns>
        private Vi_SysPosiPermModel Populate_Vi_SysPosiPermEntity_FromDr(IDataReader dr)
        {
            Vi_SysPosiPermModel Obj = new Vi_SysPosiPermModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.PosiID = ((dr["PosiID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PosiID"]);
            Obj.PosiName = dr["PosiName"].ToString();
            Obj.SysModuleID = ((dr["SysModuleID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["SysModuleID"]);
            Obj.Permissions = ((dr["Permissions"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Permissions"]);
            Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_sysposiperm 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_sysposiperm 数据实体</returns>
        private Vi_SysPosiPermModel Populate_Vi_SysPosiPermEntity_FromDr(DataRow dr)
        {
            Vi_SysPosiPermModel Obj = new Vi_SysPosiPermModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.PosiID = ((dr["PosiID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PosiID"]);
                Obj.PosiName = dr["PosiName"].ToString();
                Obj.SysModuleID = ((dr["SysModuleID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["SysModuleID"]);
                Obj.Permissions = ((dr["Permissions"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Permissions"]);
                Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_SysPosiPerm对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysPosiPerm对象</returns>
        public override Vi_SysPosiPermModel Get_Vi_SysPosiPermModel(Int32 ID)
        {
            Vi_SysPosiPermModel _Entity = null;
            string commandString = "select * from Vi_SysPosiPerm where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysPosiPermEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_SysPosiPerm所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_SysPosiPermModel> GetVi_SysPosiPermAll()
        {
            IList<Vi_SysPosiPermModel> _Entity = new List<Vi_SysPosiPermModel>();
            string commandString = "select * from Vi_SysPosiPerm";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysPosiPermEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
    }
}
