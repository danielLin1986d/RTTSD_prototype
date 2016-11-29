using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Web;

namespace LTP.Common
{
    public class FileDecrypt
    {
        public FileDecrypt()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static string Decrypt(string strSrc, string strKey)
        {
            int keylen, keypos, offset, srcpos, srcasc, tmpsrcasc;
            //string dest = "";
            byte[] bytes = new byte[strSrc.Length / 2];

            keylen = strKey.Length;

            if (keylen == 0)
            {
                strKey = "yacgo2014";
            }

            keypos = 0;

            offset = int.Parse(strSrc.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

            srcpos = 3;

            do
            {
                srcasc = int.Parse(strSrc.Substring(srcpos - 1, 2), System.Globalization.NumberStyles.HexNumber);
                if (keypos < keylen)
                {
                    keypos = keypos + 1;
                }
                else
                {
                    keypos = 1;
                }

                int itemp = System.Convert.ToInt16(strKey[keypos - 1]);

                tmpsrcasc = (srcasc ^ System.Convert.ToInt16(strKey[keypos - 1]));
                if (tmpsrcasc <= offset)
                {
                    tmpsrcasc = 255 + tmpsrcasc - offset;
                }
                else
                {
                    tmpsrcasc = tmpsrcasc - offset;
                }

                bytes[srcpos / 2 - 1] = (byte)tmpsrcasc;

                //dest = dest + System.Convert.ToChar(tmpsrcasc);

                offset = srcasc;
                srcpos = srcpos + 2;
            }
            while (srcpos < strSrc.Length);

            //return dest;
            return System.Text.Encoding.Default.GetString(bytes);
        }

        private static DataTable DecryptFile(string sourceFileName, string strKey)
        {
            string strSource, strResult;

            if (!File.Exists(sourceFileName))
            {
                return null;
            }
            else
            {
                StreamReader sr = new StreamReader(sourceFileName);
                string st = string.Empty;
                st = sr.ReadToEnd();
                sr.Close();
                string[] strList = st.Replace("\r", "").Split('\n');

                for (int i = 0; i < strList.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strList[i]))
                    {
                        strSource = strList[i];
                        strResult = Decrypt(strSource, strKey);

                        strList[i] = strResult;
                    }
                }

                //StreamWriter sw = new StreamWriter(targetFileName);
                //for (int i = 0; i < strList.Length; i++)
                //{
                //    byte[] byStr = System.Text.Encoding.Default.GetBytes(strList[i]);
                //    sw.WriteLine(strList[i]);
                //}
                //sw.Close();

                string result = "";
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("KeyName", Type.GetType("System.String"));
                dt.Columns.Add(dc1);
                DataColumn dc2 = new DataColumn("KeyValue", Type.GetType("System.String"));
                dt.Columns.Add(dc2);

                DataRow dr;

                for (int i = 0; i < strList.Length; i++)
                {
                    byte[] byStr = System.Text.Encoding.Default.GetBytes(strList[i]);
                    result = strList[i].Replace("\0", "");

                    if (result.Split('=').Length == 2)
                    {
                        dr = dt.NewRow();
                        dr["KeyName"] = result.Split('=')[0].Trim();
                        dr["KeyValue"] = result.Split('=')[1].Trim();
                        dt.Rows.Add(dr);
                    }
                }

                try
                {
                    File.Delete(sourceFileName);
                }
                catch { }

                return dt;
            }
        }


        public static string Encrypt(string strSrc, string strKey, Random ra)
        {
            int keylen, keypos, offset, srcpos, srcasc, range;
            string dest = "";
            //byte[] bytes = new byte[strSrc.Length / 2];

            byte[] bytes = System.Text.Encoding.Default.GetBytes(strSrc);

            keylen = strKey.Length;

            if (keylen == 0)
            {
                strKey = "yacgo2014";
            }

            keypos = 0;

            range = 256;

            offset = ra.Next(range);

            dest = offset.ToString("X2");

            for (srcpos = 1; srcpos <= bytes.Length; srcpos++)
            {
                srcasc = (System.Convert.ToInt16(bytes[srcpos - 1]) + offset) % 255;
                if (keypos < keylen)
                {
                    keypos = keypos + 1;
                }
                else
                {
                    keypos = 1;
                }
                srcasc = srcasc ^ (System.Convert.ToInt16(strKey[keypos - 1]));
                dest = dest + srcasc.ToString("X2");
                offset = srcasc;
            }

            return dest;
            //return System.Text.Encoding.Default.GetString(bytes);
        }

        private static string EncreptFile(string moduleIndex, string interIndex, DataTable dt, string strKey)
        {
            if (dt == null)
            {
                return "";
            }
            else
            {
                StringBuilder result = new StringBuilder();
                Random ra = new Random();
                result.Append(Encrypt("[类型]", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("模块索引=" + moduleIndex + "", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("内部索引=" + interIndex + "", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("[计算参数]", strKey, ra));
                result.Append("\r\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Append(Encrypt(dt.Rows[i]["KeyName"].ToString() + "=" + dt.Rows[i]["KeyValue"].ToString(), strKey, ra));
                    result.Append("\r\n");
                }
                result.Append(Encrypt("[其他参数]", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("最后保存日期=", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("最后计算日期=", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("[备注]", strKey, ra));
                result.Append("\r\n");
                result.Append(Encrypt("说明=", strKey, ra));
                result.Append("\r\n");

                return result.ToString();
            }
        }
    }
}
