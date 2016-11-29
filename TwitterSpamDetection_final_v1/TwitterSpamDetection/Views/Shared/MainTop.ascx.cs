using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterSpamDetection.Views.Shared
{
    public partial class MainTop : System.Web.UI.UserControl
    {
        private Model.t_rol_user _user; //用来为界面上的用户名称、注册时间、用户角色等赋值
        BLL.t_rol_role roleBll = new BLL.t_rol_role();
        string userRoleName = "";

        public Model.t_rol_user User
        {
            get { return _user; }
            set { _user = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User != null)
            {
                DataSet ds = roleBll.GetRoleNameByRoleID(User.RoleID);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    userRoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    if ((userRoleName != "") && (userRoleName == "System Administrator"))
                    {
                        userNamelb.Text = "Administrator";
                        //admin_menu_section.Visible = true;
                    }
                    if ((userRoleName != "") && (userRoleName == "User"))
                    {
                        if ((User.FirstName == "") || (User.LastName == ""))
                        {
                            userNamelb.Text = "Anonymous";
                        }
                        else
                        {
                            userNamelb.Text = User.FirstName + " " + User.LastName;
                        }
                    }
                }
                else
                {
                    LTP.Common.WindowClass.WindowBack("Failed to get the user role！");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('Login Error, please try again!');</script>");
                Response.Redirect("../User/Login.aspx");
            }
        }

        protected void SignOut(object sender, EventArgs e)
        {
            if ((userRoleName != "") && (userRoleName == "System Administrator"))
            {
                Session.Abandon();
                User = null;
                Response.Write("<script language='javascript'>window.parent.location.href='../../Views/User/Login.aspx';</script>");
            }
            if ((userRoleName != "") && (userRoleName == "User"))
            {
                Session.Abandon();
                User = null;
                Response.Write("<script language='javascript'>window.parent.location.href='../Views/User/Login.aspx';</script>");
            }
            Response.End();
        }
    }
}