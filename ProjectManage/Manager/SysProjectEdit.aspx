<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true"
    CodeBehind="SysProjectEdit.aspx.cs" Inherits="ProjectManage.Manager.SysProjectEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <table id="AddProBaseInfo" class="datalist" runat="server" cellpadding="0" cellspacing="0"
        border="0" width="94%">
        <tr>
            <th class="thfirst">
            </th>
            <th colspan="8">
                修改
                <asp:Label ID="lbl_Updatetitle" runat="server" Text=""></asp:Label>
                基本信息
            </th>
            <th class="thlast">
            </th>
        </tr>
        <tr align="center">
            <td class="tfirst" style="width: 140px;">
                项目编号：
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" ID="txt_ProCode" CssClass="input1" onblur="this.className='input1'"
                    onfocus="this.className='input1-bor'"></asp:TextBox>
            </td>
            <td colspan="2" style="width: 200px;">
                <asp:Label ID="lbl_msg_ProCode" runat="server" Text="必填(*)"></asp:Label>
            </td>
            <td colspan="2" style="width: 140px;">
                项目名称：
            </td>
            <td colspan="2">
                <asp:TextBox ID="txt_ProName" runat="server" CssClass="input1" onblur="this.className='input1'"
                    onfocus="this.className='input1-bor'"></asp:TextBox>
            </td>
            <td class="tlast" style="width: 200px;">
                <asp:Label ID="lbl_msg_ProName" runat="server" Text="必填(*)"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td class="tfirst" style="width: 140px;">
                项目类型：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectProType" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="2" style="width: 200px;">
                <asp:Label ID="lbl_msg_ProType" runat="server" Text="必填(*)"></asp:Label>
            </td>
            <td colspan="2" style="width: 140px;">
                项目性质：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectProNature" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td class="tlast" style="width: 200px;">
                <asp:Label ID="lbl_msg_ProNature" runat="server" Text="必填(*)"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td class="tfirst" style="width: 140px;">
                客户名称：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectCustomer" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="2" style="width: 200px;">
                <asp:Label ID="lbl_msg_Customer" runat="server" Text="必填(*)"></asp:Label>
            </td>
            <td colspan="2" style="width: 140px;">
                商务负责人：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectMarketRec" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td class="tlast" style="width: 200px;">
                <asp:Label ID="lbl_msg_MarketRec" runat="server" Text="必填(*)"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td class="tfirst" style="width: 140px;">
                研发负责人：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectDeveloperRec" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="2" style="width: 200px;">
                <asp:Label ID="lbl_msg_DeveloperRec" runat="server" Text="必填(*)"></asp:Label>
            </td>
            <td colspan="2" style="width: 140px;">
                测试负责人：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectTesterRec" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td class="tlast" style="width: 200px;">
                <asp:Label ID="lbl_msg_TesterRec" runat="server" Text="必填(*)"></asp:Label>
            </td>
        </tr>
         <tr align="center">
            <td class="tfirst" style="width: 140px;">
                项目状态：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectClose" Width="145" runat="server">
                    <asp:ListItem Value="1" Text="启用"></asp:ListItem>
                    <asp:ListItem Value="0" Text="关闭" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="2" style="width: 200px;">
                <%--<asp:Label ID="Label1" runat="server" Text="必填(*)"></asp:Label>--%>
            </td>
            <td colspan="2" style="width: 140px;">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
            <td class="tlast" style="width: 200px;">
                <%--<asp:Label ID="Label2" runat="server" Text="必填(*)"></asp:Label>--%>
            </td>
        </tr>
        <tr align="center">
            <td class="tfirst">
            </td>
            <td colspan="4">
                <asp:Button ID="btn_OK" runat="server" Text="确定" CssClass="btn2" OnClick="btn_OK_Click" />
            </td>
            <td colspan="4">
                <asp:Button ID="btn_Cancel" runat="server" Text="返回列表" CssClass="btn2" OnClick="btn_Cancel_Click" />
            </td>
            <td class="tlast">
            </td>
        </tr>
    </table>
</asp:Content>
