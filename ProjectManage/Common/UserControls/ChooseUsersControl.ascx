<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChooseUsersControl.ascx.cs"
        Inherits="ProjectManage.Common.ChooseUsersControl" %>
<div style="" id="ChooseUserMain_Div">
        <table style="font-size: 12px; width: 100%; display: none;" border="0" cellpadding="0"
                cellspacing="0" id="chooseUserArea">
                <tbody>
                        <tr class="title" style="cursor: move;">
                                <td colspan="10">
                                        <img src="http://img01.51jobcdn.com/im/2009/search/title_layer_yd.gif"><span>&nbsp;请选择参与员工</span>
                                        <span class="ccType"><span cctype="close" style="cursor: pointer;" id="btnSure">[确认]</span>
                                                <span></span>
                                </td>
                        </tr>
                        <tr>
                                <td colspan="10">
                                        <table style="width: 100%;">
                                                <tbody>
                                                        <asp:Repeater ID="RepeaterAllUserDepart" runat="server" OnItemDataBound="RepeaterUserItem_ItemDataBound">
                                                                <ItemTemplate>
                                                                        <tr>
                                                                                <td style="width: 20%;" class="cityOrange">
                                                                                        <%#Eval("DepartName")%>
                                                                                </td>
                                                                                <td>
                                                                                        <ul style="list-style-type: none;">
                                                                                                <asp:Repeater ID="RepeaterUserItem" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                                <li style="float: left; margin-left: 10px;">
                                                                                                                        <input type="checkbox" name="users" value="<%#Eval("SysNo") %>" id="ChooseUserCheckBox" />
                                                                                                                        <span>
                                                                                                                                <%#Eval("UserName")%></span> </li>
                                                                                                        </ItemTemplate>
                                                                                                </asp:Repeater>
                                                                                        </ul>
                                                                                </td>
                                                                        </tr>
                                                                </ItemTemplate>
                                                        </asp:Repeater>
                                                </tbody>
                                        </table>
                                </td>
                        </tr>
                        <tr class="bottomLine">
                                <td colspan="10">
                                </td>
                        </tr>
                </tbody>
        </table>
</div>
