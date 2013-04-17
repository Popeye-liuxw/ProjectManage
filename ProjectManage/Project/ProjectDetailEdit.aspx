<%@ Page Title="项目概况" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectDetailEdit.aspx.cs" Inherits="ProjectManage.Project.ProjectDetailEdit" %>

<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <script type="text/javascript">
        $("")
        function add_newshow_onclick() {
            window.location.href = "AddProjectResultShow.aspx";
        }

    </script>
    <div id="r_topmenu">
        <uc:Spinner ID="spn_Menu" runat="server" MenuID="3" />
    </div>
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p>
            <asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div id="projectBasic">
        <!-- 项目详细 -->
        <div id="ProDetailTitle">
            项目[<asp:Label ID="lbl_ProName" runat="server" Text=""></asp:Label>]详细信息一览</div>
        <table id="pro_det" cellpadding="0" cellspacing="0" border="0" width="90%">
            <tr>
                <td align="right">
                    项目编号：
                </td>
                <td>
                    &nbsp;<asp:Label ID="lbl_ProjId" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
                <td align="right">
                    项目名称：
                </td>
                <td>
                    &nbsp;<asp:Label ID="lbl_ProjName" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                    项目类型：
                </td>
                <td>
<%--                    <asp:DropDownList CssClass="selectBox" ID="ddl_ProType" runat="server">
                    </asp:DropDownList>--%>
                    &nbsp;<asp:Label ID="lbl_ProType" runat="server"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td align="right">
                    项目性质：
                </td>
                <td>
<%--                    <asp:DropDownList CssClass="selectBox" ID="ddl_ProNature" runat="server">
                    </asp:DropDownList>--%>
                    &nbsp;<asp:Label ID="lbl_ProNature" runat="server"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    客户名称：
                </td>
                <td>
<%--                    <asp:DropDownList ID="ddl_AllCus" CssClass="selectBox" runat="server">
                    </asp:DropDownList>--%>
                    &nbsp;<asp:Label ID="lbl_AllCus" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
                <td align="right">
                    商务负责人：
                </td>
                <td>
                   &nbsp;<asp:Label ID="lbl_MarketRec" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                    研发负责人：
                </td>
                <td>
                   &nbsp;<asp:Label ID="lbl_DeveloperRec" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
                <td align="right">
                    测试负责人：
                </td>
                <td>
                    &nbsp;<asp:Label ID="lbl_TesterRec" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                    研发人员：
                </td>
                <td colspan="5">
                    <asp:CheckBoxList ID="cbl_dev" runat="server" RepeatColumns="8" RepeatDirection="Horizontal"
                        CssClass="chl_list">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    测试人员：
                </td>
                <td colspan="5">
                    <asp:CheckBoxList ID="cbl_TestUser" runat="server" RepeatColumns="8" RepeatDirection="Horizontal"
                        CssClass="chl_list">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    商务人员：
                </td>
                <td colspan="5">
                    <asp:CheckBoxList ID="cbl_market" runat="server" RepeatColumns="8" RepeatDirection="Horizontal"
                        CssClass="chl_list">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6">
                    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Btn_Save" runat="server" Text="保存" CssClass="btn2" OnClick="Btn_Save_Click" />&nbsp;
                    <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="btn2" OnClick="btn_Back_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
