using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： PermissionMuster.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/29 20:04:33
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Model
{
    public class PermissionMuster
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        public int PosiID { get; set; }

        /// <summary>
        /// 功能模块ID
        /// </summary>
        public int SysModuleID { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public int PermissionID { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 权限对象
        /// </summary>
        public PermissionModel  Permissions{ get; set; }

        /// <summary>
        /// 权限实体对象
        /// </summary>
        public Vi_SysPosiPermModel PosiPermModel { get; set; }

    }
}
