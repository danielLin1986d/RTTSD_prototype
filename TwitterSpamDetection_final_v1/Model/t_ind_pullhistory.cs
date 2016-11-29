using System;

namespace TwitterSpamDetection.Model
{
    /// <summary>
    /// t_ind_pullhistory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_ind_pullhistory
    {
        public t_ind_pullhistory()
        { }
        #region Model
        private string _id;
        private string _numofpull;
        private string _numoftotal;
        private DateTime? _pulldate;
        private int? _issuccessful;
        private string _userid;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NumOfPull
        {
            set { _numofpull = value; }
            get { return _numofpull; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NumOfTotal
        {
            set { _numoftotal = value; }
            get { return _numoftotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PullDate
        {
            set { _pulldate = value; }
            get { return _pulldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsSuccessful
        {
            set { _issuccessful = value; }
            get { return _issuccessful; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        #endregion Model

    }
}


