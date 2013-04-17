<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeEverybody.aspx.cs"
    Inherits="ProjectManage.WelcomeEverybody" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script language="javascript" type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/images/favicon.ico" type="image/x-icon" />
    <title>北京中科卓视项目管理系统欢迎你</title>
    <style type="text/css">
        *{margin:0;padding:0}
        body{width:100%;background:#E4F3FA;}
        #iMain{width:952px;margin:100px auto; }
        #header{width:100%;height:9px;border:#1px solid #ddd;background:url(images/content-top.gif);}
        #content{width:100%;height:270px;background:url(images/content-body.gif) repeat-y; padding-top:12px;}
        #footer{width:100%;height:40px; background:url(images/content-bottom.gif) no-repeat;}
        #cleft{width:398px;height:200px; color:#666}
        #cright{width:500px; margin-left:10px;margin-right:10px; height:240px; border-left:#ddd 1px solid;float:right; }
        #cright ul{width:370px;margin:0px auto;font-size:13px;color:#808080}
        #cright ul li{width:100%;height:22px;line-height:22px; list-style-type:none;margin-top:4px;margin-bottom:4px; border-bottom:1px dotted #D9DFF0;}
        #cright h2{font-size:16px; height:30px; line-height:30px;padding-left:28px;color:#3D5BA1}
        #cleft ul li{ list-style-type:none;padding-left:88px;width:330px;margin:0 auto; margin-top:5px;height:34px; font-size:14px; line-height:30px;}
        #imgbtn{margin-left:80px;}
        #topimg{width:90%;height:39px;margin:0px 5% 8px;background:url(images/topiiimage.jpg) no-repeat;}
        #regBtn{margin-top:0px;margin-left:110px;}
        .checkText{height:20px;border:1px solid #CCE6F3;font-size:14px;line-height:20px;color:#333}
        .mail{width:90px;border-top:0px;border-left:0px;border-right:0px;border-bottom:1px solid #CCE6F3;height:18px; vertical-align:middle;}
    </style>
    <script type="text/javascript">
        function CheckInput() {
            var username = document.getElementById("userName").value; var password = document.getElementById("userDay").value; var userMail = document.getElementById('userMail');
            if (username == "") {
                alert("请输入姓名！");
                return false;
            }
            if (userMail == "") {
                alert("请输入电子邮箱地址");
                return false;
            }
            if (password == "") {
                alert("请输入密码！");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
<form runat="server">
    <div id="iMain">
      <div id="header"></div>
        <div id="content">
        <div id="cright">
        <h2>关于激活帐号的说明</h2>
                <ul>
                    <li>
                    1.系统需要确保每一位使用者是本公司员工。
                    </li>
                    <li>
                    2.生日输入您的出生日期，格式 YYYY-MM-DD。
                    </li>
                    <li>
                    3.邮箱为公司分配邮箱：Example@visione.com.cn
                    </li>                    
                    <li>
                    4.确保你的邮箱为可用状态。
                    </li>
                    <li>
                    5.注册后您的邮箱将会收到一封激活帐号的电子邮件。
                    </li>
                    <li>
                    6.本系统未使用明文密码，大家可以放心使用。
                    </li>
                </ul>
        
        </div>
        <div id="cleft">
        <div id="topimg"></div>
            <ul>
                <li>
                    <label>姓 名：</label>
                    <input type="text" runat="server" class="checkText" name="userName" maxlength="8" id="userName" /><label style="color:#FF0000">*</label>
                </li>
                <li>
                    <label>生 日：</label>
                    <input type="text" runat="server" maxlength="18" class="checkText" name="userPwd" id="userDay" readonly="readonly" value="1990-01-01" onclick="WdatePicker()" /><label style="color:#FF0000">*</label>
                </li>
                <li>
                    <label>邮 箱：</label>
                    <input type="text" runat="server" maxlength="18" class="mail" name="userMail" id="userMail" />@visione.com.cn<label style="color:#FF0000">*</label>
                </li>
                <li>
                    <asp:Label ID= "lbl_msg" runat="server" style="color:#FF0000"></asp:Label>
                </li>
            </ul>
            <div id="regBtn">            
            <asp:ImageButton ID="btn_Check" CssClass="imgbtn" OnClientClick="return CheckInput();" OnClick="btn_Check_Click" ImageUrl="images/jihuo.png" runat="server" /></div>
            </div>
            
        </div>
        <div id="footer"></div>
    </div>
</form>

</body>
</html>
