
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysEmailServerSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
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
	public partial class Vi_SysEmailServerSqlPrivider : Vi_SysEmailServerProvider
	{

        public override int GetEmailServerByUserName(string userName)
        {
            int result = 0;
            string sql = " SELECT Count([ID]) as PCount FROM [Vi_SysEmailServer] where [UserName] = @UserName ";
            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@UserName", System.Data.DbType.String, userName);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    result = ((dr["PCount"]) == DBNull.Value) ? 0 : int.Parse(dr["PCount"].ToString());
                }
            }
            return result;
        }

        public override Vi_SysEmailServerModel FindEmailServerState(int state)
        {
            Vi_SysEmailServerModel _Entity = null;
            string commandString = "SELECT [ID] ,[UserName],[UserPwd],[Port],[EnableSSL],[SMTPHost],[EmailName],[Address],[DisplayName],[State],[UserID],[CreateTime],[UpdateTime] FROM [Vi_SysEmailServer] where State=@State";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "State", DbType.Int32, state);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysEmailServerEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
    }
}
