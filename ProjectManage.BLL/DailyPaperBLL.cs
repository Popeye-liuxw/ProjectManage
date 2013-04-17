using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using System.Data;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： DailyPaperBLL.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/10 14:47:24
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 日报操作
    /// </summary>
    public class DailyPaperBLL
    {
        private Vi_PrjDailyPaperProvider dailySql;

        public DailyPaperBLL()
        {
            dailySql = DataFactory.CreateVi_PrjDailyPaperSqlPrivider();
        }
        /// <summary>
        /// 保存日报内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveDailyPaper(Vi_PrjDailyPaperModel model)
        {
            bool result = false;
            int temp = dailySql.SaveVi_PrjDailyPaper(model);
            if (temp > 0) result = true;
            return result;
        }
        /// <summary>
        /// 检测当天是否添加了日报
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true 已经添加 false 未添加</returns>
        public bool CheckDailyPaper(Vi_PrjDailyPaperModel model)
        {
            bool result = false;
            if (model != null)
            {
                Vi_PrjDailyPaperModel temp = dailySql.GetPrjDailyPaperInfo(model.PrjID, model.UserID, DateTime.Now);
                if (temp != null) result = true;
            }
            return result;
        }

        /// <summary>
        /// 发送邮件通知
        /// </summary>
        /// <param name="add">收件人邮箱</param>
        /// <param name="prjName">项目名称</param>
        /// <param name="userName">人员姓名</param>
        /// <param name="dailyContent">日报内容</param>
        /// <param name="changePaper">需求变更内容</param>
        /// <returns></returns>
        public bool SendMail(List<string> add, string prjName, string userName, string dailyContent, string changePaper)
        {
            SysMailSenderBll mail = new SysMailSenderBll();
            StringBuilder mailcontent = new StringBuilder(200);
            string title = "项目日报";
            if (!string.IsNullOrEmpty(prjName))
                title = string.Format("{0} {1} 日报 {2}", userName, prjName, DateTime.Now.ToString("yyyy年MM月dd日"));
            //mailcontent.Append("<div style='width:98%;margin:20px;'>");
            //mailcontent.AppendFormat("      <h2 style='font-size:12px;color:#FFF;line-height:30px;height:30px;width:100%;background:#486AAA;padding-left:12px;margin:0px;'>{0} 项目日报内容如下:</h2>", prjName);
            //mailcontent.AppendFormat("      <div style='width:100%;border:#ddd 1px solid;padding:20px 0px 20px 12px;'>{0}</div>", dailyContent);
            //mailcontent.Append("</div>");
            mailcontent.AppendFormat("      <h2 style='font-size:12px;color:#FFF;line-height:30px;height:30px;width:100%;background:#486AAA;padding-left:12px;margin:0px;'>{0} 项目日报内容如下:</h2>", prjName);
            mailcontent.AppendLine(dailyContent);
            if (!string.IsNullOrEmpty(changePaper))
            {
                //需求变更
                //mailcontent.Append("<div style='width:98%;margin:20px;'>");
                //mailcontent.AppendFormat("      <h2 style='font-size:12px;color:#FFF;line-height:30px;height:30px;width:100%;background:#486AAA;padding-left:12px;margin:0px;'>{0} 项目需求变更如下:</h2>", prjName);
                //mailcontent.AppendFormat("      <div style='width:100%;border:#ddd 1px solid;padding:20px 0px 20px 12px;'>{0}</div>", changePaper);
                //mailcontent.Append("</div>");  
                mailcontent.AppendLine("<br/>");
                mailcontent.AppendFormat("      <h2 style='font-size:12px;color:#FFF;line-height:30px;height:30px;width:100%;background:#486AAA;padding-left:12px;margin:0px;'>{0} 项目需求变更如下:</h2>", prjName);
                mailcontent.AppendLine(changePaper);
            }

            return mail.SenderEMailMessage(add, title, mailcontent);
        }

        /// <summary>
        /// 获取指定项目最近一段时间的日报内容
        /// </summary>
        /// <param name="prjId">项目ID</param>
        /// <param name="top">条目数</param>
        /// <returns></returns>
        public List<Vi_PrjDailyPaperModel> GetPrjDailyPaperModel(int prjId,int userId, int top)
        {
            List<Vi_PrjDailyPaperModel> models = new List<Vi_PrjDailyPaperModel>();
            if (top <= 0) top = 10;
            models = dailySql.GetPrjDailyPaper(prjId,userId, top).ToList();
            return models;
        }
        /// <summary>
        /// 获取指定日报内容
        /// </summary>
        /// <param name="prjId">日报ID</param>        
        /// <returns></returns>
        public Vi_PrjDailyPaperModel GetPrjDailyPaperModel(int id)
        {
            Vi_PrjDailyPaperModel model = null;
            if (id > 0)
                model = dailySql.Get_Vi_PrjDailyPaperModel(id);
            return model;
        }
        /// <summary>
        /// 获取指定项目最近一段时间的需求变更内容
        /// </summary>
        /// <param name="prjId">项目ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="top">条目数</param>
        /// <returns></returns>
        public List<Vi_PrjChangePaperModel> GetPrjChangePaperModel(int prjId, int userId, int top)
        {
            List<Vi_PrjChangePaperModel> models = new List<Vi_PrjChangePaperModel>();
            if (top <= 0) top = 10;
            Vi_PrjChangePaperProvider changeSql = DataFactory.CreateVi_PrjChangePaperSqlPrivider();
            if (changeSql != null)
            {
                models = changeSql.GetPrjChangePaper(prjId, userId, top).ToList();
            }
            return models;
        }

        /// <summary>
        /// 获取工作日天数
        /// </summary>
        /// <param name="dt1">起始日期</param>
        /// <param name="dt2">结束日期</param>
        /// <returns></returns>
        public int getDays(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts1 = dt1.Subtract(dt2);//TimeSpan得到dt1和dt2的时间间隔
            int countday = ts1.Days;//获取两个日期间的总天数
            int weekday = 0;//工作日
            //循环用来扣除总天数中的双休日
            for (int i = 0; i < countday; i++)
            {
                DateTime tempdt = dt1.Date.AddDays(i);
                if (tempdt.DayOfWeek != System.DayOfWeek.Saturday && tempdt.DayOfWeek != System.DayOfWeek.Sunday)
                {
                    weekday++;
                }
            }
            return weekday;
        }
        /// <summary>
        /// 获取当月的工作日天数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int getDays(DateTime dt)
        {
            DateTime dt1 = new DateTime(dt.Year, dt.Month, 1);
            int countday = DateTime.DaysInMonth(dt.Year, dt.Month);//获取当前月的总天数
            int weekday = 0;//工作日
            //循环用来扣除总天数中的双休日
            for (int i = 0; i < countday; i++)
            {
                DateTime tempdt = dt1.Date.AddDays(i);
                if (tempdt.DayOfWeek != System.DayOfWeek.Saturday && tempdt.DayOfWeek != System.DayOfWeek.Sunday)
                {
                    weekday++;
                }
            }
            return weekday;
        }

        public DataTable GetPrjMonthModel(string userID, string Month,string Year)
        {
            DataTable result = new DataTable();
            int userid, month, year;
            if (int.TryParse(userID, out userid) && int.TryParse(Month, out month) && int.TryParse(Year,out year))
            {
                result = dailySql.GetMonthDataTable(userid, month, year);
            }
            return result;
        }
    }
}
