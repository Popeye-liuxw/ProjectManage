using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： ModuleLevel.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/24 15:38:44
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Model
{
    [Serializable]
    public class ModuleLevel
    {
        public ModuleLevel(string name,int value)
        {
            this._levelName = name;
            this._levelValue = value;
        }

        private string _levelName;

        /// <summary>
        /// 等级名称
        /// </summary>
        public string LevelName
        {
            get { return _levelName; }
            set { _levelName = value; }
        }

        private int _levelValue;
        /// <summary>
        /// 等级值
        /// </summary>
        public int LevelValue
        {
            get { return _levelValue; }
            set { _levelValue = value; }
        }


    }
}
