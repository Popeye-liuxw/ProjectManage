using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： ItemTypeModel.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/21 18:05:35
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Model
{
    [Serializable]
    public class ItemTypeModel
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _itemValue;

        public int ItemValue
        {
            get { return _itemValue; }
            set { _itemValue = value; }
        }

        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        private int _TypeValue;

        public int TypeValue
        {
            get { return _TypeValue; }
            set { _TypeValue = value; }
        }

        private string _TypeName;

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        private DateTime _createTime;

        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
    }
}
