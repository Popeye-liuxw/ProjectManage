// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： DepartmentModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Department数据实体
	/// </summary>
	[Serializable]
	public class DepartmentModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _cDepCode;
		///<summary>
		///
		///</summary>
		private bool _bDepEnd;
		///<summary>
		///
		///</summary>
		private string _cDepName = String.Empty;
		///<summary>
		///
		///</summary>
		private byte _iDepGrade;
		///<summary>
		///
		///</summary>
		private string _cDepPerson = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDepProp = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDepPhone = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDepAddress = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDepMemo = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cDepHelp = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public DepartmentModel()
		{
		}
		///<summary>
		///
		///</summary>
		public DepartmentModel
		(
			string cDepCode,
			bool bDepEnd,
			string cDepName,
			byte iDepGrade,
			string cDepPerson,
			string cDepProp,
			string cDepPhone,
			string cDepAddress,
			string cDepMemo,
			string cDepHelp
		)
		{
			_cDepCode    = cDepCode;
			_bDepEnd     = bDepEnd;
			_cDepName    = cDepName;
			_iDepGrade   = iDepGrade;
			_cDepPerson  = cDepPerson;
			_cDepProp    = cDepProp;
			_cDepPhone   = cDepPhone;
			_cDepAddress = cDepAddress;
			_cDepMemo    = cDepMemo;
			_cDepHelp    = cDepHelp;
			
		}
		#endregion
		
		#region 公共属性
		
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
		public bool bDepEnd
		{
			get {return _bDepEnd;}
			set {_bDepEnd = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepName
		{
			get {return _cDepName;}
			set {_cDepName = value;}
		}

		///<summary>
		///
		///</summary>
		public byte iDepGrade
		{
			get {return _iDepGrade;}
			set {_iDepGrade = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepPerson
		{
			get {return _cDepPerson;}
			set {_cDepPerson = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepProp
		{
			get {return _cDepProp;}
			set {_cDepProp = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepPhone
		{
			get {return _cDepPhone;}
			set {_cDepPhone = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepAddress
		{
			get {return _cDepAddress;}
			set {_cDepAddress = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepMemo
		{
			get {return _cDepMemo;}
			set {_cDepMemo = value;}
		}

		///<summary>
		///
		///</summary>
		public string cDepHelp
		{
			get {return _cDepHelp;}
			set {_cDepHelp = value;}
		}
	
		#endregion
	}
}
