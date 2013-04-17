<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractDetail.ascx.cs"
        Inherits="ProjectManage.Pages.Contract.ContractDetail" %>
<div id="ContractDetail_Div" style="display: none; width: 1000px; height: 700px;
        overflow: scroll;">
        <table id="forms" cellpadding="0" cellspacing="0" border="0" width="90%">
                <tr>
                        <td class="ftfirst" align="right">
                                项目编号：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                项目名称：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                项目类型：
                        </td>
                        <td>
                                <select name="departmentname" id="Select1">
                                        <option value="1">总经办</option>
                                        <option value="2">软件研发部</option>
                                        <option value="3">财务部</option>
                                        <option value="4">市场部</option>
                                        <option value="5">算法部</option>
                                </select>
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                项目性质：
                        </td>
                        <td>
                                <select name="departmentname" id="Select2">
                                        <option value="1">总经办</option>
                                        <option value="2">软件研发部</option>
                                        <option value="3">财务部</option>
                                        <option value="4">市场部</option>
                                        <option value="5">算法部</option>
                                </select>
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                合同类型：
                        </td>
                        <td>
                                <select name="departmentname" id="departmentname">
                                        <option value="1">总经办</option>
                                </select>
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                合同应付金额：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                合同应收金额：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                签订时间
                        </td>
                        <td>
                                <input size="40" name="name" class="inputcalender" id="datepicker" onblur="this.className='inputcalender'"
                                        onfocus="this.className='inputcalender-bor'" />
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $(function () {
                                            $("#datepicker").datepicker();
                                        });
                                    });
                                </script>
                        </td>
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                客户信息：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                存档数量
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                        </td>
                        <td class="ftlast" align="left">
                                （此项为必填）
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right" colspan="6">
                                <input type="button" name="Submit" value="保存" style="width: 60px; height: 24px; font-size: 12px;
                                        background: #86A9D2; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"
                                        id="BtnSave" />
                                <input type="button" name="Submit" value="取消" style="width: 60px; height: 24px; font-size: 12px;
                                        background: #86A9D2; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"
                                        id="Button1" />
                        </td>
                </tr>
        </table>
        <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0"
                width="90%">
                <tr>
                        <td colspan="6">
                                付款信息
                        </td>
                </tr>
                <tr>
                        <th class="thfirst">
                                付款时间
                        </th>
                        <th>
                                付款额
                        </th>
                        <th>
                                剩余额度
                        </th>
                </tr>
                <tr align="center">
                        <td class="tfirst">
                                数据
                        </td>
                        <td>
                                数据
                        </td>
                        <td>
                                数据
                        </td>
                </tr>
        </table>
        <table class="datalist" id="Table1" cellpadding="0" cellspacing="0" border="0" width="90%">
                <tr>
                        <td colspan="6">
                                收款信息
                        </td>
                </tr>
                <tr>
                        <th class="thfirst">
                                收款时间
                        </th>
                        <th>
                                收款额
                        </th>
                        <th>
                                剩余额度
                        </th>
                </tr>
        </table>
</div>
