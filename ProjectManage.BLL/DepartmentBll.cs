using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Provider;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;

/*
 * =================================================================== 
 * 项目说明 
 * ====================================================================
 * visione @ CopyRight 2007-2012
 * File Name： DepartmentBll.cs
 * Project Name：ProjectManageSystem 
 * Create Time：2012/8/29 14:35:03
 * Code By：lxs
 * ===================================================================
 */

namespace ProjectManage.BLL
{
    public class DepartmentBll
    {
        public List<DepartmentModel> getAllDepartment()
        {
            DepartmentProvider departModelList = DataFactory.CreateDepartmentSqlPrivider();
            return departModelList.GetDepartmentAll().ToList();
        }
    }
}
