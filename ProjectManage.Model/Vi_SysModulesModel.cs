// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysModulesModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysModules数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysModulesModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _moduleName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _uRL = String.Empty;
		///<summary>
		///
		///</summary>
		private string _moduleLevel = String.Empty;
		///<summary>
		///
		///</summary>
		private string _moduleNum = String.Empty;
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
		///功能模块表，记录系统所有项目模块
		///</summary>
		public Vi_SysModulesModel()
		{
		}
		///<summary>
		///功能模块表，记录系统所有项目模块
		///</summary>
		public Vi_SysModulesModel
		(
			int iD,
			string moduleName,
			string uRL,
			string moduleLevel,
			string moduleNum,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD          = iD;
			_moduleName  = moduleName;
			_uRL         = uRL;
			_moduleLevel = moduleLevel;
			_moduleNum   = moduleNum;
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
		public string ModuleName
		{
			get {return _moduleName;}
			set {_moduleName = value;}
		}

		///<summary>
		///
		///</summary>
		public string URL
		{
			get {return _uRL;}
			set {_uRL = value;}
		}

		///<summary>
		///
		///</summary>
		public string ModuleLevel
		{
			get {return _moduleLevel;}
			set {_moduleLevel = value;}
		}

		///<summary>
		///
		///</summary>
		public string ModuleNum
		{
			get {return _moduleNum;}
			set {_moduleNum = value;}
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
