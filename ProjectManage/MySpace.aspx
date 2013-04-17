<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MySpace.aspx.cs" Inherits="ProjectManage.MySpace" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <script src="js/tablecolor.js" type="text/javascript"></script>
    <script type="text/javascript">
    function CheckIsPhoneNum(str) {
        var ab = /^(13[0-9]|15[0-9]|18[0-9])\d{8}$/; if (!ab.test(str)) { return false; } else { return true; }
    }
    function checkOk() {
        var telPhone = document.getElementById("right_main_txt_telphone").value;
        var oldPwd = document.getElementById("right_main_txt_oldPwd").value;
        var newPwd = document.getElementById("right_main_txt_newPwd").value;
        var renewPwd = document.getElementById("right_main_txt_renewPwd").value;
        var msg = document.getElementById("right_main_lbl_msg");
        if (telPhone == "") {
            msg.innerText = "请输入您的手机号码！"
            return false;
        }
        if (CheckIsPhoneNum(telPhone) == false) {
            msg.innerText = "请输入正确的手机号码！";
            return false;
        }
        //如果旧密码输入了，则判断下新密码和重复输入新密吗地方是否为空 任何一个为空则
        if (oldPwd != "" ) {
            if (newPwd == "") {
                msg.innerText = "请输入您的新密码！";
                return false;
            }
            if (renewPwd == "") {
                msg.innerText = "请重复输入您的新密码！";
                return false;
            }
            if (newPwd != renewPwd) {
                msg.innerText ="您两次输入的新密码不一致请核对！";
                return false;
            }
        }
    }
</script>
<table id="MySpaceDetail" class="datalist" runat = "server"  cellpadding="0" cellspacing="0" border="0"  width="94%">
<tr> <th class="thfirst"></th><th colspan="6">个人资料</th><th class="thlast"></th></tr>
<tr align="center">
    <td class="tfirst">&nbsp;</td>
    <td style="width:160px;">部门：</td>
    <td style="width:160px;"><asp:Label ID="lbl_Department" runat="server" Text="[]"></asp:Label></td>
    <td style="width:160px;">用户名：</td>
    <td style="width:160px;"><asp:Label ID="lbl_UserName" runat="server" Text="[]"></asp:Label></td>
    <td style="width:160px;">邮箱：</td>
    <td style="width:160px;"><asp:Label ID="lbl_Email" runat="server" Text="Label"></asp:Label></td>
    <td class="tlast">&nbsp;</td>
</tr>
<tr>
<td class="tfirst">&nbsp;</td>
<td colspan="6" align="center">
<asp:Button ID="btn_Update" runat="server" Text="修 改" CssClass="btn2" 
        onclick="btn_Update_Click"/>
</td >
<td class="tlast">&nbsp;</td>
</tr>
</table>
<table id="MyspaceUpdate" class="datalist" runat="server" visible="false"  cellpadding="0" cellspacing="0" border="0"  width="94%">
<tr><th class="thfirst"></th>
<th colspan="4">个人信息</th>
<th class="thlast"></th>
</tr>
<tr align="center">
    <td class="tfirst">&nbsp;</td>
    <td>手机号码：</td>
    <td><asp:TextBox ID="txt_telphone" MaxLength="15" CssClass="input1" runat="server"></asp:TextBox></td>
    <td>原账户密码：</td>
    <td><asp:TextBox ID="txt_oldPwd" TextMode ="Password" MaxLength="15" CssClass="input1" runat="server"></asp:TextBox></td>
    <td class="tlast">&nbsp;</td>
    </tr>
<tr>
    <td class="tfirst">&nbsp;</td>
    <td>新密码：</td>
    <td><asp:TextBox ID="txt_newPwd" TextMode ="Password" MaxLength="15" CssClass="input1" runat="server"></asp:TextBox></td>
    <td>重复新密码：</td>
    <td><asp:TextBox ID="txt_renewPwd" TextMode ="Password" MaxLength="15" CssClass="input1" runat="server"></asp:TextBox></td>
    <td class="tlast">&nbsp;</td>
</tr>
<tr>
<td class="tfirst"></td>
<td colspan="4" align="center"><asp:Label ID="lbl_msg" ForeColor="Red" runat="server" Text="提示：只填写手机号码，不填写密码信息默认只更新手机号码！"></asp:Label></td>
<td class="tlast"></td>
</tr>
<tr align="center">
    <td class="tfirst">&nbsp;</td>
    <td colspan="2"><asp:Button ID="btn_Save" runat="server" Text="确 定" CssClass="btn2" OnClientClick="return checkOk()" onclick="btn_Save_Click"/></td>
    <td colspan="2"><asp:Button ID="btn_Back" runat="server" Text="返 回" CssClass="btn2" 
            onclick="btn_Back_Click"/></td>
    <td class="tlast">&nbsp;</td>
</tr>
</table>
<asp:Repeater runat="server" ID = "userLog_List">
<HeaderTemplate>
    <table cellpadding="0" cellspacing="0" border="0" class="datalist" id="userlogTable" width="94%">
    <tr>
        <th class="thfirst"></th><th colspan="2">用户登录日志</th><th class="thlast"></th>
    </tr>
</HeaderTemplate>
<ItemTemplate>
    <tr>
        <td class="tfirst" style="width:20px;"></td><td  colspan="2" style="text-align:left">ID:<%#Eval("ID") %>,用户名:<%#Eval("UserName") %>,本次登录IP:<%#Eval("TheIP")%>,操作系统:<%#Eval("IOS") %>,浏览器：<%#Eval("Browser")%>,内容：<%#Eval("Operate")%> 时间：<%#Eval("CreateTime") %></td><td class="tlast"></td>
    </tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
<webdiyer:AspNetPager ID="ANP" CssClass="paginator"   
        CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="23" 
        PrevPageText="上一页"  ShowCustomInfoSection="Left" 
        onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left" 
        LayoutType="Table"  >
</webdiyer:AspNetPager>


</asp:Content>
