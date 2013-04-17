using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Common;

namespace ProjectManage
{
    public partial class DailyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CssControl.SwitchCSS(this.Page, "style/form.css");
            JsControl.SwitchJS(this.Page, "js/tablecolor.js");
        }
    }
}