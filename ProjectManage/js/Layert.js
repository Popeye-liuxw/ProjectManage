$("#test6").click(function () {
    alert("xx");

    $("#StaffDetail").zxxbox();    //或者是$.zxxbox($("#login"));
    $("#loginBtn").click(function () {
        /*
        *
        一些登录操作
        *
        */
        alert("登录成功！");
        $.zxxbox.hide();
    });
    $("#cancelBtn").click(function () {
        $.zxxbox.hide();
    });
});