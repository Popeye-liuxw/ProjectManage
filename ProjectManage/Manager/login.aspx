<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectManage.Manager.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>项目管理系统-管理登录</title>
    <link href="../style/login.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
       
         function RefreshImage() { var el = document.getElementById("pageValidatecode1"); el.src = el.src + '?'; }
         function check() {
             var username = document.getElementById("userName").value; var password = document.getElementById("userPwd").value; var Validatecode = document.getElementById("kaptcha").value;
             if (username == "") {
                 document.getElementById("lbl_msg").innerHTML = "用户名不能为空！";
                 return false;
             }
             if (password == "") {
                 document.getElementById("lbl_msg").innerHTML = "密码不能为空！";
                 return false;
             }
             if (Validatecode == "") {
                 document.getElementById("lbl_msg").innerHTML = "请输入验证码！";
                 return false;
             }
         }
    </script>
    <style type="text/css">
        *{margin:0px; padding:0px;}
       
        
    </style>
</head>
<body>
    <div id="iHeader">
    <div class="iLogo"></div>
    <span style="float:right; margin-top:30px; margin-right:10px;" >V<asp:Label ID="lbl_Version" runat="server">1.0.0.0</asp:Label></span>
</div>
<div id="iMain">
  <form id="form1" runat="server">
        <div class="loginBox">
            <h3><b>管理员登录</b></h3>
            <p><input type="text" runat="server"  class="text" name="userName" maxlength="20" id="userName"/></p>
            <p><input type="password" runat="server" maxlength="18" class="text" name="userPwd" id="userPwd" value="****"/></p>
             <p> <input type="text" runat="server" class="text" style="width:110px;" maxlength="4" name="kaptchafield" id="kaptcha" />
            
            	<img  id="pageValidatecode1" style="position:relative;top:11px;cursor: pointer; width:85px;height:30px;" title="验证码，点击换一张"  src="VerifyCode.aspx" onmouseup="RefreshImage()" alt="点击重刷新" /></p>
            <p class="clear">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btn_Login" CssClass="loginBoxbutton" runat="server" Text="快速登录" OnClientClick="return check();"  onclick="btn_Login_Click" /></p>
        </div>
    </form>
</div>
<div id="iFooter">
    <span>www.visione.com.cn &copy; 2012 京ICP备00000000号</span>
    <a href="#">关于卓视</a> · 
    <a href="#">联系我们</a> · 
    <a href="#">帮助中心</a>
</div>
</body>
</html>
