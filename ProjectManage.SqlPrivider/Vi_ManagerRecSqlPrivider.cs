
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ManagerRecSqlPrivider.cs
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
using System.Data.Common;
using System.Data;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
    public partial class Vi_ManagerRecSqlPrivider : Vi_ManagerRecProvider
	{
        /// <summary>
        /// 获取项目经理实体
        /// </summary>
        /// <param name="prjID">项目ID</param>
        /// <returns></returns>
        public override Vi_ManagerRecModel Get_Vi_ManagerRecModelByPrjID(int prjID)
        {
            Vi_ManagerRecModel _Entity = null;
            string commandString = "select * from Vi_ManagerRec where ProjectID=@ProjectID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ProjectID", DbType.Int32, prjID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_ManagerRecEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
    }
}
