﻿
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysBackUserProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/6
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_SysBackUserProvider
    {
        public abstract Vi_SysBackUserModel getModelByManagerName(string mName);

	}
}