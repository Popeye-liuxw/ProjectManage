
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
	public partial class Vi_SysLogSqlPrivider:Vi_SysLogProvider
	{
		#region Vi_SysLog
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveVi_SysLog(Vi_SysLogModel Model)
		{
			string commandString="INSERT INTO [Vi_SysLog] ([SysType],[UserName],[UserID],[TheIP],[LastIP],[IOS],[Browser],[Operate],[Back],[CreateTime],[UpdateTime]) values( @SysType, @UserName, @UserID, @TheIP, @LastIP, @IOS, @Browser, @Operate, @Back, @CreateTime, @UpdateTime)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@SysType",DbType.Int32,Model.SysType);
		db.AddInParameter(command,"@UserName",DbType.String,Model.UserName);
		db.AddInParameter(command,"@UserID",DbType.Int32,Model.UserID);
		db.AddInParameter(command,"@TheIP",DbType.String,Model.TheIP);
		db.AddInParameter(command,"@LastIP",DbType.String,Model.LastIP);
		db.AddInParameter(command,"@IOS",DbType.String,Model.IOS);
		db.AddInParameter(command,"@Browser",DbType.String,Model.Browser);
		db.AddInParameter(command,"@Operate",DbType.String,Model.Operate);
		db.AddInParameter(command,"@Back",DbType.String,Model.Back);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdateVi_SysLog(Vi_SysLogModel Model)
		{
			string commandString="update [Vi_SysLog] set [SysType]=@SysType,[UserName]=@UserName,[UserID]=@UserID,[TheIP]=@TheIP,[LastIP]=@LastIP,[IOS]=@IOS,[Browser]=@Browser,[Operate]=@Operate,[Back]=@Back,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime, where ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@SysType",DbType.Int32,Model.SysType);
		db.AddInParameter(command,"@UserName",DbType.String,Model.UserName);
		db.AddInParameter(command,"@UserID",DbType.Int32,Model.UserID);
		db.AddInParameter(command,"@TheIP",DbType.String,Model.TheIP);
		db.AddInParameter(command,"@LastIP",DbType.String,Model.LastIP);
		db.AddInParameter(command,"@IOS",DbType.String,Model.IOS);
		db.AddInParameter(command,"@Browser",DbType.String,Model.Browser);
		db.AddInParameter(command,"@Operate",DbType.String,Model.Operate);
		db.AddInParameter(command,"@Back",DbType.String,Model.Back);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public override int DeleteVi_SysLog(int ID)
		{
			string commandString="delete from Vi_SysLog where dbo.Vi_SysLog.ID=@dbo.Vi_SysLog.ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@dbo.Vi_SysLog.ID",DbType.Int32);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_SysLog返回的查询dateset创建一个Vi_SysLog对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysLog对象</returns>
        private Vi_SysLogModel Populate_Vi_SysLogEntity_FromDr(DataSet ds)
        {
            Vi_SysLogModel nObject = new Vi_SysLogModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.SysType = ((ds.Tables[0].Rows[0]["SysType"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["SysType"]);
                nObject.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                nObject.TheIP = ds.Tables[0].Rows[0]["TheIP"].ToString();
                nObject.LastIP = ds.Tables[0].Rows[0]["LastIP"].ToString();
                nObject.IOS = ds.Tables[0].Rows[0]["IOS"].ToString();
                nObject.Browser = ds.Tables[0].Rows[0]["Browser"].ToString();
                nObject.Operate = ds.Tables[0].Rows[0]["Operate"].ToString();
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
		/// 得到  vi_syslog 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_syslog 数据实体</returns>
		private Vi_SysLogModel Populate_Vi_SysLogEntity_FromDr(IDataReader dr)
		{
			Vi_SysLogModel Obj = new Vi_SysLogModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.SysType = (( dr["SysType"])==DBNull.Value)?0:Convert.ToInt32( dr["SysType"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.TheIP =  dr["TheIP"].ToString();
				Obj.LastIP =  dr["LastIP"].ToString();
				Obj.IOS =  dr["IOS"].ToString();
				Obj.Browser =  dr["Browser"].ToString();
				Obj.Operate =  dr["Operate"].ToString();
				Obj.Back =  dr["Back"].ToString();
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_syslog 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_syslog 数据实体</returns>
		private Vi_SysLogModel Populate_Vi_SysLogEntity_FromDr(DataRow dr)
		{
			Vi_SysLogModel Obj = new Vi_SysLogModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.SysType = (( dr["SysType"])==DBNull.Value)?0:Convert.ToInt32( dr["SysType"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.TheIP =  dr["TheIP"].ToString();
				Obj.LastIP =  dr["LastIP"].ToString();
				Obj.IOS =  dr["IOS"].ToString();
				Obj.Browser =  dr["Browser"].ToString();
				Obj.Operate =  dr["Operate"].ToString();
				Obj.Back =  dr["Back"].ToString();
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_SysLog对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysLog对象</returns>
        public override Vi_SysLogModel Get_Vi_SysLogModel(Int32 ID)
        {
            Vi_SysLogModel _Entity=null;
            string commandString="select * from Vi_SysLog where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"ID",DbType.Int32);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_SysLogEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_SysLog所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_SysLogModel> GetVi_SysLogAll()
		{
			IList< Vi_SysLogModel> _Entity=new List< Vi_SysLogModel>();
			string commandString="select * from Vi_SysLog";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_SysLogEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
