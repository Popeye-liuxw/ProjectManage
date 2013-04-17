// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysSendEmailModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_SysSendEmail数据实体
	/// </summary>
	[Serializable]
	public class Vi_SysSendEmailModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///邮件标题
		///</summary>
		private string _mailTitle = String.Empty;
		///<summary>
		///邮件内容
		///</summary>
		private string _mailContent = String.Empty;
		///<summary>
		///邮件地址
		///</summary>
		private string _email = String.Empty;
		///<summary>
		///重新发送时间
		///</summary>
		private DateTime _resendTime;
		///<summary>
		///1 准备发送
        ///4 取消发送
        ///10 发送完成
		///</summary>
		private int _sendState;
		///<summary>
		///
		///</summary>
		private int _userID;
		///<summary>
		///
		///</summary>
		private DateTime _createTime;
		///<summary>
		///
		///</summary>
		private DateTime _updateTime;
		#endregion
		
		#region 构造函数
		///<summary>
		///邮件发送记录表
		///</summary>
		public Vi_SysSendEmailModel()
		{
		}
		///<summary>
		///邮件发送记录表
		///</summary>
		public Vi_SysSendEmailModel
		(
			int iD,
			string mailTitle,
			string mailContent,
			string email,
			DateTime resendTime,
			int sendState,
			int userID,
			DateTime createTime,
			DateTime updateTime
		)
		{
			_iD          = iD;
			_mailTitle   = mailTitle;
			_mailContent = mailContent;
			_email       = email;
			_resendTime  = resendTime;
			_sendState   = sendState;
			_userID      = userID;
			_createTime  = createTime;
			_updateTime  = updateTime;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public int ID
		{
			get {return _iD;}
			set {_iD = value;}
		}

		///<summary>
		///邮件标题
		///</summary>
		public string MailTitle
		{
			get {return _mailTitle;}
			set {_mailTitle = value;}
		}

		///<summary>
		///邮件内容
		///</summary>
		public string MailContent
		{
			get {return _mailContent;}
			set {_mailContent = value;}
		}

		///<summary>
		///邮件地址
		///</summary>
		public string Email
		{
			get {return _email;}
			set {_email = value;}
		}

		///<summary>
		///重新发送时间
		///</summary>
		public DateTime ResendTime
		{
			get {return _resendTime;}
			set {_resendTime = value;}
		}

		///<summary>
		///1 准备发送
        ///4 取消发送
        ///10 发送完成
		///</summary>
		public int SendState
		{
			get {return _sendState;}
			set {_sendState = value;}
		}

		///<summary>
		///
		///</summary>
		public int UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
	
		#endregion
	}
}
