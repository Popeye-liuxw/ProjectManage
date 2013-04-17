<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="SysUserEdit.aspx.cs" Inherits="ProjectManage.Manager.SysUserEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <table class="forms" runat="server"  cellpadding="0" 
        cellspacing="0" border="0" width="94%" id="isExistUpdate">
    <tr>
        <th colspan="8" style="height: 24px">编辑用户<asp:Label ID="lbl_realName" runat="server" Text=""></asp:Label>信息</th>
    </tr>
        <tr>
        <td class="ftfirst"></td>
        <td>用户名：</td><td><input size="40" runat="server" id="userName" name="userName" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
            </td>
        <td>用户密码：</td><td><input size="40" runat="server" id="userPwd" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" /></td>
        <td>部  门：</td><td><asp:DropDownList ID="ddl_Department" runat="server"></asp:DropDownList>
        </td>
        <td class="ftlast"></td>
        </tr>
        <tr>
            <td class="ftfirst"></td>
            <td>电子邮箱：</td><td><input size="40" id="Email" runat="server" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />@visione.com.cn</td>
            <td>手机号码：</td><td><input size="40" id="telpnone" runat="server" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" /></td>
            <td>联系电话：</td><td><input size="40" id="telNum" runat="server" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" /></td>
        <td class="ftlast"></td>
        </tr>
    </table>
    <div class="sysTips"><p>TIPS：设置该用户职位(可选多个)</p></div>
    <asp:CheckBoxList ID="chk_PosiList" CssClass="chk_list" runat="server" RepeatDirection="Horizontal"
        RepeatColumns="6" EnableTheming="False" TextAlign="Right">
    </asp:CheckBoxList>
    <div id="SaveUserInfo" class="SaveinfoDiv">
        <asp:Label CssClass="lbl_msgOK" ID="lbl_msg" runat="server" Text=""></asp:Label> <asp:Button ID="btn_SaveInfo" runat="server" CssClass="btn2" Text="保 存" onclick="btn_SaveInfo_Click" /> &nbsp;&nbsp;<input type="button" onclick="javascript:window.location.href='UserManage.aspx'" name="back" value="返 回" class="btn2" id="btn_back"/>
    </div>
</asp:Content>
