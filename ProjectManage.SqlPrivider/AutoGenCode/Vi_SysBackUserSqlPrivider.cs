
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysBackUserSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
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
	public partial class Vi_SysBackUserSqlPrivider:Vi_SysBackUserProvider
	{
		#region Vi_SysBackUser
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
        public override int SaveVi_SysBackUser(Vi_SysBackUserModel Model)
        {
            Model.CreateTime = DateTime.Now;
            string commandString = "INSERT INTO [Vi_SysBackUser] ([UserName],[UserPwd],[RealName],[Email],[PhoneNum],[Back],[CreateTime],[UpdateTime]) values( @UserName, @UserPwd, @RealName, @Email, @PhoneNum, @Back, @CreateTime,@UpdateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@UserName", DbType.String, Model.UserName);
            db.AddInParameter(command, "@UserPwd", DbType.String, Model.UserPwd);
            db.AddInParameter(command, "@RealName", DbType.String, Model.RealName);
            db.AddInParameter(command, "@Email", DbType.String, Model.Email);
            db.AddInParameter(command, "@PhoneNum", DbType.String, Model.PhoneNum);
            db.AddInParameter(command, "@Back", DbType.String, Model.Back);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
        public override int UpdateVi_SysBackUser(Vi_SysBackUserModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_SysBackUser] set [UserName]=@UserName,[UserPwd]=@UserPwd,[RealName]=@RealName,[Email]=@Email,[PhoneNum]=@PhoneNum,[Back]=@Back,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@UserName", DbType.String, Model.UserName);
            db.AddInParameter(command, "@UserPwd", DbType.String, Model.UserPwd);
            db.AddInParameter(command, "@RealName", DbType.String, Model.RealName);
            db.AddInParameter(command, "@Email", DbType.String, Model.Email);
            db.AddInParameter(command, "@PhoneNum", DbType.String, Model.PhoneNum);
            db.AddInParameter(command, "@Back", DbType.String, Model.Back);
            //db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public override int DeleteVi_SysBackUser(int ID)
		{
			string commandString="delete from Vi_SysBackUser where Vi_SysBackUser.ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@ID",DbType.Int32,ID);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_SysBackUser返回的查询dateset创建一个Vi_SysBackUser对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysBackUser对象</returns>
        private Vi_SysBackUserModel Populate_Vi_SysBackUserEntity_FromDr(DataSet ds)
        {
            Vi_SysBackUserModel nObject = new Vi_SysBackUserModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                nObject.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                nObject.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                nObject.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                nObject.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                nObject.Back = ds.Tables[0].Rows[0]["Back"].ToString();
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
		/// 得到  vi_sysbackuser 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysbackuser 数据实体</returns>
		private Vi_SysBackUserModel Populate_Vi_SysBackUserEntity_FromDr(IDataReader dr)
		{
			Vi_SysBackUserModel Obj = new Vi_SysBackUserModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserPwd =  dr["UserPwd"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.Email =  dr["Email"].ToString();
				Obj.PhoneNum =  dr["PhoneNum"].ToString();
				Obj.Back =  dr["Back"].ToString();
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_sysbackuser 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysbackuser 数据实体</returns>
		private Vi_SysBackUserModel Populate_Vi_SysBackUserEntity_FromDr(DataRow dr)
		{
			Vi_SysBackUserModel Obj = new Vi_SysBackUserModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserPwd =  dr["UserPwd"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.Email =  dr["Email"].ToString();
				Obj.PhoneNum =  dr["PhoneNum"].ToString();
				Obj.Back =  dr["Back"].ToString();
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_SysBackUser对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysBackUser对象</returns>
        public override Vi_SysBackUserModel Get_Vi_SysBackUserModel(Int32 ID)
        {
            Vi_SysBackUserModel _Entity=null;
            string commandString="select * from Vi_SysBackUser where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32,ID);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_SysBackUserEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_SysBackUser所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_SysBackUserModel> GetVi_SysBackUserAll()
		{
			IList< Vi_SysBackUserModel> _Entity=new List< Vi_SysBackUserModel>();
			string commandString="select * from Vi_SysBackUser";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_SysBackUserEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
