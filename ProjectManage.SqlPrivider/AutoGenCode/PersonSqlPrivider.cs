
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： PersonSqlPrivider.cs
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
	public partial class PersonSqlPrivider:PersonProvider
	{
		#region Person
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SavePerson(PersonModel Model)
		{
			string commandString="INSERT INTO [Person] ([cPersonName],[cDepCode],[cPersonProp],[cPersonHelp],[dBirthday],) values( @cPersonName, @cDepCode, @cPersonProp, @cPersonHelp, @dBirthday)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@cPersonCode",DbType.String,Model.cPersonCode);
		db.AddInParameter(command,"@cPersonName",DbType.String,Model.cPersonName);
		db.AddInParameter(command,"@cDepCode",DbType.String,Model.cDepCode);
		db.AddInParameter(command,"@cPersonProp",DbType.String,Model.cPersonProp);
		db.AddInParameter(command,"@cPersonHelp",DbType.String,Model.cPersonHelp);
		db.AddInParameter(command,"@dBirthday",DbType.DateTime,Model.dBirthday);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdatePerson(PersonModel Model)
		{
			string commandString="update [Person] set [cPersonName]=@cPersonName,[cDepCode]=@cDepCode,[cPersonProp]=@cPersonProp,[cPersonHelp]=@cPersonHelp,[dBirthday]=@dBirthday, where cPersonCode=@cPersonCode";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@cPersonCode",DbType.String,Model.cPersonCode);
		db.AddInParameter(command,"@cPersonName",DbType.String,Model.cPersonName);
		db.AddInParameter(command,"@cDepCode",DbType.String,Model.cDepCode);
		db.AddInParameter(command,"@cPersonProp",DbType.String,Model.cPersonProp);
		db.AddInParameter(command,"@cPersonHelp",DbType.String,Model.cPersonHelp);
		db.AddInParameter(command,"@dBirthday",DbType.DateTime,Model.dBirthday);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="cPersonCode">cPersonCode</param>
		/// <returns>影响的条数</returns>
		public override int DeletePerson(string cPersonCode)
		{
			string commandString="delete from Person where dbo.Person.cPersonCode=@dbo.Person.cPersonCode";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@dbo.Person.cPersonCode",DbType.String);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Person返回的查询dateset创建一个Person对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Person对象</returns>
        private PersonModel Populate_PersonEntity_FromDr(DataSet ds)
        {
            PersonModel nObject = new PersonModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.cPersonCode = ds.Tables[0].Rows[0]["cPersonCode"].ToString();
                nObject.cPersonName = ds.Tables[0].Rows[0]["cPersonName"].ToString();
                nObject.cDepCode = ds.Tables[0].Rows[0]["cDepCode"].ToString();
                nObject.cPersonProp = ds.Tables[0].Rows[0]["cPersonProp"].ToString();
                nObject.cPersonHelp = ds.Tables[0].Rows[0]["cPersonHelp"].ToString();
                nObject.dBirthday = ((ds.Tables[0].Rows[0]["dBirthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["dBirthday"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
		/// <summary>
		/// 得到  person 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>person 数据实体</returns>
		private PersonModel Populate_PersonEntity_FromDr(IDataReader dr)
		{
			PersonModel Obj = new PersonModel();
			
				Obj.cPersonCode =  dr["cPersonCode"].ToString();
				Obj.cPersonName =  dr["cPersonName"].ToString();
				Obj.cDepCode =  dr["cDepCode"].ToString();
				Obj.cPersonProp =  dr["cPersonProp"].ToString();
				Obj.cPersonHelp =  dr["cPersonHelp"].ToString();
				Obj.dBirthday = (( dr["dBirthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dBirthday"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  person 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>person 数据实体</returns>
		private PersonModel Populate_PersonEntity_FromDr(DataRow dr)
		{
			PersonModel Obj = new PersonModel();
			if(dr!=null)
			{
				Obj.cPersonCode =  dr["cPersonCode"].ToString();
				Obj.cPersonName =  dr["cPersonName"].ToString();
				Obj.cDepCode =  dr["cDepCode"].ToString();
				Obj.cPersonProp =  dr["cPersonProp"].ToString();
				Obj.cPersonHelp =  dr["cPersonHelp"].ToString();
				Obj.dBirthday = (( dr["dBirthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dBirthday"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Person对象
        /// </summary>
        /// <param name="cPersonCode">cPersonCode</param>
        /// <returns>Person对象</returns>
        public override PersonModel Get_PersonModel(string cPersonCode)
        {
            PersonModel _Entity=null;
            string commandString="select * from Person where cPersonCode=@cPersonCode";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"cPersonCode",DbType.String,cPersonCode);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_PersonEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Person所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList< PersonModel> GetPersonAll()
		{
			IList< PersonModel> _Entity=new List< PersonModel>();
			//string commandString="select * from Person";
            try
            {
                string commandString = string.Format("select * from [UFDATA_005_{0}].[dbo].[Person]", DateTime.Now.Year);
                using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
                {
                    while (dr.Read())
                    {
                        _Entity.Add(Populate_PersonEntity_FromDr(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                string commandString = string.Format("select * from [Person]");
                using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
                {
                    while (dr.Read())
                    {
                        _Entity.Add(Populate_PersonEntity_FromDr(dr));
                    }
                }
            }
           
			return _Entity;
		}
#endregion
	}
}
