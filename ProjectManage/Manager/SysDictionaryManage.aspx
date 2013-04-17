<%@ Page Title="项目管理系统-字典管理-后台" Language="C#" MasterPageFile="~/Manager/Manager.Master"
    AutoEventWireup="true" CodeBehind="SysDictionaryManage.aspx.cs" Inherits="ProjectManage.Manager.SysDictionaryManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div class="sysTips">
        <p>
            TIPS：该处主要用来配置常见类型，请勿随意调整。</p>
    </div>
    <div id="pager">
        <asp:GridView ID="gv_List" CssClass="datalist" AutoGenerateColumns="false" runat="server"
            Width="94%" GridLines="None" BorderStyle="None" EnableModelValidation="False"
            EnableTheming="False" DataKeyNames="ID" OnRowDataBound="gv_List_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="序号">
                    <HeaderStyle CssClass="thfirst" />
                    <ItemStyle CssClass="tfirst" />
                </asp:BoundField>
                <asp:BoundField DataField="TypeName" HeaderText="类型名称"></asp:BoundField>
                <asp:BoundField DataField="TypeValue" HeaderText="类型值" />
                <asp:BoundField DataField="CreateTime" HeaderText="创建时间"></asp:BoundField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <img class="iconTips" alt="" src="../images/look.png" />
                        <asp:LinkButton ID="btn_QueryType" runat="server" CssClass="linkBtn" CommandArgument='<%#Eval("ID") %>' OnClick="btn_QueryType_Click" Text="查看"></asp:LinkButton>&nbsp;
                        <img class="iconTips" alt="" src="../images/insert.png" />
                        <asp:LinkButton ID="btn_AddItemType" runat="server" CssClass="linkBtn" CommandArgument='<%#Eval("ID") %>' OnClick="btn_AddItemType_Click" Text="添加"></asp:LinkButton>&nbsp;
                        <%--<asp:Button ID="btn_DeleteType" runat="server" CommandArgument='<%# Eval("ID") %>'
                            OnClick="btn_DeleteType_Click" Text="删除" OnClientClick="javascript:return confirm('确定要删除该类别么，如果删除，将会导致系统出现未知错误！')">
                        </asp:Button>--%>
                    </ItemTemplate>
                    <HeaderStyle CssClass="thlast" />
                    <ItemStyle CssClass="tlast" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <asp:Panel ID="EditType" runat="server">
        <div id="edit">
            <table id="TypeTable" class="forms" cellpadding="0" cellspacing="0" border="0" width="94%">
                <tr>
                    <th colspan="4">
                        主类型信息
                    </th>
                </tr>
                <tr>
                    <td class="ftfirst" align="right">
                        类型名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_BigType" runat="server" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"></asp:TextBox>
                    </td>
                    <td align="right">
                        类型值：
                    </td>
                    <td class="ftlast">
                        <asp:TextBox ID="txt_BigValue" runat="server" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Button ID="btn_BigValue" runat="server" Text="获取" OnClick="btn_BigValue_Click" />
                    </td>
                </tr>
            </table>
            <div class="SaveinfoDiv">
                <asp:Button ID="btn_Commit" runat="server" Text="保存" CssClass="btn2" OnClick="btn_Commit_Click" />
            </div>
        </div>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="pnl_ItemList" runat="server" Visible="false">
        <div id="ItemPager">
            <asp:GridView ID="gv_ItemList" CssClass="datalist" AutoGenerateColumns="false" runat="server"
                Width="94%" GridLines="None" BorderStyle="None" EnableModelValidation="False"
                EnableTheming="False" DataKeyNames="ID" OnRowDataBound="gv_ItemList_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="序号">
                        <HeaderStyle CssClass="thfirst" />
                        <ItemStyle CssClass="tfirst" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ItemName" HeaderText="类型名称"></asp:BoundField>
                    <asp:BoundField DataField="ItemValue" HeaderText="类型值" ></asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="创建时间"></asp:BoundField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <img class="iconTips" alt="" src="../images/pencil.png" />
                            <asp:LinkButton ID="btn_ItemEditType" runat="server" CssClass="linkBtn" CommandArgument='<%#Eval("ID") %>' Text="编辑" onclick="btn_ItemEditType_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="thlast" />
                        <ItemStyle CssClass="tlast" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </div>
        
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="EditItemType" runat="server" Visible="false">
        <div id="itemEdit">
            <table id="itemType" class="forms" cellpadding="0" cellspacing="0" border="0" width="94%">
                <tr>
                    <th colspan="4">
                        子类型信息
                    </th>
                </tr>
                <tr>
                    <td class="ftfirst" align="right">
                        类型名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_ItemTypeName" runat="server" tip="输入可以为空,如果不空,将按照绑定的验证规则验证." check="1" name="name" class="input1" onblur="this.className='input1'"
                            onfocus="this.className='input1-bor'"></asp:TextBox>
                    </td>
                    <td align="right">
                        类型值：
                    </td>
                    <td class="ftlast">
                        <asp:TextBox ID="txt_ItemTypeValue" runat="server" class="input1" onblur="this.className='input1'"
                            onfocus="this.className='input1-bor'"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btn_CommitItemType" runat="server" Text="保存" CssClass="btn2" OnClick="btn_CommitItemType_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btn_Cancel" runat="server" Text="取消" CssClass="btn2" OnClick="btn_Cancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
</asp:Content>
