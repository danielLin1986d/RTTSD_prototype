/**  版本信息模板在安装目录下，可自行修改。
* t_rol_role.cs
*
* 功 能： N/A
* 类 名： t_rol_role
*
*/
using System;
namespace TwitterSpamDetection.Model
{
	/// <summary>
	/// t_rol_role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_rol_role
	{
		public t_rol_role()
		{}
		#region Model
		private string _id;
		private string _rolename;
		private DateTime _createddate;
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
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		#endregion Model

	}
}

