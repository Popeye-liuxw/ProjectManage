<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="SysUserAdd.aspx.cs" Inherits="ProjectManage.Manager.SysUserAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function CheckInput() {
            if ($("#userName").length < 1) {
                alert("请填写用户名");
                return false;
            }
            if ($("#RealName").length < 1) {
                alert("请填写真实姓名");
                return false;
            }
            if ($("#Email").length < 1) {
                alert("请填写电子邮箱");
                return false;
            }
            return true;
        }
    </script>
<table class="forms" runat="server"  cellpadding="0" 
        cellspacing="0" border="0" width="94%" id="isExistUpdate">
    <tr>
        <th colspan="8" style="height: 24px">新增用户</th>
    </tr>
        <tr>
            <td class="ftfirst"></td>
            <td>用户名：</td><td title="姓名首字母简写+员工编号组成"><input size="40" runat="server" 
                id="userName" name="userName" class="input1" onblur="this.className='input1'" 
                onfocus="this.className='input1-bor'" clientidmode="Static" /><label style="color:#FF0000">*</label></td>
            <td>真实姓名：</td><td><input size="40" runat="server" id="RealName" name="name" 
                class="input1" onblur="this.className='input1'" 
                onfocus="this.className='input1-bor'" clientidmode="Static" /><label style="color:#FF0000">*</label></td>
            <td>部  门：</td><td><asp:DropDownList ID="ddl_Department" runat="server" 
                ClientIDMode="Static"></asp:DropDownList>
            </td>
            <td class="ftlast"></td>
        </tr>
        <tr>
            <td class="ftfirst"></td>
            <td>出生日期：</td><td><input size="40" id="Birthday" runat="server" title="点击选择日期" 
                name="name" class="input1" readonly="readonly" value="1990-01-01" 
                onclick="WdatePicker()" clientidmode="Static" /><label style="color:#FF0000">*</label></td>
            <td>电子邮箱：</td><td><input size="40" id="Email" runat="server" name="name" 
                class="input1" onblur="this.className='input1'" 
                onfocus="this.className='input1-bor'" clientidmode="Static" />@visione.com.cn<label style="color:#FF0000">*</label></td>
            <td>手机号码：</td><td><input size="40" id="telpnone" runat="server" name="name" 
                class="input1" onblur="this.className='input1'" 
                onfocus="this.className='input1-bor'" clientidmode="Static" /></td>
            <td class="ftlast"></td>
        </tr>
    </table>
    <div id="SaveUserInfo" class="SaveinfoDiv">
        <asp:Label CssClass="lbl_msgOK" ID="lbl_msg" runat="server" Text=""></asp:Label> <asp:Button ID="btn_SaveInfo" runat="server" CssClass="btn2" Text="保 存" OnClientClick="return CheckInput();" onclick="btn_SaveInfo_Click" /> &nbsp;&nbsp;<input type="button" onclick="javascript:window.location.href='UserManage.aspx'" name="back" value="返 回" class="btn2" id="btn_back"/>
    </div>
</asp:Content>
