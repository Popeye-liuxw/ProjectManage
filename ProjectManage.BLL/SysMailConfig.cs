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
 * 文件： SysMailConfig.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/6 15:02:49
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 用来配置系统邮件信息
    /// </summary>
    public class SysMailConfig
    {
        private Vi_SysEmailServerModel emailServer;

        public SysMailConfig()
        { }
        /// <summary>
        /// 配置发件服务器基本信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpwd"></param>
        /// <param name="configName"></param>
        public SysMailConfig(string username, string userpwd,string configName)
        {
            emailServer = new Vi_SysEmailServerModel();            
            emailServer.UserName = username;
            emailServer.UserPwd = userpwd;
            if (string.IsNullOrEmpty(configName)) configName = username;
            emailServer.EmailName = configName;
        }

        public Vi_SysEmailServerModel EmailServer
        {
            get 
            { 
                if(emailServer == null)
                {
                    emailServer = new Vi_SysEmailServerModel();                    
                }
                return emailServer;
            }
        }
        /// <summary>
        /// 检测是否已经配置过该邮件服务器
        /// </summary>
        /// <returns></returns>
        public bool ExecuteCheck(string userName)
        {
            bool result = false;
            Vi_SysEmailServerProvider emailServerSql = DataFactory.CreateVi_SysEmailServerSqlPrivider();

            if (emailServer != null)
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    int count = emailServerSql.GetEmailServerByUserName(userName);
                    if (count > 0) result = true;
                }
            }

            return result;
        }
        /// <summary>
        /// 保存发件邮箱相关配置
        /// </summary>
        /// <param name="displayName">发件人姓名</param>
        /// <param name="address">发件人邮箱地址</param>
        /// <param name="port">端口号</param>
        /// <param name="smtp">邮件服务器地址</param>
        /// <param name="ssl">服务器端是否要求启用安全连接</param>
        /// <param name="state">是否立即启动该配置</param>
        /// <param name="adminID">操作人ID</param>
        /// <returns></returns>
        public bool SaveMailConfig(string displayName,string address,int port,string smtp,bool ssl,bool state, int adminID)
        {
            bool result = false;
            Vi_SysEmailServerProvider emailServerSql = DataFactory.CreateVi_SysEmailServerSqlPrivider();            
            emailServer.Port = port;
            emailServer.SMTPHost = smtp;
            if (string.IsNullOrEmpty(address)) address = emailServer.UserName;
            emailServer.Address = address;
            emailServer.UserID = adminID;
            emailServer.EnableSSL = ssl ? 1 : 0;
            emailServer.DisplayName = displayName;
            emailServer.State = (int)EmailState.NO;
            if (state)
            {
                Vi_SysEmailServerModel startEmail = emailServerSql.FindEmailServerState((int)EmailState.OK);
                if (startEmail == null)
                {
                    emailServer.State = (int)EmailState.OK;
                }
                else
                {
                    startEmail.State = (int)EmailState.NO;
                    emailServerSql.UpdateVi_SysEmailServer(startEmail);
                }
            }

            emailServer.UserPwd = MD5Tool.MD5Encrypt(emailServer.UserPwd);

            int temp = emailServerSql.SaveVi_SysEmailServer(emailServer);
            if (temp > 0) result = true;

            return result;
        }
        /// <summary>
        /// 获取邮件服务器配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vi_SysEmailServerModel GetEmailServerConfig(int id)
        {
            Vi_SysEmailServerModel model = new Vi_SysEmailServerModel();
            Vi_SysEmailServerProvider emailServerSql = DataFactory.CreateVi_SysEmailServerSqlPrivider();
            model = emailServerSql.Get_Vi_SysEmailServerModel(id);
            return model;
        }

        /// <summary>
        /// 获取所有邮件列表
        /// </summary>
        /// <returns></returns>
        public List<Vi_SysEmailServerModel> GetEmailConfigList()
        {
            List<Vi_SysEmailServerModel> models = new List<Vi_SysEmailServerModel>();
            Vi_SysEmailServerProvider emailServerSql = DataFactory.CreateVi_SysEmailServerSqlPrivider();

            models = emailServerSql.GetVi_SysEmailServerAll().ToList();

            return models;
        }

        /// <summary>
        /// 更新邮件配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmailConfig(Vi_SysEmailServerModel model)
        {
            bool result = false;
            Vi_SysEmailServerProvider emailServerSql = DataFactory.CreateVi_SysEmailServerSqlPrivider();

            if (model != null)
            {
                if (model.State == 10)
                {
                    Vi_SysEmailServerModel startEmail = emailServerSql.FindEmailServerState((int)EmailState.OK);
                    if (startEmail == null)
                    {
                        int temp = emailServerSql.UpdateVi_SysEmailServer(model);
                        if (temp > 0) result = true;
                    }
                    else
                    {
                        startEmail.State = (int)EmailState.NO;
                        emailServerSql.UpdateVi_SysEmailServer(startEmail);
                        int temp = emailServerSql.UpdateVi_SysEmailServer(model);                        
                        if (temp > 0) result = true;
                    }
                }
                else
                {
                    int temp = emailServerSql.UpdateVi_SysEmailServer(model);
                    if (temp > 0) result = true;
                }
            }
            return result;
        }
    }
}
