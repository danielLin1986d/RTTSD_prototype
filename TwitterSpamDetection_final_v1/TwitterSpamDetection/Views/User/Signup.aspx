<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="TwitterSpamDetection.Views.User.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head runat="server">
    <title>Twitter Spam Detection System -- User Sign Up</title>
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
                    <h1 class="auth-title">Twitter Spam Detection System
                    </h1>

                </header>
                <div class="auth-content">
                    <p class="text-xs-center">SIGNUP TO GET INSTANT ACCESS</p>
                    <form id="regForm" name="regForm" method="post" onsubmit="return false" novalidate="" runat="server">
                        <div class="form-group">
                            <label for="email">Email</label>
                            <input type="email" class="form-control underlined" name="txtEmail" id="txtEmail" placeholder="Enter email address" required="" onblur="validEmail();" onchange="changeEmail();" />
                        </div>
                        <div id="divNameError" runat="server" style="color: Red;"></div>
                        <div id="divNameOK" runat="server" style="color: Green;"></div>
                        <div class="form-group">
                            <label for="password">Password</label>
                            <input type="password" class="form-control underlined" id="txtPwd" name="txtPwd" placeholder="Enter password" required="" onblur="validPwd();" />
                        </div>
                        <div class="form-group">
                            <label for="password">Re-type Password</label>
                            <input type="password" class="form-control underlined" id="txtCPwd" name="txtCPwd" placeholder="Re-type password" required="" onblur="validCPwd();" />
                        </div>
                        <div class="form-group">
                            <label for="password">Validation Code</label>
                            <div class="row">
                                <div class="col-sm-6">
                                    <input id="txtUserVal" name="txtUserVal" type="text" class="form-control underlined" placeholder="Validation Code" required="" />
                                </div>
                                <img alt="Validation Code" id="Rgvalcode" src="../VCode/VCode.aspx?w=105&h=29" width="35%" style="cursor: pointer; margin-left: 10px; margin-bottom: 10px; float: left;"
                                    height="34" onclick="javascript:var now=new Date();var number = now.getSeconds(); this.src='../VCode/VCode.aspx?w=105&h=29&dd'+number;" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="agree">
                                <input class="checkbox" name="agree" id="agree" type="checkbox" required="" />
                                <span>Agree the terms and <a href="#">policy</a></span>
                            </label>
                        </div>
                        <div class="form-group">
                            <button type="submit" id="btnReg" onclick="submitForm();" class="btn btn-block btn-primary">Sign Up</button>
                        </div>
                        <div class="form-group">
                            <p class="text-muted text-xs-center">Already have an account? <a href="login.html">Login!</a></p>
                        </div>
                        <p id="Rg_error_msg" style="color: #CC0033; font-size: 16px; padding-top: 5px; font-weight: bold; text-align: center; clear: both"></p>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- Reference block for JS -->
    <script src="../../dist/js/jquery.js"></script>
    <!-- <script type="text/javascript" src="../../dist/js/icheck.min.js"></script>-->
    <script src="../../dist/js/app.js"></script>
    <script type="text/javascript" src="../../dist/js/JQValid.js"></script>
    <script type="text/javascript">
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

        /* Register Form Validation */
        var E = false;
        var FM = false;
        var SM = false;
        var C = false;

        var xmlHttp;
        function createXmlRequest() {
            if (window.ActiveXObject) {
                var xmlHttps = ["MSXML2.XMLHttp.5.0", "MSXML2.XMLHttp4.0",
                         "MSXML2.XMLHttp3.0", "MSXML2.XMLHttp", "Microsoft.XMLHTTP"];
                try {
                    for (var i = 0; i < xmlHttps.length; i++) {
                        xmlHttp = new ActiveXObject(xmlHttps[i]);
                        return xmlHttp;
                    }
                }
                catch (error) {
                }
            }
            else {
                xmlHttp = new XMLHttpRequest();
                return xmlHttp;
            }
            throw new Error("Check Username failed！");
        }
        function handleStateChange() {
            if (xmlHttp.readyState == 4) {
                if (xmlHttp.responseText == "1") {
                    document.getElementById("divNameError").innerHTML = "This email has been registered by other user, please use another one.";
                    document.getElementById("divNameOK").innerHTML = "";
                    var btnReg = document.getElementById("btnReg");
                    btnReg.disabled = true;
                    E = false;
                }
                if (xmlHttp.responseText == "0") {
                    document.getElementById("divNameOK").innerHTML = "You can use this email to register!";
                    document.getElementById("divNameError").innerHTML = "";
                    var btnReg = document.getElementById("btnReg");
                    btnReg.disabled = false;
                    E = true;
                }
            }
        }

        function submitForm() {
            validEmail();
            validPwd();
            validCPwd();
            validCode();
            if (E && FM && SM && C) {
                if ($("#agree").is(":checked")) {
                    $("#Rg_error_msg").text("");
                    //        $("#btnReg").val("稍等...");
                    $("#btnReg").attr("disabled", true);
                    //$("#regForm").submit();
                    $.ajax({
                        url: "../Ashx/Register.ashx",
                        type: "post",
                        data: $("#regForm").serialize(),
                        dataType: "text",
                        success: function (json) {
                            var errMsg = json.split("###")[0];
                            try {
                                var jpUrl = json.split("###")[1];
                            } catch (e) { }
                            if (errMsg != "") {
                                $("#Rgvalcode").click();
                                $("#Rg_error_msg").html(errMsg);
                                //$("#btnReg").disabled = false;
                                $("#btnReg").removeAttr('disabled');
                            }
                            else {
                                $("#btnReg").disabled = false;
                                window.location.href = jpUrl;
                            }
                        }
                    });
                }
                else {
                    //$("#btnReg").disable = true;
                    $("#Rg_error_msg").text("You should agree the terms and policy.");
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function changeEmail() {
            E = false;
            $("#Rg_error_msg").text("");
        }
        function validEmail() {
            if (!E) {
                if (IsNothing($("#txtEmail"), "Email should not be null！", $("#Rg_error_msg"))) {
                    E = false;
                }
                else {
                    if ($("#txtEmail").val() != "") {
                        if (checkemail($("#txtEmail"), "Email format is not correct！", $("#Rg_error_msg"))) {
                            E = false;
                        } else {
                            /*else {
                                var option = {
                                    url: "../Ashx/CheckUserExistance.ashx",
                                    type: 'post',
                                    dataType: 'text',
                                    data: { userName: $("#txtEmail").val().trim() }, //发送服务器数据 
                                    async: false,
                                    success: function (data) {  //成功事件 
                                        if (data != "") {
                                            $("#spanEmail").html(data);
                                            E = false;
                                        }
                                        else {
                                            $("#spanEmail").html("");
                                            E = true;
                                        }
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) { //发送失败事件 
                                        $("#spanEmail").html("");
                                        E = false;
                                    }
                                };
                                //进行异步传输 
                                $.ajax(option);
                            }*/
                            xmlHttp = createXmlRequest();
                            xmlHttp.onreadystatechange = handleStateChange;
                            var userNameToCheck = document.getElementById("txtEmail").value;
                            if (userNameToCheck == "") {
                                return;
                            }
                            else {
                                xmlHttp.open("GET", "../Ashx/CheckUserExistance.ashx?userNameToCheck=" + userNameToCheck + "", true);
                                xmlHttp.send(null);
                            }
                        }
                    }
                }
            } else {
                $("#btnReg").disabled = true;
            }
        }

        function validPwd() {
            $("#Rg_error_msg").text("");
            if (IsNothing($("#txtPwd"), "Password should not be null！", $("#Rg_error_msg"))) {
                FM = false;
            }
            else {
            if ($("#txtPwd").val() != "") {
                if (checkpwd($("#txtPwd"), "Password should be more than 6 digits！", $("#Rg_error_msg"))) {
                    FM = false;
                }
                else {
                    FM = true;
                }
              }
            }
        }

        function validCPwd() {
            $("#Rg_error_msg").text("");
            if (IsNothing($("#txtCPwd"), "Repeated Password should not be null！", $("#Rg_error_msg"))) {
                SM = false;
            }
            else {
            if ($("#txtCPwd").val() != "") {
                if ($("#txtPwd").val() != $("#txtCPwd").val()) {
                    $("#Rg_error_msg").html("Repeated password is different from the previous！");
                    SM = false;
                    $("#btnReg").disabled = true;
                }
                else {
                    $("#spanCPwd").html("");
                    SM = true;
                }
              }
            }
        }

        function changeCode() {
            $("#Rg_error_msg").text("");
            C = false;
        }
        function validCode() {
            if (!C) {
                if (IsNothing($("#txtUserVal"), "The validation code should not be null！", $("#Rg_error_msg"))) {
                    C = false;
                    //$("#btnReg").disable = true;
                }
                    /*else {
                        var option = {
                            url: "../Ashx/Register.ashx",
                            type: 'post',
                            dataType: 'text',
                            data: { validCode: $("#txtUserRgVal").val().trim() }, //发送服务器数据 
                            async: false,
                            success: function (data) {  //成功事件 
                                if (data != "") {
                                    $("#spanCode").html(data);
                                    C = false;
                                }
                                else {
                                    $("#spanCode").html("");
                                    C = true;
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) { //发送失败事件 
                                $("#spanCode").html("");
                                C = false;
                            }
                        };
                        //进行异步传输 
                        $.ajax(option);
                    }*/else {
                    C = true;
                }
            }
        }
    </script>
</body>
</html>
