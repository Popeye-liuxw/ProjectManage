<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HomePage.aspx.cs" Inherits="ProjectManage.HomePage" %>

<asp:Content ID="Head1" ContentPlaceHolderID="head_main" runat="server">
    <%--<script type="text/javascript" language="JavaScript1.2">
        var rector = 3
        var stopit = 0
        var a = 1
        var shake;

        function init(which) {
            stopit = 0
            shake = which
            shake.style.left = 0
            shake.style.top = 0
        }

        function rattleimage() {
            if ((!document.all && !document.getElementById) || stopit == 1)
                return
            if (a == 1) {
                shake.style.top = parseInt(shake.style.top) + rector
            }
            else if (a == 2) {
                shake.style.left = parseInt(shake.style.left) + rector
            }
            else if (a == 3) {
                shake.style.top = parseInt(shake.style.top) - rector
            }
            else {
                shake.style.left = parseInt(shake.style.left) - rector
            }
            if (a < 4)
                a++
            else
                a = 1
            setTimeout("rattleimage()", 50)
        }

        function stoprattle(which) {
            stopit = 1
            which.style.left = 0
            which.style.top = 0
        }
    </script>
    
    class="shakeimage" onmouseover="init(this);rattleimage()"
                                onmouseout="stoprattle(this)"
    --%>
    <script type="text/javascript">
　　        var i = 0;
        document.onkeydown = zoom;
        function zoom() {
            var IEKey = event.keyCode;
            if (IEKey == 76) {
                i++;
                document.body.style.zoom = 1 + i / 10;
            }
            if (IEKey == 83) {
                i--;
                document.body.style.zoom = 1 + i / 10;
            }
            if (IEKey == 82) {
                document.body.style.zoom = 1;
                i = 1;
            }
            if (IEKey == 17) {
                document.body.style.zoom = 1;
            }
        }
        function changeSize() {
            //获取图片的zoom样式属性 如果zoom样式不存在 即100
            var zoom = parseInt(img.style.zoom, 10) || 100;
            //根据滚轮的滚动值
            zoom += event.wheelDelta / 12;
            //判断zoom值是否大于0 zoom小于0图片无法显示
            alert(zoom);
            document.body.style.zoom = 100 + "%";

            //禁止触发滚轮滚动的默认事件
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div class="mybox" >
        <ul class="t-c">
            <li class="li-hori-w122">
                <div class="box-app">
                    <p>
                        <a class="img-app" target="_blank" href="http://192.168.0.24:8088/mantis/login_page.php"
                            title=""><i class="img-app-none"></i>
                            <img alt="Bug管理工具" width="70" height="70" src="images/fav.png" />
                        </a>
                    </p>
                    <h5 class="t-overflow">
                        <a style="font-size: 14px;" target="_blank" href="http://192.168.0.24:8088/mantis/login_page.php">
                            Bug管理工具</a></h5>
                </div>
            </li>
            <li class="li-hori-w122">
                <div class="box-app">
                    <p>
                        <a class="img-app" target="_blank" href="http://mail.visione.com.cn" title=""><i
                            class="img-app-none"></i>
                            <img alt="公司邮件" width="70" height="70" src="images/rss.png" />
                        </a>
                    </p>
                    <h5 class="t-overflow">
                        <a style="font-size: 14px;" target="_blank" href="http://mail.visione.com.cn">公司邮件</a></h5>
                </div>
            </li>
            <li class="li-hori-w122">
                <div class="box-app">
                    <p>
                        <a class="img-app" href="#" title=""><i class="img-app-none"></i>
                            <img alt="公司论坛" width="70" height="70" src="images/studio.png" />
                        </a>
                    </p>
                    <h5 class="t-overflow">
                        <a style="font-size: 14px;" href="#">公司论坛</a></h5>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
