
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysEmailServerSqlPrivider.cs
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
	public partial class Vi_SysEmailServerSqlPrivider:Vi_SysEmailServerProvider
	{
		#region Vi_SysEmailServer
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
        public override int SaveVi_SysEmailServer(Vi_SysEmailServerModel Model)
        {
            Model.CreateTime = DateTime.Now;
            string commandString = "INSERT INTO [Vi_SysEmailServer] ([UserName],[UserPwd],[Port],[EnableSSL],[SMTPHost],[EmailName],[Address],[DisplayName],[State],[UserID],[CreateTime]) values( @UserName, @UserPwd, @Port, @EnableSSL, @SMTPHost, @EmailName, @Address, @DisplayName, @State, @UserID, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
            db.AddInParameter(command, "@UserName", DbType.String, Model.UserName);
            db.AddInParameter(command, "@UserPwd", DbType.String, Model.UserPwd);
            db.AddInParameter(command, "@Port", DbType.Int32, Model.Port);
            db.AddInParameter(command, "@EnableSSL", DbType.Int32, Model.EnableSSL);
            db.AddInParameter(command, "@SMTPHost", DbType.String, Model.SMTPHost);
            db.AddInParameter(command, "@EmailName", DbType.String, Model.EmailName);
            db.AddInParameter(command, "@Address", DbType.String, Model.Address);
            db.AddInParameter(command, "@DisplayName", DbType.String, Model.DisplayName);
            db.AddInParameter(command, "@State", DbType.Int32, Model.State);
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
        public override int UpdateVi_SysEmailServer(Vi_SysEmailServerModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_SysEmailServer] set [UserName]=@UserName,[UserPwd]=@UserPwd,[Port]=@Port,[EnableSSL]=@EnableSSL,[SMTPHost]=@SMTPHost,[EmailName]=@EmailName,[Address]=@Address,[DisplayName]=@DisplayName,[State]=@State,[UserID]=@UserID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@UserName", DbType.String, Model.UserName);
            db.AddInParameter(command, "@UserPwd", DbType.String, Model.UserPwd);
            db.AddInParameter(command, "@Port", DbType.Int32, Model.Port);
            db.AddInParameter(command, "@EnableSSL", DbType.Int32, Model.EnableSSL);
            db.AddInParameter(command, "@SMTPHost", DbType.String, Model.SMTPHost);
            db.AddInParameter(command, "@EmailName", DbType.String, Model.EmailName);
            db.AddInParameter(command, "@Address", DbType.String, Model.Address);
            db.AddInParameter(command, "@DisplayName", DbType.String, Model.DisplayName);
            db.AddInParameter(command, "@State", DbType.Int32, Model.State);
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
		public override int DeleteVi_SysEmailServer(int ID)
		{
			string commandString="delete from Vi_SysEmailServer where dbo.Vi_SysEmailServer.ID=@dbo.Vi_SysEmailServer.ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@dbo.Vi_SysEmailServer.ID",DbType.Int32);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_SysEmailServer返回的查询dateset创建一个Vi_SysEmailServer对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysEmailServer对象</returns>
        private Vi_SysEmailServerModel Populate_Vi_SysEmailServerEntity_FromDr(DataSet ds)
        {
            Vi_SysEmailServerModel nObject = new Vi_SysEmailServerModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                nObject.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                nObject.Port = ((ds.Tables[0].Rows[0]["Port"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["Port"]);
                nObject.EnableSSL = ((ds.Tables[0].Rows[0]["EnableSSL"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["EnableSSL"]);
                nObject.SMTPHost = ds.Tables[0].Rows[0]["SMTPHost"].ToString();
                nObject.EmailName = ds.Tables[0].Rows[0]["EmailName"].ToString();
                nObject.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                nObject.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                nObject.State = ((ds.Tables[0].Rows[0]["State"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["State"]);
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
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
		/// 得到  vi_sysemailserver 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysemailserver 数据实体</returns>
		private Vi_SysEmailServerModel Populate_Vi_SysEmailServerEntity_FromDr(IDataReader dr)
		{
			Vi_SysEmailServerModel Obj = new Vi_SysEmailServerModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserPwd =  dr["UserPwd"].ToString();
				Obj.Port = (( dr["Port"])==DBNull.Value)?0:Convert.ToInt32( dr["Port"]);
				Obj.EnableSSL = (( dr["EnableSSL"])==DBNull.Value)?0:Convert.ToInt32( dr["EnableSSL"]);
				Obj.SMTPHost =  dr["SMTPHost"].ToString();
				Obj.EmailName =  dr["EmailName"].ToString();
				Obj.Address =  dr["Address"].ToString();
				Obj.DisplayName =  dr["DisplayName"].ToString();
				Obj.State = (( dr["State"])==DBNull.Value)?0:Convert.ToInt32( dr["State"]);
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_sysemailserver 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_sysemailserver 数据实体</returns>
		private Vi_SysEmailServerModel Populate_Vi_SysEmailServerEntity_FromDr(DataRow dr)
		{
			Vi_SysEmailServerModel Obj = new Vi_SysEmailServerModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserPwd =  dr["UserPwd"].ToString();
				Obj.Port = (( dr["Port"])==DBNull.Value)?0:Convert.ToInt32( dr["Port"]);
				Obj.EnableSSL = (( dr["EnableSSL"])==DBNull.Value)?0:Convert.ToInt32( dr["EnableSSL"]);
				Obj.SMTPHost =  dr["SMTPHost"].ToString();
				Obj.EmailName =  dr["EmailName"].ToString();
				Obj.Address =  dr["Address"].ToString();
				Obj.DisplayName =  dr["DisplayName"].ToString();
				Obj.State = (( dr["State"])==DBNull.Value)?0:Convert.ToInt32( dr["State"]);
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_SysEmailServer对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysEmailServer对象</returns>
        public override Vi_SysEmailServerModel Get_Vi_SysEmailServerModel(Int32 ID)
        {
            Vi_SysEmailServerModel _Entity=null;
            string commandString="SELECT [ID] ,[UserName],[UserPwd],[Port],[EnableSSL],[SMTPHost],[EmailName],[Address],[DisplayName],[State],[UserID],[CreateTime],[UpdateTime] FROM [Vi_SysEmailServer] where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, ID);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_SysEmailServerEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_SysEmailServer所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_SysEmailServerModel> GetVi_SysEmailServerAll()
		{
			IList< Vi_SysEmailServerModel> _Entity=new List< Vi_SysEmailServerModel>();
            string commandString = "SELECT [ID] ,[UserName],[UserPwd],[Port],[EnableSSL],[SMTPHost],[EmailName],[Address],[DisplayName],[State],[UserID],[CreateTime],[UpdateTime] FROM Vi_SysEmailServer";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_SysEmailServerEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
