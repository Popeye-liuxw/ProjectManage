<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectResultsShow.aspx.cs" Inherits="ProjectManage.ProjectResultsShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <table id="ProjectResultsearch" class="datalist"  cellpadding="0" cellspacing="0" border="0"  width="90%">
<tr> <th colspan="10">项目成果展示信息搜索</th></tr>
<tr align="center">
    <td class="tfirst">项目名称：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td>项目编号：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td >时间自：</td>
    <td>
     <input size="30" type="text" id="Resultdatepickerstart" class="inputcalender" onblur="this.className='inputcalender'"
                    onfocus="this.className='inputcalender-bor'" />
                <script type="text/javascript">
                    $(document).ready(function () {
                        $(function () {
                            $("#Resultdatepickerstart").datepicker();
                        });
                    });
                </script>
    </td>
    <td>到：</td>
    <td>
        <input size="30" type="text" id="Resultdatepickerend" class="inputcalender" onblur="this.className='inputcalender'"
                    onfocus="this.className='inputcalender-bor'" />
                <script type="text/javascript">
                    $(document).ready(function () {
                        $(function () {
                            $("#Resultdatepickerend").datepicker();
                        });
                    });
                </script>
    </td>
    <td>
            <input type="submit" name="Submit" value="查  询" style="width:76px;height:24px; font-size: 12px;color:#FFF; background:#486AAA;cursor:hand; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/> 
    </td>
    <td class="tlast"> 
    <script type="text/javascript">
        $(document).ready(function () {
            $("#add_newShow").click(function () {
                location.href = "AddProjectShow.aspx";
            });
        });
    </script>
            <input type="button" name="add_user" id="add_newShow" value="添加新展示" style="width:76px;height:24px; font-size: 12px; color:#FFF; cursor:hand;background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/>
     </td>
    </tr>
</table>
<table class="datalist" id="tb_ProjectShow" cellpadding="0" cellspacing="0" border="0"  width="90%">
    <tr>
                <th class="thfirst">列头数据</th>
                <th>列头数据</th>
                <th>列头数据</th>
                <th>列头数据</th>
                <th>编辑</th>
                <th class="thlast">删除</th>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     </table>
<div id="pager_top">
    <div class="pager"><a href="#">&lt; Prev</a><a href="#">1</a><span class="current">2</span><a href="#">3</a><a href="#">4</a><a href="#">5</a><a href="#">6</a><a href="#">7</a><a href="#">8</a><a href="#">9</a><a href="#">10</a><a href="#">11</a>···<a href="#">18</a><a href="#">Next &gt;</a></div>
    </div>
</asp:Content>
