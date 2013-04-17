using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： PermissionModel.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/28 17:19:13
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.Model
{
    /// <summary>
    /// 权限对象
    /// </summary>
    public class PermissionModel
    {
        public PermissionModel(){ }

        public PermissionModel(bool read, bool write)
        {
            _read = read;
            _write = write;
        }

        private bool _read = false;

        public bool Read
        {
            get { return _read; }
            set { _read = value; }
        }

        private bool _write = false;

        public bool Write
        {
            get { return _write; }
            set { _write = value; }
        }        
    }
}
