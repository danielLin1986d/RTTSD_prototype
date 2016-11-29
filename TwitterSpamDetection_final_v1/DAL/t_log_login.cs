/**  版本信息模板在安装目录下，可自行修改。
* t_log_login.cs
*
* 功 能： N/A
* 类 名： t_log_login
*
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace TwitterSpamDetection.DAL
{
	/// <summary>
	/// 数据访问类:t_log_login
	/// </summary>
	public partial class t_log_login
	{
		public t_log_login()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_log_login");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.t_log_login model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_log_login(");
			strSql.Append("ID,UserID,IPAddress,LoginDate,LastLogin,ClientInfo)");
			strSql.Append(" values (");
			strSql.Append("@ID,@UserID,@IPAddress,@LoginDate,@LastLogin,@ClientInfo)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36),
					new MySqlParameter("@UserID", MySqlDbType.VarChar,36),
					new MySqlParameter("@IPAddress", MySqlDbType.VarChar,20),
					new MySqlParameter("@LoginDate", MySqlDbType.DateTime),
					new MySqlParameter("@LastLogin", MySqlDbType.DateTime),
					new MySqlParameter("@ClientInfo", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.IPAddress;
			parameters[3].Value = model.LoginDate;
			parameters[4].Value = model.LastLogin;
			parameters[5].Value = model.ClientInfo;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.t_log_login model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_log_login set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("IPAddress=@IPAddress,");
			strSql.Append("LoginDate=@LoginDate,");
			strSql.Append("LastLogin=@LastLogin,");
			strSql.Append("ClientInfo=@ClientInfo");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserID", MySqlDbType.VarChar,36),
					new MySqlParameter("@IPAddress", MySqlDbType.VarChar,20),
					new MySqlParameter("@LoginDate", MySqlDbType.DateTime),
					new MySqlParameter("@LastLogin", MySqlDbType.DateTime),
					new MySqlParameter("@ClientInfo", MySqlDbType.VarChar,255),
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.IPAddress;
			parameters[2].Value = model.LoginDate;
			parameters[3].Value = model.LastLogin;
			parameters[4].Value = model.ClientInfo;
			parameters[5].Value = model.ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_log_login ");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_log_login ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.t_log_login GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,IPAddress,LoginDate,LastLogin,ClientInfo from t_log_login ");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			Model.t_log_login model=new Model.t_log_login();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.t_log_login DataRowToModel(DataRow row)
		{
			Model.t_log_login model=new Model.t_log_login();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["IPAddress"]!=null)
				{
					model.IPAddress=row["IPAddress"].ToString();
				}
				if(row["LoginDate"]!=null && row["LoginDate"].ToString()!="")
				{
					model.LoginDate=DateTime.Parse(row["LoginDate"].ToString());
				}
				if(row["LastLogin"]!=null && row["LastLogin"].ToString()!="")
				{
					model.LastLogin=DateTime.Parse(row["LastLogin"].ToString());
				}
				if(row["ClientInfo"]!=null)
				{
					model.ClientInfo=row["ClientInfo"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,IPAddress,LoginDate,LastLogin,ClientInfo ");
			strSql.Append(" FROM t_log_login ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_log_login ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_log_login T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_log_login";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

