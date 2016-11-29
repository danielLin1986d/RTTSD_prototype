/**  版本信息模板在安装目录下，可自行修改。
* t_ind_twittercredential.cs
*
* 功 能： N/A
* 类 名： t_ind_twittercredential
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
	/// 数据访问类:t_ind_twittercredential
	/// </summary>
	public partial class t_ind_twittercredential
	{
		public t_ind_twittercredential()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.t_ind_twittercredential model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_ind_twittercredential(");
			strSql.Append("ID,UserID,CreatedDate,ConsumerKey,ConsumerSecret,AccessToken,AccessTokenSecret)");
			strSql.Append(" values (");
			strSql.Append("@ID,@UserID,@CreatedDate,@ConsumerKey,@ConsumerSecret,@AccessToken,@AccessTokenSecret)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36),
					new MySqlParameter("@UserID", MySqlDbType.VarChar,36),
					new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("@ConsumerKey", MySqlDbType.VarChar,100),
					new MySqlParameter("@ConsumerSecret", MySqlDbType.VarChar,100),
					new MySqlParameter("@AccessToken", MySqlDbType.VarChar,100),
					new MySqlParameter("@AccessTokenSecret", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.CreatedDate;
			parameters[3].Value = model.ConsumerKey;
			parameters[4].Value = model.ConsumerSecret;
			parameters[5].Value = model.AccessToken;
			parameters[6].Value = model.AccessTokenSecret;

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
		public bool Update(Model.t_ind_twittercredential model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_ind_twittercredential set ");
			strSql.Append("ID=@ID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("ConsumerKey=@ConsumerKey,");
			strSql.Append("ConsumerSecret=@ConsumerSecret,");
			strSql.Append("AccessToken=@AccessToken,");
			strSql.Append("AccessTokenSecret=@AccessTokenSecret");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36),
					new MySqlParameter("@UserID", MySqlDbType.VarChar,36),
					new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("@ConsumerKey", MySqlDbType.VarChar,100),
					new MySqlParameter("@ConsumerSecret", MySqlDbType.VarChar,100),
					new MySqlParameter("@AccessToken", MySqlDbType.VarChar,100),
					new MySqlParameter("@AccessTokenSecret", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.CreatedDate;
			parameters[3].Value = model.ConsumerKey;
			parameters[4].Value = model.ConsumerSecret;
			parameters[5].Value = model.AccessToken;
			parameters[6].Value = model.AccessTokenSecret;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_ind_twittercredential ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Model.t_ind_twittercredential GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,CreatedDate,ConsumerKey,ConsumerSecret,AccessToken,AccessTokenSecret from t_ind_twittercredential ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Model.t_ind_twittercredential model=new Model.t_ind_twittercredential();
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
		public Model.t_ind_twittercredential DataRowToModel(DataRow row)
		{
			Model.t_ind_twittercredential model=new Model.t_ind_twittercredential();
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
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["ConsumerKey"]!=null)
				{
					model.ConsumerKey=row["ConsumerKey"].ToString();
				}
				if(row["ConsumerSecret"]!=null)
				{
					model.ConsumerSecret=row["ConsumerSecret"].ToString();
				}
				if(row["AccessToken"]!=null)
				{
					model.AccessToken=row["AccessToken"].ToString();
				}
				if(row["AccessTokenSecret"]!=null)
				{
					model.AccessTokenSecret=row["AccessTokenSecret"].ToString();
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
			strSql.Append("select ID,UserID,CreatedDate,ConsumerKey,ConsumerSecret,AccessToken,AccessTokenSecret ");
			strSql.Append(" FROM t_ind_twittercredential ");
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
			strSql.Append("select count(1) FROM t_ind_twittercredential ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from t_ind_twittercredential T ");
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
			parameters[0].Value = "t_ind_twittercredential";
			parameters[1].Value = "";
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

