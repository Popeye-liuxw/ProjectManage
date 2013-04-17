
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_PrjChangePaperProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/3
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_PrjChangePaperProvider
    {
        /// <summary>
        /// 根据项目ID，获取top条最新变更数据
        /// </summary>
        /// <param name="prjId">项目ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="top">条目数</param>
        /// <returns></returns>
        public abstract IList<Vi_PrjChangePaperModel> GetPrjChangePaper(int prjId, int userId, int top);
	}
}