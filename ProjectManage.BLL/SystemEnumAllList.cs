using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManage.BLL
{
    // =================================================================== 
    // 公共用枚举定义说明
    //====================================================================
    // visione @ CopyRight 2007-2012
    // 文件： SystemEnumAllList.cs
    // 项目名称：ProjectManageSystem 
    // 创建时间：2012/8/15
    // 负责人：Popeye_lxw
    // ===================================================================




    /// <summary>
    /// 系统权限
    /// </summary>
    public enum SystemPermission
    {
        /// <summary>
        /// 未设置
        /// </summary>
        Other = 0,
        /// <summary>
        /// 读权限
        /// </summary>
        Read = 10,
        /// <summary>
        /// 写权限
        /// </summary>
        Write = 20,
    }
    /// <summary>
    /// 类型等级
    /// </summary>
    public enum TypeLeve
    {
        /// <summary>
        /// 子类型
        /// </summary>
        ItemType = 100,
        /// <summary>
        /// 总类型
        /// </summary>
        BigType = 200,
    }
    /// <summary>
    /// 邮件配置状态
    /// </summary>
    public enum EmailState
    {
        /// <summary>
        /// 未启用
        /// </summary>
        NO = 0,
        /// <summary>
        /// 已启用
        /// </summary>
        OK = 10,        
    }
    /// <summary>
    /// 发送状态
    /// </summary>
    public enum SendEmailState
    {
        /// <summary>
        /// 发送完成
        /// </summary>
        OK = 10,
        /// <summary>
        /// 取消发送
        /// </summary>
        Cancel = 4,
        /// <summary>
        /// 准备发送
        /// </summary>
        Ready = 1,
    }
    
}
