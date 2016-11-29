using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Net;

namespace LTP.Common
{
    public class StringClass
    {
        public StringClass()
        {
            //构造器
        }

        private static Regex RegPhone = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegMobile = new Regex(@"^(13[0-9]|15[0-9]|18[6|8|9])\d{8}$");
        private static Regex RegIdNumber = new Regex(@"\d{17}[\d|X]|\d{15}");

        /// <summary>
        /// 去掉空格
        /// </summary>
        /// <param name="sTestString"></param>
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

        public static bool CheckMobile(string inputData)
        {
            Match m = RegMobile.Match(inputData);
            return m.Success;
        }

        public static bool CheckPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }

        public static bool CheckIDNumber(string inputData)
        {
            Match m = RegIdNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 获取字符串前面固定长度字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="l">前 l 个字符(中文视为两个英文)</param>
        /// <returns></returns>
        public static string GetCHString(string s, int l)
        {
            string temp = s.Replace("&nbsp;"," ");
            if (System.Text.RegularExpressions.Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Length <= l)
            {
                return temp;
            }
            for (int i = temp.Length; i >= 0; i--)
            {
                temp = temp.Substring(0, i);
                if (System.Text.RegularExpressions.Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Length <= l - 3)
                {
                    return temp + "...";
                }
            }
            return "";
        }

        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取字符串的长度</param>
        /// <returns></returns>
        public static string GetENString(string str, int num)
        {
            return (str.Length > num) ? str.Substring(0, num) + "..." : str;
        }

        public static string StripHTML(string strHtml)
        {
            string[] aryReg ={
							  @"<script[^>]*?>.*?</script>",

							  @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",

							  @"([\r\n])[\s]+",

							  @"&(quot|#34);",

							  @"&(amp|#38);",

							  @"&(lt|#60);",

							  @"&(gt|#62);", 

							  @"&(nbsp|#160);", 

							  @"&(iexcl|#161);",

							  @"&(cent|#162);",

							  @"&(pound|#163);",

							  @"&(copy|#169);",

							  @"&#(\d+);",

							  @"-->",

							  @"<!--.*\n"

						  };



            string[] aryRep = {

							   "",

							   "",

							   "",

							   "\"",

							   "&",

							   "<",

							   ">",

							   " ",

							   "\xa1",//chr(161),

							   "\xa2",//chr(162),

							   "\xa3",//chr(163),

							   "\xa9",//chr(169),

							   "",

							   "\r\n",

							   ""

						   };



            string newReg = aryReg[0];

            string strOutput = strHtml;

            for (int i = 0; i < aryReg.Length; i++)
            {

                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);

                strOutput = regex.Replace(strOutput, aryRep[i]);

            }

            strOutput.Replace("<", "");

            strOutput.Replace(">", "");
            strOutput.Replace("&nbsp", "");

            strOutput.Replace("\r\n", "");

            return strOutput;

        }

        /// <summary>
        /// 汉字编码转换,解决IE地址栏中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncodeUrl(string input)
        {
            return System.Web.HttpUtility.UrlEncode(EncodeString(input));
        }

        /// <summary>
        /// 修改特殊字符（空格除外）
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string EncodeStr(string str)
        {
            return str.Replace("<br />\r\n", "\r\n").Replace("'", "&apos;").Replace(@"""", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(" where ", " wh&#101;re ").
                Replace(" select ", " sel&#101;ct ").Replace(" insert ", " ins&#101;rt ").Replace(" create ", " cr&#101;ate ").Replace(" drop ", " dro&#112 ").
                Replace(" alter ", " alt&#101;r ").Replace(" delete ", " del&#101;te ").Replace(" update ", " up&#100;ate ").Replace(" or ", " o&#114; ").Replace("\"", @"&#34;").Replace(",", "，");
        }

        /// <summary>
        /// 修改特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string EncodeString(string str)
        {
            return str.Replace("<br />\r\n", "\r\n").Replace("'", "&apos;").Replace(@"""", "&quot;").Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(" where ", " wh&#101;re ").
                Replace(" select ", " sel&#101;ct ").Replace(" insert ", " ins&#101;rt ").Replace(" create ", " cr&#101;ate ").Replace(" drop ", " dro&#112 ").
                Replace(" alter ", " alt&#101;r ").Replace(" delete ", " del&#101;te ").Replace(" update ", " up&#100;ate ").Replace(" or ", " o&#114; ").Replace("\"", @"&#34;").
                Replace("\r\n", "<br />\r\n");
        }

        /// <summary>
        /// 修改SQL字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string RemoveSQL(string str)
        {
            return str.Replace(" where ", " wh&#101;re ").Replace(" select ", " sel&#101;ct ").Replace(" insert ", " ins&#101;rt ").Replace(" create ", " cr&#101;ate ").Replace(" drop ", " dro&#112 ").
                Replace(" alter ", " alt&#101;r ").Replace(" delete ", " del&#101;te ").Replace(" update ", " up&#100;ate ").Replace(" or ", " o&#114; ").Replace("'", "&apos;"); ;
        }

        /// <summary>
        /// 恢复特殊字符
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string UncodeString(string str)
        {
            return str.Replace("&apos;", "'").Replace("&quot;", @"""").Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ").Replace(" wh&#101;re ", " where ").
                Replace(" sel&#101;ct ", " select ").Replace(" ins&#101;rt ", " insert ").Replace(" cr&#101;ate ", " create ").Replace(" dro&#112 ", " drop ").
                Replace(" alt&#101;r ", " alter ").Replace(" del&#101;te ", " delete ").Replace(" up&#100;ate ", " update ").Replace(" o&#114; ", " or ").Replace(@"&#34;", "\"");
        }

        /// <summary>
        /// 替换敏感词
        /// </summary>
        /// <param name="str">要替换的敏感词</param>
        /// <returns></returns>
        public static string ReplaceSensitiveStr(string str)
        {
            return str.Replace("反共", "***").Replace("社会主义灭亡", "***").Replace("灭亡中国", "***").Replace("打倒中国", "***").Replace("太子党", "***").Replace("上海帮", "***").Replace("河蟹社会", "***").Replace("韩国狗", "***").
                Replace("一党专制", "***").Replace("一党专政", "***").Replace("专制政权", "***").Replace("中国人权", "***").Replace("官逼民反", "***").Replace("89动乱", "***").Replace("支持藏独", "***").Replace("北京帮", "***").Replace("警匪一家", "***").
                Replace("官匪一家", "***").Replace("大纪元", "***").Replace("共产专制", "***").Replace("共产王朝", "***").Replace("恶党", "***").Replace("邪党", "***").Replace("共匪", "***").Replace("中国猪", "***").Replace("台湾猪", "***").Replace("贱人", "***").Replace("装b", "***").
                Replace("大sb", "***").Replace("傻逼", "***").Replace("傻b", "***").Replace("煞逼", "***").Replace("婊子养的", "***").Replace("婊子养", "***").Replace("我日你", "***").Replace("我操", "***").Replace("我草", "***").Replace("爆你菊", "***").Replace("艹你", "***").
                Replace("你他妈", "***").Replace("草你吗", "***").Replace("操你妈", "***").Replace("操你娘", "***").Replace("操他妈", "***").Replace("日你妈", "***").Replace("干你妈", "***").Replace("干你娘", "***").Replace("操你祖宗", "***").Replace("操你全家", "***").Replace("操你大爷", "***").
                Replace("狗杂种", "***").Replace("狗娘养", "***").Replace("死全家", "***").Replace("全家死光", "***").Replace("全家不得好死", "***").Replace("全家死绝", "***").Replace("人渣", "***").Replace("fuck", "***").Replace("Fuck", "***").Replace("FUCK", "***").Replace("Fuck-you", "***").
                Replace("贱b", "***").Replace("a片", "***").Replace("黄片", "***").Replace("轮法功", "***").Replace("三去车仑", "***").Replace("法x功", "***").Replace("大法弟子", "***").Replace("退党", "***").Replace("被操", "***").Replace("被插", "***").Replace("潮吹", "***").Replace("成人电影", "***").
                Replace("成人论坛", "***").Replace("成人色情", "***").Replace("成人小说", "***").Replace("成人文学", "***").Replace("18禁", "***").Replace("成人文学", "***").Replace("钦定接班人", "***").Replace("六四事件", "***").Replace("买卖枪支", "***").Replace("高校暴乱", "***").Replace("共产极权", "***").
                Replace("共产无赖", "***").Replace("共产小丑", "***").Replace("共奴", "***").Replace("胡瘟", "***");
        }

        /// <summary>
        /// 转义传送Pad端的字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodePadStr(string str)
        {
            return UncodeString(str).Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }

        public static string GetSpell(string cn)
        {
            byte[] arrCN = System.Text.Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return System.Text.Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
        }

        /// <summary>
        /// 获取汉字第一个拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string GetSpells(string input)
        {
            int len = input.Length;
            string reVal = "";
            for (int i = 0; i < len; i++)
            {
                reVal += GetSpell(input.Substring(i, 1));
            }
            return reVal;
        }

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="BJstr"></param>
        /// <returns></returns>
        public static string GetQuanJiao(string BJstr)
        {
            char[] c = BJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 0)
                    {
                        b[0] = (byte)(b[0] - 32);
                        b[1] = 255;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }

            string strNew = new string(c);
            return strNew;
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="QJstr"></param>
        /// <returns></returns>
        public static string GetBanJiao(string QJstr)
        {
            char[] c = QJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            string strNew = new string(c);
            return strNew;
        }

        public enum PasswordFormat { SHA1, MD5_32, MD5_16 }

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="PasswordString">要加密的字符串</param>
        /// <param name="PasswordFormat">要加密的类别</param>
        /// <returns></returns>
        public static string EncryptPassword(string PasswordString, PasswordFormat paFormat)
        {
            string passWord;
            switch (paFormat)
            {
                case PasswordFormat.SHA1:
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
                        break;
                    }
                case PasswordFormat.MD5_32:
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        break;
                    }
                case PasswordFormat.MD5_16:
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        passWord = passWord.Substring(8, 16);
                        break;
                    }
                default:
                    {
                        passWord = string.Empty;
                        break;
                    }
            }
            return passWord;
        }

        public static string UbbReplace(string str)
        {
            return str.Replace("\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;");
        }

        public static string GetPageInfo(String url)
        {
            WebResponse wr_result = null;
            StringBuilder txthtml = new StringBuilder();
            try
            {
                WebRequest wr_req = WebRequest.Create(url);
                wr_result = wr_req.GetResponse();
                Stream ReceiveStream = wr_result.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
                StreamReader sr = new StreamReader(ReceiveStream, encode);
                if (true)
                {
                    Char[] read = new Char[256];
                    int count = sr.Read(read, 0, 256);
                    while (count > 0)
                    {
                        String str = new String(read, 0, count);
                        txthtml.Append(str);
                        count = sr.Read(read, 0, 256);
                    }
                }
            }
            catch (Exception)
            {
                txthtml.Append("err");
            }
            finally
            {
                if (wr_result != null)
                {
                    wr_result.Close();
                }
            }
            return txthtml.ToString();
        }


        public static string KeywordShow(string result, string keyword)
        {
            if (keyword != "")
            {
                keyword = keyword.Replace("&nbsp;", "+");
                for (int i = 0; i < keyword.Split('+').Length; i++)
                {
                    result = result.Replace(keyword.Split('+')[i], "<font style='color:orange;'>" + keyword.Split('+')[i] + "</font>");
                }
            }
            return result;
        }

        public static string GetOrderID()
        {
            Random ra = new Random();
            return DateTime.Now.ToString("yyyyMMddHHmmss") + ra.Next(10, 99).ToString();
        }
    }
}
