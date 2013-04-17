using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： SystemLegalPowerBll.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/15 17:17:23
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 系统权限，针对每一个页面
    /// </summary>
    public static class SystemLegalPowerBll
    {        
        /// <summary>
        /// 得到某用户针对某模块的使用权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="moduleID">模块ID</param>
        /// <returns>SystemPermission 系统权限枚举对象</returns>
        public static SystemPermission GetSystemPermission(int userID, int moduleID)
        {
            SystemPermission permission = SystemPermission.Other;
            SysPositionManage manage = new SysPositionManage();
            PermissionModel model = manage.GetPermissionModelByModuleIDAndUserID(moduleID, userID);
            permission = manage.GetPermission(model);
            return permission;
        }
    }
}
