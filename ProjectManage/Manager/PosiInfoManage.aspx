<%@ Page Title="项目管理系统-职位信息管理-后台" Language="C#" MasterPageFile="~/Manager/Manager.Master"
    AutoEventWireup="true" CodeBehind="PosiInfoManage.aspx.cs" Inherits="ProjectManage.Manager.PosiInfoManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="pager">
        <asp:GridView ID="gv_List" CssClass="datalist" AutoGenerateColumns="False" runat="server"
            Width="94%" GridLines="None" BorderStyle="None" EnableModelValidation="False" EnableTheming="False"
            OnRowDataBound="gv_List_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="序号">
                    <HeaderStyle CssClass="thfirst" />
                    <ItemStyle CssClass="tfirst" />
                </asp:BoundField>
                <asp:BoundField DataField="PosiName" HeaderText="职位名称"></asp:BoundField>
                <asp:BoundField DataField="Back" HeaderText="职位编号" />
                <asp:BoundField DataField="CreateTime" HeaderText="创建时间">
                    <HeaderStyle CssClass="thlast" />
                    <ItemStyle CssClass="tlast" />
                </asp:BoundField>
  <%--              <asp:CommandField EditText="修改" ShowEditButton="True" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />--%>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <div id="edit">
        <table id="tableEdit" class="forms" cellpadding="0" cellspacing="0" border="0" width="95%">
            <tr>
                <th colspan="6">
                    职位信息
                </th>
            </tr>
            <tr>
                <td class="ftfirst" align="right">
                    职位名称：
                </td>
                <td>
                    <asp:TextBox ID="txt_PosiName" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    (此项为必填项)
                </td>
                <td align="right">
                    职位编号：
                </td>
                <td>
                    <asp:TextBox ID="txt_Back" runat="server"></asp:TextBox>
                </td>
                <td class="ftlast" align="left">
                    (此项为必填项)
                </td>
            </tr>
        </table>
        <div class="SaveinfoDiv">
            <asp:Button ID="btn_Commit" runat="server" Text="保存" CssClass="btn2" OnClick="btn_Commit_Click" />
        </div>
    </div>
</asp:Content>
