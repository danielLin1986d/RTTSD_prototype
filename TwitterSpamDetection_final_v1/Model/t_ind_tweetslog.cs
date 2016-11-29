/**  版本信息模板在安装目录下，可自行修改。
* t_ind_tweetslog.cs
*
* 功 能： N/A
* 类 名： t_ind_tweetslog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/21 21:10:50   N/A    初版
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
	/// t_ind_tweetslog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_ind_tweetslog
	{
		public t_ind_tweetslog()
		{}
		#region Model
		private string _id;
		private string _userid;
		private DateTime _createddate;
		private string _directory;
		private string _numberoftweets;
		private int? _isdetected;
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
		public DateTime CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Directory
		{
			set{ _directory=value;}
			get{return _directory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NumberOfTweets
		{
			set{ _numberoftweets=value;}
			get{return _numberoftweets;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDetected
		{
			set{ _isdetected=value;}
			get{return _isdetected;}
		}
		#endregion Model

	}
}

