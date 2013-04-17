
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ProjectInfoProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：lxs Popeye-lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using System.Data;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_ProjectInfoProvider
    {
        public abstract int AddProjectFromT3(Vi_ProjectInfoModel viim);
        public abstract int UpdateProFromT3(Vi_ProjectInfoModel viim);
        /// <summary>
        /// 得到为分配项目的数据
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">单页数据条数</param>
        /// <param name="counts">数据总数</param>
        /// <param name="strWhere">查询组合条件</param>
        /// <returns></returns>
        public abstract DataTable getUnallocatedData(int pageNum, int pageSize, int counts, string strWhere);
        /// <summary>
        /// 得到未分配项目的数量
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public abstract int getUnallocatedCount(string strWhere);
        /// <summary>
        /// 获取某用户相关的所有项目
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public abstract IList<Vi_ProjectInfoModel> GetProjectInfoByUser(int userID);
        /// <summary>
        /// 获取某用户项目个数
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public abstract int GetProjectInfoCountByUser(int userID);

        /// <summary>
        /// 检测某用户是否参与某个项目
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="ProId">项目ID</param>
        /// <returns></returns>
        public abstract bool ProjectWithUser(int UserId, int ProId);
	}
}