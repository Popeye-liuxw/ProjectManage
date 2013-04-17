// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysBackUserModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysBackUser数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysBackUserModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _userName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _userPwd = String.Empty;
		///<summary>
		///
		///</summary>
		private string _realName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _email = String.Empty;
		///<summary>
		///
		///</summary>
		private string _phoneNum = String.Empty;
		///<summary>
		///
		///</summary>
		private string _back = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _createTime;
		///<summary>
		///
		///</summary>
		private DateTime _updateTime;
		#endregion
		
		#region 构造函数
		///<summary>
		///系统后台管理用户信息表
		///</summary>
		public Vi_SysBackUserModel()
		{
		}
		///<summary>
		///系统后台管理用户信息表
		///</summary>
		public Vi_SysBackUserModel
		(
			int iD,
			string userName,
			string userPwd,
			string realName,
			string email,
			string phoneNum,
			string back,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_userName   = userName;
			_userPwd    = userPwd;
			_realName   = realName;
			_email      = email;
			_phoneNum   = phoneNum;
			_back       = back;
			_createTime = createTime;
			_updateTime = updateTime;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public int ID
		{
			get {return _iD;}
			set {_iD = value;}
		}

		///<summary>
		///
		///</summary>
		public string UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}

		///<summary>
		///
		///</summary>
		public string UserPwd
		{
			get {return _userPwd;}
			set {_userPwd = value;}
		}

		///<summary>
		///
		///</summary>
		public string RealName
		{
			get {return _realName;}
			set {_realName = value;}
		}

		///<summary>
		///
		///</summary>
		public string Email
		{
			get {return _email;}
			set {_email = value;}
		}

		///<summary>
		///
		///</summary>
		public string PhoneNum
		{
			get {return _phoneNum;}
			set {_phoneNum = value;}
		}

		///<summary>
		///
		///</summary>
		public string Back
		{
			get {return _back;}
			set {_back = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
	
		#endregion
	}
}
