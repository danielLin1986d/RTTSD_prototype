/**  版本信息模板在安装目录下，可自行修改。
* t_rol_user.cs
*
* 功 能： N/A
* 类 名： t_rol_user
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
    /// 数据访问类:t_rol_user
    /// </summary>
    public partial class t_rol_user
    {
        public t_rol_user()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_rol_user");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)           };
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        public bool checkUserExistance(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from t_rol_user");
            strSql.Append(" where UserName='" + userName + "'");
            strSql.Append(";");

            return DbHelperMySQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.t_rol_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_rol_user(");
            strSql.Append("ID,Username,Password,FirstName,LastName,Mobile,TelNum,Address,Country,CreatedDate,IsValid,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Username,@Password,@FirstName,@LastName,@Mobile,@TelNum,@Address,@Country,@CreatedDate,@IsValid,@RoleID)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@Username", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Password", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FirstName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@LastName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Mobile", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TelNum", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Address", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Country", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("@IsValid", MySqlDbType.Int32,4),
                    new MySqlParameter("@RoleID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.FirstName;
            parameters[4].Value = model.LastName;
            parameters[5].Value = model.Mobile;
            parameters[6].Value = model.TelNum;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Country;
            parameters[9].Value = model.CreatedDate;
            parameters[10].Value = model.IsValid;
            parameters[11].Value = model.RoleID;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.t_rol_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_rol_user set ");
            strSql.Append("Username=@Username,");
            strSql.Append("Password=@Password,");
            strSql.Append("FirstName=@FirstName,");
            strSql.Append("LastName=@LastName,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("TelNum=@TelNum,");
            strSql.Append("Address=@Address,");
            strSql.Append("Country=@Country,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("IsValid=@IsValid,");
            strSql.Append("RoleID=@RoleID");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Username", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Password", MySqlDbType.VarChar,50),
                    new MySqlParameter("@FirstName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@LastName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Mobile", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TelNum", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Address", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Country", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("@IsValid", MySqlDbType.Int32,4),
                    new MySqlParameter("@RoleID", MySqlDbType.VarChar,36),
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.FirstName;
            parameters[3].Value = model.LastName;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.TelNum;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.Country;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.IsValid;
            parameters[10].Value = model.RoleID;
            parameters[11].Value = model.ID;

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
            strSql.Append("delete from t_rol_user ");
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
            strSql.Append("delete from t_rol_user ");
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
        public Model.t_rol_user GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Username,Password,FirstName,LastName,Mobile,TelNum,Address,Country,CreatedDate,IsValid,RoleID from t_rol_user ");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ID", MySqlDbType.VarChar,36)           };
            parameters[0].Value = ID;

            Model.t_rol_user model = new Model.t_rol_user();
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
        public Model.t_rol_user DataRowToModel(DataRow row)
        {
            Model.t_rol_user model = new Model.t_rol_user();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["Username"] != null)
                {
                    model.Username = row["Username"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["FirstName"] != null)
                {
                    model.FirstName = row["FirstName"].ToString();
                }
                if (row["LastName"] != null)
                {
                    model.LastName = row["LastName"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["TelNum"] != null)
                {
                    model.TelNum = row["TelNum"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["IsValid"] != null && row["IsValid"].ToString() != "")
                {
                    model.IsValid = int.Parse(row["IsValid"].ToString());
                }
                if (row["RoleID"] != null)
                {
                    model.RoleID = row["RoleID"].ToString();
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
            strSql.Append("select ID,Username,Password,FirstName,LastName,Mobile,TelNum,Address,Country,CreatedDate,IsValid,RoleID ");
            strSql.Append(" FROM t_rol_user ");
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
            strSql.Append("select count(1) FROM t_rol_user ");
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
            strSql.Append(")AS Row, T.*  from t_rol_user T ");
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
			parameters[0].Value = "t_rol_user";
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

        public Model.t_rol_user Login(string userName, string userPwd, Model.t_log_login logModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" call P_ROL_UserLogin (");
            strSql.Append("?UserName,?UserPwd,?ID,?IPAddress,?LoginDate,?ClientInfo)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?UserPwd", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ID", MySqlDbType.VarChar,36),
                    new MySqlParameter("?IPAddress", MySqlDbType.VarChar,20),
                    new MySqlParameter("?LoginDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ClientInfo", MySqlDbType.VarChar,255)};
            parameters[0].Value = userName;
            parameters[1].Value = userPwd;
            parameters[2].Value = logModel.ID;
            parameters[3].Value = logModel.IPAddress;
            parameters[4].Value = logModel.LoginDate;
            parameters[5].Value = logModel.ClientInfo;

            Model.t_rol_user model = new Model.t_rol_user();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["ID"] != null)
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Username"] != null)
                {
                    model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null)
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FirstName"] != null)
                {
                    model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LastName"] != null)
                {
                    model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null)
                {
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelNum"] != null)
                {
                    model.TelNum = ds.Tables[0].Rows[0]["TelNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null)
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Country"] != null)
                {
                    model.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsValid"] != null && ds.Tables[0].Rows[0]["IsValid"].ToString() != "")
                {
                    model.IsValid = int.Parse(ds.Tables[0].Rows[0]["IsValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"] != null)
                {
                    model.RoleID = ds.Tables[0].Rows[0]["RoleID"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RegisterUser(Model.t_rol_user model)
        {
            StringBuilder strSql = new StringBuilder();
            /*strSql.Append(" call P_ROL_UserRegister (");
            strSql.Append("?ID,?Username,?Password,?CreatedDate,?IsValid,?RoleID)");*
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Username", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Password", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?IsValid", MySqlDbType.Int32,4),
                    new MySqlParameter("?RoleID", MySqlDbType.VarChar,36),
                    new MySqlParameter("?ID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.IsValid;
            parameters[4].Value = model.RoleID;
            parameters[5].Value = model.ID;

            try
            {
                return DbHelperMySQL.GetSingle(strSql.ToString(), parameters).ToString();
            }
            catch
            {
                return "Database Error, Please contact the system administrator！";
            }*/

            strSql.Append("insert into t_rol_user(");
            strSql.Append("ID,Username,Password,CreatedDate,IsValid,RoleID)");
            strSql.Append(" values (");
            strSql.Append("?ID,?Username,?Password,?CreatedDate,?IsValid,?RoleID);");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Username", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Password", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?IsValid", MySqlDbType.Int32,4),
                    new MySqlParameter("?RoleID", MySqlDbType.VarChar,36),
                    new MySqlParameter("?ID", MySqlDbType.VarChar,36)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.IsValid;
            parameters[4].Value = model.RoleID;
            parameters[5].Value = model.ID;


            int rows = 0;
            try
            {
                rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            }
            catch
            { }
            if (rows > 0)
            {
                return "";
            }
            else
            {
                return "Database Error, registration failed！";
            }

            #endregion  ExtensionMethod
        }
    }
}

