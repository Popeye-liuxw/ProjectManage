<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectBasicInfoManagement.aspx.cs" Inherits="ProjectManage.ProjectBasicInfoManagement" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <script src="../js/tablecolor.js" type="text/javascript"></script>
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
        <div id="ProjectInfoMain">
                <table id="Prosearch" class="datalist" cellpadding="0" cellspacing="0" border="0"
                        width="94%">
                        <tr><th class="thfirst"></th><th colspan="4">项目信息搜索</th><th class="thlast"></th></tr>
                        <tr align="center">
                                <td class="tfirst">项目名称：</td>
                                <td><input runat="server" id="sProName" size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
                                <td>项目类型：</td>
                                <td><asp:DropDownList ID="ddl_ProType"  Width="140" runat="server"></asp:DropDownList></td>
                                <td>项目性质：</td>
                                <td class="tlast"><asp:DropDownList ID="ddl_ProNature" Width="140" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr align="center">
                                <td colspan="3" class="tfirst">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btn_unProject" runat="server" 
                                        Text="未分配项目" CssClass="btn2" onclick="btn_unProject_Click" /></td>
                                <td><asp:Button ID="btn_AddNewPro" runat="server" Text="添加项目" CssClass="btn2" 
                                        onclick="btn_AddNewPro_Click" /></td>
                                <td colspan="3" class="tlast">
                                    <asp:Button ID="btn_search" runat="server" CssClass="btn2" Text="搜索" 
                                        onclick="btn_search_Click" /></td>
                        </tr>
                </table>
                <table id="AddProBaseInfo" class="datalist" visible="false" runat="server" cellpadding="0" cellspacing="0" border="0" width="94%">
                <tr><th class="thfirst"></th><th colspan="8">
                    <asp:Label ID="lbl_Updatetitle" runat="server" Text="添加"></asp:Label>基本信息</th><th class="thlast"></th></tr>
                <tr align="center">                 
                    <td class="tfirst" style="width:140px;">项目编号：</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" id="txt_ProCode" CssClass="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"></asp:TextBox>
                    </td>
                    <td colspan="2" style="width:200px;"><asp:Label ID="lbl_msg_ProCode" runat="server" Text="必填(*)"></asp:Label></td>
                        
                    <td colspan="2" style="width:140px;">项目名称：</td>
                    <td colspan="2" >
                        <asp:TextBox ID="txt_ProName" runat="server" CssClass="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"></asp:TextBox>                   
                    </td>                   
                    <td class="tlast" style="width:200px;"> <asp:Label ID="lbl_msg_ProName" runat="server" Text="必填(*)"></asp:Label></td>
                </tr>
                 <tr align="center">
                    <td class="tfirst" style="width:140px;">项目类型：</td>
                    <td colspan="2"  >
                        <asp:DropDownList ID="ddl_SelectProType" Width="145" runat="server"></asp:DropDownList>
                    </td>
                    <td colspan="2" style="width:200px;">
                        <asp:Label ID="lbl_msg_ProType" runat="server" Text="必填(*)"></asp:Label></td>
                    <td colspan="2"  style="width:140px;">项目性质：</td>
                    <td colspan="2"  >
                        <asp:DropDownList ID="ddl_SelectProNature" Width="145" runat="server"></asp:DropDownList>
                    </td>
                    <td class="tlast" style="width:200px;">
                        <asp:Label ID="lbl_msg_ProNature" runat="server" Text="必填(*)"></asp:Label></td>
                </tr>
                 <tr align="center">
                    <td class="tfirst" style="width:140px;">客户名称：</td>
                    <td colspan="2"   ><asp:DropDownList ID="ddl_SelectCustomer" Width="145" runat="server"></asp:DropDownList></td>
                    <td colspan="2" style="width:200px;"><asp:Label ID="lbl_msg_Customer" runat="server" Text="必填(*)"></asp:Label></td>
                         <td colspan="2"  style="width:140px;">商务负责人：</td>
                    <td colspan="2"><asp:DropDownList ID="ddl_SelectMarketRec" Width="145" runat="server"></asp:DropDownList></td>
                    <td class="tlast" style="width:200px;">
                        <asp:Label ID="lbl_msg_MarketRec" runat="server" Text="必填(*)"></asp:Label></td>
                </tr>
                <tr align="center">
                    <td class="tfirst" style="width:140px;">研发负责人：</td>
                    <td colspan="2"   ><asp:DropDownList ID="ddl_SelectDeveloperRec" Width="145" runat="server"></asp:DropDownList></td>
                    <td colspan="2" style="width:200px;">
                        <asp:Label ID="lbl_msg_DeveloperRec" runat="server" Text="必填(*)"></asp:Label></td>
                    <td colspan="2"  style="width:140px;">测试负责人：</td>
                    <td colspan="2"><asp:DropDownList ID="ddl_SelectTesterRec" Width="145" runat="server"></asp:DropDownList></td>
                    <td class="tlast" style="width:200px;">
                        <asp:Label ID="lbl_msg_TesterRec" runat="server" Text="必填(*)"></asp:Label></td>
                </tr>
                <%--<tr align="center">
                    <td class="tfirst" style="width:140px;"></td>
                    <td colspan="2"   ></td>
                    <td colspan="2" style="width:200px;">
                        </td>                   
                   <td colspan="2"  style="width:140px;">项目经理：</td>
                    <td colspan="2"><asp:DropDownList ID="ddl_SelectProManager" Width="145" runat="server"></asp:DropDownList></td>
                    <td class="tlast" style="width:200px;">
                        <asp:Label ID="lbl_msg_ProManger" runat="server" Text="必填(*)"></asp:Label></td>
                </tr>--%>
                <tr align="center">
                    <td class="tfirst"></td>
                    <td colspan="4"><asp:Button ID="btn_OK" runat="server" Text="确定" CssClass="btn2" 
                            onclick="btn_OK_Click" /></td>
                    <td colspan="4">
                        <asp:Button ID="btn_Cancel" runat="server" Text="返回列表" 
                            CssClass="btn2" onclick="btn_Cancel_Click" /></td>
                    <td class="tlast"></td>
                </tr>
                </table>
            <asp:Repeater ID="rep_PojList" runat="server" 
                    onitemdatabound="rep_PojList_ItemDataBound" 
                    onitemcreated="rep_PojList_ItemCreated">
            <HeaderTemplate>
                <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0" width="94%">
                        <tr>
                                <th class="thfirst">序号</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>项目类型</th>
                                <th>项目性质</th>
                                <th>客户名称</th>
                                <th >查看详细</th>
                                <%--<th runat="server" id="thEdit">编辑</th>--%>
                                <th class="thlast">&nbsp;</th>
                        </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <tr align="center">
                                <td class="tfirst"><asp:Label ID="lbl_id" runat="server" Text=''></asp:Label></td>
                                <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("citemcode") %>'></asp:Label></td>
                                <td align="center"><asp:Label ID="Label3" runat="server" Text='<%#Eval("citemname") %>'></asp:Label></td>
                                <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("PrjTypeName").ToString()==""?"暂未设置":Eval("PrjTypeName") %>'></asp:Label></td>
                                <td><asp:Label ID="Label5" runat="server" Text='<%#Eval("PrjNatureName").ToString()==""?"暂未设置":Eval("PrjNatureName") %>'></asp:Label></td>
                                <td><asp:Label ID="Label6" runat="server" Text='<%#Eval("cCusAbbName").ToString()==""?"暂未设置":Eval("cCusAbbName") %>'></asp:Label></td>
                                <td><img class="iconTips" alt="" src="../images/ViewDetail.png" /> <asp:LinkButton ID="Link_ViewDetail" PostBackUrl='<%#"ProjectDetail.aspx?prjID="+Eval("ID") %>' CssClass="linkBtn" runat="server">查看详细</asp:LinkButton></td>
                                <%--<td  runat="server" id="tdEdit"><img class="iconTips" alt="" src="../images/pencil.png" /><asp:LinkButton ID="Link_EditPro" PostBackUrl='<%#"ProjectDetailEdit.aspx?id="+Eval("ID") %>' CssClass="linkBtn" runat="server">编辑</asp:LinkButton></td>--%>
                                <td  class="tlast">&nbsp;</td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                </table>
                </FooterTemplate>
                 </asp:Repeater>
                <webdiyer:AspNetPager ID="ANP" CssClass="paginator" CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="23" PrevPageText="上一页"  ShowCustomInfoSection="Left"  onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left" LayoutType="Table"  >
                </webdiyer:AspNetPager>


           <asp:Repeater ID="rep_Unallocated" runat="server" 
                Visible ="false"     onitemcommand="rep_Unallocated_ItemCommand" 
                    onitemdatabound="rep_Unallocated_ItemDataBound">
            <HeaderTemplate>
                <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0" width="94%">
                        <tr>
                                <th class="thfirst">序号</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>项目类型</th>
                                <th>项目性质</th>
                                <th>客户名称</th>
                                <th runat="server" id="thEdit">分配编辑</th>
                                <th class="thlast">&nbsp;</th>
                        </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <tr align="center">
                                <td class="tfirst"><asp:Label ID="lbl_UNid" runat="server" Text=''></asp:Label><asp:Label Visible="false" ID="lbl_proId" runat="server" Text='<%#Eval("ID") %>'></asp:Label></td>
                                <td><asp:Label ID="lbl_ProCode" runat="server" Text='<%#Eval("citemcode") %>'></asp:Label></td>
                                <td align="center"><asp:Label ID="Label3" runat="server" Text='<%#Eval("citemname") %>'></asp:Label></td>
                                <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("PrjTypeName").ToString()==""?"暂未设置":Eval("PrjTypeName") %>'></asp:Label></td>
                                <td><asp:Label ID="Label5" runat="server" Text='<%#Eval("PrjNatureName").ToString()==""?"暂未设置":Eval("PrjNatureName") %>'></asp:Label></td>
                                <td><asp:Label ID="Label6" runat="server" Text='暂未设置'></asp:Label></td>
                                <td  runat="server" id="tdEdit"><img class="iconTips" alt="" src="../images/pencil.png" /><asp:LinkButton ID="Link_EditPro" CssClass="linkBtn" runat="server">分配编辑</asp:LinkButton></td>
                                <td  class="tlast">&nbsp;</td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                </table>
                </FooterTemplate>
                 </asp:Repeater>
                <webdiyer:AspNetPager ID="ANP1" CssClass="paginator" 
                    CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" Visible ="false"
                    FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="23" 
                    PrevPageText="上一页"  ShowCustomInfoSection="Left"   CustomInfoTextAlign="Left" 
                    LayoutType="Table" onpagechanged="ANP1_PageChanged"  >
                </webdiyer:AspNetPager>

                <p>&nbsp;</p>
        </div>
</asp:Content>
