// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_PrjChangePaperModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/3
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_PrjChangePaper数据实体
	/// </summary>
	[Serializable]
	public class Vi_PrjChangePaperModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _prjID;
		///<summary>
		///10 系统发出通知
		///</summary>
		private int _state;
		///<summary>
		///
		///</summary>
		private string _summarize = String.Empty;
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
		///用来记录项目中需求的变化，一个项目有可能多次变更
		///</summary>
		public Vi_PrjChangePaperModel()
		{
		}
		///<summary>
		///用来记录项目中需求的变化，一个项目有可能多次变更
		///</summary>
		public Vi_PrjChangePaperModel
		(
			int iD,
			int prjID,
			int state,
			string summarize,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_prjID      = prjID;
			_state      = state;
			_summarize  = summarize;
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
		public int PrjID
		{
			get {return _prjID;}
			set {_prjID = value;}
		}

		///<summary>
		///10 系统发出通知
		///</summary>
		public int State
		{
			get {return _state;}
			set {_state = value;}
		}

		///<summary>
		///
		///</summary>
		public string summarize
		{
			get {return _summarize;}
			set {_summarize = value;}
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
