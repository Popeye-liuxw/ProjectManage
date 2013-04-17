
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysSendEmailSqlPrivider.cs
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
	public partial class Vi_SysSendEmailSqlPrivider: Vi_SysSendEmailProvider
	{

        public override int GetEmailStateCount(int state)
        {
            int count = 0;
            string sql = "select Count([ID]) as PCount  from Vi_SysSendEmail where SendState = @SendState";            
            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@SendState", System.Data.DbType.Int32, state);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    count = ((dr["PCount"]) == DBNull.Value) ? 0 : int.Parse(dr["PCount"].ToString());
                }
            }


            return count;
        }

        public override bool ClearEmail(Vi_SysSendEmailModel mail)
        {
            throw new NotImplementedException();
        }

        public override IList<Vi_SysSendEmailModel> GetEmailStateList(int state)
        {
            IList<Vi_SysSendEmailModel> _Entity = new List<Vi_SysSendEmailModel>();
            string sql = "SELECT [ID],[MailTitle],[MailContent],[Email],[ResendTime],[SendState],[UserID],[CreateTime],[UpdateTime] FROM Vi_SysSendEmail where SendState = @SendState";
            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@SendState", DbType.Int32, state);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysSendEmailEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        public override IList<Vi_SysSendEmailModel> GetEmailStateList(int state, DateTime ResendTime)
        {
            IList<Vi_SysSendEmailModel> _Entity = new List<Vi_SysSendEmailModel>();
            string sql = "SELECT [ID],[MailTitle],[MailContent],[Email],[ResendTime],[SendState],[UserID],[CreateTime],[UpdateTime] FROM Vi_SysSendEmail where SendState = @SendState and ResendTime  between @bResendTime and @eResendTime";
            DbCommand command = db.GetSqlStringCommand(sql);
            db.AddInParameter(command, "@SendState", DbType.Int32, state);
            db.AddInParameter(command, "@bResendTime", DbType.DateTime, ResendTime);
            db.AddInParameter(command, "@eResendTime", DbType.DateTime, ResendTime.AddMinutes(3));
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysSendEmailEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
    }
}
