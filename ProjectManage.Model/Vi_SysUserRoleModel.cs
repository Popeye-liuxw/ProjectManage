// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserRoleModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/15
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysUserRole数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysUserRoleModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _userID;
		///<summary>
		///
		///</summary>
		private int _posiID;
		///<summary>
		///
		///</summary>
		private string _back = String.Empty;
		///<summary>
		///
		///</summary>
		private int _back2;
		///<summary>
		///
		///</summary>
		private DateTime _createTime;
		#endregion
		
		#region 构造函数
		///<summary>
		///用户角色信息，用来对应用户和职位关系
		///</summary>
		public Vi_SysUserRoleModel()
		{
		}
		///<summary>
		///用户角色信息，用来对应用户和职位关系
		///</summary>
		public Vi_SysUserRoleModel
		(
			int iD,
			int userID,
			int posiID,
			string back,
			int back2,
			DateTime createTime
		)
		{
			_iD         = iD;
			_userID     = userID;
			_posiID     = posiID;
			_back       = back;
			_back2      = back2;
			_createTime = createTime;
			
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
		public int UserID
		{
			get {return _userID;}
			set {_userID = value;}
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
		public string Back
		{
			get {return _back;}
			set {_back = value;}
		}

		///<summary>
		///
		///</summary>
		public int Back2
		{
			get {return _back2;}
			set {_back2 = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}
	
		#endregion
	}
}
