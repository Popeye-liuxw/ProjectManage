using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Threading;
using System.Timers;
using ProjectManage.BLL;
using System.Configuration;

namespace ProjectManage
{
    public class Global : System.Web.HttpApplication
    {
        private string url = "";
        log4net.ILog logger = log4net.LogManager.GetLogger("WebLogger");
        private readonly SysMailError mailerr = new SysMailError();
        void Application_Start(object sender, EventArgs e)
        {
            logger.Info("application start");
            url = ConfigurationManager.AppSettings["UrlPath"].ToString();
            if (url == string.Empty)
                url = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + HttpRuntime.AppDomainAppVirtualPath; //HttpContext.Current.Request.ApplicationPath;
            logger.Info("request_url:" + url);
            System.Timers.Timer myTimer = new System.Timers.Timer(10000);
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true;
            myTimer.AutoReset = true;
        }

        void myTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            lock (this)
            {
                logger.Info("start checking email");
                //发送邮件
                if (mailerr.CheckErrorMail())
                {
                    mailerr.TrySendMail();
                }
                logger.Info("finish checking email");
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码
            logger.Info("application end");
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            logger.Info("application Error");
        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            logger.Info("Session Start");
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。
            logger.Info("Session End");
        }
    }
}
