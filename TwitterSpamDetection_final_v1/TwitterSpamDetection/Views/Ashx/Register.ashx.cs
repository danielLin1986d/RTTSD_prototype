using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using LTP.Common;

namespace TwitterSpamDetection.Views.Ashx
{
    /// <summary>
    /// Summary description for Register
    /// </summary>
    public class Register : IHttpHandler, IRequiresSessionState
    {
        BLL.t_rol_role roleBll = new BLL.t_rol_role();
        BLL.t_rol_user userBll = new BLL.t_rol_user();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "text/plain";

            StringBuilder error = new StringBuilder();
            string userName = StringClass.EncodeString(context.Request.Form["txtEmail"].Trim());
            string userPwd = context.Request.Form["txtPwd"];
            string userCPwd = context.Request.Form["txtCPwd"];
            string checkCode = context.Request.Form["txtUserVal"];
            if (!CheckInput.CheckEmail(userName))
            {
                error.Append("The email format is incorrect, Please check！<br>");
            }
            if (userPwd.Length < 6)
            {
                error.Append("The password should not be less than 6 digits.！<br>");
            }
            else
            {
                if (userPwd != userCPwd)
                {
                    error.Append("Repeated password is different from the previous！<br>");
                }
            }
            if (checkCode != context.Session["ValidateCode"].ToString())
            {
                error.Append("Wrong Validation Code！");
            }
            string userID = Guid.NewGuid().ToString().ToLower();
            if (error.ToString() == "")
            {
                Model.t_rol_user model = new Model.t_rol_user();
                model.ID = userID;
                model.Username = userName;
                model.Password = StringClass.EncryptPassword(userPwd, StringClass.PasswordFormat.MD5_32);
                model.IsValid = 1;
                model.CreatedDate = DateTime.Now;

                // Get the RoleID by RoleName. For normal User
                DataSet Ds = roleBll.GetRoleIDByRoleName("User");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    WindowClass.WindowBack("Failed to get User's Role ID！");
                }
                else
                {
                    model.RoleID = Ds.Tables[0].Rows[0]["ID"].ToString();
                }

                error.Append((new BLL.t_rol_user()).RegisterUser(model));
            }

            if (error.ToString() != "")
            {
                context.Response.Write(error.ToString());
                return;
            }
            else
            {
                Model.t_rol_user model = new Model.t_rol_user();
                model = userBll.GetModel(userID);
                if (model != null)
                {
                    context.Session["User"] = model;
                    model = null;
                    context.Response.Write("<script language='javascript'>window.location.href='/../Views/index.aspx';</script>");
                }
                else
                {
                    WindowClass.WindowBack("Failed to get User model！");
                    context.Response.Write("<script language='javascript'>window.location.href='/../Views/User/Login.aspx';</script>");
                }
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