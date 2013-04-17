<%@ Page Title="月报" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonthlyReportInfo.aspx.cs" Inherits="ProjectManage.Project.MonthlyReportInfoaspx" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="r_topmenu">
        <uc:Spinner id="spn_Menu" runat="server" MenuID="7"  />
    </div>
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div style=" text-align:center;">该模块还在开发中，敬请期待</div>
</asp:Content>
