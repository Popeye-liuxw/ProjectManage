using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using log4net;
/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： SysMailError.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/7 11:18:26
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 邮件发送失败
    /// </summary>
    public class SysMailError
    {
        private Vi_SysSendEmailProvider sendMailSql;
        private log4net.ILog logger = log4net.LogManager.GetLogger("EmialLogger");

        public SysMailError()
        {
            sendMailSql = DataFactory.CreateVi_SysSendEmailSqlPrivider();
        }
        /// <summary>
        /// 记入退信库
        /// </summary>
        /// <param name="senderList"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void WriteErrorMail(List<string> senderList, string title, StringBuilder content)
        {
            logger.Info("邮件服务器退信，标题 " + title);
            Vi_SysSendEmailModel model = new Vi_SysSendEmailModel();
            StringBuilder addressee = new StringBuilder(25 * senderList.Count);
            foreach (var item in senderList)
            {
                addressee.Append(";");
                addressee.Append(item);
            }
            addressee.Remove(0, 1);

            model.MailTitle = title;
            model.MailContent = content.ToString();
            model.ResendTime = DateTime.Now.AddHours(2);
            model.SendState = (int)SendEmailState.Ready;
            model.Email = addressee.ToString();
            try
            {
                if (sendMailSql.SaveVi_SysSendEmail(model) > 0)
                {
                    //保存成功
                    logger.Info("写入退信库成功");
                }
                else
                {
                    //保存失败
                    logger.Info("写入退信库失败，需要联系管理人员");
                }
            }
            catch (Exception ex)
            {
                logger.Error("记录错误邮件失败，原因: ", ex);
            }
            
        }

        /// <summary>
        /// 检测是否存在未发出的邮件
        /// </summary>
        /// <returns></returns>
        public bool CheckErrorMail()
        {
            bool result = false;
            int temp = sendMailSql.GetEmailStateCount((int)SendEmailState.Ready);
            if (temp > 0) result = true;
            return result;
        }
        /// <summary>
        /// 尝试发送邮件
        /// </summary>
        public void TrySendMail()
        {
            try
            {
                logger.Info("TryBenginSendErrEmail");

                List<Vi_SysSendEmailModel> sendMails = sendMailSql.GetEmailStateList((int)SendEmailState.Ready, DateTime.Now).ToList();
                SysMailSenderBll send = new SysMailSenderBll();
                foreach (Vi_SysSendEmailModel item in sendMails)                
                {                    
                   
                    if (send.CheckEmailServer())
                    {
                        bool result = send.SenderEMailMessage(item.Email, item.MailTitle, item.MailContent);

                        if (result)
                        {
                            sendMailSql.DeleteVi_SysSendEmail(item.ID);
                        }
                        else
                        {
                            item.ResendTime = DateTime.Now.AddHours(2);
                            item.SendState = (int)SendEmailState.Ready;
                            sendMailSql.UpdateVi_SysSendEmail(item);
                        }
                    }
                }

                logger.Info("CompleteSendErrEmail [" + sendMails.Count + "] item");
            }
            catch (Exception ex)
            {
                logger.Error("错误邮件发送再次失败", ex);
            }
        }
    }
}
