
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using System.Data;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_SysUserProvider
    {
        public abstract bool FieldAccess(DataSet de);
        /// <summary>
        /// 添加一条用户信息记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public abstract int AddUser(Vi_SysUserModel model);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public abstract int UpdateUser(Vi_SysUserModel model);
        //根据用户名得到用户信息
        public abstract Vi_SysUserModel getUserInfoByUserName(string UserName);
        //根据真名得到用户信息
        public abstract Vi_SysUserModel getUserInfoByRealName(string RealName);
        /// <summary>
        /// 检测是否有该人
        /// </summary>
        /// <param name="username">用户姓名</param>
        /// <param name="birthday">生日</param>
        public abstract Vi_SysUserModel CheckUserByName(string username, DateTime birthday);
        /// <summary>
        /// 得到所有用户信息包括未激活账户。
        /// </summary>
        /// <returns></returns>
        public abstract IList<Vi_SysUserModel> getAllSysUsers();


        
	}
}