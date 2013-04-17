using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManage.Common
{
    public class ClientInfo
    {
        /// <summary>
        /// 获得客户端浏览器类型
        /// </summary>
        /// <returns></returns>
        public string getBrowser()
        {
            string browsers;
            HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
            string aa = bc.Browser.ToString();
            if (aa.Length == 2 && aa.Contains("SE")) aa = "搜狗浏览器";
            string bb = bc.Version.ToString();
            browsers = aa + bb;
            return browsers;
        }
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public string getIP()
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (null == result || result == String.Empty)
            {
                return "0.0.0.0";
            }
            return result;
        }
        /// <summary>
        /// 获取操作系统版本号
        /// </summary>
        /// <returns></returns>
        public string SystemCheck()
        {
            string Agent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];

            if (Agent.IndexOf("NT 4.0") > 0)
            {
                return "Windows NT ";
            }
            else if (Agent.IndexOf("NT 5.0") > 0)
            {
                return "Windows 2000";
            }
            else if (Agent.IndexOf("NT 5.1") > 0)
            {
                return "Windows XP";
            }
            else if (Agent.IndexOf("NT 5.2") > 0)
            {
                return "Windows 2003";
            }
            else if (Agent.IndexOf("NT 6.0") > 0)
            {
                return "Windows Vista";
            }
            else if (Agent.IndexOf("NT 6.1") > 0)
            {
                return "Windows 7";
            }
            else if (Agent.IndexOf("WindowsCE") > 0)
            {
                return "Windows CE";
            }
            else if (Agent.IndexOf("NT") > 0)
            {
                return "Windows NT ";
            }
            else if (Agent.IndexOf("9x") > 0)
            {
                return "Windows ME";
            }
            else if (Agent.IndexOf("98") > 0)
            {
                return "Windows 98";
            }
            else if (Agent.IndexOf("95") > 0)
            {
                return "Windows 95";
            }
            else if (Agent.IndexOf("Win32") > 0)
            {
                return "Win32";
            }
            else if (Agent.IndexOf("Linux") > 0)
            {
                return "Linux";
            }
            else if (Agent.IndexOf("SunOS") > 0)
            {
                return "SunOS";
            }
            else if (Agent.IndexOf("Mac") > 0)
            {
                return "Mac";
            }
            else if (Agent.IndexOf("Linux") > 0)
            {
                return "Linux";
            }
            else if (Agent.IndexOf("Windows") > 0)
            {
                return "Windows";
            }
            return "未知类型";

        }
    }
}