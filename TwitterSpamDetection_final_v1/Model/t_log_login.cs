/**  版本信息模板在安装目录下，可自行修改。
* t_log_login.cs
*
* 功 能： N/A
* 类 名： t_log_login
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/16 19:05:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace TwitterSpamDetection.Model
{
	/// <summary>
	/// t_log_login:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_log_login
	{
		public t_log_login()
		{}
		#region Model
		private string _id;
		private string _userid;
		private string _ipaddress;
		private DateTime? _logindate;
		private DateTime? _lastlogin;
		private string _clientinfo;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IPAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LoginDate
		{
			set{ _logindate=value;}
			get{return _logindate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLogin
		{
			set{ _lastlogin=value;}
			get{return _lastlogin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClientInfo
		{
			set{ _clientinfo=value;}
			get{return _clientinfo;}
		}
		#endregion Model

	}
}

