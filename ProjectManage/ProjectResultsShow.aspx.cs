using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Common;


namespace ProjectManage
{
    public partial class ProjectResultsShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CssControl.SwitchCSS(this.Page, "style/jquery-ui-1.7.custom.css");
            CssControl.SwitchCSS(this.Page, "style/blue3.css");
            JsControl.SwitchJS(this.Page, "js/jquery-ui-1.7.custom.min.js");
            JsControl.SwitchJS(this.Page, "js/tablecolor.js");
            CssControl.SwitchCSS(this.Page, "style/form.css");
        }
    }
}