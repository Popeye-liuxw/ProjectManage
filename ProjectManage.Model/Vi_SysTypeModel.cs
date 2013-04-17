// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysTypeModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysType数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysTypeModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _typeName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _typeValue;
		///<summary>
		///
		///</summary>
		private string _bigType = String.Empty;
		///<summary>
		///
		///</summary>
		private int _bigValue;
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
        /// <summary>
        /// 100小类
        /// 200大类
        /// </summary>
        private int _level;
		#endregion
		
		#region 构造函数
		///<summary>
		///类型信息表
		///</summary>
		public Vi_SysTypeModel()
		{
		}
		///<summary>
		///类型信息表
		///</summary>
        public Vi_SysTypeModel
        (
            int iD,
            string typeName,
            int typeValue,
            string bigType,
            int bigValue,
            int userID,
            int level,
            DateTime createTime,
            DateTime updateTime
        )
        {
            _iD = iD;
            _typeName = typeName;
            _typeValue = typeValue;
            _bigType = bigType;
            _bigValue = bigValue;
            _userID = userID;
            _level = level;
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
		public string TypeName
		{
			get {return _typeName;}
			set {_typeName = value;}
		}

		///<summary>
		///
		///</summary>
		public int TypeValue
		{
			get {return _typeValue;}
			set {_typeValue = value;}
		}

		///<summary>
		///
		///</summary>
		public string BigType
		{
			get {return _bigType;}
			set {_bigType = value;}
		}

		///<summary>
		///
		///</summary>
		public int BigValue
		{
			get {return _bigValue;}
			set {_bigValue = value;}
		}
        /// <summary>
        /// 100小类
        /// 200大类
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
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
