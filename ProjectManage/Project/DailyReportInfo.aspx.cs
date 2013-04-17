using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;

namespace ProjectManage.Project
{
    public partial class DailyReportInfo : System.Web.UI.Page
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
                if (Request.QueryString["prjID"] == null)
                {
                    Response.Redirect("ProjectBasicInfoManagement.aspx");
                    return;
                }
                string prjid = Request.QueryString["prjID"].ToString();
                string userid = Session["UserId"].ToString();
                spn_Menu.QueryString = "&prjID=" + prjid;
                spn_Menu.MenuID = 8; //日报
                btn_Save.Visible = false;
                try
                {
                    int prjID = int.Parse(prjid);
                    int userID = int.Parse(userid);
                    SysProjectBll prj = new SysProjectBll();
                    if (prj.getAllProjectWithUser(userID, prjID))
                    {
                        SystemPermission sys = SystemLegalPowerBll.GetSystemPermission(userID, spn_Menu.MenuID);
                        if (sys == SystemPermission.Read || sys == SystemPermission.Write)
                        {
                            if (sys == SystemPermission.Write)
                            {
                                btn_Save.Visible = true;
                            }
                            Vi_ProjectInfoModel project = prj.GetProjectInfoModel(prjID);
                            if (project != null)
                            {
                                lbl_Title.Text = project.citemname;
                                BindDailyReport(prjID, userID);
                            }
                        }
                        else
                        {
                            tip.Visible = true;
                            lbl_Tip.Text = "你的系统权限不够,不能查看该日报信息";
                            return;
                        }
                    }
                    else
                    {
                        tip.Visible = true;
                        lbl_Tip.Text = "抱歉，你并没有参与该项目";
                        return;
                    }

                }
                catch (Exception ex)
                {

                    Response.Write("传递参数有误！" + ex.Message);
                    Response.End();
                }

                ViewState["userID"] = userid;
                ViewState["userName"] = Session["RealName"] as string;
                ViewState["prjID"] = prjid;
            }
        }

        private void BindDailyReport(int prjId,int userId)
        {
            if (prjId <= 0 || userId <= 0) return;
            DailyPaperBLL dailyBll = new DailyPaperBLL();
            rpt_Daily.DataSource = dailyBll.GetPrjDailyPaperModel(prjId, userId, 7);
            rpt_Daily.DataBind();
            rpt_ChangePaper.DataSource = dailyBll.GetPrjChangePaperModel(prjId, userId, 5);
            rpt_ChangePaper.DataBind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (ViewState["prjID"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "tip", "alert('获取项目信息失败')", true);
                return;
            }
            Response.Redirect("AddDailyReport.aspx?prjID=" + ViewState["prjID"].ToString());
        }
    }
}