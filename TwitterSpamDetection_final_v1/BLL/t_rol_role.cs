/**  版本信息模板在安装目录下，可自行修改。
* t_rol_role.cs
*
* 功 能： N/A
* 类 名： t_rol_role
*
*/
using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;

namespace TwitterSpamDetection.BLL
{
	/// <summary>
	/// t_rol_role
	/// </summary>
	public partial class t_rol_role
	{
		private readonly DAL.t_rol_role dal=new DAL.t_rol_role();
		public t_rol_role()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.t_rol_role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.t_rol_role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.t_rol_role GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.t_rol_role GetModelByCache(string ID)
		{
			
			string CacheKey = "t_rol_roleModel-" + ID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.t_rol_role)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.t_rol_role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.t_rol_role> DataTableToList(DataTable dt)
		{
			List<Model.t_rol_role> modelList = new List<Model.t_rol_role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.t_rol_role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// Get Role Name by RoleID
        /// </summary>
        public DataSet GetRoleNameByRoleID(string roleID)
        {
            return dal.GetRoleNameByRoleID(roleID);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// Get RoleID by RoleName
        /// </summary>
        public DataSet GetRoleIDByRoleName(string RoleName)
        {
            return dal.GetRoleIDByRoleName(RoleName);
        }

        #endregion  ExtensionMethod
    }
}

