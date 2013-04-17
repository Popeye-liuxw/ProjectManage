using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;

namespace ProjectManage
{
    public partial class ListDailyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                string userid = Session["UserId"].ToString();
                try
                {                   
                    int userID = int.Parse(userid);
                    ViewState["UserId"] = userid;
                    ViewState["write"] = false;
                    SystemPermission sys = SystemLegalPowerBll.GetSystemPermission(userID, 14);//TODO:填写模型ID 
                    if (sys == SystemPermission.Read || sys == SystemPermission.Write)
                    {
                        if (sys == SystemPermission.Write)
                        {
                            ViewState["write"] = true;
                        }
                        btn_Math.Visible = true;
                        AddProBaseInfo.Visible = true;
                    }
                    else
                    {
                        btn_Math.Visible = false;
                        tip.Visible = true;
                        lbl_Tip.Text = "对不起，没有系统权限！";
                    }
                    bindDDList(); 
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
                ViewState["userID"] = userid;
                ViewState["userName"] = Session["RealName"] as string;
            }
        }

        private void bindDDList()
        {
            UserBLL userbll = new UserBLL();
            List<Vi_SysUserModel> users = userbll.getAllUsers();
            ddl_SelectName.DataSource = users;
            ddl_SelectName.DataTextField = "RealName";
            ddl_SelectName.DataValueField = "ID";
            ddl_SelectName.DataBind();
            string[] months = new string[12];
            for (int i = 0; i < 12; i++)
            {
                months[i] = (i + 1).ToString();
            }            
            ddl_SelectMonth.DataSource = months;
            ddl_SelectMonth.SelectedValue = DateTime.Now.Month.ToString();
            ddl_SelectMonth.DataBind();            
            ddl_Year.DataSource = new string[] { dt.Year.ToString(), (dt.Year - 1).ToString() };
            ddl_Year.DataBind();
        }

        protected void btn_Math_Click(object sender, EventArgs e)
        {
            string meg = string.Empty;
            int count, workday;
            DailyPaperBLL dailybll = new DailyPaperBLL();           
            rep_List.DataSource = dailybll.GetPrjMonthModel(ddl_SelectName.SelectedValue, ddl_SelectMonth.SelectedValue,ddl_Year.SelectedValue);
            rep_List.DataBind();
            lbl_meg.Text = meg;
            if (rep_List.Items.Count > 0)
            {
                count = rep_List.Items.Count;
                dt = new DateTime(int.Parse(ddl_Year.SelectedValue), int.Parse(ddl_SelectMonth.SelectedValue), 1);
                workday = dailybll.getDays(dt);
                meg = string.Format("本月工作日(不包含节假日)共{1}天，日报填写{0}条", count, workday);
                //item++;
                if (item < workday)
                {
                    lbl_meg.ForeColor = System.Drawing.Color.Red;
                    meg = meg + string.Format("，其中有{0}天未填写日报", workday - item);
                }
                else
                {
                    lbl_meg.ForeColor = System.Drawing.Color.Black;
                }
                lbl_meg.Text = meg;
            }
            item = 0;
        }
        DateTime dt = DateTime.Now;
        int item;
        protected void rep_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    string id = ((System.Data.DataRowView)(e.Item.DataItem))["ID"].ToString();
                    bool write = (bool)ViewState["write"];
                    if (write)
                    {
                        BoundLink(id, (HyperLink)e.Item.FindControl("hyperlink1"));
                    }
                    else
                    { 
                        string text = ((System.Data.DataRowView)(e.Item.DataItem))["RealName"].ToString();
                        Label lbl = new Label();
                        lbl.Text = text;
                        e.Item.Controls.Remove(e.Item.FindControl("hyperlink1"));
                        e.Item.Controls.AddAt(3, lbl);                        
                    }
                    string time = ((System.Data.DataRowView)(e.Item.DataItem))["CreateTime"].ToString();
                    DateTime dt1 = Convert.ToDateTime(time);
                    if (dt.Date.Day == dt1.Date.Day)
                    { 
                        //nothing to du here
                    }
                    else
                    {
                        dt = dt1;
                        item++;
                    }
                }
                catch (Exception ex)
                {
                    string id = ((System.Data.DataRowView)(e.Item.DataItem))["ID"].ToString();
                    BoundLink(id, (HyperLink)e.Item.FindControl("hyperlink1"));
                }                
            }
        }
        protected void BoundLink(string id, HyperLink hyper)
        {
            if (hyper == null) return;
            if (string.IsNullOrEmpty(id)) return;           
            string url= string.Format(@"javascript:window.open('DailyReportItemInfo.aspx?key={0}kec-{1}','noname','height=400,width=850,left=300, top=100,fullscreen=0,toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=0')", id, Guid.NewGuid());
            hyper.Attributes.Add("onclick", url);
        }
        protected void rep_List_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void rep_List_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }
        
    }
}