using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjectManage.Common
{
        public partial class ChooseUsersControl : System.Web.UI.UserControl
        {
                //public string ContainerID { get; set; }

                protected void Page_Load(object sender, EventArgs e)
                {
                        GetUsers();
                }

                /// <summary>
                /// 绑定用户
                /// </summary>
                private void GetUsers()
                {

                }

                protected void RepeaterUserItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
                {
                   
                }
        }
}