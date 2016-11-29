using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace LTP.Common
{
    public class WindowClass
    {
        public WindowClass()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 去除字符串两边的空格相当于Trim()
        /// </summary>
        /// <param name="sTestString">需要去除两边空格的字符串</param>
        /// <returns></returns>
        public static String StringTrim(String sTestString)
        {
            if (sTestString != null)
            {
                sTestString = System.Text.RegularExpressions.Regex.Replace(sTestString, @"(^\s*)|(\s*$)", "");
                return sTestString;
            }
            else
            {
                return "";
            }
        }

        public void ErrorRedirect(String sErrorCode)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='/error/error.asp?errorcode=" + sErrorCode + "';</script>");
        }

        public static void WindowReload()
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='" + HttpContext.Current.Request.Url + "';</script>");
        }

        public static void WindowGoHref(String sUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='" + sUrl + "';</script>");
        }

        public static void WindowGoHref(String sErrorMessage, String sUrl)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + sErrorMessage + "');</script>");
            HttpContext.Current.Response.Write("<script language='javascript'>window.location.href='" + sUrl + "';</script>");
        }

        public static void WindowSelectHref(String sErrorMessage, String sUrl, String nUrl)
        {
            HttpContext.Current.Response.Write("<script language=javascript>if(confirm('" + sErrorMessage + "')){window.loaction.href='" + sUrl + "';}else{window.location.href='" + nUrl + "';}</script>");
        }

        public static void WindowTrace(String sMessage)
        {
            HttpContext.Current.Response.Write("<script language=javascript>alert('" + sMessage + "');</script>");
        }

        public static void WindowClose()
        {
            HttpContext.Current.Response.Write("<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");
            HttpContext.Current.Response.End();
        }

        public static void WindowClose(String sMessage)
        {
            HttpContext.Current.Response.Write("<script language=javascript>alert('" + sMessage + "');window.opener=null;window.open('','_self');window.close();</script>");
            HttpContext.Current.Response.End();
        }

        public static void WindowBack(String sMessage)
        {
            HttpContext.Current.Response.Write("<script language=javascript>alert('" + sMessage + "');history.back();</script>");
            HttpContext.Current.Response.End();
        }

        public static void WindowRefresh(String sMessage)
        {
            HttpContext.Current.Response.Write("<script language=javascript>alert('" + sMessage + "');history.back();</script>");
            HttpContext.Current.Response.Write("<script language='javascript'>window.location.href=document.URL;</script>");
        }

        public static void OpenWindow(String sUrl, String sWindth, String sHeigth)
        {
            if (StringTrim(sUrl) != String.Empty)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>window.open('" + sUrl + "','','width=" + sWindth + ",height=" + sHeigth + ",alwaysRaised =yes,titlebar=no,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no');</script>");
            }
        }

        public static void OpenWindow(System.Web.UI.Page Page, String sUrl)
        {
            if (StringTrim(sUrl) != String.Empty)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "window.open('" + sUrl + "');", true);
            }
        }

        public static void WindowTrace(System.Web.UI.Page Page, string error)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('" + error + "');", true);
        }

        public static void WindowClose(System.Web.UI.Page Page, string error)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('" + error + "');window.opener=null;window.open('','_self');window.close();", true);
        }

        public static void DgClose(System.Web.UI.Page Page)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "dg.cancel();", true);
        }

        public static void DgClose(System.Web.UI.Page Page, String sMessage)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('" + sMessage + "');dg.cancel();", true);
        }
    }
}

