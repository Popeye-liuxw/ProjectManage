<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Form.aspx.cs" Inherits="ProjectManage.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">

 <form id="formM" style="margin:0;padding:0" method="post" action="Form.aspx"> 
    <table class="forms" cellpadding="0" cellspacing="0" border="0" width="94%">
   
    <tr>
        <th colspan="6">表单数据</th>
    </tr>
        <tr>
            <td class="ftfirst" align="right">项名称：</td>
            <td colspan="2">
                <input size="40" id="itemName" tip="输入可以为空,如果不空,将按照绑定的验证规则验证." check="1" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"  />
            </td>
            <td align="right">项名称：</td>
            <td class="ftlast" align="left" colspan="2"> <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" /></td>
        </tr>
        <tr>
            <td class="ftfirst" align="right">项名称：</td>
            <td align="left" colspan="2">
            <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td align="right">项名称：</td>
            <td class="ftlast" align="left" colspan="2">
            <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
            </td>
        </tr>
        <tr>
            <td class="ftfirst" align="right">项名称：</td>
            <td align="left" colspan="2">
            <select name="departmentname" id="departmentname">
                    <option value="1">总经办</option>
                    <option value="2">软件研发部</option>
                    <option value="3">财务部</option>
                    <option value="4">市场部</option>
                    <option value="5">算法部</option>
                </select></td>
            <td align="right">时间：</td>
            <td class="ftlast" align="left" colspan="2">  
            <input size="30" type="text" id="datepicker" class="inputcalender" onblur="this.className='inputcalender'" onfocus="this.className='inputcalender-bor'" />
            </td>
        </tr>
        <tr>
            <td class="ftfirst" align="right">项名称：</td>
            <td align="left" colspan="2">
            <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" /></td>
            <td align="right">项名称：</td>
            <td class="ftlast" align="left" colspan="2"><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" /></td>
        </tr>
        <tr>
        <td class="ftfirst"></td>
        <td colspan="2" align="center"> <input type="submit" name="Submit" value="添加" class="btn2" id="btnAdd" /></td>
        <td class="ftlast" colspan="3"><input type="button" name="Submit" value="取消" class="btn2" id="Button1" /></td>
        </tr>
    </table>
    <!--  --></form>
    <script src="js/superValidator.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        //验证控件
        //1.不能为空
        //2.只能位数字
        //3.只能为汉字
        //4.邮箱
        //5.手机号码
        //6.长度限制
        //7.日期
        //传入表单ID 自动验证表但是上不符合规则的表单控件
        $(document).ready(function () {
            setChineseCheck("name:itemName");
        });

// ]]>
    </script>
</asp:Content>
