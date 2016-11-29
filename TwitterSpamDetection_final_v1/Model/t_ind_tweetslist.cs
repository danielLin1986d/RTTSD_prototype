/**  版本信息模板在安装目录下，可自行修改。
* t_ind_tweetslist.cs
*
* 功 能： N/A
* 类 名： t_ind_tweetslist
*
*/
using System;
namespace TwitterSpamDetection.Model
{
	/// <summary>
	/// t_ind_tweetslist:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_ind_tweetslist
	{
        public t_ind_tweetslist()
        { }
        #region Model
        private string _id;
        private string _statusid;
        private string _createdbyuser;
        private DateTime? _accountcreateddate;
        private DateTime? _tweetcreateddate;
        private string _accountage;
        private string _followerscount;
        private string _friendscount;
        private string _favoritescount;
        private string _listedcount;
        private string _statusescount;
        private string _retweetcount;
        private string _favoritecount;
        private string _hashtapscount;
        private string _usermentionscount;
        private string _urlscount;
        private string _numberofchar;
        private string _numberofdigits;
        private string _tweetcontent;
        private string _isspam;
        private string _knnresult;
        private string _kknnresult;
        private string _naivebayesresult;
        private string _randomforestresult;
        private string _c50result;
        private string _gbmresult;
        private string _logisticregressionresult;
        private string _neuralnetworkresult;
        private string _probabilityofspam;
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
        public string StatusID
        {
            set { _statusid = value; }
            get { return _statusid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedByUser
        {
            set { _createdbyuser = value; }
            get { return _createdbyuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AccountCreatedDate
        {
            set { _accountcreateddate = value; }
            get { return _accountcreateddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TweetCreatedDate
        {
            set { _tweetcreateddate = value; }
            get { return _tweetcreateddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccountAge
        {
            set { _accountage = value; }
            get { return _accountage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FollowersCount
        {
            set { _followerscount = value; }
            get { return _followerscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FriendsCount
        {
            set { _friendscount = value; }
            get { return _friendscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FavoritesCount
        {
            set { _favoritescount = value; }
            get { return _favoritescount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ListedCount
        {
            set { _listedcount = value; }
            get { return _listedcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StatusesCount
        {
            set { _statusescount = value; }
            get { return _statusescount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RetweetCount
        {
            set { _retweetcount = value; }
            get { return _retweetcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FavoriteCount
        {
            set { _favoritecount = value; }
            get { return _favoritecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HashTapsCount
        {
            set { _hashtapscount = value; }
            get { return _hashtapscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserMentionsCount
        {
            set { _usermentionscount = value; }
            get { return _usermentionscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UrlsCount
        {
            set { _urlscount = value; }
            get { return _urlscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NumberOfChar
        {
            set { _numberofchar = value; }
            get { return _numberofchar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NumberOfDigits
        {
            set { _numberofdigits = value; }
            get { return _numberofdigits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TweetContent
        {
            set { _tweetcontent = value; }
            get { return _tweetcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsSpam
        {
            set { _isspam = value; }
            get { return _isspam; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// /// <summary>
		/// 
		/// </summary>
		public string knnResult
        {
            set { _knnresult = value; }
            get { return _knnresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kknnResult
        {
            set { _kknnresult = value; }
            get { return _kknnresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string naivebayesResult
        {
            set { _naivebayesresult = value; }
            get { return _naivebayesresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string randomforestResult
        {
            set { _randomforestresult = value; }
            get { return _randomforestresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string c50Result
        {
            set { _c50result = value; }
            get { return _c50result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gbmResult
        {
            set { _gbmresult = value; }
            get { return _gbmresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logisticregressionResult
        {
            set { _logisticregressionresult = value; }
            get { return _logisticregressionresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string neuralnetworkResult
        {
            set { _neuralnetworkresult = value; }
            get { return _neuralnetworkresult; }
        }
        public string ProbabilityOfSpam
        {
            set { _probabilityofspam = value; }
            get { return _probabilityofspam; }
        }
        #endregion Model

    }
}

