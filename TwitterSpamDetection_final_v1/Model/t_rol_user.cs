/**  版本信息模板在安装目录下，可自行修改。
* t_rol_user.cs
*
* 功 能： N/A
* 类 名： t_rol_user
*
*/
using System;

namespace TwitterSpamDetection.Model
{
	/// <summary>
	/// t_rol_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_rol_user
	{
		public t_rol_user()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _password;
		private string _firstname;
		private string _lastname;
		private string _mobile;
		private string _telnum;
		private string _address;
		private string _country;
		private DateTime _createddate;
		private int _isvalid;
		private string _roleid;
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
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FirstName
		{
			set{ _firstname=value;}
			get{return _firstname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastName
		{
			set{ _lastname=value;}
			get{return _lastname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelNum
		{
			set{ _telnum=value;}
			get{return _telnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
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
		public int IsValid
		{
			set{ _isvalid=value;}
			get{return _isvalid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

