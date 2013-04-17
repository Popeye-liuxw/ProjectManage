using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using System.Data;

/*
 * =================================================================== 
 * 项目说明 
 * ====================================================================
 * visione @ CopyRight 2007-2012
 * File Name： CustomerBll.cs
 * Project Name：ProjectManageSystem 
 * Create Time：2012/9/12 10:19:26
 * Code By：lxs
 * ===================================================================
 */

namespace ProjectManage.BLL
{
    public class CustomerBll
    {
        /// <summary>
        /// 得到所有客户信息
        /// </summary>
        /// <returns></returns>
        public IList<CustomerModel> getAllCostomer()
        {
            CustomerProvider cp = DataFactory.CreateCustomerSqlPrivider();
            return cp.GetCustomerAll();
        }
    }
}
