
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiPermProvider.cs
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
    public  abstract partial class Vi_SysPosiPermProvider
    {
        /// <summary>
        /// 根据职位ID获取相关权限
        /// </summary>
        /// <param name="posiID">职位ID</param>
        /// <returns></returns>
        public abstract IList<Vi_SysPosiPermModel> GetPosiPermByPosiInfo(int posiID);

        /// <summary>
        /// 根据功能模块获取相关权限
        /// </summary>
        /// <param name="sysModuleID">模块ID</param>
        /// <returns></returns>
        public abstract IList<Vi_SysPosiPermModel> GetPosiPermByModules(int sysModuleID,int userID);


        /// <summary>
        /// 检测该功能模块设定权限个数
        /// </summary>
        /// <param name="sysModuleID">模块ID</param>
        /// <param name="posiID">职位ID</param>
        /// <returns></returns>
        public abstract int ExistsPosiPermByModules(int sysModuleID, int posiID);

        /// <summary>
        /// 得到系统权限编号
        /// </summary>
        /// <param name="sysModuleID">模块ID</param>
        /// <param name="posiID">职位ID</param>
        /// <returns></returns>
        public abstract int GetPermissions(int sysModuleID, int posiID);

        /// <summary>
        /// 检测是否存在该权限
        /// </summary>
        /// <param name="PosiID">职位编号</param>
        /// <param name="SysModuleID">功能模块ID</param>
        /// <returns></returns>
        public abstract bool Exists(int PosiID, int SysModuleID);

        /// <summary>
        /// 根据职位编号和功能模块ID,返回一个Vi_SysPosiPerm对象
        /// </summary>
        /// <param name="id">Vi_SysPosiPerm ID</param>
        /// <returns>Vi_SysPosiPerm对象</returns>
        public abstract Vi_SysPosiPermModel Get_Vi_SysPosiPermModel(int PosiID, int SysModuleID);

        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public abstract int UpdateVi_SysPosiPerm(int PosiID, int SysModuleID, int Permissions);
        
	}
}