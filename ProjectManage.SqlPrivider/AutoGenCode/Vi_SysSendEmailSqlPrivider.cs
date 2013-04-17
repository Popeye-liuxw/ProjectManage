
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysSendEmailSqlPrivider.cs
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
	public partial class Vi_SysSendEmailSqlPrivider:Vi_SysSendEmailProvider
	{
        #region Vi_SysSendEmail

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int SaveVi_SysSendEmail(Vi_SysSendEmailModel Model)
        {
            Model.CreateTime = DateTime.Now;
            string commandString = "INSERT INTO [Vi_SysSendEmail] ([MailTitle],[MailContent],[Email],[ResendTime],[SendState],[UserID],[CreateTime]) values( @MailTitle, @MailContent, @Email, @ResendTime, @SendState, @UserID, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@MailTitle", DbType.String, Model.MailTitle);
            db.AddInParameter(command, "@MailContent", DbType.String, Model.MailContent);
            db.AddInParameter(command, "@Email", DbType.String, Model.Email);
            db.AddInParameter(command, "@ResendTime", DbType.DateTime, Model.ResendTime);
            db.AddInParameter(command, "@SendState", DbType.Int32, Model.SendState);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            //db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_SysSendEmail(Vi_SysSendEmailModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_SysSendEmail] set [MailTitle]=@MailTitle,[MailContent]=@MailContent,[Email]=@Email,[ResendTime]=@ResendTime,[SendState]=@SendState,[UserID]=@UserID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@MailTitle", DbType.String, Model.MailTitle);
            db.AddInParameter(command, "@MailContent", DbType.String, Model.MailContent);
            db.AddInParameter(command, "@Email", DbType.String, Model.Email);
            db.AddInParameter(command, "@ResendTime", DbType.DateTime, Model.ResendTime);
            db.AddInParameter(command, "@SendState", DbType.Int32, Model.SendState);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            //db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///删除数据库一条数据
        ///</summary>
        /// <param name="ID">ID</param>
        /// <returns>影响的条数</returns>
        public override int DeleteVi_SysSendEmail(int ID)
        {
            string commandString = "delete from Vi_SysSendEmail where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_SysSendEmail返回的查询dateset创建一个Vi_SysSendEmail对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysSendEmail对象</returns>
        private Vi_SysSendEmailModel Populate_Vi_SysSendEmailEntity_FromDr(DataSet ds)
        {
            Vi_SysSendEmailModel nObject = new Vi_SysSendEmailModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.MailTitle = ds.Tables[0].Rows[0]["MailTitle"].ToString();
                nObject.MailContent = ds.Tables[0].Rows[0]["MailContent"].ToString();
                nObject.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                nObject.ResendTime = ((ds.Tables[0].Rows[0]["ResendTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["ResendTime"]);
                nObject.SendState = ((ds.Tables[0].Rows[0]["SendState"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["SendState"]);
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                nObject.CreateTime = ((ds.Tables[0].Rows[0]["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]);
                nObject.UpdateTime = ((ds.Tables[0].Rows[0]["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateTime"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
        /// <summary>
        /// 得到  vi_syssendemail 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_syssendemail 数据实体</returns>
        private Vi_SysSendEmailModel Populate_Vi_SysSendEmailEntity_FromDr(IDataReader dr)
        {
            Vi_SysSendEmailModel Obj = new Vi_SysSendEmailModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.MailTitle = dr["MailTitle"].ToString();
            Obj.MailContent = dr["MailContent"].ToString();
            Obj.Email = dr["Email"].ToString();
            Obj.ResendTime = ((dr["ResendTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["ResendTime"]);
            Obj.SendState = ((dr["SendState"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["SendState"]);
            Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_syssendemail 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_syssendemail 数据实体</returns>
        private Vi_SysSendEmailModel Populate_Vi_SysSendEmailEntity_FromDr(DataRow dr)
        {
            Vi_SysSendEmailModel Obj = new Vi_SysSendEmailModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.MailTitle = dr["MailTitle"].ToString();
                Obj.MailContent = dr["MailContent"].ToString();
                Obj.Email = dr["Email"].ToString();
                Obj.ResendTime = ((dr["ResendTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["ResendTime"]);
                Obj.SendState = ((dr["SendState"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["SendState"]);
                Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_SysSendEmail对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysSendEmail对象</returns>
        public override Vi_SysSendEmailModel Get_Vi_SysSendEmailModel(Int32 ID)
        {
            Vi_SysSendEmailModel _Entity = null;
            string commandString = "SELECT [ID],[MailTitle],[MailContent],[Email],[ResendTime],[SendState],[UserID],[CreateTime],[UpdateTime] FROM where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysSendEmailEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_SysSendEmail所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_SysSendEmailModel> GetVi_SysSendEmailAll()
        {
            IList<Vi_SysSendEmailModel> _Entity = new List<Vi_SysSendEmailModel>();
            string commandString = "SELECT [ID],[MailTitle],[MailContent],[Email],[ResendTime],[SendState],[UserID],[CreateTime],[UpdateTime] FROM Vi_SysSendEmail";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysSendEmailEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
	}
}
