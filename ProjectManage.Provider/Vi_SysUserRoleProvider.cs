
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserRoleProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/15
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public abstract partial class Vi_SysUserRoleProvider : DataTiersProvider
    {
        public abstract IList<Vi_SysUserRoleModel> GetUserRolesByUserId(int UserID);
        public abstract int IsExistPosiByUserIDAndRoleId(int UserId,int PosiId);
	}
}