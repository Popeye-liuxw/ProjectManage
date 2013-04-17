
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiPermSqlPrivider.cs
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
	public partial class Vi_SysPosiPermSqlPrivider : Vi_SysPosiPermProvider
	{

        public override IList<Vi_SysPosiPermModel> GetPosiPermByPosiInfo(int posiID)
        {
            IList<Vi_SysPosiPermModel> _Entity = new List<Vi_SysPosiPermModel>();
            string Sql = "SELECT [ID] ,[PosiID],[PosiName],[SysModuleID],[Permissions],[UserID],[CreateTime],[UpdateTime] FROM [Vi_SysPosiPerm] where [PosiID] = @posiID";
            DbCommand command = db.GetSqlStringCommand(Sql);
            db.AddInParameter(command, "@posiID", System.Data.DbType.Int32, posiID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysPosiPermEntity_FromDr(dr));
                }
            }

            return _Entity;

        }

        public override IList<Vi_SysPosiPermModel> GetPosiPermByModules(int sysModuleID,int userID)
        {
            IList<Vi_SysPosiPermModel> Entitys = new List<Vi_SysPosiPermModel>();
            string Sql = "SELECT p.[ID] ,p.[PosiID],p.[PosiName],p.[SysModuleID],p.[Permissions],p.[UserID],p.[CreateTime],p.[UpdateTime] from Vi_SysPosiPerm as p join Vi_SysUserRole as r on p.PosiID = r.PosiID and r.UserID = @UserID and p.SysModuleID = @SysModuleID";

            DbCommand command = db.GetSqlStringCommand(Sql);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, sysModuleID);
            db.AddInParameter(command, "@UserID", DbType.Int32, userID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Entitys.Add(Populate_Vi_SysPosiPermEntity_FromDr(dr));
                }
            }
            return Entitys;
        }

        public override bool Exists(int PosiID, int SysModuleID)
        {
            bool result = false;
            string sql = " SELECT Count([ID]) as PCount FROM [Vi_SysPosiPerm] where [PosiID] = @PosiID and [SysModuleID] = @SysModuleID ";

            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@PosiID", DbType.Int32, PosiID);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, SysModuleID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                if(dr.Read())
                {
                    int count = ((dr["PCount"]) == DBNull.Value) ? 0 : int.Parse(dr["PCount"].ToString());

                    if (count > 0) result = true;
                }
            }

            return result;
        }

        public override Vi_SysPosiPermModel Get_Vi_SysPosiPermModel(int PosiID, int SysModuleID)
        {
            Vi_SysPosiPermModel _Entity = null;
            string commandString = "select * from Vi_SysPosiPerm where [PosiID] = @PosiID and [SysModuleID] = @SysModuleID ";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@PosiID", DbType.Int32, PosiID);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, SysModuleID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysPosiPermEntity_FromDr(dr);
                }
            }
            return _Entity;
        }

        public override int UpdateVi_SysPosiPerm(int PosiID, int SysModuleID, int Permissions)
        {
            string commandString = "update [Vi_SysPosiPerm] set [Permissions]=@Permissions,[UpdateTime]=@UpdateTime where [PosiID]=@PosiID and [SysModuleID]=@SysModuleID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@PosiID", DbType.Int32, PosiID);
            //db.AddInParameter(command, "@PosiName", DbType.String, Model.PosiName);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, SysModuleID);
            db.AddInParameter(command, "@Permissions", DbType.Int32, Permissions);
            //db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            //db.AddInParameter(command,"@CreateTime",DbType.DateTime,Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, DateTime.Now);
            return db.ExecuteNonQuery(command);
        }

        public override int ExistsPosiPermByModules(int sysModuleID, int posiID)
        {
            int result = 0;
            string sql = " SELECT Count([ID]) as PCount FROM [Vi_SysPosiPerm] where [PosiID] = @PosiID and [SysModuleID] = @SysModuleID ";
            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, sysModuleID);
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

        public override int GetPermissions(int sysModuleID, int posiID)
        {
            int result = 0;
            string sql = " SELECT [Permissions] FROM [Vi_SysPosiPerm] where [PosiID] = @PosiID and [SysModuleID] = @SysModuleID ";
            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@SysModuleID", DbType.Int32, sysModuleID);
            db.AddInParameter(command, "@PosiID", System.Data.DbType.Int32, posiID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    result = ((dr["Permissions"]) == DBNull.Value) ? 0 : int.Parse(dr["Permissions"].ToString());
                }
            }
            return result;
        }
    }
}
