
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ProjectInfoSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw lxs
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
    public partial class Vi_ProjectInfoSqlPrivider : Vi_ProjectInfoProvider
	{
        public override int AddProjectFromT3(Vi_ProjectInfoModel Model)
        {
            string commandString = "INSERT INTO [Vi_ProjectInfo] ([I_id],[citemcode],[citemname],[citemccode],[bclose],[CreateTime],[UpdateTime]) values( @I_id, @citemcode, @citemname,@citemccode,@bclose,@CreateTime, @UpdateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@I_id", DbType.Int32, Model.I_id);
            db.AddInParameter(command, "@citemcode", DbType.String, Model.citemcode);
            db.AddInParameter(command, "@citemname", DbType.String, Model.citemname);
            db.AddInParameter(command, "@citemccode", DbType.String, Model.citemccode);
            db.AddInParameter(command, "@bclose", DbType.Int32, Model.bclose);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        public override int UpdateProFromT3(Vi_ProjectInfoModel Model)
        {
            string commandString = "update [Vi_ProjectInfo] set [I_id]=@I_id,[citemcode]=@citemcode,[citemname]=@citemname,[citemccode]=@citemccode,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@I_id", DbType.Int32, Model.I_id);
            db.AddInParameter(command, "@citemcode", DbType.String, Model.citemcode);
            db.AddInParameter(command, "@citemname", DbType.String, Model.citemname);
            db.AddInParameter(command, "@citemccode", DbType.String, Model.citemccode);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 得到所有未分配人员的项目
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public override DataTable getUnallocatedData(int pageNum,int pageSize,int counts,string strWhere)
        {
            string commandString= "SELECT a.[ID],a.[i_id],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                            + " [iotherused],[ContractNumber],[ProjectNatureSysNo],[cCusCode],[cPersonCode],"
                            + " a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                            + " FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                            + " left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 "
                            + strWhere + " and  a.ID  not in   (select distinct ProjectID from (select ProjectID,StaffID from Vi_DeveloperRec "
                            + " union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec "
                            + " union select ProjectID,StaffID from Vi_TesterRec) as c)";
            return GetPageTable(commandString, "", pageNum, pageSize, counts);
        }
        public override DataTable GetPageTable(string sql, string orderField, int pageNumber, int pageSize, int recordCounts)
        {
            return base.GetPageTable(sql, orderField, pageNumber, pageSize, recordCounts);
        }

        public override int getUnallocatedCount(string strWhere)
        {
            string commandString = "SELECT a.[ID],a.[i_id],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                            + " [iotherused],[ContractNumber],[ProjectNatureSysNo],[cCusCode],[cPersonCode],"
                            + " a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                            + " FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                            + " left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 "
                            + strWhere + " and  a.ID  not in   (select distinct ProjectID from (select ProjectID,StaffID from Vi_DeveloperRec "
                            + " union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec "
                            + " union select ProjectID,StaffID from Vi_TesterRec) as c)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            return db.ExecuteDataSet(command).Tables[0].Rows.Count;
        }	
        /// <summary>
        /// 得到某个用户相关的项目信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public override IList<Vi_ProjectInfoModel> GetProjectInfoByUser(int userID)
        {
            IList<Vi_ProjectInfoModel> _Entity = new List<Vi_ProjectInfoModel>();
            string commandString = " SELECT [ID],[I_id],[citemcode],[citemname],[bclose],[citemccode],[iotherused],[ContractNumber],[ProjectNatureSysNo],[cCusCode],[cPersonCode],[UserID],[CreateTime],[UpdateTime],[PrjType],[PrjNature],[DeveloperRec],[TesterRec],[MarketRec] FROM [Vi_ProjectInfo] WHERE ID IN ( "
                            + "select distinct ProjectID from (select ProjectID,StaffID from Vi_DeveloperRec "
                            + "union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec "
                            + "union select ProjectID,StaffID from Vi_TesterRec) as a where StaffID= @userID)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@userID", DbType.Int32, userID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_ProjectInfoEntity_FromDr(dr));
                }
            }
            return _Entity;
        }

        /// <summary>
        /// 获得某个用户的项目个数
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public override int GetProjectInfoCountByUser(int userID)
        {
            string commandString = "select COUNT(id) as Fcount from Vi_ProjectInfo where ID in( "
                + "select distinct ProjectID from (select ProjectID,StaffID from Vi_DeveloperRec "
                + "union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec "
                + "union select ProjectID,StaffID from Vi_TesterRec) as a where StaffID= @userID)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@userID", DbType.Int32, userID);
            return Convert.ToInt32(db.ExecuteScalar(command));
        }
        /// <summary>
        /// 某用户是否参与某个项目
        /// </summary>
        public override bool ProjectWithUser(int userID, int ProId)
        {
            bool result = false;
            string commandString = " select t.ProjectID,t.StaffID from( "
                                 + " select distinct ProjectID,StaffID from Vi_DeveloperRec union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec union select ProjectID,StaffID from Vi_TesterRec "
                                 + ") as t where t.ProjectID = @prjID and t.StaffID = @userID ";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@userID", DbType.Int32, userID);
            db.AddInParameter(command, "@prjID", DbType.Int32, ProId);
            int tmp = Convert.ToInt32(db.ExecuteScalar(command));
            if (tmp > 0) result = true;
            return result;
        }
    }
}
