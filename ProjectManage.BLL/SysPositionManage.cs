using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using ProjectManage.Provider;

// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： SysPositionManage.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/15
// 负责人：Popeye_lxw
// ===================================================================
namespace ProjectManage.BLL
{
    /// <summary>
    /// 职位权限管理
    /// </summary>
    public class SysPositionManage
    {
        private Vi_SysPosiPermProvider _PosiSql;

        public SysPositionManage()
        {
            this._PosiSql = DataFactory.CreateVi_SysPosiPermSqlPrivider();
        }
        /// <summary>
        /// 得到所有模块信息
        /// </summary>
        /// <returns></returns>
        public List<Vi_SysModulesModel> GetSysModuleAll()
        {
            List<Vi_SysModulesModel> modules = new List<Vi_SysModulesModel>();
            Vi_SysModulesProvider moduleSql = DataFactory.CreateVi_SysModulesSqlPrivider();
            if (moduleSql != null)
            {
                modules = moduleSql.GetVi_SysModulesAll().ToList();
            }
            return modules;
        }


        /// <summary>
        /// 得到所有职位权限信息
        /// </summary>
        /// <returns></returns>
        public List<Vi_SysPosiPermModel> GetSysPosiPermAll()
        {
            List<Vi_SysPosiPermModel> PosiPerm = new List<Vi_SysPosiPermModel>();
            if (_PosiSql != null)
            {
                PosiPerm = _PosiSql.GetVi_SysPosiPermAll().ToList();
            }
            return PosiPerm;
        }
        /// <summary>
        /// 根据职位获取相关权限信息
        /// </summary>
        /// <param name="posiID"></param>
        /// <returns></returns>
        public List<Vi_SysPosiPermModel> GetPosiPermByPosiInfo(int posiID)
        {
            List<Vi_SysPosiPermModel> PosiPerm = new List<Vi_SysPosiPermModel>();
            if (_PosiSql != null)
            {
                PosiPerm = _PosiSql.GetPosiPermByPosiInfo(posiID).ToList();
            }
            return PosiPerm;
        }
        /// <summary>
        /// 根据功能模块ID及人员ID获取相关权限
        /// </summary>
        /// <param name="sysModuleID"></param>
        /// <returns></returns>
        private List<Vi_SysPosiPermModel> GetPosiPermBySysModuleID(int sysModuleID,int userID)
        {
            List<Vi_SysPosiPermModel> posiperm = new List<Vi_SysPosiPermModel>();

            if (_PosiSql != null)
            {
                posiperm = _PosiSql.GetPosiPermByModules(sysModuleID, userID).ToList();
            }

            return posiperm;
        }
        
        /// <summary>
        /// 检测功能模块权限是否设定
        /// </summary>
        /// <param name="sysModuleID"></param>
        /// <param name="posiID"></param>
        /// <returns></returns>
        public bool ExistsPosiPermBySysModuleID(int sysModuleID , int posiID)
        {
            bool result = false;
            int count = 0;

            count = _PosiSql.ExistsPosiPermByModules(sysModuleID, posiID);

            if (count > 0) result = true;

            return result;
        }

        /// <summary>
        ///  将数据值转换成系统权限
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        private SystemPermission ConvertPermission(int permissions)
        {
            SystemPermission p = SystemPermission.Other;

            if (permissions == 10) p = SystemPermission.Read;

            if (permissions == 20) p = SystemPermission.Write;

            return p;
        }
        /// <summary>
        /// 将系统权限转换成数据值
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private int ConvertPermissions(SystemPermission permission)
        {
            int permissions = 0;
            switch (permission)
            {
                case SystemPermission.Other:
                    permissions = 0;
                    break;
                case SystemPermission.Read:
                    permissions = 10;
                    break;
                case SystemPermission.Write:
                    permissions = 20;
                    break;
            }
            return permissions;
        }

        /// <summary>
        /// 将系统权限转换成权限对象
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private PermissionModel ConvertPermissionsBySys(SystemPermission permission)
        {
            PermissionModel model = new PermissionModel();
            switch (permission)
            {
                case SystemPermission.Other:
                    break;
                case SystemPermission.Read:
                    model.Read = true;
                    break;
                case SystemPermission.Write:
                    model.Write = true;                    
                    break;
                default:
                    break;
            }
            return model;
        }

        /// <summary>
        /// 保存权限信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SavePermission(Vi_SysPosiPermModel model)
        {
            bool result = false;
            if (_PosiSql.SaveVi_SysPosiPerm(model) > 0) result = true;
            return result;
        }

        /// <summary>
        /// 保存权限信息
        /// </summary>
        /// <param name="posiPerms"></param>
        /// <returns></returns>
        public bool SavePermission(List<PermissionMuster> PermissionMuster)
        {
            bool result = false;
            try
            {
                if (PermissionMuster != null)
                {
                    foreach (PermissionMuster item in PermissionMuster)
                    {
                        if (_PosiSql.Exists(item.PosiID, item.SysModuleID))
                        {
                            if (item.PosiPermModel != null)
                            {
                                _PosiSql.UpdateVi_SysPosiPerm(item.PosiID, item.SysModuleID, item.PosiPermModel.Permissions);
                            }
                        }
                        else
                            SavePermission(item.PosiPermModel);
                    }
                    result = true;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        /// <summary>
        /// 根据权限对象，获取系统权限表示形式
        /// </summary>
        /// <param name="permission">权限对象</param>
        /// <returns></returns>
        public SystemPermission GetPermission(PermissionModel permission)
        {
            SystemPermission p = SystemPermission.Other;

            if (permission.Read && permission.Write)
            {
                p = SystemPermission.Write;
            }
            else if (permission.Read)
            {
                p = SystemPermission.Read;
            }
            else if (permission.Write)
            {
                p = SystemPermission.Write;
            }

            return p;
        }


        /// <summary>
        /// 获取系统权限对象
        /// </summary>
        /// <param name="moduleID">模块ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public PermissionModel GetPermissionModelByModuleIDAndUserID(int moduleID, int userID)
        {
            PermissionModel result = new PermissionModel();
            if (moduleID > 0 && userID > 0)
            {
                List<Vi_SysPosiPermModel> PosiPerms = GetPosiPermBySysModuleID(moduleID, userID);
                foreach (Vi_SysPosiPermModel item in PosiPerms)
                {
                    SystemPermission sysPermission = ConvertPermission(item.Permissions);
                    if (sysPermission == SystemPermission.Read) result.Read = true;
                    if (sysPermission == SystemPermission.Write) result.Write = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据权限对象，获取真实权限编号
        /// </summary>
        /// <param name="permission">权限对象</param>
        /// <returns></returns>
        public int GetPermissionByModel(PermissionModel permission)
        {
            int result = 0;

            SystemPermission p = SystemPermission.Other;
            if (permission.Read && permission.Write)
            {
                p = SystemPermission.Write;
            }
            else if (permission.Read)
            {
                p = SystemPermission.Read;
            }
            else if (permission.Write)
            {
                p = SystemPermission.Write;
            }

            result = ConvertPermissions(p);

            return result;
        }
        /// <summary>
        /// 根据职位ID和模块ID获取权限对象
        /// </summary>
        /// <param name="posiID">职位ID</param>
        /// <param name="SysModuleID">权限ID</param>
        /// <returns></returns>
        public PermissionModel GetPermissionModel(int posiID, int SysModuleID)
        {
            PermissionModel result = new PermissionModel();
            if (posiID > 0 && SysModuleID > 0)
            {
                SystemPermission permission = ConvertPermission(_PosiSql.GetPermissions(SysModuleID, posiID));
                result = ConvertPermissionsBySys(permission);
            }
            return result;
        }
    }
    
}
