// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： CustomerModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Customer数据实体
	/// </summary>
	[Serializable]
	public class CustomerModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _cCusCode;
		///<summary>
		///
		///</summary>
		private string _cCusName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusAbbName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCCCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDCCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cTrade = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusAddress = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusPostCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusRegCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusBank = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusAccount = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _dCusDevDate;
		///<summary>
		///
		///</summary>
		private string _cCusLPerson = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusEmail = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusPerson = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusPhone = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusFax = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusBP = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusHand = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusPPerson = String.Empty;
		///<summary>
		///
		///</summary>
		private double _iCusDisRate;
		///<summary>
		///
		///</summary>
		private string _cCusCreGrade = String.Empty;
		///<summary>
		///
		///</summary>
		private double _iCusCreLine;
		///<summary>
		///
		///</summary>
		private byte _iCusCreDate;
		///<summary>
		///
		///</summary>
		private string _cCusPayCond = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusOAddress = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusOType = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusHeadCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusWhCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusDepart = String.Empty;
		///<summary>
		///
		///</summary>
		private double _iARMoney;
		///<summary>
		///
		///</summary>
		private DateTime _dLastDate;
		///<summary>
		///
		///</summary>
		private double _iLastMoney;
		///<summary>
		///
		///</summary>
		private DateTime _dLRDate;
		///<summary>
		///
		///</summary>
		private double _iLRMoney;
		///<summary>
		///
		///</summary>
		private DateTime _dEndDate;
		///<summary>
		///
		///</summary>
		private int _iFrequency;
		///<summary>
		///
		///</summary>
		private string _cCusDefine1 = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusDefine2 = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusDefine3 = String.Empty;
		///<summary>
		///
		///</summary>
		private short _iCostGrade;
		///<summary>
		///
		///</summary>
		private string _cUUAccount = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cCusHelp = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cZQCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _uniqueID = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _dBirthday;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public CustomerModel()
		{
		}
		///<summary>
		///
		///</summary>
		public CustomerModel
		(
			string cCusCode,
			string cCusName,
			string cCusAbbName,
			string cCCCode,
			string cDCCode,
			string cTrade,
			string cCusAddress,
			string cCusPostCode,
			string cCusRegCode,
			string cCusBank,
			string cCusAccount,
			DateTime dCusDevDate,
			string cCusLPerson,
			string cCusEmail,
			string cCusPerson,
			string cCusPhone,
			string cCusFax,
			string cCusBP,
			string cCusHand,
			string cCusPPerson,
			double iCusDisRate,
			string cCusCreGrade,
			double iCusCreLine,
			byte iCusCreDate,
			string cCusPayCond,
			string cCusOAddress,
			string cCusOType,
			string cCusHeadCode,
			string cCusWhCode,
			string cCusDepart,
			double iARMoney,
			DateTime dLastDate,
			double iLastMoney,
			DateTime dLRDate,
			double iLRMoney,
			DateTime dEndDate,
			int iFrequency,
			string cCusDefine1,
			string cCusDefine2,
			string cCusDefine3,
			short iCostGrade,
			string cUUAccount,
			string cCusHelp,
			string cZQCode,
			string uniqueID,
			DateTime dBirthday
		)
		{
			_cCusCode     = cCusCode;
			_cCusName     = cCusName;
			_cCusAbbName  = cCusAbbName;
			_cCCCode      = cCCCode;
			_cDCCode      = cDCCode;
			_cTrade       = cTrade;
			_cCusAddress  = cCusAddress;
			_cCusPostCode = cCusPostCode;
			_cCusRegCode  = cCusRegCode;
			_cCusBank     = cCusBank;
			_cCusAccount  = cCusAccount;
			_dCusDevDate  = dCusDevDate;
			_cCusLPerson  = cCusLPerson;
			_cCusEmail    = cCusEmail;
			_cCusPerson   = cCusPerson;
			_cCusPhone    = cCusPhone;
			_cCusFax      = cCusFax;
			_cCusBP       = cCusBP;
			_cCusHand     = cCusHand;
			_cCusPPerson  = cCusPPerson;
			_iCusDisRate  = iCusDisRate;
			_cCusCreGrade = cCusCreGrade;
			_iCusCreLine  = iCusCreLine;
			_iCusCreDate  = iCusCreDate;
			_cCusPayCond  = cCusPayCond;
			_cCusOAddress = cCusOAddress;
			_cCusOType    = cCusOType;
			_cCusHeadCode = cCusHeadCode;
			_cCusWhCode   = cCusWhCode;
			_cCusDepart   = cCusDepart;
			_iARMoney     = iARMoney;
			_dLastDate    = dLastDate;
			_iLastMoney   = iLastMoney;
			_dLRDate      = dLRDate;
			_iLRMoney     = iLRMoney;
			_dEndDate     = dEndDate;
			_iFrequency   = iFrequency;
			_cCusDefine1  = cCusDefine1;
			_cCusDefine2  = cCusDefine2;
			_cCusDefine3  = cCusDefine3;
			_iCostGrade   = iCostGrade;
			_cUUAccount   = cUUAccount;
			_cCusHelp     = cCusHelp;
			_cZQCode      = cZQCode;
			_uniqueID     = uniqueID;
			_dBirthday    = dBirthday;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string cCusCode
		{
			get {return _cCusCode;}
			set {_cCusCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusName
		{
			get {return _cCusName;}
			set {_cCusName = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusAbbName
		{
			get {return _cCusAbbName;}
			set {_cCusAbbName = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCCCode
		{
			get {return _cCCCode;}
			set {_cCCCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDCCode
		{
			get {return _cDCCode;}
			set {_cDCCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cTrade
		{
			get {return _cTrade;}
			set {_cTrade = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusAddress
		{
			get {return _cCusAddress;}
			set {_cCusAddress = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusPostCode
		{
			get {return _cCusPostCode;}
			set {_cCusPostCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusRegCode
		{
			get {return _cCusRegCode;}
			set {_cCusRegCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusBank
		{
			get {return _cCusBank;}
			set {_cCusBank = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusAccount
		{
			get {return _cCusAccount;}
			set {_cCusAccount = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime dCusDevDate
		{
			get {return _dCusDevDate;}
			set {_dCusDevDate = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusLPerson
		{
			get {return _cCusLPerson;}
			set {_cCusLPerson = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusEmail
		{
			get {return _cCusEmail;}
			set {_cCusEmail = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusPerson
		{
			get {return _cCusPerson;}
			set {_cCusPerson = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusPhone
		{
			get {return _cCusPhone;}
			set {_cCusPhone = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusFax
		{
			get {return _cCusFax;}
			set {_cCusFax = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusBP
		{
			get {return _cCusBP;}
			set {_cCusBP = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusHand
		{
			get {return _cCusHand;}
			set {_cCusHand = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusPPerson
		{
			get {return _cCusPPerson;}
			set {_cCusPPerson = value;}
		}

		///<summary>
		///
		///</summary>
		public double iCusDisRate
		{
			get {return _iCusDisRate;}
			set {_iCusDisRate = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusCreGrade
		{
			get {return _cCusCreGrade;}
			set {_cCusCreGrade = value;}
		}

		///<summary>
		///
		///</summary>
		public double iCusCreLine
		{
			get {return _iCusCreLine;}
			set {_iCusCreLine = value;}
		}

		///<summary>
		///
		///</summary>
		public byte iCusCreDate
		{
			get {return _iCusCreDate;}
			set {_iCusCreDate = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusPayCond
		{
			get {return _cCusPayCond;}
			set {_cCusPayCond = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusOAddress
		{
			get {return _cCusOAddress;}
			set {_cCusOAddress = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusOType
		{
			get {return _cCusOType;}
			set {_cCusOType = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusHeadCode
		{
			get {return _cCusHeadCode;}
			set {_cCusHeadCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusWhCode
		{
			get {return _cCusWhCode;}
			set {_cCusWhCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusDepart
		{
			get {return _cCusDepart;}
			set {_cCusDepart = value;}
		}

		///<summary>
		///
		///</summary>
		public double iARMoney
		{
			get {return _iARMoney;}
			set {_iARMoney = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime dLastDate
		{
			get {return _dLastDate;}
			set {_dLastDate = value;}
		}

		///<summary>
		///
		///</summary>
		public double iLastMoney
		{
			get {return _iLastMoney;}
			set {_iLastMoney = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime dLRDate
		{
			get {return _dLRDate;}
			set {_dLRDate = value;}
		}

		///<summary>
		///
		///</summary>
		public double iLRMoney
		{
			get {return _iLRMoney;}
			set {_iLRMoney = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime dEndDate
		{
			get {return _dEndDate;}
			set {_dEndDate = value;}
		}

		///<summary>
		///
		///</summary>
		public int iFrequency
		{
			get {return _iFrequency;}
			set {_iFrequency = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusDefine1
		{
			get {return _cCusDefine1;}
			set {_cCusDefine1 = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusDefine2
		{
			get {return _cCusDefine2;}
			set {_cCusDefine2 = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusDefine3
		{
			get {return _cCusDefine3;}
			set {_cCusDefine3 = value;}
		}

		///<summary>
		///
		///</summary>
		public short iCostGrade
		{
			get {return _iCostGrade;}
			set {_iCostGrade = value;}
		}

		///<summary>
		///
		///</summary>
		public string cUUAccount
		{
			get {return _cUUAccount;}
			set {_cUUAccount = value;}
		}

		///<summary>
		///
		///</summary>
		public string cCusHelp
		{
			get {return _cCusHelp;}
			set {_cCusHelp = value;}
		}

		///<summary>
		///
		///</summary>
		public string cZQCode
		{
			get {return _cZQCode;}
			set {_cZQCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string UniqueID
		{
			get {return _uniqueID;}
			set {_uniqueID = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime dBirthday
		{
			get {return _dBirthday;}
			set {_dBirthday = value;}
		}
	
		#endregion
	}
}
