using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using LTP.Common;
using System.Data;

namespace TwitterSpamDetection.Views.Ashx
{
    /// <summary>
    /// Summary description for UserLogin
    /// </summary>
    public class UserLogin : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "text/plain";

            string strUserName = StringClass.EncodeString(context.Request.Form["txtUserName"].Trim());
            string strOldPwd = StringClass.EncodeString(context.Request.Form["txtUserPwd"]);
            string strUserPwd = StringClass.EncryptPassword(context.Request.Form["txtUserPwd"], StringClass.PasswordFormat.MD5_32);
            bool IsRemember = context.Request.Form["remember"] != null ? true : false;

            if (String.IsNullOrEmpty(strUserName))
            {
                context.Response.Write("Please enter your email as user name！");
                return;
            }
            else
            {
                strUserName = StringClass.RemoveSQL(strUserName.ToLower());
            }
            if (String.IsNullOrEmpty(strOldPwd))
            {
                context.Response.Write("Please enter your password！");
                return;
            }
            else
            {
                strUserPwd = StringClass.EncryptPassword(strOldPwd, StringClass.PasswordFormat.MD5_32).ToLower();
            }
            if (context.Session["ValidateCode"] != null)
            {
                if (context.Request.Form["txtUserVal"].Trim() != context.Session["ValidateCode"].ToString())
                {
                    context.Response.Write("Validation Code is not correct！");
                    return;
                }
            }

            string error = "";
            Model.t_log_login loginLog = new Model.t_log_login();
            loginLog.ID = Guid.NewGuid().ToString().ToLower();
            loginLog.LoginDate = DateTime.Now;
            loginLog.IPAddress = context.Request.ServerVariables["REMOTE_ADDR"] != null ? context.Request.ServerVariables["REMOTE_ADDR"].Trim() : "";
            loginLog.ClientInfo = context.Request.ServerVariables["Http_User_Agent"];
            Model.t_rol_user user = (new BLL.t_rol_user()).Login(strUserName, strUserPwd, loginLog);
            if (user != null && user.Password.ToLower() == strUserPwd.ToLower())
            {
                if (user.IsValid > 0)
                {
                    try
                    {
                        HttpCookie Cookie = new HttpCookie("UserCookie");
                        if (IsRemember)
                        {
                            Cookie.Expires = DateTime.Now.AddDays(7);
                        }
                        else
                        {
                            Cookie.Expires = DateTime.Now.AddDays(-1);
                        }
                        Random ra = new Random();
                        string cookieValue = FileDecrypt.Encrypt(user.ID + "&" + user.Username, "", ra);
                        Cookie.Values.Add("cookieValue", cookieValue);

                        context.Response.Cookies.Add(Cookie);
                    }
                    catch { }
                }
                else
                {
                    error = "This user has been disabled！";
                    context.Response.Write(error);
                    return;
                }
                context.Session["User"] = user;
            }
            else
            {
                error = "Your username or passowrd is incorrect！";
                context.Response.Write(error);
                return;
            }

            string roleName = "";
            BLL.t_rol_role roleBll = new BLL.t_rol_role();
            DataSet roleNameDS = roleBll.GetRoleNameByRoleID(user.RoleID);
            if (roleNameDS.Tables[0].Rows.Count != 0)
            {
                roleName = roleNameDS.Tables[0].Rows[0]["RoleName"].ToString();
            }
            else
            {
                context.Response.Write("Failed to get the role.");
            }
            if (roleName == "System Administrator")
            {
                context.Response.Write("<script language='javascript'>window.location.href='/../Views/Admin/index.aspx';</script>");
            }
            if (roleName == "User")
            {
                user = null;
                loginLog = null;
                context.Response.Write("<script language='javascript'>window.location.href='/../Views/index.aspx';</script>");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}