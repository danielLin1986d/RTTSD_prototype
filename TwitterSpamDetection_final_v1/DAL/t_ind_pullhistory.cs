using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace TwitterSpamDetection.DAL
{
    /// <summary>
    /// 数据访问类:t_ind_pullhistory
    /// </summary>
    public partial class t_ind_pullhistory
    {
        public t_ind_pullhistory()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_ind_pullhistory");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)           };
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TwitterSpamDetection.Model.t_ind_pullhistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_ind_pullhistory(");
            strSql.Append("ID,NumOfPull,NumOfTotal,PullDate,IsSuccessful,UserID)");
            strSql.Append(" values (");
            strSql.Append("@ID,@NumOfPull,@NumOfTotal,@PullDate,@IsSuccessful,@UserID)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@NumOfPull", MySqlDbType.VarChar,45),
                    new MySqlParameter("@NumOfTotal", MySqlDbType.VarChar,45),
                    new MySqlParameter("@PullDate", MySqlDbType.DateTime),
                    new MySqlParameter("@IsSuccessful", MySqlDbType.Int32,4),
                    new MySqlParameter("@UserID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NumOfPull;
            parameters[2].Value = model.NumOfTotal;
            parameters[3].Value = model.PullDate;
            parameters[4].Value = model.IsSuccessful;
            parameters[5].Value = model.UserID;

            int result = 0;
            try
            {
                result = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            }
            catch { }
            if (result > 0)
            {
                return "";
            }
            else
            {
                return "Failed to save the pull action.";
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TwitterSpamDetection.Model.t_ind_pullhistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_ind_pullhistory set ");
            strSql.Append("NumOfPull=@NumOfPull,");
            strSql.Append("NumOfTotal=@NumOfTotal,");
            strSql.Append("PullDate=@PullDate,");
            strSql.Append("IsSuccessful=@IsSuccessful,");
            strSql.Append("UserID=@UserID");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@NumOfPull", MySqlDbType.VarChar,45),
                    new MySqlParameter("@NumOfTotal", MySqlDbType.VarChar,45),
                    new MySqlParameter("@PullDate", MySqlDbType.DateTime),
                    new MySqlParameter("@IsSuccessful", MySqlDbType.Int32,4),
                    new MySqlParameter("@UserID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.NumOfPull;
            parameters[1].Value = model.NumOfTotal;
            parameters[2].Value = model.PullDate;
            parameters[3].Value = model.IsSuccessful;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_ind_pullhistory ");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)           };
            parameters[0].Value = ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_ind_pullhistory ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public TwitterSpamDetection.Model.t_ind_pullhistory GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NumOfPull,NumOfTotal,PullDate,IsSuccessful,UserID from t_ind_pullhistory ");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)           };
            parameters[0].Value = ID;

            TwitterSpamDetection.Model.t_ind_pullhistory model = new TwitterSpamDetection.Model.t_ind_pullhistory();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public TwitterSpamDetection.Model.t_ind_pullhistory DataRowToModel(DataRow row)
        {
            TwitterSpamDetection.Model.t_ind_pullhistory model = new TwitterSpamDetection.Model.t_ind_pullhistory();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["NumOfPull"] != null)
                {
                    model.NumOfPull = row["NumOfPull"].ToString();
                }
                if (row["NumOfTotal"] != null)
                {
                    model.NumOfTotal = row["NumOfTotal"].ToString();
                }
                if (row["PullDate"] != null && row["PullDate"].ToString() != "")
                {
                    model.PullDate = DateTime.Parse(row["PullDate"].ToString());
                }
                if (row["IsSuccessful"] != null && row["IsSuccessful"].ToString() != "")
                {
                    model.IsSuccessful = int.Parse(row["IsSuccessful"].ToString());
                }
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NumOfPull,NumOfTotal,PullDate,IsSuccessful,UserID ");
            strSql.Append(" FROM t_ind_pullhistory ");
            strSql.Append(" order by PullDate desc");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_ind_pullhistory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from t_ind_pullhistory T ");
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
			parameters[0].Value = "t_ind_pullhistory";
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


