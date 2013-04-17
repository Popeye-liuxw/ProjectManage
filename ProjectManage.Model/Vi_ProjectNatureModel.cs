// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ProjectNatureModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_ProjectNature数据实体
	/// </summary>
	[Serializable]
	public class Vi_ProjectNatureModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _i_id;
		///<summary>
		///
		///</summary>
		private string _caption = String.Empty;
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
		///项目性质
		///</summary>
		public Vi_ProjectNatureModel()
		{
		}
		///<summary>
		///项目性质
		///</summary>
		public Vi_ProjectNatureModel
		(
			int iD,
			int i_id,
			string caption,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_i_id       = i_id;
			_caption    = caption;
			_userID     = userID;
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
		public int I_id
		{
			get {return _i_id;}
			set {_i_id = value;}
		}

		///<summary>
		///
		///</summary>
		public string Caption
		{
			get {return _caption;}
			set {_caption = value;}
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
