/**  版本信息模板在安装目录下，可自行修改。
* t_ind_tweetslist.cs
*
* 功 能： N/A
* 类 名： t_ind_tweetslist
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
	/// 数据访问类:t_ind_tweetslist
	/// </summary>
	public partial class t_ind_tweetslist
	{
		public t_ind_tweetslist()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_ind_tweetslist");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录 by checking statusID
        /// </summary>
        public bool ExistsByStatusID(string StatusID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_ind_tweetslist");
            strSql.Append(" where StatusID=@StatusID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@StatusID", MySqlDbType.VarChar,36)           };
            parameters[0].Value = StatusID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.t_ind_tweetslist model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_ind_tweetslist(");
            strSql.Append("ID,StatusID,CreatedByUser,AccountCreatedDate,TweetCreatedDate,AccountAge,FollowersCount,FriendsCount,FavoritesCount,ListedCount,StatusesCount,RetweetCount,FavoriteCount,HashTapsCount,UserMentionsCount,UrlsCount,NumberOfChar,NumberOfDigits,TweetContent,IsSpam,knnResult,kknnResult,naivebayesResult,randomforestResult,c50Result,gbmResult,logisticregressionResult,neuralnetworkResult,ProbabilityOfSpam)");
            strSql.Append(" values (");
            strSql.Append("@ID,@StatusID,@CreatedByUser,@AccountCreatedDate,@TweetCreatedDate,@AccountAge,@FollowersCount,@FriendsCount,@FavoritesCount,@ListedCount,@StatusesCount,@RetweetCount,@FavoriteCount,@HashTapsCount,@UserMentionsCount,@UrlsCount,@NumberOfChar,@NumberOfDigits,@TweetContent,@IsSpam,@knnResult,@kknnResult,@naivebayesResult,@randomforestResult,@c50Result,@gbmResult,@logisticregressionResult,@neuralnetworkResult,@ProbabilityOfSpam)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@StatusID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@CreatedByUser", MySqlDbType.VarChar,255),
                    new MySqlParameter("@AccountCreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("@TweetCreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("@AccountAge", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FollowersCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FriendsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FavoritesCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ListedCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@StatusesCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@RetweetCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FavoriteCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@HashTapsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@UserMentionsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@UrlsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@NumberOfChar", MySqlDbType.VarChar,50),
                    new MySqlParameter("@NumberOfDigits", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TweetContent", MySqlDbType.MediumText),
                    new MySqlParameter("@IsSpam", MySqlDbType.VarChar,20),
                    new MySqlParameter("@knnResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@kknnResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@naivebayesResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@randomforestResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@c50Result", MySqlDbType.VarChar,20),
                    new MySqlParameter("@gbmResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@logisticregressionResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@neuralnetworkResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@ProbabilityOfSpam", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.StatusID;
            parameters[2].Value = model.CreatedByUser;
            parameters[3].Value = model.AccountCreatedDate;
            parameters[4].Value = model.TweetCreatedDate;
            parameters[5].Value = model.AccountAge;
            parameters[6].Value = model.FollowersCount;
            parameters[7].Value = model.FriendsCount;
            parameters[8].Value = model.FavoritesCount;
            parameters[9].Value = model.ListedCount;
            parameters[10].Value = model.StatusesCount;
            parameters[11].Value = model.RetweetCount;
            parameters[12].Value = model.FavoriteCount;
            parameters[13].Value = model.HashTapsCount;
            parameters[14].Value = model.UserMentionsCount;
            parameters[15].Value = model.UrlsCount;
            parameters[16].Value = model.NumberOfChar;
            parameters[17].Value = model.NumberOfDigits;
            parameters[18].Value = model.TweetContent;
            parameters[19].Value = model.IsSpam;
            parameters[20].Value = model.knnResult;
            parameters[21].Value = model.kknnResult;
            parameters[22].Value = model.naivebayesResult;
            parameters[23].Value = model.randomforestResult;
            parameters[24].Value = model.c50Result;
            parameters[25].Value = model.gbmResult;
            parameters[26].Value = model.logisticregressionResult;
            parameters[27].Value = model.neuralnetworkResult;
            parameters[28].Value = model.ProbabilityOfSpam;

            int result = 0;
            try
            {
                result = DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
            }
            catch { }

            if (result > 0)
			{
				return "";
			}
			else
			{
				return "Failed to add tweet's data to database, please contact system admin!";
			}
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.t_ind_tweetslist model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_ind_tweetslist set ");
            strSql.Append("StatusID=@StatusID,");
            strSql.Append("CreatedByUser=@CreatedByUser,");
            strSql.Append("AccountCreatedDate=@AccountCreatedDate,");
            strSql.Append("TweetCreatedDate=@TweetCreatedDate,");
            strSql.Append("AccountAge=@AccountAge,");
            strSql.Append("FollowersCount=@FollowersCount,");
            strSql.Append("FriendsCount=@FriendsCount,");
            strSql.Append("FavoritesCount=@FavoritesCount,");
            strSql.Append("ListedCount=@ListedCount,");
            strSql.Append("StatusesCount=@StatusesCount,");
            strSql.Append("RetweetCount=@RetweetCount,");
            strSql.Append("FavoriteCount=@FavoriteCount,");
            strSql.Append("HashTapsCount=@HashTapsCount,");
            strSql.Append("UserMentionsCount=@UserMentionsCount,");
            strSql.Append("UrlsCount=@UrlsCount,");
            strSql.Append("NumberOfChar=@NumberOfChar,");
            strSql.Append("NumberOfDigits=@NumberOfDigits,");
            strSql.Append("TweetContent=@TweetContent,");
            strSql.Append("IsSpam=@IsSpam,");
            strSql.Append("knnResult=@knnResult,");
            strSql.Append("kknnResult=@kknnResult,");
            strSql.Append("naivebayesResult=@naivebayesResult,");
            strSql.Append("randomforestResult=@randomforestResult,");
            strSql.Append("c50Result=@c50Result,");
            strSql.Append("gbmResult=@gbmResult,");
            strSql.Append("logisticregressionResult=@logisticregressionResult,");
            strSql.Append("neuralnetworkResult=@neuralnetworkResult,");
            strSql.Append("ProbabilityOfSpam=@ProbabilityOfSpam");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@StatusID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@CreatedByUser", MySqlDbType.VarChar,255),
                    new MySqlParameter("@AccountCreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("@TweetCreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("@AccountAge", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FollowersCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FriendsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FavoritesCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ListedCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@StatusesCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@RetweetCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FavoriteCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@HashTapsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@UserMentionsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@UrlsCount", MySqlDbType.VarChar,50),
                    new MySqlParameter("@NumberOfChar", MySqlDbType.VarChar,50),
                    new MySqlParameter("@NumberOfDigits", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TweetContent", MySqlDbType.MediumText),
                    new MySqlParameter("@IsSpam", MySqlDbType.VarChar,20),
                    new MySqlParameter("@knnResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@kknnResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@naivebayesResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@randomforestResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@c50Result", MySqlDbType.VarChar,20),
                    new MySqlParameter("@gbmResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@logisticregressionResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@neuralnetworkResult", MySqlDbType.VarChar,20),
                    new MySqlParameter("@ProbabilityOfSpam", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.StatusID;
            parameters[1].Value = model.CreatedByUser;
            parameters[2].Value = model.AccountCreatedDate;
            parameters[3].Value = model.TweetCreatedDate;
            parameters[4].Value = model.AccountAge;
            parameters[5].Value = model.FollowersCount;
            parameters[6].Value = model.FriendsCount;
            parameters[7].Value = model.FavoritesCount;
            parameters[8].Value = model.ListedCount;
            parameters[9].Value = model.StatusesCount;
            parameters[10].Value = model.RetweetCount;
            parameters[11].Value = model.FavoriteCount;
            parameters[12].Value = model.HashTapsCount;
            parameters[13].Value = model.UserMentionsCount;
            parameters[14].Value = model.UrlsCount;
            parameters[15].Value = model.NumberOfChar;
            parameters[16].Value = model.NumberOfDigits;
            parameters[17].Value = model.TweetContent;
            parameters[18].Value = model.IsSpam;
            parameters[19].Value = model.knnResult;
            parameters[20].Value = model.kknnResult;
            parameters[21].Value = model.naivebayesResult;
            parameters[22].Value = model.randomforestResult;
            parameters[23].Value = model.c50Result;
            parameters[24].Value = model.gbmResult;
            parameters[25].Value = model.logisticregressionResult;
            parameters[26].Value = model.neuralnetworkResult;
            parameters[27].Value = model.ProbabilityOfSpam;
            parameters[28].Value = model.ID;

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
			strSql.Append("delete from t_ind_tweetslist ");
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
			strSql.Append("delete from t_ind_tweetslist ");
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
		public Model.t_ind_tweetslist GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,StatusID,CreatedByUser,AccountCreatedDate,TweetCreatedDate,AccountAge,FollowersCount,FriendsCount,FavoritesCount,ListedCount,StatusesCount,RetweetCount,FavoriteCount,HashTapsCount,UserMentionsCount,UrlsCount,NumberOfChar,NumberOfDigits,TweetContent,IsSpam,knnResult,kknnResult,naivebayesResult,randomforestResult,c50Result,gbmResult,logisticregressionResult,neuralnetworkResult,ProbabilityOfSpam from t_ind_tweetslist ");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			Model.t_ind_tweetslist model=new Model.t_ind_tweetslist();
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
		public Model.t_ind_tweetslist DataRowToModel(DataRow row)
		{
            Model.t_ind_tweetslist model = new Model.t_ind_tweetslist();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["StatusID"] != null)
                {
                    model.StatusID = row["StatusID"].ToString();
                }
                if (row["CreatedByUser"] != null)
                {
                    model.CreatedByUser = row["CreatedByUser"].ToString();
                }
                if (row["AccountCreatedDate"] != null && row["AccountCreatedDate"].ToString() != "")
                {
                    model.AccountCreatedDate = DateTime.Parse(row["AccountCreatedDate"].ToString());
                }
                if (row["TweetCreatedDate"] != null && row["TweetCreatedDate"].ToString() != "")
                {
                    model.TweetCreatedDate = DateTime.Parse(row["TweetCreatedDate"].ToString());
                }
                if (row["AccountAge"] != null)
                {
                    model.AccountAge = row["AccountAge"].ToString();
                }
                if (row["FollowersCount"] != null)
                {
                    model.FollowersCount = row["FollowersCount"].ToString();
                }
                if (row["FriendsCount"] != null)
                {
                    model.FriendsCount = row["FriendsCount"].ToString();
                }
                if (row["FavoritesCount"] != null)
                {
                    model.FavoritesCount = row["FavoritesCount"].ToString();
                }
                if (row["ListedCount"] != null)
                {
                    model.ListedCount = row["ListedCount"].ToString();
                }
                if (row["StatusesCount"] != null)
                {
                    model.StatusesCount = row["StatusesCount"].ToString();
                }
                if (row["RetweetCount"] != null)
                {
                    model.RetweetCount = row["RetweetCount"].ToString();
                }
                if (row["FavoriteCount"] != null)
                {
                    model.FavoriteCount = row["FavoriteCount"].ToString();
                }
                if (row["HashTapsCount"] != null)
                {
                    model.HashTapsCount = row["HashTapsCount"].ToString();
                }
                if (row["UserMentionsCount"] != null)
                {
                    model.UserMentionsCount = row["UserMentionsCount"].ToString();
                }
                if (row["UrlsCount"] != null)
                {
                    model.UrlsCount = row["UrlsCount"].ToString();
                }
                if (row["NumberOfChar"] != null)
                {
                    model.NumberOfChar = row["NumberOfChar"].ToString();
                }
                if (row["NumberOfDigits"] != null)
                {
                    model.NumberOfDigits = row["NumberOfDigits"].ToString();
                }
                if (row["TweetContent"] != null)
                {
                    model.TweetContent = row["TweetContent"].ToString();
                }
                if (row["IsSpam"] != null)
                {
                    model.IsSpam = row["IsSpam"].ToString();
                }
                if (row["knnResult"] != null)
                {
                    model.knnResult = row["knnResult"].ToString();
                }
                if (row["kknnResult"] != null)
                {
                    model.kknnResult = row["kknnResult"].ToString();
                }
                if (row["naivebayesResult"] != null)
                {
                    model.naivebayesResult = row["naivebayesResult"].ToString();
                }
                if (row["randomforestResult"] != null)
                {
                    model.randomforestResult = row["randomforestResult"].ToString();
                }
                if (row["c50Result"] != null)
                {
                    model.c50Result = row["c50Result"].ToString();
                }
                if (row["gbmResult"] != null)
                {
                    model.gbmResult = row["gbmResult"].ToString();
                }
                if (row["logisticregressionResult"] != null)
                {
                    model.logisticregressionResult = row["logisticregressionResult"].ToString();
                }
                if (row["neuralnetworkResult"] != null)
                {
                    model.neuralnetworkResult = row["neuralnetworkResult"].ToString();
                }
                if (row["ProbabilityOfSpam"] != null)
                {
                    model.ProbabilityOfSpam = row["ProbabilityOfSpam"].ToString();
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
            strSql.Append("select ID,StatusID,CreatedByUser,AccountCreatedDate,TweetCreatedDate,AccountAge,FollowersCount,FriendsCount,FavoritesCount,ListedCount,StatusesCount,RetweetCount,FavoriteCount,HashTapsCount,UserMentionsCount,UrlsCount,NumberOfChar,NumberOfDigits,TweetContent,IsSpam,knnResult,kknnResult,naivebayesResult,randomforestResult,c50Result,gbmResult,logisticregressionResult,neuralnetworkResult,ProbabilityOfSpam ");
            strSql.Append(" FROM t_ind_tweetslist order by AccountCreatedDate desc");
            if (strWhere.Trim()!="")
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
			strSql.Append("select count(1) FROM t_ind_tweetslist ");
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
			strSql.Append(")AS Row, T.*  from t_ind_tweetslist T ");
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
			parameters[0].Value = "t_ind_tweetslist";
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

        public DataSet GetTweetListByPage(int currentPageIndex, int pageSize, string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) from t_ind_tweetslist ");
            strSql.Append( strWhere);
            strSql.Append(";");

            strSql.Append(" SELECT ID,StatusID,CreatedByUser,TweetCreatedDate,FavoritesCount,TweetContent,IsSpam,c50Result FROM t_ind_tweetslist");
            strSql.Append(strWhere);
            strSql.Append(strOrder);
            strSql.Append(" limit " + ((currentPageIndex - 1) * pageSize).ToString() + "," + pageSize.ToString() + "");
            strSql.Append(" ;");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        // Get the number of spam/non-spam tweets
        public DataSet GetSpamTweetsNumber(string spamStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) from t_ind_tweetslist ");
            strSql.Append("where t_ind_tweetslist.IsSpam='" + spamStr +"'");
            strSql.Append(";");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetTotalNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) from t_ind_tweetslist");
            strSql.Append(";");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        // Get spam tweets based on C5.0 classifier
        public DataSet GetSpamTweetsCFiveO(string spamStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) from t_ind_tweetslist ");
            strSql.Append("where t_ind_tweetslist.c50Result='" + spamStr + "'");
            strSql.Append(";");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public string UpdateIsSpamByID(string ID, string IsSpam)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_ind_tweetslist ");
            strSql.Append(" set IsSpam='" + IsSpam + "'");
            strSql.Append("where t_ind_tweetslist.ID='" + ID + "'");
            strSql.Append(";");

            int result = 0;
            try
            {
                result = DbHelperMySQL.ExecuteSql(strSql.ToString());
            }
            catch
            { }

            if(result > 0)
            {
                return "";
            }
            else
            {
                return "failed to update the tweet records!";
            }
            
        }
        #endregion  ExtensionMethod
    }
}

