<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link rel="stylesheet" type="text/css" href="Resource/js/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Resource/js/themes/icon.css" />
    <script type="text/javascript" src="Resource/js/jquery-1.4.2.min.js"></script>
    <script src="Resource/js/jQuery.easyui.js" type="text/javascript"></script>
    <script src="Resource/js/outlook2.js" type="text/javascript"></script>

   
    <script type="text/javascript">
        var _menus = { "menus": [
						{ "menuid": "1", "icon": "icon-sys", "menuname": "信息管理",
						    "menus": [
                                    { "menuname": "班级管理", "icon": "icon-nav", "url": "CategoryProvien.aspx" },
                                    { "menuname": "学生管理", "icon": "icon-nav", "url": "MemberList.aspx" }
								]
						},
                        { "menuid": "1", "icon": "icon-sys", "menuname": "考勤管理",
                            "menus": [
									{ "menuname": "考勤课程", "icon": "icon-nav", "url": "KeChengList.aspx" }
								]
                        }
				]
        };

        $(function () {


            $('#loginOut').click(function () {
                $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {
                    if (r) {
                        location.href = 'Login.aspx';
                    }
                });

            })
        });

    </script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no">
 <form id="form1" runat="server">
    </form>

    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 40px;
        background: url(images/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%;
        line-height: 30px; color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float: right; padding-right: 20px;" class="head">
        <!--<a href="#" id="editpass">修改密码</a> -->
            <a href="#" id="loginOut">安全退出</a></span> 江南大学人文学院教育技术学实验课签到系统
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2; text-align: left">
        <div class="footer" style="text-align: left">
        </div>
    </div>
    <div region="west" split="true" title="导航菜单" style="width: 180px;" id="west">
        <div class="easyui-accordion" fit="true" border="false">
            <!--  导航内容 -->
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow: hidden">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="欢迎使用" style="padding: 20px; overflow: hidden; text-align: center" id="home">
                <h1>
                    欢迎使用IC卡签到系统</h1>
                <object id="csharpActiveX" classid="clsid:A4933801-4419-4DCF-9090-8CC2A1A8DA86" codebase="ReadCardSetup.CAB#version=1.0.0" style="display: none;"></object>
   
            </div>
        </div>
    </div>
</body>
</html>
