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
    public partial class SysModulesManage : System.Web.UI.Page
    {
        private SysModuleBLL sysModule = new SysModuleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindModuleLevel();
                BindFirstModule();
                BindTreeView();
            }
        }

        private void BindFirstModule()
        {
            ddl_ModuleFirst.DataSource = sysModule.GetFirstModuleNodes();
            ddl_ModuleFirst.DataTextField = "ModuleName";
            ddl_ModuleFirst.DataValueField = "ModuleLevel";
            ddl_ModuleFirst.DataBind();
            ddl_ModuleFirst.Items.Insert(0,new ListItem("--请选择--", "-1"));
            ddl_ModuleFirst.SelectedIndex = 0;
        }


        private void BindTreeView()
        {
            List<Vi_SysModulesModel> firstModules = sysModule.GetFirstModuleNodes();
            List<Vi_SysModulesModel> childModules = null;
            tree_Modules.Nodes.Clear();
            TreeNodeCollection TreeNodes = tree_Modules.Nodes;

            TreeNode firstModule = null;
            TreeNode childModule = null;
            foreach (Vi_SysModulesModel item in firstModules)
            {
                firstModule = new TreeNode(item.ModuleName, item.ID.ToString());
                //firstModule.NavigateUrl = item.URL;
                childModules = sysModule.GetChildModuleNodes(item.ModuleLevel);

                foreach (Vi_SysModulesModel childNode in childModules)
                {
                    childModule = new TreeNode(childNode.ModuleName, childNode.ID.ToString());
                    //childModule.NavigateUrl = childNode.URL;                    
                    
                    firstModule.ChildNodes.Add(childModule);
                }

                TreeNodes.Add(firstModule);
            }

        }

        private void BindModuleLevel()
        {            
            this.ddl_ModuleLevel.DataSource = sysModule.GetModuleLevels();
            this.ddl_ModuleLevel.DataTextField = "LevelName";
            this.ddl_ModuleLevel.DataValueField = "LevelValue";
            this.ddl_ModuleLevel.DataBind();
        }


        private void InitializeComponent()
        {
            txt_Name.Value = string.Empty;
            txt_Url.Value = string.Empty;
            ddl_ModuleFirst.SelectedIndex = 0;
            ViewState["ModuleNode"] = null;
        }

        protected void ddl_ModuleLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_ModuleLevel.SelectedValue == "200")
            {
                ddl_ModuleFirst.Visible = true;
                BindFirstModule();
            }
            else
                ddl_ModuleFirst.Visible = false;
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {              
            if (txt_Name.Value.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请输入模块名称')", true);
                return;
            }
            if (txt_Url.Value.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请输入模块连接地址')", true);
                return;
            }
            if (ddl_ModuleLevel.SelectedValue == "200" && ddl_ModuleFirst.SelectedValue == "-1")
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('请选择要添加到那级栏目！')", true);
                return;
            }

            Vi_SysModulesModel modules = new Vi_SysModulesModel();
            if (ViewState["ModuleNode"] != null)
            {
                string id = ViewState["ModuleNode"] as string;
                modules = sysModule.GetMouduleNode(id);
                modules.ModuleName = txt_Name.Value;
                modules.URL = txt_Url.Value;
            }
            else
            {
                modules.ModuleName = txt_Name.Value;
                modules.URL = txt_Url.Value;
                modules.ModuleLevel = sysModule.GetModuleLevel(ddl_ModuleFirst.SelectedValue, new ModuleLevel(ddl_ModuleLevel.SelectedItem.Text, int.Parse(ddl_ModuleLevel.SelectedItem.Value)));
                modules.ModuleNum = sysModule.GetModuleNum(modules.ModuleLevel);
            }
            if (sysModule.SaveModuleNode(modules))
            {
                BindTreeView();
                InitializeComponent();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('保存菜单失败！')", true);
            }
        }

        protected void tree_Modules_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = tree_Modules.SelectedNode;
            Vi_SysModulesModel module = sysModule.GetMouduleNode(node.Value);
            if (module != null)
            {
                txt_Name.Value = module.ModuleName;
                txt_Url.Value = module.URL;
                if (module.ModuleNum == string.Empty)
                {
                    ddl_ModuleLevel.SelectedIndex = 0;
                    ddl_ModuleFirst.Visible = false;
                    
                }
                else
                {
                    ddl_ModuleLevel.SelectedIndex = 1;
                    ddl_ModuleFirst.SelectedValue = module.ModuleNum;
                    ddl_ModuleFirst.Visible = true;
                }
                ddl_ModuleLevel.Enabled = false;
                ddl_ModuleFirst.Enabled = false;
            }

            string str = node.Text;
            ViewState["ModuleNode"] = node.Value;
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            ddl_ModuleFirst.Enabled = true;
            ddl_ModuleLevel.Enabled = true;
        }
    }
}