/**  版本信息模板在安装目录下，可自行修改。
* t_rol_role.cs
*
* 功 能： N/A
* 类 名： t_rol_role
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
	/// 数据访问类:t_rol_role
	/// </summary>
	public partial class t_rol_role
	{
		public t_rol_role()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_rol_role");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.t_rol_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_rol_role(");
			strSql.Append("ID,RoleName,CreatedDate)");
			strSql.Append(" values (");
			strSql.Append("@ID,@RoleName,@CreatedDate)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36),
					new MySqlParameter("@RoleName", MySqlDbType.VarChar,64),
					new MySqlParameter("@CreatedDate", MySqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.CreatedDate;

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
		public bool Update(Model.t_rol_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_rol_role set ");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("CreatedDate=@CreatedDate");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RoleName", MySqlDbType.VarChar,64),
					new MySqlParameter("@CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.CreatedDate;
			parameters[2].Value = model.ID;

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
			strSql.Append("delete from t_rol_role ");
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
			strSql.Append("delete from t_rol_role ");
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
		public Model.t_rol_role GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,RoleName,CreatedDate from t_rol_role ");
			strSql.Append(" where ID=@ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			Model.t_rol_role model=new Model.t_rol_role();
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
		public Model.t_rol_role DataRowToModel(DataRow row)
		{
			Model.t_rol_role model=new Model.t_rol_role();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
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
			strSql.Append("select ID,RoleName,CreatedDate ");
			strSql.Append(" FROM t_rol_role ");
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
			strSql.Append("select count(1) FROM t_rol_role ");
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
			strSql.Append(")AS Row, T.*  from t_rol_role T ");
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
			parameters[0].Value = "t_rol_role";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// Get Role Name By RoleID
        /// </summary>
        public DataSet GetRoleNameByRoleID(string roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleName from t_rol_role ");
            strSql.Append("where ID='" + roleID + "';");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// Get RoleID by RoleName
        /// </summary>
        public DataSet GetRoleIDByRoleName(string RoleName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID ");
            strSql.Append(" FROM t_rol_role ");
            if (RoleName.Trim() != "")
            {
                strSql.Append(" where RoleName='" + RoleName + "'");
            }
            strSql.Append(";");

            return DbHelperMySQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

