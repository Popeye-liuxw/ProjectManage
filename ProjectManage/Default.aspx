<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableEventValidation="false"
    EnableViewStateMac="false" Inherits="ProjectManage.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目管理系统-用户登录</title>
    <link href="style/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var ie = (function () {
            var undef,
	        v = 3,
	        test = document.createElement('div'),
	        all = test.getElementsByTagName('i');
            while (
	            test.innerHTML = '<!--[if gt IE ' + (++v) + ']><i></i><![endif]-->',
	            all[0]);
            return v > 4 ? v : undef;
        })();
        function RefreshImage() { var el = document.getElementById("pageValidatecode1"); el.src = el.src + '?'; }
        function check() {
            var username = document.getElementById("userName").value; var password = document.getElementById("userPwd").value; var Validatecode = document.getElementById("kaptcha").value;
            if (username == "" || username == "请输入真实姓名或用户名") {
                document.getElementById("lbl_msg").innerHTML = "用户名不能为空！";
                return false;
            }
            if (password == "" || password == "****") {
                document.getElementById("lbl_msg").innerHTML = "密码不能为空！";
                return false;
            }
            if (Validatecode == "") {
                document.getElementById("lbl_msg").innerHTML = "验证码不能为空！";
                return false;
            }
        }
        window.onload = function () {
            document.getElementById("userPwd").value = "****";            
            if (ie == 6) {
                document.getElementById("pageValidatecode1").style.top = "4px";
            }            
        }  
    </script>
</head>
<body>
    <div id="iHeader">
        <div class="iLogo">
        </div>
    </div>
    <div id="iMain">
        <form id="form1" runat="server">
        <div class="loginBox">
            <h3>
                <b>用户登录</b></h3>
            <p>
                <input type="text" runat="server" onblur="if(value=='' || value=='请输入真实姓名或用户名'){value='请输入真实姓名或用户名'}"
                    onfocus="if(value=='' || value=='请输入真实姓名或用户名'){value=''}" value="请输入真实姓名或用户名"
                    class="text" name="userName" maxlength="20" id="userName" /></p>
            <p>
                <input type="password" runat="server" onblur="if(value=='' || value=='****'){value='****'}"
                    onfocus="if(value=='' || value=='****'){value=''}" maxlength="18" class="text"
                    name="userPwd" id="userPwd" clientidmode="Inherit" /></p>
            <p>
                <input type="text" onblur="if(value==''){value='验证码'}" onfocus="if(value=='验证码'){value=''}"
                    runat="server" class="text" value="验证码" style="width: 110px;" maxlength="4" name="kaptchafield"
                    id="kaptcha" />
                <img id="pageValidatecode1" title="验证码，点击换一张" style="position: relative; top: 11px;
                    cursor: pointer; width: 85px; height: 30px;" src="VerificationCode.aspx" onmouseup="RefreshImage()"
                    alt="点击重刷新" /></p>
            <p class="clear">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btn_Login" CssClass="loginBoxbutton" runat="server" Text="快速登录" OnClientClick="return check();"
                    OnClick="btn_Login_Click" />
                &nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/WelcomeEverybody.aspx" runat="server">激活账户</asp:HyperLink>
            </p>
        </div>
        </form>
    </div>
    <div id="iFooter">
        <span>www.visione.com.cn &copy; 2012 京ICP备00000000号</span> <a href="http://www.visione.com.cn/">关于卓视</a>
        · <a href="http://www.visione.com.cn/content.php?bm=web_danye&id=2">联系我们</a> · <a href="#">帮助中心</a>
    </div>
</body>
</html>
