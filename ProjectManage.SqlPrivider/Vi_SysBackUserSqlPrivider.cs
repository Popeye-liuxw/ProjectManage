
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysBackUserSqlPrivider.cs
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
	public partial class Vi_SysBackUserSqlPrivider
	{
        /// <summary>
        /// 根据用户名得到用户实体信息
        /// </summary>
        /// <param name="mName"></param>
        /// <returns></returns>
        public override Vi_SysBackUserModel getModelByManagerName(string mName)
        {
            Vi_SysBackUserModel _Entity = null;
            string commandString = "select * from Vi_SysBackUser where UserName=@nName";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@nName", DbType.String,mName);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysBackUserEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
	}
}
