using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// JSControl 的摘要说明
/// </summary>
/// 
namespace ProjectManage.Common
{
    public class JsControl
    {
        /// <summary>
        /// 调用母版页向母版页添加当前页的JS或者CSS
        /// </summary>
        /// <param name="page"></param>
        /// <param name="JSFilePath"></param>
        public static void SwitchJS(Page page, string JSFilePath)
        {
            HtmlGenericControl HGControl = new HtmlGenericControl("script");
            HGControl.Attributes.Add("type", "text/javascript");
            HGControl.Attributes.Add("src", JSFilePath);
            page.Header.Controls.Add(HGControl);
        }
    }
}
