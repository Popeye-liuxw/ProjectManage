
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_MarketRecSqlPrivider.cs
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
	public partial class Vi_MarketRecSqlPrivider:Vi_MarketRecProvider
	{
		#region Vi_MarketRec
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveVi_MarketRec(Vi_MarketRecModel Model)
		{
			string commandString="INSERT INTO [Vi_MarketRec] ([StaffID],[ProjectID],[ProjectName],[UserID],[CreateTime],[UpdateTime]) values( @StaffID, @ProjectID, @ProjectName, @UserID, @CreateTime, @UpdateTime)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@StaffID",DbType.Int32,Model.StaffID);
		db.AddInParameter(command,"@ProjectID",DbType.Int32,Model.ProjectID);
		db.AddInParameter(command,"@ProjectName",DbType.String,Model.ProjectName);
		db.AddInParameter(command,"@UserID",DbType.Int32,Model.UserID);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdateVi_MarketRec(Vi_MarketRecModel Model)
		{
			string commandString="update [Vi_MarketRec] set [StaffID]=@StaffID,[ProjectID]=@ProjectID,[ProjectName]=@ProjectName,[UserID]=@UserID,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime where ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@StaffID",DbType.Int32,Model.StaffID);
		db.AddInParameter(command,"@ProjectID",DbType.Int32,Model.ProjectID);
		db.AddInParameter(command,"@ProjectName",DbType.String,Model.ProjectName);
		db.AddInParameter(command,"@UserID",DbType.Int32,Model.UserID);
		db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
		db.AddInParameter(command,"@UpdateTime",DbType.DateTime,Model.UpdateTime);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public override int DeleteVi_MarketRec(int ID)
		{
			string commandString="delete from Vi_MarketRec where Vi_MarketRec.ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@ID",DbType.Int32,ID);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_MarketRec返回的查询dateset创建一个Vi_MarketRec对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_MarketRec对象</returns>
        private Vi_MarketRecModel Populate_Vi_MarketRecEntity_FromDr(DataSet ds)
        {
            Vi_MarketRecModel nObject = new Vi_MarketRecModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.StaffID = ((ds.Tables[0].Rows[0]["StaffID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["StaffID"]);
                nObject.ProjectID = ((ds.Tables[0].Rows[0]["ProjectID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectID"]);
                nObject.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
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
		/// 得到  vi_marketrec 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_marketrec 数据实体</returns>
		private Vi_MarketRecModel Populate_Vi_MarketRecEntity_FromDr(IDataReader dr)
		{
			Vi_MarketRecModel Obj = new Vi_MarketRecModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.StaffID = (( dr["StaffID"])==DBNull.Value)?0:Convert.ToInt32( dr["StaffID"]);
				Obj.ProjectID = (( dr["ProjectID"])==DBNull.Value)?0:Convert.ToInt32( dr["ProjectID"]);
				Obj.ProjectName =  dr["ProjectName"].ToString();
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_marketrec 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_marketrec 数据实体</returns>
		private Vi_MarketRecModel Populate_Vi_MarketRecEntity_FromDr(DataRow dr)
		{
			Vi_MarketRecModel Obj = new Vi_MarketRecModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.StaffID = (( dr["StaffID"])==DBNull.Value)?0:Convert.ToInt32( dr["StaffID"]);
				Obj.ProjectID = (( dr["ProjectID"])==DBNull.Value)?0:Convert.ToInt32( dr["ProjectID"]);
				Obj.ProjectName =  dr["ProjectName"].ToString();
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_MarketRec对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_MarketRec对象</returns>
        public override Vi_MarketRecModel Get_Vi_MarketRecModel(Int32 ID)
        {
            Vi_MarketRecModel _Entity=null;
            string commandString="select * from Vi_MarketRec where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"ID",DbType.Int32);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_MarketRecEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_MarketRec所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_MarketRecModel> GetVi_MarketRecAll()
		{
			IList< Vi_MarketRecModel> _Entity=new List< Vi_MarketRecModel>();
			string commandString="select * from Vi_MarketRec";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_MarketRecEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
