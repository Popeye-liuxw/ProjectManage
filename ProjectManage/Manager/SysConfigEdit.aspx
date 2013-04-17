<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="SysConfigEdit.aspx.cs" Inherits="ProjectManage.Manager.SysConfigEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
<table class="forms" runat="server"  cellpadding="0" cellspacing="0" border="0" width="94%" >
    <tr>
        <th colspan="8" style="height: 24px">配置<asp:Label ID="lbl_EmailName" runat="server" Text=""></asp:Label>信息</th>
    </tr>
        <tr>
            <td class="ftfirst"></td>
            <td>配置名称：</td><td><asp:TextBox ID="txt_EmailName" runat="server"></asp:TextBox>&nbsp;<label style=" color:Red">*</label></td>            
            <td>邮箱地址：</td><td><asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>&nbsp;<label style=" color:Red">*</label></td>
            <td>邮箱密码：</td><td><asp:TextBox ID="txt_UserPwd" runat="server" 
                TextMode="Password"></asp:TextBox>&nbsp;<label style=" color:Red">*</label></td>
            <td class="ftlast"></td>
        </tr>
         <tr>
            <td class="ftfirst"></td>
            <td>端口号：</td><td><asp:TextBox ID="txt_Port" runat="server">25</asp:TextBox>&nbsp;<label style=" color:Red">*</label></td>            
            <td>SMTP地址：</td><td><asp:TextBox ID="txt_SMTPHost" runat="server"></asp:TextBox>&nbsp;<label style=" color:Red">*</label></td>
            <td>SSL加密：</td><td><asp:CheckBox ID="cbx_EnableSSL" runat="server" /></td>
            <td class="ftlast"></td>
        </tr>
        <tr>
            <td class="ftfirst"></td>
            <td>发件人地址：</td><td><asp:TextBox ID="txt_Address" runat="server"></asp:TextBox></td>
            <td>发件人姓名：</td><td><asp:TextBox ID="txt_DisplayName" runat="server"></asp:TextBox>&nbsp;<label style=" color:Red">*</label></td>
            <td>立即启用：</td><td><asp:CheckBox ID="cbx_State" runat="server" /></td>
        <td class="ftlast"></td>
        </tr>
    </table>
    <div id="SaveUserInfo" class="SaveinfoDiv">
        <asp:Label CssClass="lbl_msgOK" ID="lbl_msg" runat="server" Text=""></asp:Label> <asp:Button ID="btn_SaveInfo" runat="server" CssClass="btn2" Text="保 存" onclick="btn_SaveInfo_Click" /> &nbsp;&nbsp;<asp:Button 
            ID="btn_Back" runat="server" CssClass="btn2" Text="返 回" 
            onclick="btn_Back_Click" />
    </div>

</asp:Content>
