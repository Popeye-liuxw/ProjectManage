
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysModulesProvider.cs
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
    public  abstract partial class Vi_SysModulesProvider
    {
        /// <summary>
        /// 得到最大节点等级值
        /// </summary>
        /// <returns></returns>
        public abstract string GetModuleLevelDesc();
        /// <summary>
        /// 得到最大子节点等级值
        /// </summary>
        /// <param name="moduleLevel"></param>
        /// <returns></returns>
        public abstract string GetModuleLevelNodeDesc(string moduleLevel);

        public abstract IList<Vi_SysModulesModel> FirstModuleNodes();

        public abstract IList<Vi_SysModulesModel> ChildModuleNodes(string moduleNum);
	}
}