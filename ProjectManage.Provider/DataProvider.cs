using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： DataProvider.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/3 15:14:09
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Provider
{
    /// <summary>
    /// 数据访问，基本功能
    /// </summary>
    public abstract class DataProvider
    {
        public abstract System.Data.DataTable GetDataTable(string sql);

        public abstract System.Data.DataTable GetPageTable(string sql, string orderField, int pageNumber, int pageSize);

        public abstract int GetSqlCount(string sql);
    }
}
