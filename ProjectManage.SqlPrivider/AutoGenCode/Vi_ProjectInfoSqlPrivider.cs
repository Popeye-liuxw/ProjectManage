
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ProjectInfoSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/24
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using ProjectManage.Model;
using ProjectManage.Provider;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
	public partial class Vi_ProjectInfoSqlPrivider:Vi_ProjectInfoProvider
	{
        #region Vi_ProjectInfo

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>返回实体ID</returns>
        public override int SaveVi_ProjectInfo(Vi_ProjectInfoModel Model)
        {            
            Model.CreateTime = DateTime.Now;
            string commandString = "INSERT INTO [Vi_ProjectInfo] ([I_id],[citemcode],[citemname],[bclose],[citemccode],[iotherused],[ContractNumber],[ProjectNatureSysNo],[cCusCode],[cPersonCode],[UserID],[CreateTime],[PrjType],[PrjNature],[DeveloperRec],[TesterRec],[MarketRec]) values( @I_id, @citemcode, @citemname, @bclose, @citemccode, @iotherused, @ContractNumber, @ProjectNatureSysNo, @cCusCode, @cPersonCode, @UserID, @CreateTime, @PrjType, @PrjNature, @DeveloperRec, @TesterRec, @MarketRec) SELECT @@IDENTITY AS [id]";
            DbCommand command = db.GetSqlStringCommand(commandString);                                                                                                                                                                                                                                                                                                                                                                                                     
            //db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);                                                                                                                                                                                                                                                                                                                                                                                                  
            db.AddInParameter(command, "@I_id", DbType.Int32, Model.I_id);
            db.AddInParameter(command, "@citemcode", DbType.String, Model.citemcode);
            db.AddInParameter(command, "@citemname", DbType.String, Model.citemname);
            db.AddInParameter(command, "@bclose", DbType.Int32, Model.bclose);
            db.AddInParameter(command, "@citemccode", DbType.String, Model.citemccode);
            db.AddInParameter(command, "@iotherused", DbType.Int32, Model.iotherused);
            db.AddInParameter(command, "@ContractNumber", DbType.String, Model.ContractNumber);
            db.AddInParameter(command, "@ProjectNatureSysNo", DbType.Int32, Model.ProjectNatureSysNo);
            db.AddInParameter(command, "@cCusCode", DbType.String, Model.cCusCode);
            db.AddInParameter(command, "@cPersonCode", DbType.String, Model.cPersonCode);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            db.AddInParameter(command, "@PrjType", DbType.Int32, Model.PrjType);
            db.AddInParameter(command, "@PrjNature", DbType.Int32, Model.PrjNature);
            db.AddInParameter(command, "@DeveloperRec", DbType.Int32, Model.DeveloperRec);
            db.AddInParameter(command, "@TesterRec", DbType.Int32, Model.TesterRec);
            db.AddInParameter(command, "@MarketRec", DbType.Int32, Model.MarketRec);
            return Convert.ToInt32(db.ExecuteScalar(command));
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_ProjectInfo(Vi_ProjectInfoModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_ProjectInfo] set [I_id]=@I_id,[citemcode]=@citemcode,[citemname]=@citemname,[bclose]=@bclose,[citemccode]=@citemccode,[iotherused]=@iotherused,[ContractNumber]=@ContractNumber,[ProjectNatureSysNo]=@ProjectNatureSysNo,[cCusCode]=@cCusCode,[cPersonCode]=@cPersonCode,[UserID]=@UserID,[UpdateTime]=@UpdateTime,[PrjType]=@PrjType,[PrjNature]=@PrjNature,[DeveloperRec]=@DeveloperRec,[TesterRec]=@TesterRec,[MarketRec]=@MarketRec where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@I_id", DbType.Int32, Model.I_id);
            db.AddInParameter(command, "@citemcode", DbType.String, Model.citemcode);
            db.AddInParameter(command, "@citemname", DbType.String, Model.citemname);
            db.AddInParameter(command, "@bclose", DbType.Int32, Model.bclose);
            db.AddInParameter(command, "@citemccode", DbType.String, Model.citemccode);
            db.AddInParameter(command, "@iotherused", DbType.Int32, Model.iotherused);
            db.AddInParameter(command, "@ContractNumber", DbType.String, Model.ContractNumber);
            db.AddInParameter(command, "@ProjectNatureSysNo", DbType.Int32, Model.ProjectNatureSysNo);
            db.AddInParameter(command, "@cCusCode", DbType.String, Model.cCusCode);
            db.AddInParameter(command, "@cPersonCode", DbType.String, Model.cPersonCode);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            //db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            db.AddInParameter(command, "@PrjType", DbType.Int32, Model.PrjType);
            db.AddInParameter(command, "@PrjNature", DbType.Int32, Model.PrjNature);
            db.AddInParameter(command, "@DeveloperRec", DbType.Int32, Model.DeveloperRec);
            db.AddInParameter(command, "@TesterRec", DbType.Int32, Model.TesterRec);
            db.AddInParameter(command, "@MarketRec", DbType.Int32, Model.MarketRec);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///删除数据库一条数据
        ///</summary>
        /// <param name="ID">ID</param>
        /// <returns>影响的条数</returns>
        public override int DeleteVi_ProjectInfo(int ID)
        {
            string commandString = "delete from Vi_ProjectInfo where dbo.Vi_ProjectInfo.ID=@dbo.Vi_ProjectInfo.ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_ProjectInfo.ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_ProjectInfo返回的查询dateset创建一个Vi_ProjectInfo对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_ProjectInfo对象</returns>
        private Vi_ProjectInfoModel Populate_Vi_ProjectInfoEntity_FromDr(DataSet ds)
        {
            Vi_ProjectInfoModel nObject = new Vi_ProjectInfoModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.I_id = ((ds.Tables[0].Rows[0]["I_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["I_id"]);
                nObject.citemcode = ds.Tables[0].Rows[0]["citemcode"].ToString();
                nObject.citemname = ds.Tables[0].Rows[0]["citemname"].ToString();
                nObject.bclose = (int)ds.Tables[0].Rows[0]["bclose"];
                nObject.citemccode = ds.Tables[0].Rows[0]["citemccode"].ToString();
                nObject.iotherused = ((ds.Tables[0].Rows[0]["iotherused"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["iotherused"]);
                nObject.ContractNumber = ds.Tables[0].Rows[0]["ContractNumber"].ToString();
                nObject.ProjectNatureSysNo = ((ds.Tables[0].Rows[0]["ProjectNatureSysNo"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectNatureSysNo"]);
                nObject.cCusCode = ds.Tables[0].Rows[0]["cCusCode"].ToString();
                nObject.cPersonCode = ds.Tables[0].Rows[0]["cPersonCode"].ToString();
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                nObject.CreateTime = ((ds.Tables[0].Rows[0]["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]);
                nObject.UpdateTime = ((ds.Tables[0].Rows[0]["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateTime"]);
                nObject.PrjType = ((ds.Tables[0].Rows[0]["PrjType"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["PrjType"]);
                nObject.PrjNature = ((ds.Tables[0].Rows[0]["PrjNature"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["PrjNature"]);
                nObject.DeveloperRec = ((ds.Tables[0].Rows[0]["DeveloperRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["DeveloperRec"]);
                nObject.TesterRec = ((ds.Tables[0].Rows[0]["TesterRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["TesterRec"]);
                nObject.MarketRec = ((ds.Tables[0].Rows[0]["MarketRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["MarketRec"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
        /// <summary>
        /// 得到  vi_projectinfo 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_projectinfo 数据实体</returns>
        private Vi_ProjectInfoModel Populate_Vi_ProjectInfoEntity_FromDr(IDataReader dr)
        {
            Vi_ProjectInfoModel Obj = new Vi_ProjectInfoModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.I_id = ((dr["I_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["I_id"]);
            Obj.citemcode = dr["citemcode"].ToString();
            Obj.citemname = dr["citemname"].ToString();
            string x = dr["bclose"].ToString();
            Obj.bclose = ((dr["bclose"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["bclose"]);
            Obj.citemccode = dr["citemccode"].ToString();
            Obj.iotherused = ((dr["iotherused"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["iotherused"]);
            Obj.ContractNumber = dr["ContractNumber"].ToString();
            Obj.ProjectNatureSysNo = ((dr["ProjectNatureSysNo"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProjectNatureSysNo"]);
            Obj.cCusCode = dr["cCusCode"].ToString();
            Obj.cPersonCode = dr["cPersonCode"].ToString();
            Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            Obj.PrjType = ((dr["PrjType"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrjType"]);
            Obj.PrjNature = ((dr["PrjNature"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrjNature"]);
            Obj.DeveloperRec = ((dr["DeveloperRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DeveloperRec"]);
            Obj.TesterRec = ((dr["TesterRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["TesterRec"]);
            Obj.MarketRec = ((dr["MarketRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["MarketRec"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_projectinfo 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_projectinfo 数据实体</returns>
        private Vi_ProjectInfoModel Populate_Vi_ProjectInfoEntity_FromDr(DataRow dr)
        {
            Vi_ProjectInfoModel Obj = new Vi_ProjectInfoModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.I_id = ((dr["I_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["I_id"]);
                Obj.citemcode = dr["citemcode"].ToString();
                Obj.citemname = dr["citemname"].ToString();
                Obj.bclose = (int)dr["bclose"];
                Obj.citemccode = dr["citemccode"].ToString();
                Obj.iotherused = ((dr["iotherused"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["iotherused"]);
                Obj.ContractNumber = dr["ContractNumber"].ToString();
                Obj.ProjectNatureSysNo = ((dr["ProjectNatureSysNo"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProjectNatureSysNo"]);
                Obj.cCusCode = dr["cCusCode"].ToString();
                Obj.cPersonCode = dr["cPersonCode"].ToString();
                Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
                Obj.PrjType = ((dr["PrjType"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrjType"]);
                Obj.PrjNature = ((dr["PrjNature"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrjNature"]);
                Obj.DeveloperRec = ((dr["DeveloperRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DeveloperRec"]);
                Obj.TesterRec = ((dr["TesterRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["TesterRec"]);
                Obj.MarketRec = ((dr["MarketRec"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["MarketRec"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_ProjectInfo对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_ProjectInfo对象</returns>
        public override Vi_ProjectInfoModel Get_Vi_ProjectInfoModel(Int32 ID)
        {
            Vi_ProjectInfoModel _Entity = null;
            string commandString = "select * from Vi_ProjectInfo where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_ProjectInfoEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_ProjectInfo所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_ProjectInfoModel> GetVi_ProjectInfoAll()
        {
            IList<Vi_ProjectInfoModel> _Entity = new List<Vi_ProjectInfoModel>();
            string commandString = "select * from Vi_ProjectInfo";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_ProjectInfoEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
	}
}
