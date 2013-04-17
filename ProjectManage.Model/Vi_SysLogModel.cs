// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysLogModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysLog数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysLogModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///区分是前台登录还是后台登录
		///</summary>
		private int _sysType;
		///<summary>
		///
		///</summary>
		private string _userName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _userID;
		///<summary>
		///
		///</summary>
		private string _theIP = String.Empty;
		///<summary>
		///
		///</summary>
		private string _lastIP = String.Empty;
		///<summary>
		///
		///</summary>
		private string _iOS = String.Empty;
		///<summary>
		///
		///</summary>
		private string _browser = String.Empty;
		///<summary>
		///具体进行了那个模块的调整
		///</summary>
		private string _operate = String.Empty;
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
		///记录系统日志信息
        ///如那个员工登录系统，什么系统，IP
		///</summary>
		public Vi_SysLogModel()
		{
		}
		///<summary>
		///记录系统日志信息
        ///如那个员工登录系统，什么系统，IP
		///</summary>
		public Vi_SysLogModel
		(
			int iD,
			int sysType,
			string userName,
			int userID,
			string theIP,
			string lastIP,
			string iOS,
			string browser,
			string operate,
			string back,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_sysType    = sysType;
			_userName   = userName;
			_userID     = userID;
			_theIP      = theIP;
			_lastIP     = lastIP;
			_iOS        = iOS;
			_browser    = browser;
			_operate    = operate;
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
		///区分是前台登录还是后台登录
		///</summary>
		public int SysType
		{
			get {return _sysType;}
			set {_sysType = value;}
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
		public int UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}

		///<summary>
		///
		///</summary>
		public string TheIP
		{
			get {return _theIP;}
			set {_theIP = value;}
		}

		///<summary>
		///
		///</summary>
		public string LastIP
		{
			get {return _lastIP;}
			set {_lastIP = value;}
		}

		///<summary>
		///
		///</summary>
		public string IOS
		{
			get {return _iOS;}
			set {_iOS = value;}
		}

		///<summary>
		///
		///</summary>
		public string Browser
		{
			get {return _browser;}
			set {_browser = value;}
		}

		///<summary>
		///具体进行了那个模块的调整
		///</summary>
		public string Operate
		{
			get {return _operate;}
			set {_operate = value;}
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
