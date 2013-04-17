
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysTypeSqlPrivider.cs
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
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
    public partial class Vi_SysTypeSqlPrivider : Vi_SysTypeProvider
	{
        /// <summary>
        /// 根据类型等级，或许相应集合
        /// </summary>
        /// <param name="level">类型等级</param>
        /// <returns></returns>
        public override IList<Vi_SysTypeModel> GetVi_SysTypeByLevel(int level)
        {
            IList<Vi_SysTypeModel> _Entity = new List<Vi_SysTypeModel>();
            string commandString = "select * from Vi_SysType where level = " + level;

            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysTypeEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 根据大类类型值，获取相应小类集合
        /// </summary>
        /// <param name="bigType">大类类型值</param>
        /// <returns></returns>
        public override IList<Vi_SysTypeModel> GetVi_SysTypeByTypeValue(int bigType,int level)
        {
            IList<Vi_SysTypeModel> _Entity = new List<Vi_SysTypeModel>();
            string commandString = "select * from Vi_SysType where BigValue = " + bigType + " and level = " + level;

            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysTypeEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 获取最大类型值
        /// </summary>
        /// <returns></returns>
        public override int GetMaxTypeValue()
        {
            int result = 0;
            string commandString = "select  Max([BigValue]) as MaxValue from Vi_SysType";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                if (dr.Read())
                {
                    result = ((dr["MaxValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["MaxValue"]);
                }
            }
            return result;
        }
        /// <summary>
        /// 检测是否存在小类型值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool ExistsItemTypeValue(int value, int typeValue, int level)
        {
            bool result = false;

            string commandString = "select  TypeValue  from Vi_SysType where TypeValue = " + value + " and BigValue = " + typeValue + " and [level] = " + level;
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                if (dr.Read())
                {
                    result = ((dr["TypeValue"]) == DBNull.Value) ? false : true;
                }
            }

            return result;
        }
    }
}
