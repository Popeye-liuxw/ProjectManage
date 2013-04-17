<%@ Page Title="项目管理系统-权限管理-后台" Language="C#" MasterPageFile="~/Manager/Manager.Master"
    AutoEventWireup="true" CodeBehind="SysPermissionEdit.aspx.cs" Inherits="ProjectManage.Manager.SysPermissionEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">

    <div id="perm_toptitle">&nbsp;&nbsp;<span class="SpanTitle">当前设置职位>></span><asp:Label ID="lbl_posiInfo" runat="server" ></asp:Label></div>
    <div id="perm_pager" >
        <asp:Repeater ID="rpt_List" runat="server" 
            onitemdatabound="rpt_List_ItemDataBound">
            <HeaderTemplate>
                <ul class="permUL">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                <asp:Label ID="lbl_SysModuleID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                <%--<asp:Label ID="lbl_PermissionID" runat="server" Text='<%# Eval("PermissionID") %>' Visible="false"></asp:Label>--%>
                <asp:Label ID="lbl_ModuleName" runat="server" Text='<%# Eval("ModuleName") %>'  ></asp:Label>
                <asp:CheckBox ID="cbx_Read" runat="server" Text="读"/>
                <asp:CheckBox ID="cbx_Write" runat="server" Text="写" />                
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="SaveinfoDiv">
        <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
        <asp:Button ID="btn_Save" CssClass="btn2" runat="server" Text="确定" 
            onclick="btn_Save_Click" />&nbsp;&nbsp;
        <input type="button" onclick="javascript:history.go(-1);" name="back" value="返 回" class="btn2" id="btn_back"/>
    </div>
</asp:Content>
