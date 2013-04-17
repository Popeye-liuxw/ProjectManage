<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyReportItemInfo.aspx.cs"
    Inherits="ProjectManage.Project.DailyReportItemInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../style/main.css" rel="stylesheet" type="text/css" />
    <link href="../style/form.css" rel="stylesheet" type="text/css" />
    <link href="../style/Tooltip.css" type="text/css" rel="stylesheet" />
    <!--[if IE 6]> 
<style type="text/css">
#right{float:right;margin-left:0px; }
</style>
<![endif]-->
    <title>日报内容详细页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p>
            <asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div class="DailyListShow">
        <div class="TopTitle"><asp:Label ID="lbl_Title" runat="server"></asp:Label></div>
        <asp:Repeater ID="rpt_Daily" runat="server">
            <HeaderTemplate>
                <div class="DailyDetail">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="Content">
                    <div class="ProDialyContent">
                        <div class="DialyT">
                            日报内容：</div>
                        <div class="DailyView">
                            <%#Eval("Summarize")%>
                        </div>
                    </div>
                </div>
                <div class="Simpinfo">
                    <div class="AddTime">
                        添加时间：<label><%#Eval("CreateTime")%></label></div>
                    <div class="ProName">
                    </div>
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
                        <div class="DemanChangeT">
                            需求变更内容：</div>
                        <div class="DemanChangeView">
                            <%#Eval("Summarize")%>
                        </div>
                    </div>
                </div>
                <div class="Simpinfo">
                    <div class="AddTime">
                        添加时间：<label><%#Eval("CreateTime")%></label></div>
                    <div class="ProName">
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
