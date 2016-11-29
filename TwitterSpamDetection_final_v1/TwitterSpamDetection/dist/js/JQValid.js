function canDrag() {
    return false;
}

function GetRequest(strName) {
    var strHref = window.document.location.href;
    var intPos = strHref.indexOf("?");
    var strRight = strHref.substr(intPos + 1);

    var arrTmp = strRight.split("&");
    for (var i = 0; i < arrTmp.length; i++) {
        var arrTemp = arrTmp[i].split("=");

        if (arrTemp[0].toUpperCase() == strName.toUpperCase()) return arrTemp[1].replace("#", "");
    }
    return "";
}

String.prototype.replaceAll = function (s1, s2) {

    return this.replace(new RegExp(s1, "gm"), s2);

}

function dateDiff(date1, date2) {
    return (date2 - date1) / (1000 * 60 * 60 * 24);
}

String.prototype.trim = function () {
    return this.replace(/^\s+/g, "").replace(/\s+$/g, "");
}

function IsNothing(field, error_msg, varSpan) {
    if (field.val().replace(/(^\s*)|(\s*$)/g, "") == "") {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}
function checknumber(field, error_msg, varSpan) {
    var val = field.val();

    if (isNaN(val)) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}

function checkmoney(field, error_msg, varSpan) {
    var val = field.val();

    if (isNaN(val)) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        if (val - 0 < 0) {
            varSpan.html(error_msg);
            return true;
        }
        varSpan.html("");
        return false;
    }
}

function checkdigit(field, error_msg, varSpan) {
    var val = field.val();
    if (isNaN(val)) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        if (val % 1 != 0) {
            varSpan.html(error_msg);
            return true;
        }
        else {
            varSpan.html("");
            return false;
        }
    }
}
function checkdate(field, error_msg, varSpan) {
    var patrn = /^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[0-9])|(1[0-9])|(2[0-3]))\:(([0-5][0-9])|([0-9]))(((\s)|(\:(([0-5][0-9])|([0-9]))))?)))?$/;
    if (!patrn.exec(field.val())) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}
function checkemail(field, error_msg, varSpan)// check email
{
    var checkflag = true;
    var retvalue;
    if (window.RegExp) {
        var tempstring = "a";
        var exam = new RegExp(tempstring);
        if (tempstring.match(exam)) {
            var ret1 = new RegExp("(@.*@)|(\\.\\.)|(@\\.)|(^\\.)");
            var ret2 = new RegExp("^.+\\@(\\[?)[a-zA-Z0-9\\-\\.]+\\.([a-zA-Z]{2,3}|[0-9]{1,3})(\\]?)$");
            retvalue = (!ret1.test(field.val()) && ret2.test(field.val()));
        }
        else {
            checkflag = false;
        }
    }
    else {
        checkflag = false;
    }
    if (!checkflag) {
        retvalue = ((field.val() != "") && (field.val().indexOf("@")) > 0 && (field.val().index.Of(".") > 0));
    }
    if (retvalue) {
        varSpan.html("");
        return false;
    }
    else {
        varSpan.html(error_msg);
        return true;
    }
}

function checkmobile(field, error_msg, varSpan) {
    var patrn = /^1[3,5,8]{1}[0-9]{1}[0-9]{8}$/;
    if (!patrn.exec(field.val())) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}

function checkpwd(field, error_msg, varSpan) {
    var patrn = /^[0-9]{1,5}$/;
    if (!patrn.exec(field.val())) {
        varSpan.html("");
        return false;
    }
    else {
        varSpan.html(error_msg);
        return true;

    }
}

function checkguid(field, error_msg, varSpan) {
    var patrn = /^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$/;
    if (!patrn.exec(field.val())) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}

function checkidnumber(field, error_msg, varSpan) {
    var patrn = /^\d{17}[\d|X]$|^\d{15}$/;
    if (!patrn.exec(field.val())) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}

function checkpostid(field, error_msg, varSpan) {
    var i, j, strTemp, len;
    var flag = 1;
    len = field.val().length;
    if (len != 6) {
        flag = 0;
    }
    strTemp = "0123456789";
    for (i = 0; i < len; i++) {
        j = strTemp.indexOf(field.val().charAt(i));
        if (j == -1) {
            flag = 0;
        }
    }
    if (flag == 0) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}

function isempty(field, error_msg, varSpan)//there is nothing in the field of textarea
{
    var flag = 0
    var str = field.val()
    for (i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) != 13 && str.charCodeAt(i) != 10 && str.charCodeAt(i) != 32) {
            flag = 1
            break;
        }
    }
    if (flag == 0) {
        varSpan.html(error_msg);
        return true;
    }
    else {
        varSpan.html("");
        return false;
    }
}


function Num()//
{
    var berr = false;
    if (!((event.keyCode >= 48 && event.keyCode <= 57))) berr = true;
    return !berr;
}
function money()//
{
    var berr = false;
    if (!((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 46)) berr = true;
    return !berr;
}

function checkfilename(field, err_msg) {/*
	var checkflag = true;
	var retvalue;
	if (window.RegExp)
	{
		var tempstring = "a";
		var exam = new RegExp(tempstring);
		if (tempstring.match(exam))
		{
			var ret1 = new RegExp("[a-zA-Z0-9]");
			var ret2 = new RegExp("[a-zA-Z0-9]");
			retvalue = (!ret1.test(field.val()) && ret2.test(field.val()));
		}
		else
		{
			checkflag = false;
		}
		if (!checkflag) 
		{
			retvalue = ( (field.val() != "") && (field.val().index.Of(".") > 0) );
		}
		if(!retvalue)
		{
			alert(err_msg);
			field.focus();
			return true;
		}
	}	*/
    return false;
}

function checkstrone(field, error_msg)// check strone
{
    var checkflag = true;
    var retvalue;
    if (field.val() != "") {
        if (window.RegExp) {
            var tempstring = "a";
            var exam = new RegExp(tempstring);
            if (tempstring.match(exam)) {
                var ret1 = new RegExp("\!|\@\|\#|\%|\&|\-|\=|\;|\:|\'|\,|\/| select | update | delete | from | and | or | exec | insert | chr | mid | truncate | not | count ", "i");
                var ret2 = /\^/;
                var ret3 = /\\/;
                var ret4 = /\$/;
                var ret5 = /\*/;
                var ret6 = /\(/;
                var ret7 = /\)/;
                var ret8 = /\+/;
                var ret9 = /\[/;
                var ret10 = /\]/;
                var ret11 = /\./;
                var ret12 = /\?/;
                retvalue = !(ret1.test(field.val()) || ret2.test(field.val()) || ret3.test(field.val()) || ret4.test(field.value) || ret5.test(field.val()) || ret6.test(field.val()) || ret7.test(field.val()) || ret8.test(field.val()) || ret9.test(field.val()) || ret10.test(field.val()) || ret11.test(field.val()) || ret12.test(field.val()));
                //retvalue = !ret1.test(field.val());
            }
            else {
                checkflag = false;
            }
        }
        else {
            checkflag = false;
        }
        if (!checkflag) {
            retvalue = ((field.val() != "") && (field.val().indexOf("@")) > 0 && (field.val().index.Of(".") > 0));
        }

        if (retvalue) {
            return false;
        }
        else {
            alert(error_msg);
            field.focus();
            return true;
        }
    }
    else {
        return false;
    }
}

function checktitle(field, error_msg)// check email
{
    var checkflag = true;
    var retvalue;
    if (field.val() != "") {
        if (window.RegExp) {
            var tempstring = "a";
            var exam = new RegExp(tempstring);
            if (tempstring.match(exam)) {
                var ret1 = new RegExp("\'| select | update | delete | from | and | or | exec | insert | chr | mid | truncate | not | count ", "i");
                retvalue = !ret1.test(field.val());
            }
            else {
                checkflag = false;
            }
        }
        else {
            checkflag = false;
        }
        if (!checkflag) {
            retvalue = ((field.val() != "") && (field.val().indexOf("@")) > 0 && (field.val().index.Of(".") > 0));
        }

        if (retvalue) {
            return false;
        }
        else {
            alert(error_msg);
            field.focus();
            return true;
        }
    }
    else {
        return false;
    }
}


//function checkpwd(field, error_msg)// check strone
//{
//    var checkflag = true;
//    var retvalue;
//    if (field.val() != "") {
//        if (window.RegExp) {
//            var tempstring = "a";
//            var exam = new RegExp(tempstring);
//            if (tempstring.match(exam)) {
//                var ret1 = new RegExp(" select | update | delete | from | and | or | exec | insert | chr | mid | truncate | not | count ", "i");
//                var ret2 = /\W/;
//                retvalue = !(ret1.test(field.val()) || ret2.test(field.val()))
//            }
//            else {
//                checkflag = false;
//            }
//        }
//        else {
//            checkflag = false;
//        }
//        if (!checkflag) {
//            retvalue = ((field.val() != "") && (field.val().indexOf("@")) > 0 && (field.val().index.Of(".") > 0));
//        }

//        if (retvalue) {
//            return false;
//        }
//        else {
//            alert(error_msg);
//            field.focus();
//            return true;
//        }
//    }
//    else {
//        return false;
//    }
//}

//no checkbox be checked
function ischecked(error_msg) {
    var iFlag = false;
    for (var i = 0; i < document.getElementById("form1").elements.length; i++) {
        if (document.getElementById("form1").elements[i].type == "checkbox") {
            if (document.getElementById("form1").elements[i].checked == true) {
                iFlag = true;
                break;
            }
        }
    }

    if (iFlag == true) {
        return false;
    }
    else {
        alert(error_msg);
        return true;
    }
}

function isboxchecked(varName, error_msg) {
    var iFlag = false;
    for (var i = 0; i < document.getElementById("form1").elements.length; i++) {
        if (document.getElementById("form1").elements[i].type == "checkbox" && document.getElementById("form1").elements[i].id.indexOf(varName) > -1) {
            if (document.getElementById("form1").elements[i].checked == true) {
                iFlag = true;
                break;
            }
        }
    }

    if (iFlag == true) {
        return false;
    }
    else {
        alert(error_msg);
        return true;
    }
}

function havacheck(formname, inputname, error_msg) {
    var flag = 0;
    for (var i = 0; i < formname.length; i++) {
        if (formname[i].name == inputname) {
            if (formname[i].checked == true) {
                flag = 1;
                break;
            }
        }
    }

    if (flag == 1) {
        return false;
    }
    else {
        alert(error_msg);
        return true;
    }
}

function checktel(field, error_msg) {
    var i, j, strTemp, len;
    var flag = 1;
    if (field.val() != "") {
        len = field.val().length;
        if (len < 7 || len > 32) {
            flag = 0;
        }
        strTemp = "0123456789-()# ";
        for (i = 0; i < len; i++) {
            j = strTemp.indexOf(field.val().charAt(i));
            if (j == -1) {
                flag = 0;
            }
        }
        if (flag == 0) {
            alert(error_msg);
            field.focus();
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}

function checkidcard(field, error_msg) {
    var checkflag = true;
    var retvalue;
    if (field.val() != "") {
        if (window.RegExp) {
            var tempstring = "a";
            var exam = new RegExp(tempstring);
            if (tempstring.match(exam)) {
                var ret1 = /\W/;
                retvalue = !ret1.test(field.val())
            }
            else {
                checkflag = false;
            }
        }
        else {
            checkflag = false;
        }
        if (!checkflag) {
            retvalue = ((field.val() != "") && (field.val().indexOf("@")) > 0 && (field.val().index.Of(".") > 0));
        }

        if (retvalue && (field.val().length == 15 || field.val().length == 18)) {
            return false;
        }
        else {
            alert(error_msg);
            field.focus();
            return true;
        }
    }
    else {
        return false;
    }
}





