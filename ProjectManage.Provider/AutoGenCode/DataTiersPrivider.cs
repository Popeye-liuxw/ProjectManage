﻿
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Provider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace ProjectManage.Provider
{
    public  abstract partial class DataTiersProvider
	{
        public readonly Database db = DatabaseFactory.CreateDatabase("ConnectionString");
	}
}