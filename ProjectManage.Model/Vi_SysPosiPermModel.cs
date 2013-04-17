// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiPermModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysPosiPerm数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysPosiPermModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _posiID;
		///<summary>
		///
		///</summary>
		private string _posiName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sysModuleID;
		///<summary>
		///权限分三种状态：
        ///0未设置
        ///10 读
        ///20 写
		///</summary>
		private int _permissions;
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
		///职位权限表针对不同职位划分不同功能模块
		///</summary>
		public Vi_SysPosiPermModel()
		{
		}
		///<summary>
		///职位权限表针对不同职位划分不同功能模块
		///</summary>
		public Vi_SysPosiPermModel
		(
			int iD,
			int posiID,
			string posiName,
			int sysModuleID,
			int permissions,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD          = iD;
			_posiID      = posiID;
			_posiName    = posiName;
			_sysModuleID = sysModuleID;
			_permissions = permissions;
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
		public int PosiID
		{
			get {return _posiID;}
			set {_posiID = value;}
		}

		///<summary>
		///
		///</summary>
		public string PosiName
		{
			get {return _posiName;}
			set {_posiName = value;}
		}

		///<summary>
		///
		///</summary>
		public int SysModuleID
		{
			get {return _sysModuleID;}
			set {_sysModuleID = value;}
		}

		///<summary>
		///权限分三种状态：
        ///0未设置
        ///10 读
        ///20 写
		///</summary>
		public int Permissions
		{
			get {return _permissions;}
			set {_permissions = value;}
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
