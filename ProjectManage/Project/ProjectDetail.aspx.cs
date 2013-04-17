using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using System.Data;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Pages.ProjectBasicinfo
{
    /// <summary>
    /// 调整页面权限 2012/9/18
    /// by lxw
    /// </summary>
    public partial class ProjectDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }
            if (Request.QueryString["prjID"] == null)
            {
                Response.Redirect("ProjectBasicInfoManagement.aspx");
                return;
            }
            if (!IsPostBack)
            {
                string prjid = Request.QueryString["prjID"].ToString();
                string userid = Session["UserId"].ToString();
                spn_Menu.QueryString = "&prjID=" + prjid;
                spn_Menu.MenuID = 3; //项目概况
                try
                {
                    int prjID = int.Parse(prjid);
                    int userID = int.Parse(userid);
                    btn_Edite.Visible = false;
                    SysProjectBll prj = new SysProjectBll();
                    if (prj.getAllProjectWithUser(userID, prjID))
                    {
                        SystemPermission permission = SystemLegalPowerBll.GetSystemPermission(userID, spn_Menu.MenuID);
                        if (permission == SystemPermission.Read || permission == SystemPermission.Write)
                        {
                            if (permission == SystemPermission.Write)
                            {
                                btn_Edite.Visible = true;
                            }
                            BindProDetail(prjID);
                        }
                        else
                        {
                            tip.Visible = true;
                            lbl_Tip.Text = "你的系统权限不够,不能查看项目概况信息";
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
                ViewState["userName"] = Session["RealName"] as string;
                ViewState["prjID"] = prjid;

                //编写页面权限判断
            }
        }
        public void BindProDetail(int ProId)
        {
            SysProjectBll bll = new SysProjectBll();
            StringBuilder Responsible = new StringBuilder(200);
            DataTable dtProDetail = bll.getProDetailByProId(ProId);
            lbl_ProName.Text = dtProDetail.Rows[0]["citemname"].ToString();//绑定项目名称
            repProDetail.DataSource = dtProDetail;
            repProDetail.DataBind();
            /*
            Vi_SysUserModel visum  = bll.getProMangerByProId(ProId);
            if (visum != null)
                lbl_PM.Text = visum.RealName.ToString();
            */
            lbl_CreateTime.Text = dtProDetail.Rows[0]["CreateTime"].ToString();
            lbl_LastUpdateTime.Text = dtProDetail.Rows[0]["UpdateTime"].ToString();
            if(dtProDetail.Rows[0]["RealName"].ToString() == "")
            {
                lbl_UpdatePerson.Text ="暂未设置";
            }
            else
            {
                lbl_UpdatePerson.Text = dtProDetail.Rows[0]["RealName"].ToString();
            }
            //得到项目负责人信息
            if (dtProDetail.Rows[0]["DeveloperRec"].ToString() == "") Responsible.Append("研发负责人：暂未设置 ");
            else
                Responsible.AppendFormat("研发负责人：{0} ", bll.GetUserNameByID(dtProDetail.Rows[0]["DeveloperRec"].ToString()));
            if (dtProDetail.Rows[0]["TesterRec"].ToString() == "") Responsible.Append("&nbsp;&nbsp;测试负责人：暂未设置 ");
            else
                Responsible.AppendFormat("&nbsp;&nbsp;测试负责人：{0} ", bll.GetUserNameByID(dtProDetail.Rows[0]["TesterRec"].ToString()));
            if (dtProDetail.Rows[0]["MarketRec"].ToString() == "") Responsible.Append("&nbsp;&nbsp;市场负责人：暂未设置 ");
            else
                Responsible.AppendFormat("&nbsp;&nbsp;市场负责人：{0} ", bll.GetUserNameByID(dtProDetail.Rows[0]["MarketRec"].ToString()));

            lbl_Responsible.Text = Responsible.ToString();

            //得到项目开发人员
            DataTable dt_Dev = new DataTable();
            dt_Dev = bll.getUserListbyUserType(ProId, " Vi_DeveloperRec ");
            DataTable dt_Test = new DataTable();
            dt_Test = bll.getUserListbyUserType(ProId, " Vi_TesterRec ");
            DataTable dt_Market = new DataTable();
            dt_Market = bll.getUserListbyUserType(ProId, " Vi_MarketRec ");
            if(dt_Dev.Rows.Count ==0)
            {
                lbl_Dev.Text = "暂未分配";
            }
            else
            {
                for (int i = 0; i < dt_Dev.Rows.Count; i++)
                {
                    lbl_Dev.Text = lbl_Dev.Text + dt_Dev.Rows[i]["RealName"].ToString() + "、";
                }
                lbl_Dev.Text = lbl_Dev.Text.Substring(0, lbl_Dev.Text.Length - 1);
            }
            if (dt_Test.Rows.Count == 0)
            {
                lbl_Tester.Text = "暂未分配";
            }
            else
            {
                for (int x = 0; x < dt_Test.Rows.Count; x++)
                {
                    lbl_Tester.Text = lbl_Tester.Text + dt_Test.Rows[x]["RealName"].ToString() + "、";
                }
                lbl_Tester.Text = lbl_Tester.Text.Substring(0, lbl_Tester.Text.Length - 1);
            }
            if (dt_Market.Rows.Count == 0)
            {
                lbl_Market.Text = "暂未分配";
            }
            else
            {
                for (int y = 0; y < dt_Market.Rows.Count; y++)
                {
                    lbl_Market.Text = lbl_Market.Text + dt_Market.Rows[y]["RealName"].ToString() + "、";
                }
                lbl_Market.Text = lbl_Market.Text.Substring(0, lbl_Market.Text.Length - 1);
            }
            int ProPerCount = dt_Dev.Rows.Count + dt_Test.Rows.Count + dt_Market.Rows.Count;
            lbl_CounPer.Text = "该项目一共分配 " + ProPerCount + " 人。其中研发人员 " + dt_Dev.Rows.Count + " 人，测试人员 " + dt_Test.Rows.Count + " 人，商务人员 " + dt_Market.Rows.Count + " 人。";

        }

        protected void btn_Edite_Click(object sender, EventArgs e)
        {
            if (ViewState["prjID"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "tip", "alert('获取项目信息失败')", true);
                return;
            }
            Response.Redirect("ProjectDetailEdit.aspx?prjID=" + ViewState["prjID"].ToString());
        }
    }
}