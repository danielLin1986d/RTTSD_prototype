using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTP.Common;

namespace TwitterSpamDetection
{
    public class PageBase : System.Web.UI.Page
    {
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                //Response.Write("系统检测到用户输入了有潜在危险的信息，例如：<'&^%>等，请点击<a href='javascript:void(0)' onclick='history.back();'>【返回】</a>修改后重新提交！");
                //Server.ClearError();
            }
            else
            {
                //Response.Redirect("Error.aspx");
            }
        }
        protected Model.t_rol_user User;

        protected override void OnPreLoad(EventArgs e)
        {
            if (this.Page != null)
            {
                try
                {
                    User = Session["User"] as Model.t_rol_user;
                }
                catch
                {
                    User = null;
                }

                if (User == null)
                {
                    Response.Write("<script>window.location.href='../Views/User/Login.aspx';</script>");
                    Response.End();
                }
                base.OnPreLoad(e);
            }
        }

        protected void FetchKeyword(string keyword, System.Web.UI.WebControls.Label lblObj)
        {
            if (Request.QueryString[keyword] != null)
            {
                lblObj.Text = LTP.Common.StringClass.EncodeString(Request.QueryString[keyword].Trim());
            }
        }

        protected void FetchKeyword(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.TextBox txtObj)
        {
            if (Request.QueryString[keyword] != null)
            {
                lblObj.Text = StringClass.EncodeString(Request.QueryString[keyword].Trim());
                txtObj.Text = lblObj.Text;
            }
        }

        protected void FetchKeyword(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.HtmlControls.HtmlInputText txtObj)
        {
            if (Request.QueryString[keyword] != null)
            {
                lblObj.Text = StringClass.EncodeString(Request.QueryString[keyword].Trim());
                txtObj.Value = lblObj.Text;
            }
        }

        protected void FetchKeyword(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.DropDownList dropObj)
        {
            if (Request.QueryString[keyword] != null)
            {
                lblObj.Text = StringClass.EncodeString(Request.QueryString[keyword].Trim());
                dropObj.SelectedValue = lblObj.Text;
            }
        }

        protected void FetchKeydate(string keyword, System.Web.UI.WebControls.Label lblObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDateTime(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
            }
        }

        protected void FetchKeydate(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.HtmlControls.HtmlInputText txtObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDateTime(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
                txtObj.Value = lblObj.Text;
            }
        }

        protected void FetchKeydate(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.TextBox txtObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDateTime(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
                txtObj.Text = lblObj.Text;
            }
        }

        protected void FetchKeyNumber(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.TextBox txtObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckNumber(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
                txtObj.Text = lblObj.Text;
            }
        }

        protected void FetchKeyGUID(string keyword, System.Web.UI.WebControls.Label lblObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckGUID(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim().ToLower();
            }
        }

        protected void FetchKeyGUID(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.DropDownList dropObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckGUID(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim().ToLower();
                dropObj.SelectedValue = lblObj.Text;
            }
        }

        protected void FetchKeyID(string keyword, System.Web.UI.WebControls.Label lblObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDigit(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
            }
        }

        protected void FetchKeyID(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.DropDownList dropObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDigit(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
                dropObj.SelectedValue = lblObj.Text;
            }
        }

        protected void FetchKeyID(string keyword, System.Web.UI.WebControls.Label lblObj, System.Web.UI.WebControls.Repeater rptObj, string objName)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDigit(Request.QueryString[keyword].Trim()))
            {
                lblObj.Text = Request.QueryString[keyword].Trim();
                for (int i = 0; i < rptObj.Items.Count; i++)
                {
                    if (((System.Web.UI.WebControls.LinkButton)rptObj.Items[i].FindControl(objName)).CommandArgument == lblObj.Text)
                    {
                        ((System.Web.UI.WebControls.LinkButton)rptObj.Items[i].FindControl(objName)).ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                ((System.Web.UI.WebControls.LinkButton)rptObj.Items[0].FindControl(objName)).ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void FetchCurpage(string keyword, Wuqi.Webdiyer.AspNetPager anpObj)
        {
            if (Request.QueryString[keyword] != null && CheckInput.CheckDigit(Request.QueryString[keyword].Trim()))
            {
                int curPage = int.Parse(Request.QueryString[keyword].ToString());
                anpObj.RecordCount = curPage * anpObj.PageSize;
                anpObj.CurrentPageIndex = curPage;
            }
            else
            {
                anpObj.CurrentPageIndex = 1;
            }
        }
    }
}