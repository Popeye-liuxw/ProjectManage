// JScript 文件
/*
 * table 鼠标悬停变色
 *@param tabID 表格名称
 *@param oveClass 鼠标进入时的样式
 *@param outClass 鼠标离开时的样式(为样式名称)
 */
$(document).ready(function () {
    function altrow(tabID, oveClass) {
        var rowObj = $("#" + tabID).find("tr");
        $.each(rowObj, function (i, obj) {
            var tr = $(obj);
            tr.mousemove(function () {
                tr.addClass(oveClass);
            });
            tr.mouseout(function () {
                tr.removeClass(oveClass);
            });
        });
    }
    altrow("userdatalist", "td"); //用户表
    altrow("ExternalCostslist", "td"); //外协费
    altrow("ProjectList", "td"); //日报
    altrow("tb_ProjectShow", "td"); //项目成果展示
    altrow("userlogTable","td");
    
    //弹出层 
});
