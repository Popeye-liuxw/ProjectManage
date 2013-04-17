using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： DataTiersProvider.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/3 14:42:42
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Provider
{
    public abstract partial class DataTiersProvider
    {
        /// <summary>
        /// 通过T-SQL语句得到一个数据表格
        /// </summary>
        /// <param name="sql">T-SQL语句</param>
        /// <returns>System.Data.DataTable类型实例</returns>
        public virtual DataTable GetDataTable(string sql)
        {            
            DataTable dt = new DataTable();
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        /// <summary>
        /// 通过T-SQL语句得到总数据条数，语句要求是一个数据数据集合的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual int GetSqlCount(string sql)
        {
            int result = 0;
            DataSet ds = db.ExecuteDataSet(CommandType.Text, AssemblyRecordCountsSql(sql));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result = Convert.ToInt32(ds.Tables[0].Rows[0]["Counts"]);
            }
            return result;
        }
        /// <summary>
        /// 得到一个分页处理后的数据表格
        /// </summary>
        /// <param name="sql">原查询语句</param>
        /// <param name="orderField">用于分页排序的字段,该处不可以定义排序方式，只是字段名称</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页面数量</param>
        /// <param name="recordCounts">记录总数</param>        
        /// <returns>System.Data.DataTable类型实例</returns>
        public virtual DataTable GetPageTable(string sql, string orderField, int pageNumber, int pageSize, int recordCounts)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(orderField)) orderField = "ID";
            int PageCounts = 0;
            DataSet ds = db.ExecuteDataSet(CommandType.Text, AssemblyPagingSql(sql, orderField, pageNumber, pageSize, recordCounts, out PageCounts));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        /// <summary>
        /// 生成取得记录总数的语句
        /// </summary>
        /// <param name="sql">原查询语句</param>
        /// <returns>取得记录总数的语句</returns>
        private string AssemblyRecordCountsSql(string sql)
        {
            string sqlGetRecordCounts = "select Count(*) as Counts from (" + sql + ") as TempTable";
            return sqlGetRecordCounts;
        }
        /// <summary>
        /// 生成分页查询语句
        /// </summary>
        /// <param name="sql">原查询语句</param>
        /// <param name="orderField">用于分页排序的字段</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页面记录数量</param>
        /// <param name="recordCounts">记录总数</param>
        /// <param name="pageCounts">页面总数</param>
        /// <returns>分页查询语句</returns>
        private string AssemblyPagingSql(string sql, string orderField, int pageNumber, int pageSize, int recordCounts, out int pageCounts)
        {
            // 计算页面数量
            if (Convert.ToInt32(pageNumber) < 1) pageNumber = 1;
            if (Convert.ToInt32(pageSize) < 1) pageSize = 1;
            pageCounts = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordCounts) / Convert.ToDouble(pageSize)));
            string sqlQuery = "";
            if (pageNumber == 1)
            {
                sqlQuery = "select top " + pageSize + " * from (" + sql + ") as TempTable order by " + orderField + " desc";
            }
            else
            {
                sqlQuery = "select top " + pageSize + " * from (" + sql + ") as TempTable where " + orderField + " < (select min(" + orderField + ") as MinID from ( select top " + (pageNumber - 1) * pageSize + "     * from (" + sql + ") as MaxTempTable order by " + orderField + " desc) as MinTempTable) order by " + orderField + " desc";
            }
            return sqlQuery;
        }
    }
}
