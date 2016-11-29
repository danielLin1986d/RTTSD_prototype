/**  版本信息模板在安装目录下，可自行修改。
* t_ind_trainingtime.cs
*
* 功 能： N/A
* 类 名： t_ind_trainingtime
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
	/// 数据访问类:t_ind_trainingtime
	/// </summary>
	public partial class t_ind_trainingtime
	{
		public t_ind_trainingtime()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_ind_trainingtime");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TwitterSpamDetection.Model.t_ind_trainingtime model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_ind_trainingtime(");
			strSql.Append("ID,Algorithm,TrainingTimeOne,TrainingTimeTwo,TrainingTimeThree,TrainingTimeFour,TrainingTimeFive)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Algorithm,@TrainingTimeOne,@TrainingTimeTwo,@TrainingTimeThree,@TrainingTimeFour,@TrainingTimeFive)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36),
					new MySqlParameter("@Algorithm", MySqlDbType.VarChar,100),
					new MySqlParameter("@TrainingTimeOne", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeTwo", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeThree", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeFour", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeFive", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Algorithm;
			parameters[2].Value = model.TrainingTimeOne;
			parameters[3].Value = model.TrainingTimeTwo;
			parameters[4].Value = model.TrainingTimeThree;
			parameters[5].Value = model.TrainingTimeFour;
			parameters[6].Value = model.TrainingTimeFive;

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
		public bool Update(TwitterSpamDetection.Model.t_ind_trainingtime model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_ind_trainingtime set ");
			strSql.Append("Algorithm=@Algorithm,");
			strSql.Append("TrainingTimeOne=@TrainingTimeOne,");
			strSql.Append("TrainingTimeTwo=@TrainingTimeTwo,");
			strSql.Append("TrainingTimeThree=@TrainingTimeThree,");
			strSql.Append("TrainingTimeFour=@TrainingTimeFour,");
			strSql.Append("TrainingTimeFive=@TrainingTimeFive");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Algorithm", MySqlDbType.VarChar,100),
					new MySqlParameter("@TrainingTimeOne", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeTwo", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeThree", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeFour", MySqlDbType.VarChar,45),
					new MySqlParameter("@TrainingTimeFive", MySqlDbType.VarChar,45),
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)};
			parameters[0].Value = model.Algorithm;
			parameters[1].Value = model.TrainingTimeOne;
			parameters[2].Value = model.TrainingTimeTwo;
			parameters[3].Value = model.TrainingTimeThree;
			parameters[4].Value = model.TrainingTimeFour;
			parameters[5].Value = model.TrainingTimeFive;
			parameters[6].Value = model.ID;

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
			strSql.Append("delete from t_ind_trainingtime ");
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
			strSql.Append("delete from t_ind_trainingtime ");
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
		public TwitterSpamDetection.Model.t_ind_trainingtime GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Algorithm,TrainingTimeOne,TrainingTimeTwo,TrainingTimeThree,TrainingTimeFour,TrainingTimeFive from t_ind_trainingtime ");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			TwitterSpamDetection.Model.t_ind_trainingtime model=new TwitterSpamDetection.Model.t_ind_trainingtime();
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
		public TwitterSpamDetection.Model.t_ind_trainingtime DataRowToModel(DataRow row)
		{
			TwitterSpamDetection.Model.t_ind_trainingtime model=new TwitterSpamDetection.Model.t_ind_trainingtime();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Algorithm"]!=null)
				{
					model.Algorithm=row["Algorithm"].ToString();
				}
				if(row["TrainingTimeOne"]!=null)
				{
					model.TrainingTimeOne=row["TrainingTimeOne"].ToString();
				}
				if(row["TrainingTimeTwo"]!=null)
				{
					model.TrainingTimeTwo=row["TrainingTimeTwo"].ToString();
				}
				if(row["TrainingTimeThree"]!=null)
				{
					model.TrainingTimeThree=row["TrainingTimeThree"].ToString();
				}
				if(row["TrainingTimeFour"]!=null)
				{
					model.TrainingTimeFour=row["TrainingTimeFour"].ToString();
				}
				if(row["TrainingTimeFive"]!=null)
				{
					model.TrainingTimeFive=row["TrainingTimeFive"].ToString();
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
			strSql.Append("select ID,Algorithm,TrainingTimeOne,TrainingTimeTwo,TrainingTimeThree,TrainingTimeFour,TrainingTimeFive ");
			strSql.Append(" FROM t_ind_trainingtime ");
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
			strSql.Append("select count(1) FROM t_ind_trainingtime ");
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
			strSql.Append(")AS Row, T.*  from t_ind_trainingtime T ");
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
			parameters[0].Value = "t_ind_trainingtime";
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

