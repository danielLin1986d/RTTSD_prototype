using LTP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using LinqToTwitter;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;

namespace TwitterSpamDetection.Views
{
    public partial class DataPullingFromTwitter : PageBase
    {
        //private List<Status> currentTweets;
        private List<String> tweetList;
        private List<String> tweetListForTXT;

        private string statusID;
        private string tweetUserName;
        private string follwersCount;
        private string friendsCount;
        private string userFavoritesCount;
        private string listedCount; // 
        private string tweetsNUM; // Statuses Count
        private string retweetCount;
        private string favoriteCount;
        private string hashtagCount;
        private string userMentionsCount;

        private DateTime tweetCreatedDate;
        private string tweetCount;

        private string timeDifference;
        private int numberOfURL;
        private int numberOfChar;
        private int numberOfDigit;

        private string pulledData;
        private string totalNumTweets;

        private int j = 0;

        private int numberOfTweetsFetched; // The number of tweets grabed each time from twitter.

        private string error = "";
        private string pulledError = "";

        BLL.t_ind_tweetslist tweetsListBll = new BLL.t_ind_tweetslist();
        BLL.t_ind_pullhistory pullhistoryBll = new BLL.t_ind_pullhistory();

        Model.t_ind_tweetslist tweetsListModel = new Model.t_ind_tweetslist();
        Model.t_ind_pullhistory pullhistoryModel = new Model.t_ind_pullhistory();

        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = ConfigHelper.GetConfigString("ConsumerKey"),
                ConsumerSecret = ConfigHelper.GetConfigString("ConsumerSecret"),
                AccessToken = ConfigHelper.GetConfigString("AccessToken"),
                AccessTokenSecret = ConfigHelper.GetConfigString("AccessTokenSecret")
            }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            ucTop.User = User;

            if (!IsPostBack)
            {
                InitRequest();
            }
        }

        private void InitRequest()
        {
            
        }

        protected void DataPulling_Click(object sender, EventArgs e)
        {
            GetMostRecent200HomeTimeLine();

            //Random ra = new Random();
            //string fileExtentionName = "log";
            //string tweetsLogFileSubFolder = DateTime.Now.Year + "_" + DateTime.Now.Month;
            //string tweetsLogFileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + ra.Next(1, 100) + "." + fileExtentionName.ToString();
            //string tweetsLogFilePath = Server.MapPath("../Temp/") + tweetsLogFileSubFolder + "/";

            //if (!System.IO.Directory.Exists(tweetsLogFilePath))
            //{
            //    System.IO.Directory.CreateDirectory(tweetsLogFilePath);
            //}

            // Check how many urls the tweet content containts. 
            string urlPatten = @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)";

            tweetListForTXT = new List<string>();

            for (int i = 0; i < tweetList.Count; i++)
            {
                string singleTweet = tweetList[i];
                string[] temp = singleTweet.Split(',');

                // Check whether this tweets has been stored in the database already.
                if(tweetsListBll.ExistsByStatusID(temp[0]))
                {
                    j++; // Record the number of repeated tweets. 
                    continue;
                }

                string tweetContentText = temp[temp.Length-1]; // Get the last item of the array which is the tweet content.

                string content = tweetContentText.Trim();
                string contentWithoutURL = "";
                string[] contentTemp = content.Split(' ');
                numberOfURL = 0;
                numberOfChar = 0;
                numberOfChar = 0;
                for (int j = 0; j < contentTemp.Length; j++)
                {
                    Regex regex = new Regex(urlPatten);
                    Match m = regex.Match(contentTemp[j]);
                    if (m.Success)
                    {
                        numberOfURL++;
                    }
                    else
                    {
                        contentWithoutURL = contentWithoutURL + contentTemp[j];
                    }
                }

                for (int j = 0; j < contentWithoutURL.Length; j++)
                {
                    if (Char.IsDigit(contentWithoutURL, j))
                    {
                        numberOfDigit++;
                    }
                    if (Char.IsLetter(contentWithoutURL, j))
                    {
                        numberOfChar++;
                    }
                }

                TimeSpan timeSpan = DateTime.Now.Subtract(DateTime.Parse(temp[2])).Duration();
                timeDifference = timeSpan.Days.ToString();

                // Select 13 features 
                //    tweetListForTXT.Add(timeDifference + "," // account_age counted in days.
                //        + temp[3] + ","
                //        + temp[4] + ","
                //        + temp[5] + ","
                //        + temp[6] + ","
                //        + temp[7] + ","
                //        + temp[8] + ","
                //        + temp[9] + "," 
                //        + temp[10] + ","
                //        + temp[11] + ","
                //        + numberOfURL.ToString() + ","
                //        + numberOfChar.ToString() + ","
                //        + numberOfDigit.ToString() + " ");

                // Insert data to database
                tweetsListModel.ID = Guid.NewGuid().ToString().ToLower();
                tweetsListModel.StatusID = temp[0]; // The unique ID for tweets.
                tweetsListModel.CreatedByUser = temp[1];
                tweetsListModel.AccountCreatedDate = DateTime.Parse(temp[2]);
                tweetsListModel.AccountAge = timeDifference;
                tweetsListModel.FollowersCount = temp[3];
                tweetsListModel.FriendsCount = temp[4];
                tweetsListModel.FavoritesCount = temp[5]; // Number of favorites
                tweetsListModel.ListedCount = temp[6];
                tweetsListModel.StatusesCount = temp[7];
                tweetsListModel.RetweetCount = temp[8];
                tweetsListModel.FavoriteCount = temp[9];
                tweetsListModel.HashTapsCount = temp[10];
                tweetsListModel.UserMentionsCount = temp[11];
                tweetsListModel.TweetCreatedDate = DateTime.Parse(temp[12]);
                tweetsListModel.UrlsCount = numberOfURL.ToString();
                tweetsListModel.NumberOfChar = numberOfChar.ToString();
                tweetsListModel.NumberOfDigits = numberOfDigit.ToString();
                tweetsListModel.TweetContent = temp[13];

                // Store each pulled tweet.
                error = tweetsListBll.Add(tweetsListModel);
            }

            if (error == "")
            {
                pulledData = (numberOfTweetsFetched - j).ToString();

                DataSet totalTweetsDS = tweetsListBll.GetTotalNumber();
                if (totalTweetsDS.Tables[0].Rows.Count != 0)
                {
                    totalNumTweets = totalTweetsDS.Tables[0].Rows[0][0].ToString();
                }

                // Store the pulling action in db.
                pullhistoryModel.ID = Guid.NewGuid().ToString().ToLower();
                pullhistoryModel.UserID = User.ID;
                pullhistoryModel.NumOfPull = pulledData; // How many non-repeated data is pulled.
                pullhistoryModel.IsSuccessful = 1; // 1 means a successful pull of data from twitter account.
                pullhistoryModel.PullDate = DateTime.Now;
                pullhistoryModel.NumOfTotal = totalNumTweets;

                pulledError = pullhistoryBll.Add(pullhistoryModel);
                if(pulledError =="")
                {
                    DataPullingIndication.Text = "Successfully pulled " + pulledData + " latest tweets from your twitter timeline at " + pullhistoryModel.PullDate + ".";
                }
                else
                {
                    WindowClass.WindowBack(pulledError);
                }

            }
            else
            {
                WindowClass.WindowBack(error);
            }

            //File.WriteAllLines(tweetsLogFilePath + tweetsLogFileName, tweetListForTXT);

        }

        private void GetMostRecent200HomeTimeLine()
        {
            var twitterContext = new TwitterContext(authorizer);

            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home && tweet.Count == 200
                         select tweet;

            tweetList = new List<String>();

            // Get the required tweet data
            tweets.ToList().ForEach(
                tweet => tweetList.Add(tweet.StatusID.ToString() + ","
                                    + tweet.User.Name.ToString() + "," 
                                    + tweet.User.CreatedAt.ToLocalTime() + "," // Account Created Date
                                    + tweet.User.FollowersCount.ToString() + "," // @attribute no_follower numeric
                                    + tweet.User.FriendsCount.ToString() + "," //  @attribute no_following numeric 
                                    + tweet.User.FavoritesCount.ToString() + "," // @attribute no_userfavourites numeric (Number of favorites)
                                    + tweet.User.ListedCount.ToString() + "," // @attribute no_userfavourites numeric
                                    + tweet.User.StatusesCount.ToString() + "," // @attribute no_tweets numeric
                                    + tweet.RetweetCount.ToString() + "," // @attribute no_retweets numeric
                                    + tweet.FavoriteCount.ToString() + "," // @attribute no_tweetfavourites numeric (Number of times the tweet was favorite)
                                    + tweet.Entities.HashTagEntities.Count.ToString() + "," // @attribute no_tweetfavourites numeric
                                    + tweet.Entities.UserMentionEntities.Count.ToString() + "," // @attribute no_usermention numeric
                                    + tweet.CreatedAt.ToLocalTime().ToString() + "," // Tweet Created Date
                                    + tweet.Text + "\n"));

            numberOfTweetsFetched = tweetList.Count;
        }

        protected void ViewData_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataDisplay.aspx");
        }
    }
}