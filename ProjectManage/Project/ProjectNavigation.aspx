<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectNavigation.aspx.cs" Inherits="ProjectManage.Project.ProjectNavigation" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导航页</title>
</head>
<body>
    <div id="r_topmenu">
        <uc:Spinner id="spn_Menu" runat="server" />
    </div>
</body>
</html>
