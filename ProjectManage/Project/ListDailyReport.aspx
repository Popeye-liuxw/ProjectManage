<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListDailyReport.aspx.cs" Inherits="ProjectManage.ListDailyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_main" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right_main" runat="server">
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <table id="AddProBaseInfo" class="datalist" visible="false" runat="server" cellpadding="0"
        cellspacing="0" border="0" width="94%">
        <tr>
            <th class="thfirst">
            </th>
            <th colspan="8">
                月统计日报
            </th>
            <th class="thlast">
            </th>
        </tr>
        <tr align="center">
            <td class="tfirst" style="width: 140px;">人员姓名：</td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_SelectName" Width="145" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="2" style="width: 200px;">
                <asp:Label ID="lbl_msg_ProType" runat="server" Text="必选(*)"></asp:Label></td>
            
            <td colspan="2" style="width: 140px;">
                年份：<asp:DropDownList ID="ddl_Year" Width="70" runat="server"></asp:DropDownList>
            </td>
            <td colspan="2" style="width: 140px;">
                月份：<asp:DropDownList ID="ddl_SelectMonth" Width="50" runat="server">
                </asp:DropDownList>
            </td>
            <td class="tlast">
                <asp:Label ID="lbl_msg_ProNature" runat="server" Text="必选(*)"></asp:Label></td>
        </tr>
        <tr align="center">
            <td class="tfirst"></td>
            <td colspan="8" style=" text-align:right;">&nbsp;
                <asp:Label ID="lbl_meg" runat="server"></asp:Label>
            </td>
            <td class="tlast">
                <asp:Button ID="btn_Math" runat="server" Text="统计" CssClass="btn2" 
                    onclick="btn_Math_Click" /></td>
        </tr>
    </table>
    <asp:Repeater ID="rep_List" runat="server" 
        onitemdatabound="rep_List_ItemDataBound" 
        ondatabinding="rep_List_DataBinding" onitemcommand="rep_List_ItemCommand" >
        <HeaderTemplate>
            <table class="datalist" id="List" cellpadding="0" cellspacing="0" border="0"
                width="94%">
                <tr>
                    <th class="thfirst">
                        &nbsp;
                    </th>
                    <th>
                        姓名
                    </th>
                    <th>
                        项目名称
                    </th>
                    <th>
                        填写日报时间
                    </th>
                    <th class="thlast">
                        &nbsp;
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr align="center">
                <td class="tfirst">
                    <asp:Label ID="lbl_id" runat="server" Text=''></asp:Label></td>
                <td>
                    <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="javascript:void(0);" Text='<%#Eval("RealName") %>' style="cursor:hand;color:#003366" ></asp:HyperLink>
                </td>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("citemname") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Label>
                </td>
                <td class="tlast">&nbsp;</td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
