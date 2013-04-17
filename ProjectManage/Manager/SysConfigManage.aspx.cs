using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Model;
using ProjectManage.BLL;

namespace ProjectManage.Manager
{
    public partial class SysConfigManage : System.Web.UI.Page
    {
        private int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGVList();
                gv_List.DataKeyNames = new string[] { "ID", "State" };
                index = 1;
            }
        }

        private void BindGVList()
        {
            SysMailConfig config = new SysMailConfig();
            gv_List.DataSource = config.GetEmailConfigList();
            gv_List.DataBind();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            String url = String.Format("SysConfigEdit.aspx?temp=edit&config={0}", ((LinkButton)sender).CommandArgument);
            Response.Redirect(url, false);
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            String url = String.Format("SysConfigEdit.aspx?temp=sys");
            Response.Redirect(url, false);
        }

        protected void gv_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                int temp =0;
                if (int.TryParse(e.Row.Cells[6].Text, out temp))
                {
                    if (temp == (int)EmailState.OK)
                        e.Row.Cells[6].Text = "已启用";
                    else
                        e.Row.Cells[6].Text = "未启用";
                }
                e.Row.Cells[0].Text = index.ToString();
                index++;
            }
        }
    }
}