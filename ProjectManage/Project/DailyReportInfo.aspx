<%@ Page Title="日报" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DailyReportInfo.aspx.cs" Inherits="ProjectManage.Project.DailyReportInfo" %>

<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="r_topmenu">
        <uc:Spinner ID="spn_Menu" runat="server" MenuID="8" />
    </div>
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div class="DailyListShow">
        <div class="TopTitle"><asp:Label ID="lbl_Title" runat="server"></asp:Label></div>
        <div id="Edit" class="SaveinfoDiv">
            <asp:Label ID="lbl_msg" runat="server"></asp:Label>
            <asp:Button ID="btn_Save" runat="server" CssClass="btn2" Text="添加" 
                onclick="btn_Save_Click"  />
        </div>
        <asp:Repeater ID="rpt_Daily" runat="server">
            <HeaderTemplate>
                <div class="DailyDetail">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="Content">
                    <div class="ProDialyContent">
                        <div class="DialyT">日报内容：</div>
                        <div class="DailyView">
                            <%#Eval("Summarize")%>
                        </div>
                    </div>
                </div>
                <div class="Simpinfo">
                    <div class="AddTime">
                        添加时间：<label><%#Eval("CreateTime")%></label></div>
                    <div class="ProName"></div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:Repeater ID="rpt_ChangePaper" runat="server">
            <HeaderTemplate>
                <div class="DailyDetail">
            </HeaderTemplate>
            <ItemTemplate>                                
                <div class="Content">
                    <div class="ProDemanChange">
                        <div class="DemanChangeT">需求变更内容：</div>
                        <div class="DemanChangeView">
                            <%#Eval("Summarize")%>
                        </div>
                    </div>
                </div>
                <div class="Simpinfo">
                    <div class="AddTime">
                        添加时间：<label><%#Eval("CreateTime")%></label></div>
                    <div class="ProName"></div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>        
    </div>
</asp:Content>
