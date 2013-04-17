using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： PrjChangePaperBLL.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/12 10:37:41
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 需求变更
    /// </summary>
    public class PrjChangePaperBLL
    {
        private Vi_PrjChangePaperProvider changeSql;

        public PrjChangePaperBLL()
        {
            changeSql = DataFactory.CreateVi_PrjChangePaperSqlPrivider();
        }

        public bool SaveChagePaper(Vi_PrjChangePaperModel model)
        {
            bool result = false;
            if (model != null)
            {
                int tmp = changeSql.SaveVi_PrjChangePaper(model);
                if (tmp > 0) result = true;
            }
            return result;
        }
    }
}
