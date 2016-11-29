/**  版本信息模板在安装目录下，可自行修改。
* t_ind_tweetslist.cs
*
* 功 能： N/A
* 类 名： t_ind_tweetslist
*
*/
using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using System.Text;

namespace TwitterSpamDetection.BLL
{
    /// <summary>
    /// t_ind_tweetslist
    /// </summary>
    public partial class t_ind_tweetslist
    {
        private readonly DAL.t_ind_tweetslist dal = new DAL.t_ind_tweetslist();
        public t_ind_tweetslist()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 是否存在该记录 by checking statusID
        /// </summary>
        public bool ExistsByStatusID(string StatusID)
        {
            return dal.ExistsByStatusID(StatusID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.t_ind_tweetslist model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.t_ind_tweetslist model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.t_ind_tweetslist GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.t_ind_tweetslist GetModelByCache(string ID)
        {

            string CacheKey = "t_ind_tweetslistModel-" + ID;
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
                catch { }
            }
            return (Model.t_ind_tweetslist)objModel;
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
        public List<Model.t_ind_tweetslist> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.t_ind_tweetslist> DataTableToList(DataTable dt)
        {
            List<Model.t_ind_tweetslist> modelList = new List<Model.t_ind_tweetslist>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.t_ind_tweetslist model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        public DataTable GetTweetListByPage(int currentPageIndex, int pageSize, string tweetSender, string tweetContent, ref int totalCount)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" where 1=1");
            if (tweetSender != "")
            {
                strWhere.Append(" and t_ind_tweetslist.CreatedByUser like '%" + tweetSender + "%'");
            }
            if (tweetContent != "")
            {
                strWhere.Append(" and t_ind_tweetslist.TweetContent like '%" + tweetContent + "%'");
            }
            StringBuilder strOrder = new StringBuilder();
            strOrder.Append(" order by");
            strOrder.Append(" t_ind_tweetslist.TweetCreatedDate desc");

            DataSet ds = dal.GetTweetListByPage(currentPageIndex, pageSize, strWhere.ToString(), strOrder.ToString());
            strWhere = null;
            strOrder = null;
            try
            {
                totalCount = System.Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            catch
            {
                totalCount = 0;
            }
            return ds.Tables[1];
        }

        public DataSet GetSpamTweetsNumber(string spamStr)
        {
            return dal.GetSpamTweetsNumber(spamStr);
        }

        public DataSet GetTotalNumber()
        {
            return dal.GetTotalNumber();
        }

        // Get spam tweets based on C5.0 classifier
        public DataSet GetSpamTweetsCFiveO(string spamStr)
        {
            return dal.GetSpamTweetsCFiveO(spamStr);
        }

        public string UpdateIsSpamByID(string ID, string IsSpam)
        {
             return dal.UpdateIsSpamByID(ID, IsSpam);
        }
        #endregion  ExtensionMethod
    }
}

