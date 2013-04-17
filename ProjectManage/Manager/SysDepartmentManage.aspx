<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="SysDepartmentManage.aspx.cs" Inherits="ProjectManage.Manager.SysDepartmentManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
<div class="sysTips"><p>由于部门列表调用T3数据库，数据变动甚微，故暂不支持修改，增加。</p></div>
    <asp:Repeater ID="rep_DepartmentList" runat="server" 
        onitemdatabound="rep_DepartmentList_ItemDataBound">
    <HeaderTemplate>
    <table class="datalist" style="width:94%" cellpadding="0" cellspacing="0" border="0">
    <tr><th class="thfirst">ID</th><th>部门编号</th><th>部门名称</th><th class="thlast">部门简写</th></tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
        <td class="tfirst"><asp:Label ID="lbl_id" runat="server" Text=''></asp:Label></td>
        <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("cDepCode") %>'></asp:Label></td>
        <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("cDepName") %>'></asp:Label></td>
        <td class="tlast"><asp:Label ID="Label3" runat="server" Text='<%#Eval("cDepHelp").ToString()==""?"暂未设置":Eval("cDepHelp")  %>'></asp:Label></td>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
