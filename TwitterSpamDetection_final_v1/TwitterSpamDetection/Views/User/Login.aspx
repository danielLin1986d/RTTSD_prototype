<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TwitterSpamDetection.Views.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head runat="server">
    <title>Twitter Spam Detection System -- User Login</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link rel="apple-touch-icon" href="apple-touch-icon.png" />
    <link rel="stylesheet" href="../../dist/css/vendor.css" />
    <link rel="stylesheet" id="themeDefaultStyle" href="../../dist/css/app.css" />
</head>
<body>
    <div class="auth">
        <div class="auth-container">
            <div class="card">
                <header class="auth-header">
                    <h1 class="auth-title">
                            Twitter Spam Detection System
                     </h1>
                </header>
                <div class="auth-content">
                    <p class="text-xs-center">LOGIN TO CONTINUE</p>
                    <form id="loginForm" name="loginForm" onsubmit="return false" action="" method="POST" novalidate="" runat="server">
                        <div class="form-group">
                            <label for="username">Email</label>
                            <input type="email" class="form-control underlined" name="txtUserName" id="txtUserName" placeholder="Your email address" required="" />
                        </div>
                        <div class="form-group">
                            <label for="password">Password</label>
                            <input type="password" class="form-control underlined" name="txtUserPwd" id="txtUserPwd" placeholder="Your password" required="" />
                        </div>
                        <div class="form-group">
                            <label for="password">Validation Code</label>
                            <div class="row">
                                <div class="col-sm-6">
                                    <input id="txtUserVal" name="txtUserVal" type="text" class="form-control underlined" placeholder="Validation Code" required="" />
                                </div>
                                <img alt="Validation Code" id="valcode" src="../VCode/VCode.aspx?w=105&h=29" width="35%" style="cursor:pointer;margin-left:10px; margin-bottom:10px;float:left;"
                                    height="34" onclick="javascript:var now=new Date();var number = now.getSeconds(); this.src='../VCode/VCode.aspx?w=105&h=29&dd'+number;" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="remember">
                                <input class="checkbox" id="remember" name="remember" type="checkbox" />
                                <span>Remember me</span>
                            </label>
                            <a href="#" class="forgot-btn pull-right">Forgot password?</a>
                        </div>
                        <div class="form-group">
                            <button type="submit" id="btnLogin" class="btn btn-block btn-primary" onclick="LoginIt();">Login</button>
                        </div>
                        <div class="form-group">
                            <p class="text-muted text-xs-center">Do not have an account? <a href="Signup.aspx" title="Sign up to get access!">Sign Up!</a></p>
                        </div>
                        <p id="error_msg" style="color:#CC0033; font-size:16px; padding-top: 5px; font-weight: bold; text-align: center; clear: both"></p>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- Reference block for JS -->
    <script src="../../dist/js/jquery.js"></script>
    <!-- <script type="text/javascript" src="../../dist/js/icheck.min.js"></script>-->
    <script src="../../dist/js/app.js"></script>
    <script type="text/javascript">
        /*$(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });*/

        /* Login Form Validation */
        function CheckLogin() {
            var userName = $("#txtUserName").val();
            var userPwd = $("#txtUserPwd").val();
            var userVCode = $("#txtUserVal").val();
            if (userName.length == 0) {
                $("#error_msg").html("The Username cannot be null!");
                $("#txtUserName").focus();
                return false;
            }
            if (userPwd.length == 0) {
                $("#error_msg").html("The Password cannot be null！");
                $("#txtUserPwd").focus();
                return false;
            }
            if (userVCode.length == 0) {
                $("#error_msg").html("The Validation Code cannot be null！");
                $("#txtUserVal").focus();
                return false;
            }
            else if (userVCode.length > 0 && userVCode.length < 4) {
                $("#error_msg").html("Please input the correct Validation Code！");
                $("#txtUserVal").focus();
                return false;
            }
            else if (userVCode.length > 4) {
                $("#error_msg").html("Please input the correct Validation Code！");
                $("#txtUserVal").focus();
                return false;
            }
            else if (userVCode.length == 4) {
                var reg = /^\d+$/;
                if (reg.test(userVCode)) {
                    return true;
                }
                else {
                    $("#error_msg").html("The format of the Validation Code is incorrect！");
                    $("#txtUserVal").focus();
                    return false;
                }
            }
            return true;
        }

        function LoginIt() {
            if (CheckLogin() == true) {
                $("#error_msg").text("");
                $("#btnLogin").disabled = true;
                $.ajax({
                    url: "../Ashx/UserLogin.ashx",
                    type: "post",
                    data: $("#loginForm").serialize(),
                    dataType: "text",
                    success: function (json) {
                        var errMsg = json.split("###")[0];
                        try {
                            var jpUrl = json.split("###")[1];
                        } catch (e) { }
                        if (errMsg != "") {
                            $("#valcode").click();
                            $("#error_msg").html(errMsg);
                            $("#btnLogin").disabled = false;
                        }
                        else {
                            $("#btnLogin").disabled = false;
                            window.location.href = jpUrl;
                        }
                    }
                });
            }
        }

        $(function () {
            var currentURL = window.location.href;
            document.onkeydown = function (e) {
                var ev = document.all ? window.event : e;
                if (ev.keyCode == 13) {
                    if (currentURL.indexOf("signup") >= 0) {
                        $("#btnReg").click();
                    } else {
                        $("#btnLogin").click();// Press the login button when is in Login page. 
                    }
                }
            }
        });
    </script>
</body>
</html>
