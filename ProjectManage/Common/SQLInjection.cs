using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManage.Common
{
    public class SQLInjection
    {
        /// <summary>
        /// 过滤客户端提交的SQL保留字符以及字符串 防止SQL注入 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String FilterStr(string str)
        {
            string[] strarr = new string[] {"SELECT","insert","update","drop",";",
                                            "'","delete","having","order","(",")",
                                            "Create","declare","master","group",
                                            "VALUES","union","exec","xp_cmdshell","xp_"
                                            };
            for (int i = 0; i < strarr.Length; i++)
            {
                str = str.Replace(strarr[i], "");
            }
            return str;
        }
    }
}