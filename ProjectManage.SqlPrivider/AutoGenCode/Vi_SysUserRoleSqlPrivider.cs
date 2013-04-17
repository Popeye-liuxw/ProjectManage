
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserRoleSqlPrivider.cs
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
	public partial class Vi_SysUserRoleSqlPrivider:Vi_SysUserRoleProvider
	{
		#region Vi_SysUserRole
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveVi_SysUserRole(Vi_SysUserRoleModel Model)
		{
			string commandString="INSERT INTO [Vi_SysUserRole] ([UserID],[PosiID],[Back],[Back2],[CreateTime]) values( @UserID, @PosiID, @Back, @Back2, @CreateTime)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@UserID",DbType.Int32,Model.UserID);
		db.AddInParameter(command,"@PosiID",DbType.Int32,Model.PosiID);
		db.AddInParameter(command,"@Back",DbType.String,Model.Back);
		db.AddInParameter(command,"@Back2",DbType.Int32,Model.Back2);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdateVi_SysUserRole(Vi_SysUserRoleModel Model)
		{
			string commandString="update [Vi_SysUserRole] set [UserID]=@UserID,[PosiID]=@PosiID,[Back]=@Back,[Back2]=@Back2,[CreateTime]=@CreateTime, where ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@UserID",DbType.Int32,Model.UserID);
		db.AddInParameter(command,"@PosiID",DbType.Int32,Model.PosiID);
		db.AddInParameter(command,"@Back",DbType.String,Model.Back);
		db.AddInParameter(command,"@Back2",DbType.Int32,Model.Back2);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public override int DeleteVi_SysUserRole(int UserId,int PosiId)
		{
			string commandString="delete from Vi_SysUserRole where UserId = @UserId and PosiId =@PosiId";
			DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(command, "@PosiId", DbType.Int32, PosiId);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_SysUserRole返回的查询dateset创建一个Vi_SysUserRole对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysUserRole对象</returns>
        private Vi_SysUserRoleModel Populate_Vi_SysUserRoleEntity_FromDr(DataSet ds)
        {
            Vi_SysUserRoleModel nObject = new Vi_SysUserRoleModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                nObject.PosiID = ((ds.Tables[0].Rows[0]["PosiID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["PosiID"]);
                nObject.Back = ds.Tables[0].Rows[0]["Back"].ToString();
                nObject.Back2 = ((ds.Tables[0].Rows[0]["Back2"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["Back2"]);
                nObject.CreateTime = ((ds.Tables[0].Rows[0]["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
		/// <summary>
		/// 得到  vi_sysuserrole 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysuserrole 数据实体</returns>
		private Vi_SysUserRoleModel Populate_Vi_SysUserRoleEntity_FromDr(IDataReader dr)
		{
			Vi_SysUserRoleModel Obj = new Vi_SysUserRoleModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.PosiID = (( dr["PosiID"])==DBNull.Value)?0:Convert.ToInt32( dr["PosiID"]);
                Obj.Back = String.IsNullOrEmpty(dr["Back"].ToString()) ? "" : dr["Back"].ToString();
				Obj.Back2 = (( dr["Back2"])==DBNull.Value)?0:Convert.ToInt32( dr["Back2"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_sysuserrole 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysuserrole 数据实体</returns>
		private Vi_SysUserRoleModel Populate_Vi_SysUserRoleEntity_FromDr(DataRow dr)
		{
			Vi_SysUserRoleModel Obj = new Vi_SysUserRoleModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.PosiID = (( dr["PosiID"])==DBNull.Value)?0:Convert.ToInt32( dr["PosiID"]);
				Obj.Back =  dr["Back"].ToString();
				Obj.Back2 = (( dr["Back2"])==DBNull.Value)?0:Convert.ToInt32( dr["Back2"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_SysUserRole对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysUserRole对象</returns>
        public override Vi_SysUserRoleModel Get_Vi_SysUserRoleModel(Int32 ID)
        {
            Vi_SysUserRoleModel _Entity=null;
            string commandString="select * from Vi_SysUserRole where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"ID",DbType.Int32);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_SysUserRoleEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_SysUserRole所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_SysUserRoleModel> GetVi_SysUserRoleAll()
		{
			IList< Vi_SysUserRoleModel> _Entity=new List< Vi_SysUserRoleModel>();
			string commandString="select * from Vi_SysUserRole";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_SysUserRoleEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
