// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysEmailServerModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysEmailServer数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysEmailServerModel
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
		private int _port;
		///<summary>
		///0不加密
        ///1加密
		///</summary>
		private int _enableSSL;
		///<summary>
		///
		///</summary>
		private string _sMTPHost = String.Empty;
		///<summary>
		///
		///</summary>
		private string _emailName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _address = String.Empty;
		///<summary>
		///
		///</summary>
		private string _displayName = String.Empty;
		///<summary>
		///0表示未启用
        ///10表示启用   
        ///只能启用一个配置项
		///</summary>
		private int _state;
		///<summary>
		///
		///</summary>
		private int _userID;
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
		///邮箱服务器相关信息
		///</summary>
		public Vi_SysEmailServerModel()
		{
		}
		///<summary>
		///邮箱服务器相关信息
		///</summary>
		public Vi_SysEmailServerModel
		(
			int iD,
			string userName,
			string userPwd,
			int port,
			int enableSSL,
			string sMTPHost,
			string emailName,
			string address,
			string displayName,
			int state,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD          = iD;
			_userName    = userName;
			_userPwd     = userPwd;
			_port        = port;
			_enableSSL   = enableSSL;
			_sMTPHost    = sMTPHost;
			_emailName   = emailName;
			_address     = address;
			_displayName = displayName;
			_state       = state;
			_userID      = userID;
			_createTime  = createTime;
			_updateTime  = updateTime;
			
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
		public int Port
		{
			get {return _port;}
			set {_port = value;}
		}

		///<summary>
		///0不加密
        ///1加密
		///</summary>
		public int EnableSSL
		{
			get {return _enableSSL;}
			set {_enableSSL = value;}
		}

		///<summary>
		///
		///</summary>
		public string SMTPHost
		{
			get {return _sMTPHost;}
			set {_sMTPHost = value;}
		}

		///<summary>
		///
		///</summary>
		public string EmailName
		{
			get {return _emailName;}
			set {_emailName = value;}
		}

		///<summary>
		///
		///</summary>
		public string Address
		{
			get {return _address;}
			set {_address = value;}
		}

		///<summary>
		///
		///</summary>
		public string DisplayName
		{
			get {return _displayName;}
			set {_displayName = value;}
		}

		///<summary>
		///0表示未启用
        ///10表示启用   
        ///只能启用一个配置项
		///</summary>
		public int State
		{
			get {return _state;}
			set {_state = value;}
		}

		///<summary>
		///
		///</summary>
		public int UserID
		{
			get {return _userID;}
			set {_userID = value;}
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
