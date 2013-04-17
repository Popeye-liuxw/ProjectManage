using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;

namespace ProjectManage.Project
{
    public partial class AddDailyReport : System.Web.UI.Page
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
                btn_Save.Visible = false;
                spn_Menu.QueryString = "&prjID=" + prjid;
                spn_Menu.MenuID = 8; //日报
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
                            BindUser();
                            FindProject(prjID);
                        }
                        else
                        {
                            tip.Visible = true;
                            lbl_Tip.Text = "你的系统权限不够,不能编写日报等相关内容，请联系管理人员";
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
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }

                ViewState["userID"] = userid;
                ViewState["userName"] = Session["RealName"].ToString();
                ViewState["prjID"] = prjid;

            }
        }

        private void FindProject(int prjid)
        {
            if (prjid > 0)
            {
                SysProjectBll proje = new SysProjectBll();
                /*
                Vi_SysUserModel prjUser = proje.getProMangerByProId(prjid);
                if (prjUser != null)
                {
                    int tmp = 0;
                    foreach (ListItem item in cbl_Attention.Items)
                    {
                        if (int.TryParse(item.Value, out tmp))
                        {
                            if (tmp == prjUser.ID)
                            {
                                item.Selected = true;
                                item.Enabled = false;                                
                            }
                        }
                    }
                }
                */
                Vi_ProjectInfoModel projeModel = proje.GetProjectInfoModel(prjid);
                if (projeModel != null)
                {
                    lbl_Title.Text = projeModel.citemname;

                    int tmp = 0;
                    foreach (ListItem item in cbl_Attention.Items)
                    {
                        if (int.TryParse(item.Value, out tmp))
                        {
                            if (tmp == projeModel.MarketRec || tmp == projeModel.DeveloperRec || tmp == projeModel.TesterRec)
                            {
                                item.Selected = true;
                                item.Enabled = false;
                            }
                        }
                    }
                }

            }
        }

        private void BindUser()
        {
            UserBLL user = new UserBLL();
            cbl_Attention.DataSource = user.getAllUsers();
            cbl_Attention.DataTextField = "RealName";
            cbl_Attention.DataValueField = "ID";
            cbl_Attention.DataBind();
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Daily.Value == "<br />" || Daily.Value.Contains("在这里输入当天工作情况总结")) 
            {
                lbl_msg.Text = "你还没有输入当天的工作情况总结，请检查";
                return;
            }

            if (Daily.Value.Length > 5000)
            {
                lbl_msg.Text = "你输入的日报内容超出系统能够承受的范围，请精简内容!";
                return;
            }
            if (ChangePaper.Value.Length > 5000)
            {
                lbl_msg.Text = "你输入的需求变更内容超出系统能够承受的范围，请精简内容!";
                return;
            }
            List<string> senderList = GetSenderList();
            if (senderList.Count <= 0)
            {
                lbl_msg.Text = "至少需要选中一名关注人";
                return;
            }
            string changeContent = string.Empty;           
            string username = "未知人员";
            int userID = Convert.ToInt32( ViewState["userID"]);
            int prjID = Convert.ToInt32(ViewState["prjID"]); 
            if (ViewState["userName"] != null) username = ViewState["userName"].ToString();
            Vi_PrjDailyPaperModel model = new Vi_PrjDailyPaperModel();
            DailyPaperBLL daily = new DailyPaperBLL();
            model.UserID = userID;
            model.PrjID = prjID;
            model.Summarize = Daily.Value;
            model.State = 0;

            if (!ChangePaper.Value.Contains("有无需求变更，在这里输入"))
            {
                Vi_PrjChangePaperModel changeModel = new Vi_PrjChangePaperModel();
                PrjChangePaperBLL changeBLL = new PrjChangePaperBLL();
                changeModel.State = 10;
                changeModel.summarize = ChangePaper.Value;
                changeModel.PrjID = prjID;
                changeModel.UserID = userID;
                //有需求变更
                changeContent = ChangePaper.Value;
                if (changeBLL.SaveChagePaper(changeModel))
                {
                    //nothing to do here!@
                }
            }

            if (daily.CheckDailyPaper(model))
            {
                lbl_msg.Text = "抱歉，你今天日报已提交请勿重复操作，如需请在0点以后再来添加。";
                Daily.Disabled = true;
                ChangePaper.Disabled = false;
                
                return;
            }

            if (daily.SendMail(senderList,lbl_Title.Text.Trim(),username,Daily.Value,changeContent))
            {
                model.State = 10;
            }
            if (daily.SaveDailyPaper(model))
            {
                lbl_msg.Text = "日报添加成功！";
                //Response.Redirect("DailyReportInfo.aspx?prjID=" + prjID);
            }
            else
            {
                lbl_msg.Text = "日报添加失败";
            }
        }

        private List<string> GetSenderList()
        {
            List<string> result = new List<string>();
            Vi_SysUserModel user = null;
            UserBLL userbll = new UserBLL();
            foreach (ListItem item in cbl_Attention.Items)
            {
                if (item.Selected)
                {
                    user = userbll.getUserModelByUserId(Convert.ToInt32(item.Value));
                    if (user != null) result.Add(user.Email);
                }
                else
                    user = null;
            }
            return result;
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("DailyReportInfo.aspx");
        }

    }
}