
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserRoleSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/15
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
	public partial class Vi_SysUserRoleSqlPrivider:Vi_SysUserRoleProvider
	{
        /// <summary>
        /// 根据用户ID得到当前用户的角色 也就是职位
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public override IList<Vi_SysUserRoleModel> GetUserRolesByUserId(int UserID)
        {
            IList<Vi_SysUserRoleModel> _Entity = new List<Vi_SysUserRoleModel>();
            string commandString = "SELECT a.[ID],[UserID],[PosiID],[PosiName],a.[Back],a.[Back2],a.[CreateTime] from [Vi_SysUserRole] a join Vi_SysPosiInfo b on a.PosiID = b.ID WHERE a.UserID=@UserID";

            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@UserID", System.Data.DbType.Int32, UserID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysUserRoleEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        public override int IsExistPosiByUserIDAndRoleId(int UserId,int PosiId)
        {
            IList<Vi_SysUserRoleModel> _Entity = new List<Vi_SysUserRoleModel>();
            string commandString = "SELECT a.[ID],[UserID],[PosiID],[PosiName],a.[Back],a.[Back2],a.[CreateTime] from [Vi_SysUserRole] a join Vi_SysPosiInfo b on a.PosiID = b.ID WHERE a.PosiID=@PosiID and a.UserId = @UserId";

            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@PosiID", System.Data.DbType.Int32, PosiId);
            db.AddInParameter(command, "@UserID", System.Data.DbType.Int32, UserId);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysUserRoleEntity_FromDr(dr));
                }
            }
            return _Entity.Count;
        }
	}
}
