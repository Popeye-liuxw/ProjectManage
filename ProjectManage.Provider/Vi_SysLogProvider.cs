
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysLogProvider.cs
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
    public  abstract partial class Vi_SysLogProvider
    {
        /// <summary>
        /// 得到用户所有系统日志信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public abstract IList<Vi_SysLogModel> getAllLogByUserId(int userId,int limit);
        /// <summary>
        /// 根据用户ID和用户类型得到用户上次登录信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public abstract Vi_SysLogModel getLastLogInfo(int userId, int limit);
	}
}