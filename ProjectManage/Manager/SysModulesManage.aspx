<%@ Page Title="项目管理系统-系统模块管理-后台" Language="C#" MasterPageFile="~/Manager/Manager.Master"
    AutoEventWireup="true" CodeBehind="SysModulesManage.aspx.cs" Inherits="ProjectManage.Manager.SysModulesManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="edit" style="float: right; width: 50%;">
        <table class="forms" cellpadding="0" cellspacing="0" border="0" width="90%">
            <tr>
                <th colspan="6">
                    模块操作
                </th>
            </tr>
            <tr>
                <td class="ftfirst" align="right">
                    模块名称：
                </td>
                <td class="ftlast" colspan="5">
                    <input size="40" id="txt_Name" runat="server" name="name" class="input1" onblur="this.className='input1'"
                        onfocus="this.className='input1-bor'" />
                </td>
            </tr>
            <tr>
                <td class="ftfirst" align="right">
                    模块地址：
                </td>
                <td class="ftlast" align="left" colspan="5">
                    <input style="width: 280px;" size="40" id="txt_Url" runat="server" name="name" class="input1"
                        onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                </td>
            </tr>
            <tr>
                <td class="ftfirst" align="right">
                    模块层级：
                </td>
                <td class="ftlast" align="left" colspan="5">
                    <asp:DropDownList ID="ddl_ModuleLevel" runat="server" OnSelectedIndexChanged="ddl_ModuleLevel_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddl_ModuleFirst" runat="server" Visible="false" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="ftfirst" align="center">
                    <asp:Button ID="btn_Add" runat="server" CssClass="btn2" Text="新增" OnClick="btn_Add_Click" />
                </td>
                <td colspan="2" align="center">
                    &nbsp;
                </td>
                <td class="ftlast" colspan="3" align="right">
                    <asp:Button ID="btn_Save" runat="server" CssClass="btn2" Text="保存" OnClick="btn_Save_Click" />
                </td>
            </tr>
        </table>
        <!--  -->
        <%--<script src="../js/superValidator.js" type="text/javascript"></script>--%>
    </div>
    <div id="treeVies">
        <asp:TreeView ID="tree_Modules" runat="server" ExpandDepth="1" PopulateNodesFromClient="False"
            OnSelectedNodeChanged="tree_Modules_SelectedNodeChanged" ShowLines="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                VerticalPadding="0px" />
        </asp:TreeView>
    </div>
</asp:Content>
