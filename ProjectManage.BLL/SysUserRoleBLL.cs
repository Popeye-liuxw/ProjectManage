using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.Provider;

/*
 * =================================================================== 
 * 项目说明 
 * ====================================================================
 * visione @ CopyRight 2007-2012
 * File Name： SysUserRoleBLL.cs
 * Project Name：ProjectManageSystem 
 * Create Time：2012/8/29 18:09:03
 * Code By：lxs
 * ===================================================================
 */

namespace ProjectManage.BLL
{
    public class SysUserRoleBLL
    {
        public List<Vi_SysUserRoleModel> getUserRolesByUserID(int UserID)
        {
            Vi_SysUserRoleProvider surl = DataFactory.CreateVi_SysUserRoleSqlPrivider();
            return surl.GetUserRolesByUserId(UserID).ToList();
        }
        //向 数据库增加一条角色信息
        public int AddUserRole(Vi_SysUserRoleModel viurm)
        {
            Vi_SysUserRoleProvider surl = DataFactory.CreateVi_SysUserRoleSqlPrivider();
            return surl.SaveVi_SysUserRole(viurm);
        }
        public int DelRolebyId(int UserId,int PosiId)
        {
            Vi_SysUserRoleProvider surl = DataFactory.CreateVi_SysUserRoleSqlPrivider();
            return surl.DeleteVi_SysUserRole(UserId, PosiId);
        }
        public int IsExistRoleByUserIDAndPosiId(int UserId, int PosiId)
        {
            Vi_SysUserRoleProvider surl = DataFactory.CreateVi_SysUserRoleSqlPrivider();
            return surl.IsExistPosiByUserIDAndRoleId(UserId, PosiId);
        }
    }
}
