
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ProjectNatureSqlPrivider.cs
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
	public partial class Vi_ProjectNatureSqlPrivider:Vi_ProjectNatureProvider
	{
		#region Vi_ProjectNature
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveVi_ProjectNature(Vi_ProjectNatureModel Model)
		{
			string commandString="INSERT INTO [Vi_ProjectNature] ([Caption],[UserID],[CreateTime],[UpdateTime],) values( @Caption, @UserID, @CreateTime, @UpdateTime)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@I_id",DbType.Int32,Model.I_id);
		db.AddInParameter(command,"@Caption",DbType.String,Model.Caption);
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
		public override int UpdateVi_ProjectNature(Vi_ProjectNatureModel Model)
		{
			string commandString="update [Vi_ProjectNature] set [Caption]=@Caption,[UserID]=@UserID,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime, where ID=@ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@ID",DbType.Int32,Model.ID);
		db.AddInParameter(command,"@I_id",DbType.Int32,Model.I_id);
		db.AddInParameter(command,"@Caption",DbType.String,Model.Caption);
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
		public override int DeleteVi_ProjectNature(int ID)
		{
			string commandString="delete from Vi_ProjectNature where dbo.Vi_ProjectNature.ID=@dbo.Vi_ProjectNature.ID";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@dbo.Vi_ProjectNature.ID",DbType.Int32);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Vi_ProjectNature返回的查询dateset创建一个Vi_ProjectNature对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_ProjectNature对象</returns>
        private Vi_ProjectNatureModel Populate_Vi_ProjectNatureEntity_FromDr(DataSet ds)
        {
            Vi_ProjectNatureModel nObject = new Vi_ProjectNatureModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.Caption = ds.Tables[0].Rows[0]["Caption"].ToString();
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
		/// 得到  vi_projectnature 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_projectnature 数据实体</returns>
		private Vi_ProjectNatureModel Populate_Vi_ProjectNatureEntity_FromDr(IDataReader dr)
		{
			Vi_ProjectNatureModel Obj = new Vi_ProjectNatureModel();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.I_id = (( dr["I_id"])==DBNull.Value)?0:Convert.ToInt32( dr["I_id"]);
				Obj.Caption =  dr["Caption"].ToString();
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  vi_projectnature 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>vi_projectnature 数据实体</returns>
		private Vi_ProjectNatureModel Populate_Vi_ProjectNatureEntity_FromDr(DataRow dr)
		{
			Vi_ProjectNatureModel Obj = new Vi_ProjectNatureModel();
			if(dr!=null)
			{
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.I_id = (( dr["I_id"])==DBNull.Value)?0:Convert.ToInt32( dr["I_id"]);
				Obj.Caption =  dr["Caption"].ToString();
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.CreateTime = (( dr["CreateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["CreateTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Vi_ProjectNature对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_ProjectNature对象</returns>
        public override Vi_ProjectNatureModel Get_Vi_ProjectNatureModel(Int32 ID)
        {
            Vi_ProjectNatureModel _Entity=null;
            string commandString="select * from Vi_ProjectNature where ID=@ID";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"ID",DbType.Int32);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_Vi_ProjectNatureEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Vi_ProjectNature所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< Vi_ProjectNatureModel> GetVi_ProjectNatureAll()
		{
			IList< Vi_ProjectNatureModel> _Entity=new List< Vi_ProjectNatureModel>();
			string commandString="select * from Vi_ProjectNature";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_Vi_ProjectNatureEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
