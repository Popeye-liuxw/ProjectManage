using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： SysMailSenderBll.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/7 10:37:15
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class SysMailSenderBll
    {
        private Vi_SysEmailServerModel emailServer;
        private Vi_SysEmailServerProvider emailSql;
        private log4net.ILog logger = log4net.LogManager.GetLogger("SysMailSenderBll");
        /// <summary>
        /// 创建邮件服务器对象
        /// </summary>
        public SysMailSenderBll()
        {
            emailSql = DataFactory.CreateVi_SysEmailServerSqlPrivider();
            this.emailServer = emailSql.FindEmailServerState((int)EmailState.OK);
        }

        /// <summary>
        /// 检测邮件服务器是否配置完成
        /// </summary>
        /// <returns></returns>
        public bool CheckEmailServer()
        {
            bool result = false;
            if (emailServer != null)
            {
                if (emailServer.UserName != string.Empty && 
                    emailServer.UserPwd != string.Empty && 
                    emailServer.Port > 0 && 
                    emailServer.SMTPHost != string.Empty
                    ) result = true;
                else result = false;
            }
            return result;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="senderList">收件人列表</param>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件内容</param>
        /// <returns>发送是否成功</returns>
        public bool SenderEMailMessage(List<string> senderList,string title,StringBuilder content)
        {
            bool result = false;
            if (CheckEmailServer())
            {
                MailSender mail = new MailSender();
                mail.SetSmtpClient(emailServer.SMTPHost, emailServer.Port, emailServer.EnableSSL > 0 ? true : false);
                mail.SetUserAddress(emailServer.UserName, emailServer.UserPwd);
                List<string> addres = senderList.FindAll(n => n.IndexOf('@') > 0);
                content.Append("<p style='text-align:right;font-size:12px;color:#223352;font-weight:bold;margin-top:30px; margin-right:30px;'>该邮件由系统发出，请勿回复</p>");
                if (addres.Count > 0)
                    result = mail.SendMailByITSSMTP(addres, title, content);
                if (result)
                {
                    logger.InfoFormat("[{0}]邮件发送成功", title);
                }
                else
                {                    
                    SysMailError err = new SysMailError();
                    err.WriteErrorMail(senderList, title, content);
                    logger.InfoFormat("[{0}]邮件发送错误，已记入错误邮件库", title);
                }
            }
            return result;
        }
        /// <summary>
        /// 提供一个便于发送的内部函数
        /// </summary>
        /// <param name="senderList">以；号为区分的一个收件人地址</param>
        /// <param name="title">标题</param>
        /// <param name="content">邮件内容</param>
        internal bool SenderEMailMessage(string senderList, string title, string content)
        {
            bool result = false;
            if (CheckEmailServer())
            {
                MailSender mail = new MailSender();
                mail.SetSmtpClient(emailServer.SMTPHost, emailServer.Port, emailServer.EnableSSL > 0 ? true : false);
                mail.SetUserAddress(emailServer.UserName, emailServer.UserPwd);

                result = mail.SendMailByITSSMTP(GetStringList(senderList), title, new StringBuilder(content));

                if (result)
                {
                    logger.InfoFormat("[{0}]邮件发送成功", title);
                }
                else
                {
                    logger.InfoFormat("[{0}]邮件发送错误，交给轮询对象来处理，将会在两个小时后继续尝试", title);
                }
            }
            return result;
        }

        private List<string> GetStringList(string senderList)
        {
            List<string> result = new List<string>();

            if (senderList.LastIndexOf(';') > 0)
            {
                string[] temp = senderList.Split(new char[] { ';' });

                result = temp.ToList<string>();
            }
            else
            {
                result.Add(senderList);
            }

            return result;
        }

        
    }
}
