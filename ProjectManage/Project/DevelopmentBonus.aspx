<%@ Page Title="项目研发奖金" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevelopmentBonus.aspx.cs" Inherits="ProjectManage.Pages.ProjectBasicinfo.DevelopmentBonus" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    
<script type="text/javascript">

</script>
<div id="r_topmenu">
     <uc:Spinner id="spn_Menu" runat="server" MenuID="5"  />
</div>
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
<div style=" text-align:center;">该模块还在开发中，敬请期待</div>
<%--<div id="developmentbonus">
        <table id="bonus" class="devebouns" cellpadding="0" cellspacing="1" border="0">
        <tr >
        <td class="devebonushead" align="center">
            项目名称：
        </td>
        <td class="devebonushead"  align="center">
            *****项目
        </td>
        <td class="devebonushead"  align="center">
            合计：
        </td>
        <td colspan="2" class="devebonushead"  align="center">
            10000
        </td>
        <td class="devebonushead" align="center">
            <input id="EditSumbonus" type="button" name="EditSumbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            张三
        </td>
        <td>
            合计:
        </td>
        <td colspan="2">999</td>
        <td  align="center">
            <input id="Button1" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button2" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
         </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button3" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
       <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">&nbsp;</td>
        <td  align="center">
            <input id="Button4" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button5" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button6" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
             <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            李四
        </td>
        <td>
            合计:
        </td>
        <td colspan="2">999</td>
        <td  align="center">
            <input id="Button7" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button8" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
         </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button9" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
       <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button10" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button11" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>
            时间：
        </td>
        <td>
            2012-05-16
        </td>
        <td colspan="2">200</td>
        <td  align="center">
            <input id="Button12" type="button" name="Editsubbonus" value="编辑" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
        </td>
        </tr>
        </table>
</div>--%>
</asp:Content>
