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
    public partial class QuickAddDaily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["UserId"] != null)
                {

                    int userid = Convert.ToInt32(Session["UserId"]);                    
                    ViewState["userID"] = userid;
                    ViewState["userName"] = Session["RealName"].ToString();                   
                    lbl_Title.Text = "请选择项目";
                    BindUser();
                    BindProjectDDL(userid);    
                }
                else
                {
                    Response.Write("请勿非法访问本页面！");
                    Response.End();
                }            
            }
        }

        private void BindProjectDDL(int userID)
        {
            SysProjectBll prjBLL = new SysProjectBll();
            ddl_PrjName.DataSource = prjBLL.GetProjectInfoByUser(userID);
            ddl_PrjName.DataTextField = "citemname";
            ddl_PrjName.DataValueField = "id";
            ddl_PrjName.DataBind();
            ddl_PrjName.Items.Insert(0, new ListItem("请选择", "-1"));
            ddl_PrjName.Items[0].Selected = true;
        }

        private void BindUser()
        {
            UserBLL user = new UserBLL();
            cbl_Attention.DataSource = user.getAllUsers();
            cbl_Attention.DataTextField = "RealName";
            cbl_Attention.DataValueField = "ID";
            cbl_Attention.DataBind();
        }
        private void InitializeDaily()
        {
            Daily.Value = "在这里输入当天工作情况总结";
            ChangePaper.Value = "有无需求变更，在这里输入";
            lbl_msg.Text = string.Empty;
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (lbl_msg.Text == "日报添加成功") return;
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
            if (ddl_PrjName.SelectedValue == "-1")
            {
                lbl_msg.Text = "亲，你还没有选择日报项目";
                return;
            }

            string changeContent = string.Empty;
            string username = "未知人员";
            int userID = Convert.ToInt32(ViewState["userID"]);
            int prjID = Convert.ToInt32(ddl_PrjName.SelectedValue);
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

            if (daily.SendMail(senderList, lbl_Title.Text.Trim(), username, Daily.Value, changeContent))
            {
                model.State = 10;
            }
            if (daily.SaveDailyPaper(model))
            {
                lbl_msg.Text = "日报添加成功";
                Daily.Disabled = true;
                ChangePaper.Disabled = false;
            }
            else
            {
                lbl_msg.Text = "日报添加失败";
            }
        }

        protected void ddl_PrjName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = ddl_PrjName.SelectedItem;
            if (item != null)
            {
                InitializeDaily();
                if (item.Value == "-1")
                {
                    lbl_Title.Text = "请选择项目";
                    BindUser();
                }
                else
                {
                    lbl_Title.Text = item.Text;
                    FindProject(Convert.ToInt32(item.Value));
                }
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

        private void FindProject(int prjid)
        {
            if (prjid > 0)
            {
                SysProjectBll proje = new SysProjectBll();
                /*
                Vi_SysUserModel prjUser = proje.getProMangerByProId(prjid);
                if (prjUser != null)
                {
                    
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
                            else
                            {
                                item.Selected = false;
                                item.Enabled = true;
                            }
                        }
                    }
                }
            }
        }
    }
}