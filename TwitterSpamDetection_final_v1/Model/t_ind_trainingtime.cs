/**  版本信息模板在安装目录下，可自行修改。
* t_ind_trainingtime.cs
*
* 功 能： N/A
* 类 名： t_ind_trainingtime
*
*/
using System;
namespace TwitterSpamDetection.Model
{
	/// <summary>
	/// t_ind_trainingtime:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_ind_trainingtime
	{
		public t_ind_trainingtime()
		{}
		#region Model
		private string _id;
		private string _algorithm;
		private string _trainingtimeone;
		private string _trainingtimetwo;
		private string _trainingtimethree;
		private string _trainingtimefour;
		private string _trainingtimefive;
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
		public string Algorithm
		{
			set{ _algorithm=value;}
			get{return _algorithm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingTimeOne
		{
			set{ _trainingtimeone=value;}
			get{return _trainingtimeone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingTimeTwo
		{
			set{ _trainingtimetwo=value;}
			get{return _trainingtimetwo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingTimeThree
		{
			set{ _trainingtimethree=value;}
			get{return _trainingtimethree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingTimeFour
		{
			set{ _trainingtimefour=value;}
			get{return _trainingtimefour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingTimeFive
		{
			set{ _trainingtimefive=value;}
			get{return _trainingtimefive;}
		}
		#endregion Model

	}
}

