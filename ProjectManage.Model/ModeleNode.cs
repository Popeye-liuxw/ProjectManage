using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： ModeleNode.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/24 14:21:06
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Model
{
    [Serializable]
    public class ModeleNode
    {
        private string _moduleName;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }

        private string _URL;

        /// <summary>
        /// 连接地址，相对路径
        /// </summary>
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        private string _moduleLevel;

        /// <summary>
        /// 模块等级
        /// </summary>
        public string ModuleLevel
        {
            get { return _moduleLevel; }
            set { _moduleLevel = value; }
        }

        private string _css = "off";
        /// <summary>
        /// 模块样式类名称
        /// </summary>
        public string Css
        {
            get { return _css; }
            set { _css = value; }
        }
    }
}
