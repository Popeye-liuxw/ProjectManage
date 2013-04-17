
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysEmailServerProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_SysEmailServerProvider
    {
        /// <summary>
        /// 获取某邮件地址的个数
        /// </summary>
        /// <param name="userName">邮件地址</param>
        /// <returns></returns>
        public abstract int GetEmailServerByUserName(string userName);

        /// <summary>
        /// 查找目前启用的邮件服务
        /// </summary>
        /// <returns></returns>
        public abstract Vi_SysEmailServerModel FindEmailServerState(int state);

	}
}