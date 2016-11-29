using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TwitterSpamDetection.Views.User
{
    public partial class VCode : System.Web.UI.Page
    {
        int _width = 45;
        int _height = 24;
        // int _width = 128;
        // int _height = 40;
        string imgDir = @"./";
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["w"] != null)
            {
                try
                {
                    this._width = int.Parse(Request.QueryString["w"].Trim());
                }
                catch
                {
                    //
                }
            }
            if (Request.QueryString["h"] != null)
            {
                try
                {
                    this._height = int.Parse(Request.QueryString["h"].Trim());
                }
                catch
                {
                    //
                }
            }
            // 4位数字的验证码
            if (!IsPostBack)
            {
                string str_ValidateCode = GetRandomNumberString(4);
                //用于验证的Session

                CreateImage(str_ValidateCode);
            }
        }

        // 生成随机数字字符串
        public string GetRandomNumberString(int int_NumberLength)
        {
            string str_Number = string.Empty;
            Random theRandomNumber = new Random();
            for (int int_index = 0; int_index < int_NumberLength; int_index++)
                str_Number += theRandomNumber.Next(10).ToString();
            Session["ValidateCode"] = str_Number;
            return str_Number;
        }

        //生成随机颜色
        public Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }

        public FileInfo[] GetAllFilesInPath(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            return di.GetFiles("*.gif", SearchOption.TopDirectoryOnly);
        }

        public string GetRandomFile(string path)
        {
            FileInfo[] fi = this.GetAllFilesInPath(path);
            Random rand = new Random(new Guid().GetHashCode() + (int)DateTime.Now.Ticks);
            int k = rand.Next(0, fi.Length);
            return fi[k].FullName;
        }

        public int GetRandomAngle()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(rand.Next(50));
            return rand.Next(-45, 45);
        }

        //根据验证字符串生成最终图象
        public void CreateImage(string str_ValidateCode)
        {
            //int int_ImageWidth = str_ValidateCode.Length * 13;
            //int width = int_ImageWidth;
            int int_ImageWidth = this.Width;
            int width = int_ImageWidth;
            int height = this.Height;
            string filePath = Server.MapPath(imgDir);
            Bitmap bgImg = (Bitmap)Bitmap.FromFile(GetRandomFile(filePath));
            Random newRandom = new Random();
            // 图高20px
            Bitmap theBitmap = new Bitmap(width, height);
            Graphics theGraphics = Graphics.FromImage(theBitmap);
            theGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            theGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            theGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            theGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 白色背景
            //theGraphics.Clear(Color.White);
            theGraphics.DrawImage(bgImg, new Rectangle(0, 0, width, height), new Rectangle(0, 0, bgImg.Width, bgImg.Height), GraphicsUnit.Pixel);
            // 灰色边框
            //theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, int_ImageWidth - 1, height - 1);
            //13pt的字体
            float fontSize = this.Height * 1.0f / 1.38f;
            float fontSpace = fontSize / 7f;
            Font theFont = new Font("Arial", fontSize);
            System.Drawing.Drawing2D.GraphicsPath gp = null;
            System.Drawing.Drawing2D.Matrix matrix;
            for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
            {
                string str_char = str_ValidateCode.Substring(int_index, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point((int)(int_index * (fontSize + fontSpace) + newRandom.Next(3)), 1 + newRandom.Next(3));
                gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddString(str_char, theFont.FontFamily, 0, fontSize, thePos, new StringFormat());
                matrix = new System.Drawing.Drawing2D.Matrix();
                int angle = GetRandomAngle();
                PointF centerPoint = new PointF(thePos.X + fontSize / 2, thePos.Y + fontSize / 2);
                matrix.RotateAt(angle, centerPoint);
                theGraphics.Transform = matrix;
                theGraphics.DrawPath(new Pen(Color.White, 2f), gp);
                //theGraphics.FillPath(new SolidBrush(Color.Black), gp);
                theGraphics.FillPath(new SolidBrush(GetRandomColor()), gp);
                theGraphics.ResetTransform();
            }
            if (gp != null) gp.Dispose();
            // 将生成的图片发回客户端
            MemoryStream ms = new MemoryStream();
            theBitmap.Save(ms, ImageFormat.Png);
            Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
            Response.ContentType = "image/gif";
            Response.BinaryWrite(ms.ToArray());
            theGraphics.Dispose();
            theBitmap.Dispose();
            Response.End();
        }
    }
}


