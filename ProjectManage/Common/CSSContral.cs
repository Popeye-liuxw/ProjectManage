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
/// CSSService 的摘要说明
/// </summary>
namespace ProjectManage.Common
{
    public class CssControl
    {
        // add css
        public static void SwitchCSS(Page page, string CSSFilePath)
        {
            HtmlLink link = new HtmlLink();
            link.Href = CSSFilePath;
            link.Attributes["rel"] = "stylesheet";
            link.Attributes["type"] = "text/css";
            page.Header.Controls.Add(link);
        }
    }
}
