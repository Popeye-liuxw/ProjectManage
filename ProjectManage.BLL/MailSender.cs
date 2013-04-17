using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;


/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： MailSender.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/4 16:37:35
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class MailSender
    {
        private SmtpClient client;
        private MailAddress AddressFrom;
        public MailSender()
        {
            client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("liuxiaowei@visione.com.cn", "test");            
            client.Port = 25;
            client.Host = "smtp.visione.com.cn";
            client.EnableSsl = false;
        }
         /// <summary>
         /// 设置Smtp服务器信息
         /// </summary>
        /// <param name="serverHost">指定Smtp服务名:如QQ:smtp.qq.com；sina：smtp.sina.cn</param>
         /// <param name="Port">端口号</param>
         public void SetSmtpClient(string serverHost, int Port,bool ssl)
         {
             client.Host = serverHost;
             client.Port = Port;
             //client.Timeout = 0;
             client.EnableSsl = ssl;
         }

         /// <summary>
         /// 发件人信息
         /// </summary>
         /// <param name="mailAddress">邮箱名称</param>
         /// <param name="mailPwd">邮箱密码MD5数据</param>
         public void SetUserAddress(string mailName, string mailPwd)
         {
             setAddressFrom(mailName, MD5Tool.MD5Decrypt(mailPwd));
         }

        /// <summary>
        /// 发送SMTP邮件
        /// </summary>
        /// <param name="senderList">收件人列表</param>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件内容</param>
        /// <returns>发送是否成功</returns>
        public bool SendMailByITSSMTP(List<String> senderList, String title, StringBuilder content)
        {            
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            foreach (String sender in senderList)
            {
                msg.To.Add(sender);
            }
            if (AddressFrom == null) AddressFrom = new MailAddress("administrator@visione.com.cn");
            msg.From = AddressFrom;
            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.Subject = title;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
            msg.Body = content.ToString();
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = true;//是否是HTML邮件 
            msg.Priority = MailPriority.Normal;//邮件优先级 
            try
            {
                client.Send(msg);                
                //可去掉
                System.Console.WriteLine(senderList[0] + "\t" + title + "\r\n" + content);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
        private void setAddressFrom(string mailAddress, string mailPwd)
        {
            //创建服务器验证
            NetworkCredential networkCreadential_My = new NetworkCredential(mailAddress, mailPwd);
            //实例化发件人地址
            AddressFrom = new MailAddress(mailAddress, "Visione", System.Text.Encoding.UTF8);
            //指定发件人信息 邮箱地址和密码
            client.Credentials = networkCreadential_My;

        }
    }
}
