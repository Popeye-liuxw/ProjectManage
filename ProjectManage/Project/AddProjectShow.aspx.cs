using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Common;

namespace ProjectManage
{
    public partial class AddProjectShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JsControl.SwitchJS(this.Page, "/editor/kindeditor.js");
            JsControl.SwitchJS(this.Page, "/editor/lang/zh_CN.js");
            CssControl.SwitchCSS(this.Page, "/editor/themes/default/default.css");
            CssControl.SwitchCSS(this.Page, "/editor/plugins/code/prettify.css");
            JsControl.SwitchJS(this.Page, "/editor/plugins/code/prettify.js");
        }
    }
}