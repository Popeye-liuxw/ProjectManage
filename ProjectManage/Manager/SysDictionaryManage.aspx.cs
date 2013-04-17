using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;

namespace ProjectManage.Manager
{
    public partial class SysDictionaryManage : System.Web.UI.Page
    {
        private SysDictionaryBll sysDictionary = new SysDictionaryBll();     
        private int index;
        private int itemIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            index = 1;
            itemIndex = 1;
            if (!IsPostBack)
            {
                SystemPermission permission = SystemLegalPowerBll.GetSystemPermission(2, 1);
                
                BoundGvList();
            }
        }

        private void BoundGvList()
        {
            this.gv_List.DataSource = sysDictionary.GetBigTypeAll();
            this.gv_List.DataBind();
        }


        protected void gv_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (index++).ToString();
            }
        }

        protected void btn_BigValue_Click(object sender, EventArgs e)
        {
            txt_BigValue.Text = sysDictionary.GetBigTypeValue();
        }

        protected void btn_Commit_Click(object sender, EventArgs e)
        {
            int bigTypeValue = 0;
            if (!int.TryParse(txt_BigValue.Text.Trim(),out bigTypeValue))
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('获取类型值错误，请重新获取!')", true);
                return;
            }

            if (txt_BigType.Text.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请输入类型名称!')", true);
                return;
            }
            MainTypeModel type = new MainTypeModel();
            type.TypeName = txt_BigType.Text;
            type.TypeValue = bigTypeValue;
            type.CreateTime = DateTime.Now;

            if (sysDictionary.SaveBigType(type))
            {
                BoundGvList();
                InitializeComponent();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('保存失败，请重试!')", true);
            }
        }
        #region 主类型操作按钮事件

        protected void btn_DeleteType_Click(object sender, EventArgs e)
        {

        }

        protected void btn_QueryType_Click(object sender, EventArgs e)
        {
            int id;
            LinkButton btn = sender as LinkButton;
            if (btn != null)
            {
                if (Int32.TryParse(btn.CommandArgument, out id))
                {
                    MainTypeModel mainType = sysDictionary.GetMainTypeModel(id);
                    if (mainType != null)
                    {
                        this.pnl_ItemList.Visible = true;
                        this.EditItemType.Visible = false;
                        BoundItemTypeList(mainType);                       
                    }
                    ViewState["MainType"] = mainType;
                }
            }
        }
        protected void btn_AddItemType_Click(object sender, EventArgs e)
        {
            int id;
            LinkButton btn = sender as LinkButton;
            if (btn != null)
            {
                if (Int32.TryParse(btn.CommandArgument, out id))
                {
                    MainTypeModel mainType = sysDictionary.GetMainTypeModel(id);
                    if (mainType != null)
                    {
                        this.pnl_ItemList.Visible = true;
                        this.EditItemType.Visible = true;
                        BoundItemTypeList(mainType);
                        InitializeComponent();                        
                    }
                    ViewState["MainType"] = mainType;
                }
            }
        }
        #endregion


        #region 值类型操作按钮事件

        protected void btn_CommitItemType_Click(object sender, EventArgs e)
        {
            int typevalue = 0;
            if (!int.TryParse(txt_ItemTypeValue.Text, out typevalue))
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请确保添加的类型值是数字!')", true);
                return;
            }
            if (txt_ItemTypeName.Text.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请添加类型名称!')", true);
                return;
            }
            MainTypeModel mainType = ViewState["MainType"] as MainTypeModel;
            if (mainType == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请确认该操作无误,系统没有获取到主类型相关内容！')", true);
                return;
            }

            if (sysDictionary.ExistsItemType(typevalue, mainType.TypeValue))
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('" + mainType.TypeName + "中已存在该值，请修改')", true);
                return; 
            }


            ItemTypeModel typeModel = ViewState["ItemType"] as ItemTypeModel;
            if (typeModel == null)
                typeModel = new ItemTypeModel();
            typeModel.TypeName = mainType.TypeName;
            typeModel.TypeValue = mainType.TypeValue;
            typeModel.ItemName = txt_ItemTypeName.Text;
            typeModel.ItemValue = typevalue;
            typeModel.CreateTime = DateTime.Now;
            if (sysDictionary.SaveItemType(typeModel))
            {
                BoundItemTypeList(mainType);
                InitializeComponent();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('保存失败，请重试!')", true);
            }
            ViewState["ItemType"] = null;
        }

        private void InitializeComponent()
        {
            this.txt_BigType.Text = string.Empty;
            this.txt_BigValue.Text = string.Empty;
            this.txt_ItemTypeName.Text = string.Empty;
            this.txt_ItemTypeValue.Text = string.Empty;
        }
        #endregion

        private void BoundItemTypeList(MainTypeModel mainType)
        {
            if (mainType == null) return;

            this.gv_ItemList.DataSource = sysDictionary.GetItemTypeAll(mainType.TypeValue);
            this.gv_ItemList.DataBind();
        }

        protected void gv_ItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (itemIndex++).ToString();
            }
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            EditItemType.Visible = false;
        }

        protected void btn_ItemEditType_Click(object sender, EventArgs e)
        {
            int id;
            LinkButton btn = sender as LinkButton;
            if (btn != null)
            {
                if (Int32.TryParse(btn.CommandArgument, out id))
                {
                    ItemTypeModel ItemType = sysDictionary.GetItemTypeModel(id);
                    if (ItemType != null)
                    {
                        txt_ItemTypeName.Text = ItemType.ItemName;
                        txt_ItemTypeValue.Text = ItemType.ItemValue.ToString();
                    }
                    ViewState["ItemType"] = ItemType;
                    EditItemType.Visible = true;
                }
            }
        }

    }
}