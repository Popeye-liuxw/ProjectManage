
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： CustomerSqlPrivider.cs
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
	public partial class CustomerSqlPrivider:CustomerProvider
	{
		#region Customer
	
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int SaveCustomer(CustomerModel Model)
		{
			string commandString="INSERT INTO [Customer] ([cCusName],[cCusAbbName],[cCCCode],[cDCCode],[cTrade],[cCusAddress],[cCusPostCode],[cCusRegCode],[cCusBank],[cCusAccount],[dCusDevDate],[cCusLPerson],[cCusEmail],[cCusPerson],[cCusPhone],[cCusFax],[cCusBP],[cCusHand],[cCusPPerson],[iCusDisRate],[cCusCreGrade],[iCusCreLine],[iCusCreDate],[cCusPayCond],[cCusOAddress],[cCusOType],[cCusHeadCode],[cCusWhCode],[cCusDepart],[iARMoney],[dLastDate],[iLastMoney],[dLRDate],[iLRMoney],[dEndDate],[iFrequency],[cCusDefine1],[cCusDefine2],[cCusDefine3],[iCostGrade],[cUUAccount],[cCusHelp],[cZQCode],[UniqueID],[dBirthday],) values( @cCusName, @cCusAbbName, @cCCCode, @cDCCode, @cTrade, @cCusAddress, @cCusPostCode, @cCusRegCode, @cCusBank, @cCusAccount, @dCusDevDate, @cCusLPerson, @cCusEmail, @cCusPerson, @cCusPhone, @cCusFax, @cCusBP, @cCusHand, @cCusPPerson, @iCusDisRate, @cCusCreGrade, @iCusCreLine, @iCusCreDate, @cCusPayCond, @cCusOAddress, @cCusOType, @cCusHeadCode, @cCusWhCode, @cCusDepart, @iARMoney, @dLastDate, @iLastMoney, @dLRDate, @iLRMoney, @dEndDate, @iFrequency, @cCusDefine1, @cCusDefine2, @cCusDefine3, @iCostGrade, @cUUAccount, @cCusHelp, @cZQCode, @UniqueID, @dBirthday)";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@cCusCode",DbType.String,Model.cCusCode);
		db.AddInParameter(command,"@cCusName",DbType.String,Model.cCusName);
		db.AddInParameter(command,"@cCusAbbName",DbType.String,Model.cCusAbbName);
		db.AddInParameter(command,"@cCCCode",DbType.String,Model.cCCCode);
		db.AddInParameter(command,"@cDCCode",DbType.String,Model.cDCCode);
		db.AddInParameter(command,"@cTrade",DbType.String,Model.cTrade);
		db.AddInParameter(command,"@cCusAddress",DbType.String,Model.cCusAddress);
		db.AddInParameter(command,"@cCusPostCode",DbType.String,Model.cCusPostCode);
		db.AddInParameter(command,"@cCusRegCode",DbType.String,Model.cCusRegCode);
		db.AddInParameter(command,"@cCusBank",DbType.String,Model.cCusBank);
		db.AddInParameter(command,"@cCusAccount",DbType.String,Model.cCusAccount);
		db.AddInParameter(command,"@dCusDevDate",DbType.DateTime,Model.dCusDevDate);
		db.AddInParameter(command,"@cCusLPerson",DbType.String,Model.cCusLPerson);
		db.AddInParameter(command,"@cCusEmail",DbType.String,Model.cCusEmail);
		db.AddInParameter(command,"@cCusPerson",DbType.String,Model.cCusPerson);
		db.AddInParameter(command,"@cCusPhone",DbType.String,Model.cCusPhone);
		db.AddInParameter(command,"@cCusFax",DbType.String,Model.cCusFax);
		db.AddInParameter(command,"@cCusBP",DbType.String,Model.cCusBP);
		db.AddInParameter(command,"@cCusHand",DbType.String,Model.cCusHand);
		db.AddInParameter(command,"@cCusPPerson",DbType.String,Model.cCusPPerson);
		db.AddInParameter(command,"@iCusDisRate",DbType.Double,Model.iCusDisRate);
		db.AddInParameter(command,"@cCusCreGrade",DbType.String,Model.cCusCreGrade);
		db.AddInParameter(command,"@iCusCreLine",DbType.Double,Model.iCusCreLine);
		db.AddInParameter(command,"@iCusCreDate",DbType.Int32,Model.iCusCreDate);
		db.AddInParameter(command,"@cCusPayCond",DbType.String,Model.cCusPayCond);
		db.AddInParameter(command,"@cCusOAddress",DbType.String,Model.cCusOAddress);
		db.AddInParameter(command,"@cCusOType",DbType.String,Model.cCusOType);
		db.AddInParameter(command,"@cCusHeadCode",DbType.String,Model.cCusHeadCode);
		db.AddInParameter(command,"@cCusWhCode",DbType.String,Model.cCusWhCode);
		db.AddInParameter(command,"@cCusDepart",DbType.String,Model.cCusDepart);
		db.AddInParameter(command,"@iARMoney",DbType.Double,Model.iARMoney);
		db.AddInParameter(command,"@dLastDate",DbType.DateTime,Model.dLastDate);
		db.AddInParameter(command,"@iLastMoney",DbType.Double,Model.iLastMoney);
		db.AddInParameter(command,"@dLRDate",DbType.DateTime,Model.dLRDate);
		db.AddInParameter(command,"@iLRMoney",DbType.Double,Model.iLRMoney);
		db.AddInParameter(command,"@dEndDate",DbType.DateTime,Model.dEndDate);
		db.AddInParameter(command,"@iFrequency",DbType.Int32,Model.iFrequency);
		db.AddInParameter(command,"@cCusDefine1",DbType.String,Model.cCusDefine1);
		db.AddInParameter(command,"@cCusDefine2",DbType.String,Model.cCusDefine2);
		db.AddInParameter(command,"@cCusDefine3",DbType.String,Model.cCusDefine3);
		db.AddInParameter(command,"@iCostGrade",DbType.Int32,Model.iCostGrade);
		db.AddInParameter(command,"@cUUAccount",DbType.String,Model.cUUAccount);
		db.AddInParameter(command,"@cCusHelp",DbType.String,Model.cCusHelp);
		db.AddInParameter(command,"@cZQCode",DbType.String,Model.cZQCode);
		db.AddInParameter(command,"@UniqueID",DbType.String,Model.UniqueID);
		db.AddInParameter(command,"@dBirthday",DbType.DateTime,Model.dBirthday);
		return db.ExecuteNonQuery(command);
		}
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public override int UpdateCustomer(CustomerModel Model)
		{
			string commandString="update [Customer] set [cCusName]=@cCusName,[cCusAbbName]=@cCusAbbName,[cCCCode]=@cCCCode,[cDCCode]=@cDCCode,[cTrade]=@cTrade,[cCusAddress]=@cCusAddress,[cCusPostCode]=@cCusPostCode,[cCusRegCode]=@cCusRegCode,[cCusBank]=@cCusBank,[cCusAccount]=@cCusAccount,[dCusDevDate]=@dCusDevDate,[cCusLPerson]=@cCusLPerson,[cCusEmail]=@cCusEmail,[cCusPerson]=@cCusPerson,[cCusPhone]=@cCusPhone,[cCusFax]=@cCusFax,[cCusBP]=@cCusBP,[cCusHand]=@cCusHand,[cCusPPerson]=@cCusPPerson,[iCusDisRate]=@iCusDisRate,[cCusCreGrade]=@cCusCreGrade,[iCusCreLine]=@iCusCreLine,[iCusCreDate]=@iCusCreDate,[cCusPayCond]=@cCusPayCond,[cCusOAddress]=@cCusOAddress,[cCusOType]=@cCusOType,[cCusHeadCode]=@cCusHeadCode,[cCusWhCode]=@cCusWhCode,[cCusDepart]=@cCusDepart,[iARMoney]=@iARMoney,[dLastDate]=@dLastDate,[iLastMoney]=@iLastMoney,[dLRDate]=@dLRDate,[iLRMoney]=@iLRMoney,[dEndDate]=@dEndDate,[iFrequency]=@iFrequency,[cCusDefine1]=@cCusDefine1,[cCusDefine2]=@cCusDefine2,[cCusDefine3]=@cCusDefine3,[iCostGrade]=@iCostGrade,[cUUAccount]=@cUUAccount,[cCusHelp]=@cCusHelp,[cZQCode]=@cZQCode,[UniqueID]=@UniqueID,[dBirthday]=@dBirthday, where cCusCode=@cCusCode";
			DbCommand command=db.GetSqlStringCommand(commandString);
		db.AddInParameter(command,"@cCusCode",DbType.String,Model.cCusCode);
		db.AddInParameter(command,"@cCusName",DbType.String,Model.cCusName);
		db.AddInParameter(command,"@cCusAbbName",DbType.String,Model.cCusAbbName);
		db.AddInParameter(command,"@cCCCode",DbType.String,Model.cCCCode);
		db.AddInParameter(command,"@cDCCode",DbType.String,Model.cDCCode);
		db.AddInParameter(command,"@cTrade",DbType.String,Model.cTrade);
		db.AddInParameter(command,"@cCusAddress",DbType.String,Model.cCusAddress);
		db.AddInParameter(command,"@cCusPostCode",DbType.String,Model.cCusPostCode);
		db.AddInParameter(command,"@cCusRegCode",DbType.String,Model.cCusRegCode);
		db.AddInParameter(command,"@cCusBank",DbType.String,Model.cCusBank);
		db.AddInParameter(command,"@cCusAccount",DbType.String,Model.cCusAccount);
		db.AddInParameter(command,"@dCusDevDate",DbType.DateTime,Model.dCusDevDate);
		db.AddInParameter(command,"@cCusLPerson",DbType.String,Model.cCusLPerson);
		db.AddInParameter(command,"@cCusEmail",DbType.String,Model.cCusEmail);
		db.AddInParameter(command,"@cCusPerson",DbType.String,Model.cCusPerson);
		db.AddInParameter(command,"@cCusPhone",DbType.String,Model.cCusPhone);
		db.AddInParameter(command,"@cCusFax",DbType.String,Model.cCusFax);
		db.AddInParameter(command,"@cCusBP",DbType.String,Model.cCusBP);
		db.AddInParameter(command,"@cCusHand",DbType.String,Model.cCusHand);
		db.AddInParameter(command,"@cCusPPerson",DbType.String,Model.cCusPPerson);
		db.AddInParameter(command,"@iCusDisRate",DbType.Double,Model.iCusDisRate);
		db.AddInParameter(command,"@cCusCreGrade",DbType.String,Model.cCusCreGrade);
		db.AddInParameter(command,"@iCusCreLine",DbType.Double,Model.iCusCreLine);
		db.AddInParameter(command,"@iCusCreDate",DbType.Int32,Model.iCusCreDate);
		db.AddInParameter(command,"@cCusPayCond",DbType.String,Model.cCusPayCond);
		db.AddInParameter(command,"@cCusOAddress",DbType.String,Model.cCusOAddress);
		db.AddInParameter(command,"@cCusOType",DbType.String,Model.cCusOType);
		db.AddInParameter(command,"@cCusHeadCode",DbType.String,Model.cCusHeadCode);
		db.AddInParameter(command,"@cCusWhCode",DbType.String,Model.cCusWhCode);
		db.AddInParameter(command,"@cCusDepart",DbType.String,Model.cCusDepart);
		db.AddInParameter(command,"@iARMoney",DbType.Double,Model.iARMoney);
		db.AddInParameter(command,"@dLastDate",DbType.DateTime,Model.dLastDate);
		db.AddInParameter(command,"@iLastMoney",DbType.Double,Model.iLastMoney);
		db.AddInParameter(command,"@dLRDate",DbType.DateTime,Model.dLRDate);
		db.AddInParameter(command,"@iLRMoney",DbType.Double,Model.iLRMoney);
		db.AddInParameter(command,"@dEndDate",DbType.DateTime,Model.dEndDate);
		db.AddInParameter(command,"@iFrequency",DbType.Int32,Model.iFrequency);
		db.AddInParameter(command,"@cCusDefine1",DbType.String,Model.cCusDefine1);
		db.AddInParameter(command,"@cCusDefine2",DbType.String,Model.cCusDefine2);
		db.AddInParameter(command,"@cCusDefine3",DbType.String,Model.cCusDefine3);
		db.AddInParameter(command,"@iCostGrade",DbType.Int32,Model.iCostGrade);
		db.AddInParameter(command,"@cUUAccount",DbType.String,Model.cUUAccount);
		db.AddInParameter(command,"@cCusHelp",DbType.String,Model.cCusHelp);
		db.AddInParameter(command,"@cZQCode",DbType.String,Model.cZQCode);
		db.AddInParameter(command,"@UniqueID",DbType.String,Model.UniqueID);
		db.AddInParameter(command,"@dBirthday",DbType.DateTime,Model.dBirthday);
		return db.ExecuteNonQuery(command);	
		}
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="cCusCode">cCusCode</param>
		/// <returns>影响的条数</returns>
		public override int DeleteCustomer(string cCusCode)
		{
			string commandString="delete from Customer where dbo.Customer.cCusCode=@dbo.Customer.cCusCode";
			DbCommand command=db.GetSqlStringCommand(commandString);
			db.AddInParameter(command,"@dbo.Customer.cCusCode",DbType.String);
			return db.ExecuteNonQuery(command);
		}
        /// <summary>
        /// 根据Customer返回的查询dateset创建一个Customer对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Customer对象</returns>
        private CustomerModel Populate_CustomerEntity_FromDr(DataSet ds)
        {
            CustomerModel nObject = new CustomerModel();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.cCusCode = ds.Tables[0].Rows[0]["cCusCode"].ToString();
                nObject.cCusName = ds.Tables[0].Rows[0]["cCusName"].ToString();
                nObject.cCusAbbName = ds.Tables[0].Rows[0]["cCusAbbName"].ToString();
                nObject.cCCCode = ds.Tables[0].Rows[0]["cCCCode"].ToString();
                nObject.cDCCode = ds.Tables[0].Rows[0]["cDCCode"].ToString();
                nObject.cTrade = ds.Tables[0].Rows[0]["cTrade"].ToString();
                nObject.cCusAddress = ds.Tables[0].Rows[0]["cCusAddress"].ToString();
                nObject.cCusPostCode = ds.Tables[0].Rows[0]["cCusPostCode"].ToString();
                nObject.cCusRegCode = ds.Tables[0].Rows[0]["cCusRegCode"].ToString();
                nObject.cCusBank = ds.Tables[0].Rows[0]["cCusBank"].ToString();
                nObject.cCusAccount = ds.Tables[0].Rows[0]["cCusAccount"].ToString();
                nObject.dCusDevDate = ((ds.Tables[0].Rows[0]["dCusDevDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["dCusDevDate"]);
                nObject.cCusLPerson = ds.Tables[0].Rows[0]["cCusLPerson"].ToString();
                nObject.cCusEmail = ds.Tables[0].Rows[0]["cCusEmail"].ToString();
                nObject.cCusPerson = ds.Tables[0].Rows[0]["cCusPerson"].ToString();
                nObject.cCusPhone = ds.Tables[0].Rows[0]["cCusPhone"].ToString();
                nObject.cCusFax = ds.Tables[0].Rows[0]["cCusFax"].ToString();
                nObject.cCusBP = ds.Tables[0].Rows[0]["cCusBP"].ToString();
                nObject.cCusHand = ds.Tables[0].Rows[0]["cCusHand"].ToString();
                nObject.cCusPPerson = ds.Tables[0].Rows[0]["cCusPPerson"].ToString();
                nObject.iCusDisRate = ((ds.Tables[0].Rows[0]["iCusDisRate"])==DBNull.Value)?0:Convert.ToDouble(ds.Tables[0].Rows[0]["iCusDisRate"]);
                nObject.cCusCreGrade = ds.Tables[0].Rows[0]["cCusCreGrade"].ToString();
                nObject.iCusCreLine = ((ds.Tables[0].Rows[0]["iCusCreLine"])==DBNull.Value)?0:Convert.ToDouble(ds.Tables[0].Rows[0]["iCusCreLine"]);
                nObject.iCusCreDate = ((ds.Tables[0].Rows[0]["iCusCreDate"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte(ds.Tables[0].Rows[0]["iCusCreDate"]);
                nObject.cCusPayCond = ds.Tables[0].Rows[0]["cCusPayCond"].ToString();
                nObject.cCusOAddress = ds.Tables[0].Rows[0]["cCusOAddress"].ToString();
                nObject.cCusOType = ds.Tables[0].Rows[0]["cCusOType"].ToString();
                nObject.cCusHeadCode = ds.Tables[0].Rows[0]["cCusHeadCode"].ToString();
                nObject.cCusWhCode = ds.Tables[0].Rows[0]["cCusWhCode"].ToString();
                nObject.cCusDepart = ds.Tables[0].Rows[0]["cCusDepart"].ToString();
                nObject.iARMoney = ((ds.Tables[0].Rows[0]["iARMoney"])==DBNull.Value)?0:Convert.ToDouble(ds.Tables[0].Rows[0]["iARMoney"]);
                nObject.dLastDate = ((ds.Tables[0].Rows[0]["dLastDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["dLastDate"]);
                nObject.iLastMoney = ((ds.Tables[0].Rows[0]["iLastMoney"])==DBNull.Value)?0:Convert.ToDouble(ds.Tables[0].Rows[0]["iLastMoney"]);
                nObject.dLRDate = ((ds.Tables[0].Rows[0]["dLRDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["dLRDate"]);
                nObject.iLRMoney = ((ds.Tables[0].Rows[0]["iLRMoney"])==DBNull.Value)?0:Convert.ToDouble(ds.Tables[0].Rows[0]["iLRMoney"]);
                nObject.dEndDate = ((ds.Tables[0].Rows[0]["dEndDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["dEndDate"]);
                nObject.iFrequency = ((ds.Tables[0].Rows[0]["iFrequency"])==DBNull.Value)?0:Convert.ToInt32(ds.Tables[0].Rows[0]["iFrequency"]);
                nObject.cCusDefine1 = ds.Tables[0].Rows[0]["cCusDefine1"].ToString();
                nObject.cCusDefine2 = ds.Tables[0].Rows[0]["cCusDefine2"].ToString();
                nObject.cCusDefine3 = ds.Tables[0].Rows[0]["cCusDefine3"].ToString();
                nObject.iCostGrade = (short)ds.Tables[0].Rows[0]["iCostGrade"];
                nObject.cUUAccount = ds.Tables[0].Rows[0]["cUUAccount"].ToString();
                nObject.cCusHelp = ds.Tables[0].Rows[0]["cCusHelp"].ToString();
                nObject.cZQCode = ds.Tables[0].Rows[0]["cZQCode"].ToString();
                nObject.UniqueID = ds.Tables[0].Rows[0]["UniqueID"].ToString();
                nObject.dBirthday = ((ds.Tables[0].Rows[0]["dBirthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime(ds.Tables[0].Rows[0]["dBirthday"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
		/// <summary>
		/// 得到  customer 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>customer 数据实体</returns>
		private CustomerModel Populate_CustomerEntity_FromDr(IDataReader dr)
		{
			CustomerModel Obj = new CustomerModel();
			
				Obj.cCusCode =  dr["cCusCode"].ToString();
				Obj.cCusName =  dr["cCusName"].ToString();
				Obj.cCusAbbName =  dr["cCusAbbName"].ToString();
				Obj.cCCCode =  dr["cCCCode"].ToString();
				Obj.cDCCode =  dr["cDCCode"].ToString();
				Obj.cTrade =  dr["cTrade"].ToString();
				Obj.cCusAddress =  dr["cCusAddress"].ToString();
				Obj.cCusPostCode =  dr["cCusPostCode"].ToString();
				Obj.cCusRegCode =  dr["cCusRegCode"].ToString();
				Obj.cCusBank =  dr["cCusBank"].ToString();
				Obj.cCusAccount =  dr["cCusAccount"].ToString();
				Obj.dCusDevDate = (( dr["dCusDevDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dCusDevDate"]);
				Obj.cCusLPerson =  dr["cCusLPerson"].ToString();
				Obj.cCusEmail =  dr["cCusEmail"].ToString();
				Obj.cCusPerson =  dr["cCusPerson"].ToString();
				Obj.cCusPhone =  dr["cCusPhone"].ToString();
				Obj.cCusFax =  dr["cCusFax"].ToString();
				Obj.cCusBP =  dr["cCusBP"].ToString();
				Obj.cCusHand =  dr["cCusHand"].ToString();
				Obj.cCusPPerson =  dr["cCusPPerson"].ToString();
				Obj.iCusDisRate = (( dr["iCusDisRate"])==DBNull.Value)?0:Convert.ToDouble( dr["iCusDisRate"]);
				Obj.cCusCreGrade =  dr["cCusCreGrade"].ToString();
				Obj.iCusCreLine = (( dr["iCusCreLine"])==DBNull.Value)?0:Convert.ToDouble( dr["iCusCreLine"]);
				Obj.iCusCreDate = (( dr["iCusCreDate"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["iCusCreDate"]);
				Obj.cCusPayCond =  dr["cCusPayCond"].ToString();
				Obj.cCusOAddress =  dr["cCusOAddress"].ToString();
				Obj.cCusOType =  dr["cCusOType"].ToString();
				Obj.cCusHeadCode =  dr["cCusHeadCode"].ToString();
				Obj.cCusWhCode =  dr["cCusWhCode"].ToString();
				Obj.cCusDepart =  dr["cCusDepart"].ToString();
				Obj.iARMoney = (( dr["iARMoney"])==DBNull.Value)?0:Convert.ToDouble( dr["iARMoney"]);
				Obj.dLastDate = (( dr["dLastDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dLastDate"]);
				Obj.iLastMoney = (( dr["iLastMoney"])==DBNull.Value)?0:Convert.ToDouble( dr["iLastMoney"]);
				Obj.dLRDate = (( dr["dLRDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dLRDate"]);
				Obj.iLRMoney = (( dr["iLRMoney"])==DBNull.Value)?0:Convert.ToDouble( dr["iLRMoney"]);
				Obj.dEndDate = (( dr["dEndDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dEndDate"]);
				Obj.iFrequency = (( dr["iFrequency"])==DBNull.Value)?0:Convert.ToInt32( dr["iFrequency"]);
				Obj.cCusDefine1 =  dr["cCusDefine1"].ToString();
				Obj.cCusDefine2 =  dr["cCusDefine2"].ToString();
				Obj.cCusDefine3 =  dr["cCusDefine3"].ToString();
				Obj.iCostGrade = (short) dr["iCostGrade"];
				Obj.cUUAccount =  dr["cUUAccount"].ToString();
				Obj.cCusHelp =  dr["cCusHelp"].ToString();
				Obj.cZQCode =  dr["cZQCode"].ToString();
				Obj.UniqueID =  dr["UniqueID"].ToString();
				Obj.dBirthday = (( dr["dBirthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dBirthday"]);
			
			return Obj;
		}
		/// <summary>
		/// 得到  customer 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>customer 数据实体</returns>
		private CustomerModel Populate_CustomerEntity_FromDr(DataRow dr)
		{
			CustomerModel Obj = new CustomerModel();
			if(dr!=null)
			{
				Obj.cCusCode =  dr["cCusCode"].ToString();
				Obj.cCusName =  dr["cCusName"].ToString();
				Obj.cCusAbbName =  dr["cCusAbbName"].ToString();
				Obj.cCCCode =  dr["cCCCode"].ToString();
				Obj.cDCCode =  dr["cDCCode"].ToString();
				Obj.cTrade =  dr["cTrade"].ToString();
				Obj.cCusAddress =  dr["cCusAddress"].ToString();
				Obj.cCusPostCode =  dr["cCusPostCode"].ToString();
				Obj.cCusRegCode =  dr["cCusRegCode"].ToString();
				Obj.cCusBank =  dr["cCusBank"].ToString();
				Obj.cCusAccount =  dr["cCusAccount"].ToString();
				Obj.dCusDevDate = (( dr["dCusDevDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dCusDevDate"]);
				Obj.cCusLPerson =  dr["cCusLPerson"].ToString();
				Obj.cCusEmail =  dr["cCusEmail"].ToString();
				Obj.cCusPerson =  dr["cCusPerson"].ToString();
				Obj.cCusPhone =  dr["cCusPhone"].ToString();
				Obj.cCusFax =  dr["cCusFax"].ToString();
				Obj.cCusBP =  dr["cCusBP"].ToString();
				Obj.cCusHand =  dr["cCusHand"].ToString();
				Obj.cCusPPerson =  dr["cCusPPerson"].ToString();
				Obj.iCusDisRate = (( dr["iCusDisRate"])==DBNull.Value)?0:Convert.ToDouble( dr["iCusDisRate"]);
				Obj.cCusCreGrade =  dr["cCusCreGrade"].ToString();
				Obj.iCusCreLine = (( dr["iCusCreLine"])==DBNull.Value)?0:Convert.ToDouble( dr["iCusCreLine"]);
				Obj.iCusCreDate = (( dr["iCusCreDate"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["iCusCreDate"]);
				Obj.cCusPayCond =  dr["cCusPayCond"].ToString();
				Obj.cCusOAddress =  dr["cCusOAddress"].ToString();
				Obj.cCusOType =  dr["cCusOType"].ToString();
				Obj.cCusHeadCode =  dr["cCusHeadCode"].ToString();
				Obj.cCusWhCode =  dr["cCusWhCode"].ToString();
				Obj.cCusDepart =  dr["cCusDepart"].ToString();
				Obj.iARMoney = (( dr["iARMoney"])==DBNull.Value)?0:Convert.ToDouble( dr["iARMoney"]);
				Obj.dLastDate = (( dr["dLastDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dLastDate"]);
				Obj.iLastMoney = (( dr["iLastMoney"])==DBNull.Value)?0:Convert.ToDouble( dr["iLastMoney"]);
				Obj.dLRDate = (( dr["dLRDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dLRDate"]);
				Obj.iLRMoney = (( dr["iLRMoney"])==DBNull.Value)?0:Convert.ToDouble( dr["iLRMoney"]);
				Obj.dEndDate = (( dr["dEndDate"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dEndDate"]);
				Obj.iFrequency = (( dr["iFrequency"])==DBNull.Value)?0:Convert.ToInt32( dr["iFrequency"]);
				Obj.cCusDefine1 =  dr["cCusDefine1"].ToString();
				Obj.cCusDefine2 =  dr["cCusDefine2"].ToString();
				Obj.cCusDefine3 =  dr["cCusDefine3"].ToString();
				Obj.iCostGrade = (short) dr["iCostGrade"];
				Obj.cUUAccount =  dr["cUUAccount"].ToString();
				Obj.cCusHelp =  dr["cCusHelp"].ToString();
				Obj.cZQCode =  dr["cZQCode"].ToString();
				Obj.UniqueID =  dr["UniqueID"].ToString();
				Obj.dBirthday = (( dr["dBirthday"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["dBirthday"]);
			}
			return Obj;
		}
        /// <summary>
        /// 根据ID,返回一个Customer对象
        /// </summary>
        /// <param name="cCusCode">cCusCode</param>
        /// <returns>Customer对象</returns>
        public override CustomerModel Get_CustomerModel(string cCusCode)
        {
            CustomerModel _Entity=null;
            string commandString="select * from Customer where cCusCode=@cCusCode";
            DbCommand command=db.GetSqlStringCommand(commandString);
            db.AddInParameter(command,"cCusCode",DbType.String,cCusCode);
            using(IDataReader dr=db.ExecuteReader(command))
            {
                while(dr.Read())
                {
                    _Entity=Populate_CustomerEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
		/// <summary>
		/// 得到数据表Customer所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public override IList<CustomerModel> GetCustomerAll()
		{
			IList< CustomerModel> _Entity=new List< CustomerModel>();
            try
            {
                string commandString = string.Format("select * from [UFDATA_005_{0}].[dbo].[Customer]", DateTime.Now.Year);
                using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
                {
                    while (dr.Read())
                    {
                        _Entity.Add(Populate_CustomerEntity_FromDr(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                string commandString = string.Format("select * from [Customer]");
                using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
                {
                    while (dr.Read())
                    {
                        _Entity.Add(Populate_CustomerEntity_FromDr(dr));
                    }
                }
            }
            

			return _Entity;
		}
#endregion
	}
}
