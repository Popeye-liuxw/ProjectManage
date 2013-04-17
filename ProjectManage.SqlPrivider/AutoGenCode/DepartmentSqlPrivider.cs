
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： DepartmentSqlPrivider.cs
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
	public partial class DepartmentSqlPrivider:DepartmentProvider
	{
		#region Department
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveDepartment(DepartmentModel Model)
		{
			string commandString="INSERT INTO [Department] ([bDepEnd],[cDepName],[iDepGrade],[cDepPerson],[cDepProp],[cDepPhone],[cDepAddress],[cDepMemo],[cDepHelp],) values( @bDepEnd, @cDepName, @iDepGrade, @cDepPerson, @cDepProp, @cDepPhone, @cDepAddress, @cDepMemo, @cDepHelp)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@cDepCode",DbType.String,Model.cDepCode);
		db.AddInParameter(command,"@bDepEnd",DbType.Boolean,Model.bDepEnd);
		db.AddInParameter(command,"@cDepName",DbType.String,Model.cDepName);
		db.AddInParameter(command,"@iDepGrade",DbType.Int32,Model.iDepGrade);
		db.AddInParameter(command,"@cDepPerson",DbType.String,Model.cDepPerson);
		db.AddInParameter(command,"@cDepProp",DbType.String,Model.cDepProp);
		db.AddInParameter(command,"@cDepPhone",DbType.String,Model.cDepPhone);
		db.AddInParameter(command,"@cDepAddress",DbType.String,Model.cDepAddress);
		db.AddInParameter(command,"@cDepMemo",DbType.String,Model.cDepMemo);
		db.AddInParameter(command,"@cDepHelp",DbType.String,Model.cDepHelp);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdateDepartment(DepartmentModel Model)
		{
			string commandString="update [Department] set [bDepEnd]=@bDepEnd,[cDepName]=@cDepName,[iDepGrade]=@iDepGrade,[cDepPerson]=@cDepPerson,[cDepProp]=@cDepProp,[cDepPhone]=@cDepPhone,[cDepAddress]=@cDepAddress,[cDepMemo]=@cDepMemo,[cDepHelp]=@cDepHelp, where cDepCode=@cDepCode";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@cDepCode",DbType.String,Model.cDepCode);
		db.AddInParameter(command,"@bDepEnd",DbType.Boolean,Model.bDepEnd);
		db.AddInParameter(command,"@cDepName",DbType.String,Model.cDepName);
		db.AddInParameter(command,"@iDepGrade",DbType.Int32,Model.iDepGrade);
		db.AddInParameter(command,"@cDepPerson",DbType.String,Model.cDepPerson);
		db.AddInParameter(command,"@cDepProp",DbType.String,Model.cDepProp);
		db.AddInParameter(command,"@cDepPhone",DbType.String,Model.cDepPhone);
		db.AddInParameter(command,"@cDepAddress",DbType.String,Model.cDepAddress);
		db.AddInParameter(command,"@cDepMemo",DbType.String,Model.cDepMemo);
		db.AddInParameter(command,"@cDepHelp",DbType.String,Model.cDepHelp);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="cDepCode">cDepCode</param>
		/// <returns>影响的条数</returns>
		public override int DeleteDepartment(string cDepCode)
		{
			string commandString="delete from Department where dbo.Department.cDepCode=@dbo.Department.cDepCode";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@dbo.Department.cDepCode",DbType.String);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Department返回的查询dateset创建一个Department对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Department对象</returns>
        private DepartmentModel Populate_DepartmentEntity_FromDr(DataSet ds)
        {
            DepartmentModel nObject = new DepartmentModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.cDepCode = ds.Tables[0].Rows[0]["cDepCode"].ToString();
                nObject.bDepEnd = (bool)ds.Tables[0].Rows[0]["bDepEnd"];
                nObject.cDepName = ds.Tables[0].Rows[0]["cDepName"].ToString();
                nObject.iDepGrade = ((ds.Tables[0].Rows[0]["iDepGrade"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte(ds.Tables[0].Rows[0]["iDepGrade"]);
                nObject.cDepPerson = ds.Tables[0].Rows[0]["cDepPerson"].ToString();
                nObject.cDepProp = ds.Tables[0].Rows[0]["cDepProp"].ToString();
                nObject.cDepPhone = ds.Tables[0].Rows[0]["cDepPhone"].ToString();
                nObject.cDepAddress = ds.Tables[0].Rows[0]["cDepAddress"].ToString();
                nObject.cDepMemo = ds.Tables[0].Rows[0]["cDepMemo"].ToString();
                nObject.cDepHelp = ds.Tables[0].Rows[0]["cDepHelp"].ToString();
            }
            else
            {
                return null;
            }
            return nObject;
        }
		/// <summary>
		/// 得到  department 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>department 数据实体</returns>
		private DepartmentModel Populate_DepartmentEntity_FromDr(IDataReader dr)
		{
			DepartmentModel Obj = new DepartmentModel();
			
				Obj.cDepCode =  dr["cDepCode"].ToString();
				Obj.bDepEnd = (bool) dr["bDepEnd"];
				Obj.cDepName =  dr["cDepName"].ToString();
				Obj.iDepGrade = (( dr["iDepGrade"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["iDepGrade"]);
				Obj.cDepPerson =  dr["cDepPerson"].ToString();
				Obj.cDepProp =  dr["cDepProp"].ToString();
				Obj.cDepPhone =  dr["cDepPhone"].ToString();
				Obj.cDepAddress =  dr["cDepAddress"].ToString();
				Obj.cDepMemo =  dr["cDepMemo"].ToString();
				Obj.cDepHelp =  dr["cDepHelp"].ToString();
			
			return Obj;
		}
		/// <summary>
		/// 得到  department 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>department 数据实体</returns>
		private DepartmentModel Populate_DepartmentEntity_FromDr(DataRow dr)
		{
			DepartmentModel Obj = new DepartmentModel();
			if(dr!=null)
			{
				Obj.cDepCode =  dr["cDepCode"].ToString();
				Obj.bDepEnd = (bool) dr["bDepEnd"];
				Obj.cDepName =  dr["cDepName"].ToString();
				Obj.iDepGrade = (( dr["iDepGrade"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["iDepGrade"]);
				Obj.cDepPerson =  dr["cDepPerson"].ToString();
				Obj.cDepProp =  dr["cDepProp"].ToString();
				Obj.cDepPhone =  dr["cDepPhone"].ToString();
				Obj.cDepAddress =  dr["cDepAddress"].ToString();
				Obj.cDepMemo =  dr["cDepMemo"].ToString();
				Obj.cDepHelp =  dr["cDepHelp"].ToString();
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Department对象
        /// </summary>
        /// <param name="cDepCode">cDepCode</param>
        /// <returns>Department对象</returns>
        public override DepartmentModel Get_DepartmentModel(string cDepCode)
        {
            DepartmentModel _Entity=null;
            string commandString="select * from Department where cDepCode=@cDepCode";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"cDepCode",DbType.String,cDepCode);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_DepartmentEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Department所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< DepartmentModel> GetDepartmentAll()
		{
			IList< DepartmentModel> _Entity=new List< DepartmentModel>();
			string commandString="select * from Department";
			using(IDataReader dr=db.ExecuteReader(CommandType.Text,commandString))
        	{
            	while(dr.Read())
            	{
                	_Entity.Add(Populate_DepartmentEntity_FromDr(dr));
            	}
       		}
			return _Entity;
		}
#endregion
	}
}
