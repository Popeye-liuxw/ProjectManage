
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserSqlPrivider.cs
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
	public partial class Vi_SysUserSqlPrivider:Vi_SysUserProvider
	{
		#region Vi_SysUser
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveVi_SysUser(Vi_SysUserModel Model)
		{
			string commandString="INSERT INTO [Vi_SysUser] ([UserName],[UserPwd],[RealName],[Birthday],[Email],[PhoneNum],[Tel],[GroupID],[CreateTime],[UpdateTime]) values( @UserName, @UserPwd, @RealName, @Birthday, @Email, @PhoneNum, @Tel, @GroupID, @CreateTime, @UpdateTime)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		//db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@UserName",DbType.String,Model.UserName);
        db.AddInParameter(command, "@UserPwd", DbType.String, "empty");
		db.AddInParameter(command,"@RealName",DbType.String,Model.RealName);
		db.AddInParameter(command,"@Birthday",DbType.DateTime,Model.Birthday);
		db.AddInParameter(command,"@Email",DbType.String,Model.Email);
		db.AddInParameter(command,"@PhoneNum",DbType.String,Model.PhoneNum);
		db.AddInParameter(command,"@Tel",DbType.String,Model.Tel);
		//db.AddInParameter(command,"@PersonProp",DbType.String,Model.PersonProp);
		//db.AddInParameter(command,"@EmployeeID",DbType.String,Model.EmployeeID);
		db.AddInParameter(command,"@GroupID",DbType.String,Model.GroupID);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdateVi_SysUser(Vi_SysUserModel Model)
		{
			string commandString="update [Vi_SysUser] set [UserName]=@UserName,[UserPwd]=@UserPwd,[RealName]=@RealName,[Birthday]=@Birthday,[Email]=@Email,[PhoneNum]=@PhoneNum,[Tel]=@Tel,[PersonProp]=@PersonProp,[EmployeeID]=@EmployeeID,[GroupID]=@GroupID,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime where ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@UserName",DbType.String,Model.UserName);
		db.AddInParameter(command,"@UserPwd",DbType.String,Model.UserPwd);
		db.AddInParameter(command,"@RealName",DbType.String,Model.RealName);
		db.AddInParameter(command,"@Birthday",DbType.DateTime,Model.Birthday);
		db.AddInParameter(command,"@Email",DbType.String,Model.Email);
		db.AddInParameter(command,"@PhoneNum",DbType.String,Model.PhoneNum);
		db.AddInParameter(command,"@Tel",DbType.String,Model.Tel);
		db.AddInParameter(command,"@PersonProp",DbType.String,Model.PersonProp);
		db.AddInParameter(command,"@EmployeeID",DbType.String,Model.EmployeeID);
		db.AddInParameter(command,"@GroupID",DbType.String,Model.GroupID);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public override int DeleteVi_SysUser(int ID)
		{
			string commandString="delete from Vi_SysUser where dbo.Vi_SysUser.ID=@dbo.Vi_SysUser.ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_SysUser.ID", DbType.Int32, ID);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_SysUser返回的查询dateset创建一个Vi_SysUser对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysUser对象</returns>
        private Vi_SysUserModel Populate_Vi_SysUserEntity_FromDr(DataSet ds)
        {
            Vi_SysUserModel nObject = new Vi_SysUserModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                nObject.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                nObject.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                nObject.Birthday = ((ds.Tables[0].Rows[0]["Birthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"]);
                nObject.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                nObject.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                nObject.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                nObject.PersonProp = ds.Tables[0].Rows[0]["PersonProp"].ToString();
                nObject.EmployeeID = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                nObject.GroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
                nObject.CreateTime = ((ds.Tables[0].Rows[0]["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]);
                nObject.UpdateTime = ((ds.Tables[0].Rows[0]["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateTime"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
		/// <summary>
		/// 得到  vi_sysuser 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysuser 数据实体</returns>
		private Vi_SysUserModel Populate_Vi_SysUserEntity_FromDr(IDataReader dr)
		{
			Vi_SysUserModel Obj = new Vi_SysUserModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserPwd =  dr["UserPwd"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.Birthday = (( dr["Birthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Birthday"]);
				Obj.Email =  dr["Email"].ToString();
				Obj.PhoneNum =  dr["PhoneNum"].ToString();
				Obj.Tel =  dr["Tel"].ToString();
				Obj.PersonProp =  dr["PersonProp"].ToString();
				Obj.EmployeeID =  dr["EmployeeID"].ToString();
				Obj.GroupID =  dr["GroupID"].ToString();
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_sysuser 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysuser 数据实体</returns>
		private Vi_SysUserModel Populate_Vi_SysUserEntity_FromDr(DataRow dr)
		{
			Vi_SysUserModel Obj = new Vi_SysUserModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserPwd =  dr["UserPwd"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.Birthday = (( dr["Birthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Birthday"]);
				Obj.Email =  dr["Email"].ToString();
				Obj.PhoneNum =  dr["PhoneNum"].ToString();
				Obj.Tel =  dr["Tel"].ToString();
				Obj.PersonProp =  dr["PersonProp"].ToString();
				Obj.EmployeeID =  dr["EmployeeID"].ToString();
				Obj.GroupID =  dr["GroupID"].ToString();
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_SysUser对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysUser对象</returns>
        public override Vi_SysUserModel Get_Vi_SysUserModel(Int32 ID)
        {
            Vi_SysUserModel _Entity=null;
            string commandString="select * from Vi_SysUser where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "ID", DbType.Int32, ID);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_SysUserEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_SysUser所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_SysUserModel> GetVi_SysUserAll()
		{
			IList< Vi_SysUserModel> _Entity=new List< Vi_SysUserModel>();
            string commandString = "select * from Vi_SysUser where UserPwd != 'empty'";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_SysUserEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
