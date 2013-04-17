using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.BLL;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： SysModuleBLL.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/24 10:41:10
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{    
    /// <summary>
    /// 系统菜单，通用模块管理
    /// </summary>
    public class SysModuleBLL
    {
        private Vi_SysModulesProvider _SysModule;

        public SysModuleBLL()
        {
            _SysModule = DataFactory.CreateVi_SysModulesSqlPrivider();
        }

        /// <summary>
        /// 得到菜单等级
        /// </summary>
        /// <returns></returns>
        public List<ModuleLevel> GetModuleLevels()
        {
            List<ModuleLevel> levels = new List<ModuleLevel>(2);
            levels.Add(new ModuleLevel("一级栏目", 100));
            levels.Add(new ModuleLevel("二级栏目", 200));
            return levels;
        }

        /// <summary>
        /// 得到一级节点集合列表
        /// </summary>
        /// <returns></returns>
        public List<Vi_SysModulesModel> GetFirstModuleNodes()
        {
            List<Vi_SysModulesModel> modules = new List<Vi_SysModulesModel>();

            modules = _SysModule.FirstModuleNodes().ToList();

            return modules;
        }

        /// <summary>
        /// 得到子节点集合列表
        /// </summary>
        /// <param name="moduleNum"></param>
        /// <returns></returns>
        public List<Vi_SysModulesModel> GetChildModuleNodes(string moduleNum)
        {
            List<Vi_SysModulesModel> modules;

            if (moduleNum == null || moduleNum == string.Empty)
                modules = new List<Vi_SysModulesModel>();
            else
                modules = _SysModule.ChildModuleNodes(moduleNum).ToList();

            return modules;
        }
        /// <summary>
        /// 保存菜单节点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveModuleNode(Vi_SysModulesModel model)
        {
            bool result = false;
            if(model != null)
            {
                int temp = 0;
                if (model.ID > 0)
                    temp = _SysModule.UpdateVi_SysModules(model);
                else
                    temp = _SysModule.SaveVi_SysModules(model);
                if (temp > 0) result = true;
            }
            return result;
        }
       
        /// <summary>
        /// 获取某个菜单节点对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Vi_SysModulesModel GetMouduleNode(string ID)
        {
            Vi_SysModulesModel model = new Vi_SysModulesModel();
            int id = 0;
            if (int.TryParse(ID, out id))
            {
                model = _SysModule.Get_Vi_SysModulesModel(id);
            }
            return model;
        }

        /// <summary>
        /// 获取模块节点标志号
        /// </summary>
        /// <param name="moduleLevel">当前级数</param>
        /// <param name="level">模块等级对象</param>
        /// <returns></returns>
        private string convertNodeNum(string moduleLevel, ModuleLevel level)
        {
            string result = string.Empty;
            int Ilevel = 1;
            int item = 1;

            if (level.LevelValue == (int)TypeLeve.ItemType)//一级栏目
            {
                if (moduleLevel == string.Empty) result = string.Format("{0:00}", Ilevel);
                else
                {
                    if (int.TryParse(moduleLevel, out Ilevel))
                    {
                        Ilevel++;
                        result = string.Format("{0:00}", Ilevel);
                    }
                }
            }
            if (level.LevelValue == (int)TypeLeve.BigType)//二级栏目
            {
                if (moduleLevel == string.Empty) result = string.Format("{0:00}|{1:00}", Ilevel, item);
                else
                {
                    string[] str = moduleLevel.Split('|');
                    if (str.Length == 2)
                    {
                        if (int.TryParse(str[0], out Ilevel) && int.TryParse(str[1], out item))
                        {
                            item++;
                            result = string.Format("{0:00}|{1:00}", Ilevel, item);
                        }
                    }
                    else
                    {
                        if (int.TryParse(moduleLevel, out Ilevel))
                        {
                            result = string.Format("{0:00}|{1:00}", Ilevel, item);//第一次节点编号
                        }
                    }
                }
            }
            
            return result;
        }
        /// <summary>
        /// 获取模块编号表示形式如：02
        /// </summary>
        /// <param name="moduleLevel"></param>
        /// <returns></returns>
        public string GetModuleNum(string moduleLevel)
        {
            string result = string.Empty;

            if (moduleLevel.Length > 3)
            {
                string[] str = moduleLevel.Split('|');
                if (str.Length == 2)
                {
                    int temp = 0;
                    if (int.TryParse(str[0], out temp))
                    {
                        result = str[0];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取模块等级，表示形式如：01|02
        /// </summary>
        /// <param name="moduleLevel"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetModuleLevel(string moduleLevel, ModuleLevel level)
        {
            string result = string.Empty;

            if (moduleLevel == string.Empty || moduleLevel == "-1")
            {
                if (level.LevelValue == (int)TypeLeve.ItemType)
                {

                    string temp = _SysModule.GetModuleLevelDesc();
                    result = convertNodeNum(temp, level);
                }
                if (level.LevelValue == (int)TypeLeve.BigType)
                {
                    if (moduleLevel == "-1") moduleLevel = string.Empty;
                    result = convertNodeNum(moduleLevel,level);
                }
            }
            else
            {
                if (level.LevelValue == (int)TypeLeve.BigType)
                {

                    string temp = _SysModule.GetModuleLevelNodeDesc(moduleLevel);

                    if (temp == string.Empty)
                        result = convertNodeNum(moduleLevel, level);
                    else
                        result = convertNodeNum(temp, level);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取子菜单节点数据包括节点样式
        /// </summary>
        /// <param name="menu">模块ID，如果为0,默认选中第一项</param>
        /// <param name="ModuleNum">模块编号</param>
        /// <param name="QueryString">形如prjID=2,需要加链接符</param>
        /// <returns></returns>        
        public List<ModeleNode> GetChildMenuNodes(int menu, string ModuleNum, string QueryString)
        {
            List<ModeleNode> result = new List<ModeleNode>();
            List<Vi_SysModulesModel> modules = GetChildModuleNodes(ModuleNum);
            result.Add(new ModeleNode());
            foreach (Vi_SysModulesModel item in modules)
            {
                ModeleNode node = new ModeleNode();
                node.ModuleName = item.ModuleName;
                if (QueryString.IndexOf('&')==0)
                    node.URL = string.Format("{0}?sys=menu{1}", item.URL, QueryString);
                else
                    node.URL = item.URL;
                if (item.ID == menu)node.Css = "on";
                result.Add(node);
            }
            result.Add(new ModeleNode());
            int tmp = result.Where(n => n.Css == "on").Count();
            if (tmp == 0 && result.Count > 0) result[1].Css = "on";
            return result;
        }
    }
}
