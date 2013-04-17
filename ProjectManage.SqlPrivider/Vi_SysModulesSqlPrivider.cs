
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysModulesSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using System.Data;
using System.Data.Common;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
	public partial class Vi_SysModulesSqlPrivider : Vi_SysModulesProvider
	{
        /// <summary>
        /// 根据条件语句，获取相关模块编号信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string GetModuleLevel(string sql)
        {
            string result = string.Empty;
            if (sql != null)
            {
                string commandString = sql;
                using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
                {
                    if (dr.Read())
                    {
                        result = ((dr[0]) == DBNull.Value) ? result : Convert.ToString(dr[0]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取树结构头节点
        /// </summary>
        /// <returns></returns>
        public override IList<Vi_SysModulesModel> FirstModuleNodes()
        {
            IList<Vi_SysModulesModel> _Entity = new List<Vi_SysModulesModel>();
            string commandString = "select * from Vi_SysModules where ModuleNum = ''";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysModulesEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 获取树结构叶子节点
        /// </summary>
        /// <param name="moduleNum"></param>
        /// <returns></returns>
        public override IList<Vi_SysModulesModel> ChildModuleNodes(string moduleNum)
        {
            IList<Vi_SysModulesModel> _Entity = new List<Vi_SysModulesModel>();
            string commandString = "select * from Vi_SysModules  where ModuleNum = @moduleNum";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@moduleNum", DbType.String, moduleNum);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysModulesEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到最大节点等级值
        /// </summary>
        /// <returns></returns>
        public override string GetModuleLevelDesc()
        {
            string result = string.Empty;
            string sql = "  select top 1 ModuleLevel from Vi_SysModules where ModuleNum = ''  order by ModuleLevel desc";
            result = GetModuleLevel(sql);
            return result;
        }
        /// <summary>
        /// 得到最大子节点等级值
        /// </summary>
        /// <param name="moduleLevel"></param>
        /// <returns></returns>
        public override string GetModuleLevelNodeDesc(string moduleLevel)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(moduleLevel))
            {
                string sql = "select top 1 ModuleLevel from Vi_SysModules where ModuleNum = '" + moduleLevel + "'  order by ModuleLevel desc";
                result = GetModuleLevel(sql);
            }

            return result;
        }
    }
}
