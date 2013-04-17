// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections.Generic;
namespace ProjectManage.Model
{
    /// <summary>
    ///Vi_SysUser数据实体
    /// </summary>
    [Serializable]
    public class Vi_SysUserModel
    {
        #region 变量定义
        ///<summary>
        ///主键ID
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
        private string _realName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private DateTime _birthday;
        ///<summary>
        ///
        ///</summary>
        private string _email = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _phoneNum = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _tel = String.Empty;
        ///<summary>
        ///T3表专用
        ///</summary>
        private string _personProp = String.Empty;
        ///<summary>
        ///T3表专用
        ///</summary>
        private string _employeeID = String.Empty;
        ///<summary>
        ///T3表专用
        ///</summary>
        private string _groupID = String.Empty;
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
        ///系统用户信息表 和员工表ID关联
        ///</summary>
        public Vi_SysUserModel()
        {
        }
        ///<summary>
        ///系统用户信息表 和员工表ID关联
        ///</summary>
        public Vi_SysUserModel
        (
            int iD,
            string userName,
            string userPwd,
            string realName,
            DateTime birthday,
            string email,
            string phoneNum,
            string tel,
            string personProp,
            string employeeID,
            string groupID,
            DateTime createTime,
            DateTime updateTime
        )
        {
            _iD = iD;
            _userName = userName;
            _userPwd = userPwd;
            _realName = realName;
            _birthday = birthday;
            _email = email;
            _phoneNum = phoneNum;
            _tel = tel;
            _personProp = personProp;
            _employeeID = employeeID;
            _groupID = groupID;
            _createTime = createTime;
            _updateTime = updateTime;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键ID
        ///</summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        ///<summary>
        ///T3表专用
        ///</summary>
        public string PersonProp
        {
            get { return _personProp; }
            set { _personProp = value; }
        }

        ///<summary>
        ///T3表专用
        ///</summary>
        public string EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        ///<summary>
        ///T3表专用
        ///</summary>
        public string GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        #endregion
    }
    public class upddateInfo
    {
        public int addNum { get; set; }
        public int updateNum { get; set; }
        public List<strinfo> info { get; set; }
    }
    public class strinfo
    {
        public String infoDetail { get; set; }
    }

}
