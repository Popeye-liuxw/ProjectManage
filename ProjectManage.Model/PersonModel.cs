// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： PersonModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Person数据实体
	/// </summary>
	[Serializable]
	public class PersonModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _cPersonCode;
		///<summary>
		///
		///</summary>
		private string _cPersonName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDepCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cPersonProp = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cPersonHelp = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _dBirthday;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public PersonModel()
		{
		}
		///<summary>
		///
		///</summary>
		public PersonModel
		(
			string cPersonCode,
			string cPersonName,
			string cDepCode,
			string cPersonProp,
			string cPersonHelp,
			DateTime dBirthday
		)
		{
			_cPersonCode = cPersonCode;
			_cPersonName = cPersonName;
			_cDepCode    = cDepCode;
			_cPersonProp = cPersonProp;
			_cPersonHelp = cPersonHelp;
			_dBirthday   = dBirthday;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string cPersonCode
		{
			get {return _cPersonCode;}
			set {_cPersonCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cPersonName
		{
			get {return _cPersonName;}
			set {_cPersonName = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepCode
		{
			get {return _cDepCode;}
			set {_cDepCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string cPersonProp
		{
			get {return _cPersonProp;}
			set {_cPersonProp = value;}
		}

		///<summary>
		///
		///</summary>
		public string cPersonHelp
		{
			get {return _cPersonHelp;}
			set {_cPersonHelp = value;}
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
