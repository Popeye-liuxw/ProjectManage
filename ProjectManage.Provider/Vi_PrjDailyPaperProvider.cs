
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_PrjDailyPaperProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/3
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
    public  abstract partial class Vi_PrjDailyPaperProvider
    {
        /// <summary>
        /// 根据项目ID，获取top条最新数据
        /// </summary>
        /// <param name="prjId">项目ID</param>
        /// <param name="top">条目数</param>
        /// <returns></returns>
        public abstract IList<Vi_PrjDailyPaperModel> GetPrjDailyPaper(int prjId,int userId, int top);

        /// <summary>
        /// 获取日报信息，根据项目ID和用户ID
        /// </summary>
        /// <param name="prjId"></param>
        /// <param name="userId"></param>
        /// <param name="dt">某天的日报，null 取最新的一条日报信息</param>
        /// <returns></returns>
        public abstract Vi_PrjDailyPaperModel GetPrjDailyPaperInfo(int prjId, int userId, DateTime dt);
        /// <summary>
        /// 获取某用户某月的日报记录情况
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public abstract DataTable GetMonthDataTable(int userID, int month,int year);
	}
}