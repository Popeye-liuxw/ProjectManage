<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectNature.ascx.cs"
        Inherits="ProjectManage.Common.UserControls.ProjectNature" %>
<select id="ProjectNatureSelect" class="selectBox">
        <option value="0">请选择</option>
        <asp:Repeater ID="RepeaterProjectNature" runat="server">
                <ItemTemplate>
                        <option value="<%#Eval("SysNo") %>">
                                <%#Eval("Caption")%></option>
                </ItemTemplate>
        </asp:Repeater>
</select>