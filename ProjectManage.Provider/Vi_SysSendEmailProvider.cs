
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysSendEmailProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_SysSendEmailProvider
    {
        /// <summary>
        /// 获取某种状态邮件个数
        /// </summary>
        /// <param name="state">状态编号</param>
        /// <returns></returns>
        public abstract int GetEmailStateCount(int state);

        /// <summary>
        /// 清理某个邮件
        /// </summary>
        /// <param name="mail">邮件对象</param>
        /// <returns></returns>
        public abstract bool ClearEmail(Vi_SysSendEmailModel mail);

        /// <summary>
        /// 获取某种状态的邮件列表
        /// </summary>
        /// <param name="state">状态编号</param>
        /// <returns></returns>
        public abstract IList<Vi_SysSendEmailModel> GetEmailStateList(int state);
        /// <summary>
        /// 获取某种状态的邮件列表
        /// </summary>
        /// <param name="state">状态编号</param>
        /// <returns></returns>
        public abstract IList<Vi_SysSendEmailModel> GetEmailStateList(int state, DateTime ResendTime);
	}
}