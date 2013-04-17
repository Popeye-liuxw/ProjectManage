<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectClass.ascx.cs"
        Inherits="ProjectManage.Common.UserControls.ProjectClass" %>
<select id="ProjectClassSelect" class="selectBox">
        <option value="0">请选择</option>
        <asp:Repeater ID="RepeaterProjectClass" runat="server">
                <ItemTemplate>
                        <option value="<%#Eval("cItemCcode") %>">
                                <%#Eval("ClassName")%></option>
                </ItemTemplate>
        </asp:Repeater>
</select>