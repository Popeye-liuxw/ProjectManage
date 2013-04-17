
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiInfoProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_SysPosiInfoProvider
    {
        /// <summary>
        /// 检测某个职位所对应的权限数
        /// </summary>
        /// <param name="posiID">职位ID</param>
        /// <returns></returns>
        public abstract int ExistsSysPosiPermByPosiID(int posiID);
	}
}