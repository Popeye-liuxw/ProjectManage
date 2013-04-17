﻿// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ManagerRecModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_ManagerRec数据实体
	/// </summary>
	[Serializable]
	public class Vi_ManagerRecModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _staffID;
		///<summary>
		///
		///</summary>
		private int _projectID;
		///<summary>
		///
		///</summary>
		private string _projectName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _userID;
		///<summary>
		///
		///</summary>
		private DateTime _createTime =DateTime.Now;
		///<summary>
		///
		///</summary>
		private DateTime _updateTime = DateTime.Now;
		#endregion
		
		#region 构造函数
		///<summary>
		///项目经理表，新添加或者修改项目经理信息存放记录表
        ///包含项目ID 员工ID 和项目名称
		///</summary>
		public Vi_ManagerRecModel()
		{
		}
		///<summary>
		///项目经理表，新添加或者修改项目经理信息存放记录表
        ///包含项目ID 员工ID 和项目名称
		///</summary>
		public Vi_ManagerRecModel
		(
			int iD,
			int staffID,
			int projectID,
			string projectName,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD          = iD;
			_staffID     = staffID;
			_projectID   = projectID;
			_projectName = projectName;
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
		public int StaffID
		{
			get {return _staffID;}
			set {_staffID = value;}
		}

		///<summary>
		///
		///</summary>
		public int ProjectID
		{
			get {return _projectID;}
			set {_projectID = value;}
		}

		///<summary>
		///
		///</summary>
		public string ProjectName
		{
			get {return _projectName;}
			set {_projectName = value;}
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
