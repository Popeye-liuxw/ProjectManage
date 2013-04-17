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
    public partial class DailyReportItemInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] == null)
            {
                Response.Write("你的请求服务器不做处理,不能查看日报信息");
                Response.End();
            }
            if (!IsPostBack)
            {
                int id;
                string tmp =Request.QueryString["key"].ToString();
                string key = tmp.Remove(tmp.IndexOf("kec"));
                if (int.TryParse(key, out id))
                {
                    BindDailyReport(id); 
                }
                else
                {
                    tip.Visible = true;
                    lbl_Tip.Text = "你的请求服务器不做处理,不能查看该日报信息";
                }
            }
        }
        private void BindDailyReport(int Id)
        {
            if (Id <= 0) return;
            DailyPaperBLL dailyBll = new DailyPaperBLL();
            List<Vi_PrjDailyPaperModel> models = new List<Vi_PrjDailyPaperModel>();
            Vi_PrjDailyPaperModel model = dailyBll.GetPrjDailyPaperModel(Id);
            if (model != null) models.Add(model);
            rpt_Daily.DataSource = models;
            rpt_Daily.DataBind();
            if (model != null)
            {
                SysProjectBll prj = new SysProjectBll();
                Vi_ProjectInfoModel project = prj.GetProjectInfoModel(model.PrjID);
                if (project != null)
                {
                    lbl_Title.Text = project.citemname;
                }
            }
            else
            {
                lbl_Title.Text = "获取标题失败";
            }
            
        }
    }
}