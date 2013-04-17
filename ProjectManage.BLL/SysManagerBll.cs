using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using ProjectManage.Provider;
using System.Data;

/*
 * =================================================================== 
 * 项目说明 系统管理 BLL
 * ====================================================================
 * visione @ CopyRight 2007-2012
 * File Name： SysManagerBll.cs
 * Project Name：ProjectManageSystem 
 * Create Time：2012/9/19 14:26:27
 * Code By：lxs
 * ===================================================================
 */

namespace ProjectManage.BLL
{
    public class SysManagerBll
    {
        /// <summary>
        /// 根据用户名得到用户实体类信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public Vi_SysBackUserModel getManagerUserInfo(string UserName)
        {
            Vi_SysBackUserProvider visbup = DataFactory.CreateVi_SysBackUserSqlPrivider();
            return visbup.getModelByManagerName(UserName);
        }
        /// <summary>
        /// 向 数据库中插入管理员登录日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertManagerLog(Vi_SysLogModel model)
        {
            bool result = false;
            Vi_SysLogProvider vilsp = DataFactory.CreateVi_SysLogSqlPrivider();
            if (vilsp.SaveVi_SysLog(model) > 0)
            {
                result = true;
            }
            return result;
        }
        //得到给用户的所有日志
        public List<Vi_SysLogModel> getAllLogsByUID(int UserId,int limit)
        {
            Vi_SysLogProvider vilsp = DataFactory.CreateVi_SysLogSqlPrivider();
            return vilsp.getAllLogByUserId(UserId,limit).ToList();
        }

        //
        public Vi_SysLogModel getLastLogInfo(int UserId, int limit)
        {
            Vi_SysLogProvider vislp = DataFactory.CreateVi_SysLogSqlPrivider();
            return vislp.getLastLogInfo(UserId, limit);
        }

        //得到登录用户日志总数
        public int getLogsCountByUserId(int UserId, int limit)
        {
            Vi_SysLogProvider vislp = DataFactory.CreateVi_SysLogSqlPrivider();

            return vislp.GetSqlCount("select  * from Vi_SysLog where UserID =" + UserId + " and SysType = " + limit );
        }
        //得到分页数据
        public DataTable getPagerLogsInfoByUserId(int UserId,int limit,int pageNum,int pageSize,int Counts)
        {
            Vi_SysLogProvider vislp = DataFactory.CreateVi_SysLogSqlPrivider();
            return vislp.GetPageTable("select  * from Vi_SysLog where UserID =" + UserId + " and SysType = " + limit , "CreateTime", pageNum, pageSize, Counts);
        }
        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="vsbum"></param>
        /// <returns></returns>
        public bool UpdateManagerInfo(Vi_SysBackUserModel vsbum)
        {
            bool result = false;
            Vi_SysBackUserProvider visbup = DataFactory.CreateVi_SysBackUserSqlPrivider();
            if (visbup.UpdateVi_SysBackUser(vsbum) > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 添加一个管理员
        /// </summary>
        /// <param name="vsbum"></param>
        /// <returns></returns>
        public bool InsertSingleManager(Vi_SysBackUserModel vsbum)
        {
            bool result = false;
            Vi_SysBackUserProvider visbup = DataFactory.CreateVi_SysBackUserSqlPrivider();
            if (visbup.SaveVi_SysBackUser(vsbum) > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 根据用户ID删除一条用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DelSingleManager(int ID)
        {
            bool result = false;
            Vi_SysBackUserProvider visbup = DataFactory.CreateVi_SysBackUserSqlPrivider();
            if (visbup.DeleteVi_SysBackUser(ID) > 0)
            {
                result = true;
            }
            return result;
        }
        public Vi_SysBackUserModel getModelByManagerID(int ID)
        {
            Vi_SysBackUserProvider visbup = DataFactory.CreateVi_SysBackUserSqlPrivider();
            return visbup.Get_Vi_SysBackUserModel(ID);
        }

    }
}
