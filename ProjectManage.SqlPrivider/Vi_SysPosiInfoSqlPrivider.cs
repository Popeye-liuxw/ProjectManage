
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiInfoSqlPrivider.cs
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
	public partial class Vi_SysPosiInfoSqlPrivider:Vi_SysPosiInfoProvider
	{

        public override int ExistsSysPosiPermByPosiID(int posiID)
        {
            int result = 0;
            string sql = " SELECT Count([ID]) as PCount FROM [Vi_SysPosiPerm] where [PosiID] = @PosiID ";
            DbCommand command = db.GetSqlStringCommand(sql);            
            db.AddInParameter(command, "@PosiID", System.Data.DbType.Int32, posiID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    result = ((dr["PCount"]) == DBNull.Value) ? 0 : int.Parse(dr["PCount"].ToString());
                }
            }
            return result;
        }
    }
}
