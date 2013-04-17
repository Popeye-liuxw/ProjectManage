// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiInfoModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysPosiInfo数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysPosiInfoModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _posiName = String.Empty;
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
		///职位信息表
		///</summary>
		public Vi_SysPosiInfoModel()
		{
		}
		///<summary>
		///职位信息表
		///</summary>
		public Vi_SysPosiInfoModel
		(
			int iD,
			string posiName,
			string back,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_posiName   = posiName;
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
		public string PosiName
		{
			get {return _posiName;}
			set {_posiName = value;}
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
