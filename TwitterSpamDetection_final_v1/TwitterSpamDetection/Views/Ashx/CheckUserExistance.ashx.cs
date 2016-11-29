using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterSpamDetection.Views.Ashx
{
    /// <summary>
    /// Summary description for CheckUserExistance
    /// </summary>
    public class CheckUserExistance : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "text/plain";

            bool checkResult = false;

            string userNameToCheck = LTP.Common.StringClass.EncodeString(context.Request.Params["userNameToCheck"].ToString().Trim());//检查用户名是否存在
            userNameToCheck = LTP.Common.StringClass.RemoveSQL(userNameToCheck);
            if (userNameToCheck != "")
            {
                BLL.t_rol_user userBll = new BLL.t_rol_user();
                checkResult = userBll.checkUserExistance(userNameToCheck);
                if (checkResult)
                {
                    context.Response.Write("1");
                    return;
                }
                else
                {
                    context.Response.Write("0");
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