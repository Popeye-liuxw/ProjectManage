using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Common;

namespace ProjectManage
{
        public partial class Main : System.Web.UI.Page
        {
                #region QueryString
                //public ProjectBasicInfoQueryEntity ProjectQueryEntity
                //{
                //        get
                //        {
                //                string queryString = Request["QueryString"];
                //                if (!string.IsNullOrEmpty(queryString))
                //                {
                //                        return SerializerHelper.Dseruakuzer<ProjectBasicInfoQueryEntity>(queryString);
                //                }
                //                return new ProjectBasicInfoQueryEntity();
                //        }
                //}
                #endregion
                protected void Page_Load(object sender, EventArgs e)
                {
                        CssControl.SwitchCSS(this.Page, "style/tableoper.css");
                        JsControl.SwitchJS(this.Page, "js/png.js");
                        JsControl.SwitchJS(this.Page, "js/tablecolor.js");

                        if (!IsPostBack)
                        {
                              GetProjectBasicInfoList();
                        }
                }


                #region 主体业务
                private void GetProjectBasicInfoList()
                {
                        //ProjectBasicInfoQueryEntity queryEntity = new ProjectBasicInfoQueryEntity();
                        //queryEntity.ContractNumber = "1234567890";
                        //queryEntity.PageInfo.PageSize = 1;
                        //queryEntity.PageInfo.PageCurrent = 0;
                        //QueryResultList<ProjectBasicInfoEntity> resultList = new ProjectBasicInfoBP().GetProjectbasicInfoList(queryEntity);
                }
                #endregion
        }
}