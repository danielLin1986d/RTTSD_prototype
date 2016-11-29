using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace LTP.Common
{
    public class ButtonClass
    {
        public ButtonClass()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 防止提交按钮重复点击
        /// </summary>
        /// <param name="curPage">页面对象</param>
        /// <param name="button">按钮对象</param>
        /// <param name="checkFunction">javascript验证函数</param>
        /// <param name="isValid">是否运用.net验证控件</param>
        public static void ButtonOnClick(Page curPage, Button button, string checkFunction, bool isValid)
        {
            StringBuilder attString = new StringBuilder();
            if (isValid)
            {
                attString.Append("if (typeof(Page_ClientValidate) == 'function') { ");

                attString.Append("if (Page_ClientValidate() == false) { return false; }} ");
            }
            else
            {
                attString.Append("if(!" + checkFunction + ") {return false;}");
            }

            attString.Append("this.value = 'Please wait...';");

            attString.Append("this.disabled = true;");

            attString.Append(curPage.ClientScript.GetPostBackEventReference(button, null));

            attString.Append(";");

            button.Attributes.Add("onclick", attString.ToString());
        }

        /// <summary>
        /// 防止提交图片按钮重复点击
        /// </summary>
        /// <param name="curPage">页面对象</param>
        /// <param name="button">按钮对象</param>
        /// <param name="checkFunction">javascript验证函数</param>
        /// <param name="isValid">是否运用.net验证控件</param>
        public static void ImgButtonDisable(Page curPage, ImageButton button, string checkFunction, bool isValid)
        {
            StringBuilder attString = new StringBuilder();
            if (isValid)
            {
                attString.Append("if (typeof(Page_ClientValidate) == 'function') { ");

                attString.Append("if (Page_ClientValidate() == false) { return false; }} ");
            }
            else
            {
                attString.Append("if(!" + checkFunction + ") {return false;}");
            }

            attString.Append("this.disabled = true;");

            attString.Append(curPage.ClientScript.GetPostBackEventReference(button, null));

            attString.Append(";");

            button.Attributes.Add("onclick", attString.ToString());
        }

        /// <summary>
        /// 防止按钮重复点击
        /// </summary>
        /// <param name="curPage">页面对象</param>
        /// <param name="button">按钮对象</param>
        /// <param name="checkFunction">javascript验证函数</param>
        /// <param name="isValid">是否运用.net验证控件</param>
        public static void ButtonDisable(Page curPage, ImageButton button, string checkFunction, bool isValid)
        {
            StringBuilder attString = new StringBuilder();
            if (isValid)
            {
                attString.Append("if (typeof(Page_ClientValidate) == 'function') { ");

                attString.Append("if (Page_ClientValidate() == false) { return false; }} ");
            }
            else
            {
                attString.Append("if(!" + checkFunction + ") {return false;}");
            }
            attString.Append("this.disabled = true;");

            attString.Append(curPage.ClientScript.GetPostBackEventReference(button, null));

            attString.Append(";");

            button.Attributes.Add("onclick", attString.ToString());
        }
        /// <summary>
        /// 防止提交按钮重复点击
        /// </summary>
        /// <param name="curPage">页面对象</param>
        /// <param name="button">按钮对象</param>
        /// <param name="checkFunction">javascript验证函数</param>
        /// <param name="isValid">是否运用.net验证控件</param>
        public static void ButtonOnClick(Page curPage, Button button, Button[] buttons, string checkFunction, bool isValid)
        {
            StringBuilder attString = new StringBuilder();
            if (isValid)
            {
                attString.Append("if (typeof(Page_ClientValidate) == 'function') { ");

                attString.Append("if (Page_ClientValidate() == false) { return false; }} ");
            }
            else
            {
                attString.Append("if(!" + checkFunction + ") {return false;}");
            }

            attString.Append("this.value = '稍等...';");

            attString.Append("this.disabled = true;");

            for (int i = 0; i < buttons.Length; i++)
            {
                attString.Append("form1." + buttons[i].ID + ".value = '稍等...';");

                attString.Append("form1." + buttons[i].ID + ".disabled = true;");
            }

            attString.Append(curPage.ClientScript.GetPostBackEventReference(button, null));

            attString.Append(";");

            button.Attributes.Add("onclick", attString.ToString());
        }
    }
}
