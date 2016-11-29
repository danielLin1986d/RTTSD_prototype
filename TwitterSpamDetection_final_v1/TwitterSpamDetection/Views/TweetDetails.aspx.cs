using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterSpamDetection.Views
{
    public partial class TweetDetails : PageBase
    {
        private int spamsCount = 0;
        private int non_spamsCount = 0;

        private string knnRs;
        private string kknnRs;
        private string nbRs;
        private string rfRs;
        private string c50Rs;
        private string gbmRs;
        private string logrRs;
        private string nnetRs;
        
        BLL.t_ind_tweetslist tweetlistBll = new BLL.t_ind_tweetslist();
        Model.t_ind_tweetslist tweetModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add the reference of user-defined control.
            ucTop.User = User;

            if (!IsPostBack)
            {
                InitRequest();
            }
        }

        private void InitRequest()
        {
            FetchKeyGUID("ID", lblTweetID);
            string tweetID = lblTweetID.Text.Trim();

            if (tweetID != null && LTP.Common.CheckInput.CheckGUID(tweetID))
            {
                tweetModel = tweetlistBll.GetModel(tweetID);
                if(tweetModel != null)
                {
                    TweetStatusID.Text = tweetModel.StatusID;
                    CreatedByUser.Text = tweetModel.CreatedByUser;
                    AccountCreatedDate.Text = tweetModel.AccountCreatedDate.ToString();
                    AccountAge.Text = tweetModel.AccountAge;
                    FollowersCount.Text = tweetModel.FollowersCount;
                    FriendsCount.Text = tweetModel.FriendsCount;
                    FavoritesCount.Text = tweetModel.FavoritesCount;
                    StatusesCount.Text = tweetModel.StatusesCount;

                    TweetContent.Text = tweetModel.TweetContent;
                    RetweetCount.Text = tweetModel.RetweetCount;
                    FavoriteCount.Text = tweetModel.FavoriteCount;
                    UserMentionsCount.Text = tweetModel.UserMentionsCount;
                    UrlsCount.Text = tweetModel.UrlsCount;

                    if(tweetModel.knnResult != "")
                    {
                        if(tweetModel.knnResult == "spammer")
                        {
                            knnRs = "-1";
                            knn.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.knnResult == "non-spammer")
                        {
                            knnRs = "1";
                            knn.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        knnRs = "0";
                        knn.Text = "Undetected";
                    }
                    if (tweetModel.kknnResult != "")
                    {
                        if (tweetModel.kknnResult == "spammer")
                        {
                            kknnRs = "-1";
                            kknn.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.kknnResult == "non-spammer")
                        {
                            kknnRs = "1";
                            kknn.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        kknnRs = "0";
                        kknn.Text = "Undetected";
                    }
                    if (tweetModel.naivebayesResult != "")
                    {
                        if (tweetModel.naivebayesResult == "spammer")
                        {
                            nbRs = "-1";
                            nb.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.naivebayesResult == "non-spammer")
                        {
                            nbRs = "1";
                            nb.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        nbRs = "0";
                        nb.Text = "Undetected";
                    }
                    if (tweetModel.randomforestResult != "")
                    {
                        if (tweetModel.randomforestResult == "spammer")
                        {
                            rfRs = "-1";
                            rf.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.randomforestResult == "non-spammer")
                        {
                            rfRs = "1";
                            rf.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        rfRs = "0";
                        rf.Text = "Undetected";
                    }
                    if (tweetModel.c50Result != "")
                    {
                        if (tweetModel.c50Result == "spammer")
                        {
                            c50Rs = "-1";
                            c50.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.c50Result == "non-spammer")
                        {
                            c50Rs = "1";
                            c50.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        c50Rs = "0";
                        c50.Text = "Undetected";
                    }
                    if (tweetModel.gbmResult != "")
                    {
                        if (tweetModel.gbmResult == "spammer")
                        {
                            gbmRs = "-1";
                            gbm.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.gbmResult == "non-spammer")
                        {
                            gbmRs = "1";
                            gbm.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        gbmRs = "0";
                        gbm.Text = "Undetected";
                    }
                    if (tweetModel.logisticregressionResult != "")
                    {
                        if (tweetModel.logisticregressionResult == "spammer")
                        {
                            logrRs = "-1";
                            logr.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.logisticregressionResult == "non-spammer")
                        {
                            logrRs = "1";
                            logr.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        logrRs = "0";
                        logr.Text = "Undetected";
                    }
                    if (tweetModel.neuralnetworkResult != "")
                    {
                        if (tweetModel.neuralnetworkResult == "spammer")
                        {
                            nnetRs = "-1";
                            nnet.Text = "Spammer";
                            spamsCount++;
                        }
                        if (tweetModel.neuralnetworkResult == "non-spammer")
                        {
                            nnetRs = "1";
                            nnet.Text = "Non-spammer";
                            non_spamsCount++;
                        }
                    }
                    else
                    {
                        nnetRs = "0";
                        nnet.Text = "Undetected";
                    }

                    if((spamsCount == 0) && (non_spamsCount == 0))
                    {
                        proOfUndetected.Text = "0";
                    }
                    proOfSpams.Text = spamsCount.ToString();
                    proOfNonSpams.Text = non_spamsCount.ToString();
                }
                else
                {
                    LTP.Common.WindowClass.WindowBack("Failed to acquire the tweet model!");
                }
            }
            else
            {
                LTP.Common.WindowClass.WindowBack("The Tweet ID is NULL or invalid!");
            }
        }
    }
}