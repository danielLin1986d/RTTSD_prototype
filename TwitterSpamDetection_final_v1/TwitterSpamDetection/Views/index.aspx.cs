using System;
using LTP.Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterSpamDetection.Views
{
    public partial class index : PageBase
    {
        BLL.t_ind_tweetslist tweetsListBll = new BLL.t_ind_tweetslist();
        BLL.t_ind_trainingtime trainingTimeBll = new BLL.t_ind_trainingtime();
        BLL.t_ind_pullhistory pullHistoryBll = new BLL.t_ind_pullhistory();

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
            // Algorithm Training Time Comparison
            DataSet TrainingDS = trainingTimeBll.GetAllList();
            if (TrainingDS.Tables[0].Rows.Count != 0)
            {
                knn1kTrainingTime.Text = TrainingDS.Tables[0].Rows[0]["TrainingTimeOne"].ToString();
                kknn1kTrainingTime.Text = TrainingDS.Tables[0].Rows[1]["TrainingTimeOne"].ToString();
                gbm1kTrainingTime.Text = TrainingDS.Tables[0].Rows[2]["TrainingTimeOne"].ToString();
                lg1kTrainingTime.Text = TrainingDS.Tables[0].Rows[3]["TrainingTimeOne"].ToString();
                rf1kTrainingTime.Text = TrainingDS.Tables[0].Rows[4]["TrainingTimeOne"].ToString();
                nb1kTrainingTime.Text = TrainingDS.Tables[0].Rows[5]["TrainingTimeOne"].ToString();
                nnet1kTrainingTime.Text = TrainingDS.Tables[0].Rows[6]["TrainingTimeOne"].ToString();

                knn10kTrainingTime.Text = TrainingDS.Tables[0].Rows[0]["TrainingTimeTwo"].ToString();
                kknn10kTrainingTime.Text = TrainingDS.Tables[0].Rows[1]["TrainingTimeTwo"].ToString();
                gbm10kTrainingTime.Text = TrainingDS.Tables[0].Rows[2]["TrainingTimeTwo"].ToString();
                lg10kTrainingTime.Text = TrainingDS.Tables[0].Rows[3]["TrainingTimeTwo"].ToString();
                rf10kTrainingTime.Text = TrainingDS.Tables[0].Rows[4]["TrainingTimeTwo"].ToString();
                nb10kTrainingTime.Text = TrainingDS.Tables[0].Rows[5]["TrainingTimeTwo"].ToString();
                nnet10kTrainingTime.Text = TrainingDS.Tables[0].Rows[6]["TrainingTimeTwo"].ToString();

                knn100kTrainingTime.Text = TrainingDS.Tables[0].Rows[0]["TrainingTimeThree"].ToString();
                kknn100kTrainingTime.Text = TrainingDS.Tables[0].Rows[1]["TrainingTimeThree"].ToString();
                gbm100kTrainingTime.Text = TrainingDS.Tables[0].Rows[2]["TrainingTimeThree"].ToString();
                lg100kTrainingTime.Text = TrainingDS.Tables[0].Rows[3]["TrainingTimeThree"].ToString();
                rf100kTrainingTime.Text = TrainingDS.Tables[0].Rows[4]["TrainingTimeThree"].ToString();
                nb100kTrainingTime.Text = TrainingDS.Tables[0].Rows[5]["TrainingTimeThree"].ToString();
                nnet100kTrainingTime.Text = TrainingDS.Tables[0].Rows[6]["TrainingTimeThree"].ToString();
            }
            else
            {
                WindowClass.WindowBack("Failed to acquire the algorithm training time information.");
            }

            // Pull History
            DataSet pullHistoryDS = pullHistoryBll.GetAllList();
            if (pullHistoryDS.Tables[0].Rows.Count != 0)
            {
                pullHistoryOne.Text = pullHistoryDS.Tables[0].Rows[4]["PullDate"].ToString(); // The earilier 
                pullHistoryTwo.Text = pullHistoryDS.Tables[0].Rows[3]["PullDate"].ToString();
                pullHistoryThree.Text = pullHistoryDS.Tables[0].Rows[2]["PullDate"].ToString();
                pullHistoryFour.Text = pullHistoryDS.Tables[0].Rows[1]["PullDate"].ToString();
                pullHistoryFive.Text = pullHistoryDS.Tables[0].Rows[0]["PullDate"].ToString(); // The latest

                TotalNumOne.Text = pullHistoryDS.Tables[0].Rows[4]["NumOfTotal"].ToString();
                TotalNumTwo.Text = pullHistoryDS.Tables[0].Rows[3]["NumOfTotal"].ToString();
                TotalNumThree.Text = pullHistoryDS.Tables[0].Rows[2]["NumOfTotal"].ToString();
                TotalNumFour.Text = pullHistoryDS.Tables[0].Rows[1]["NumOfTotal"].ToString();
                TotalNumFive.Text = pullHistoryDS.Tables[0].Rows[0]["NumOfTotal"].ToString();
            }
            else
            {
                WindowClass.WindowBack("Failed to acquire the pulling history.");
            }

            
            DataSet spamDS = tweetsListBll.GetSpamTweetsNumber("spammer");
            if(spamDS.Tables[0].Rows.Count != 0)
            {
                numOfSpams.Text = spamDS.Tables[0].Rows[0][0].ToString();
            }
            DataSet nonSpamDS = tweetsListBll.GetSpamTweetsNumber("non-spammer");
            if (nonSpamDS.Tables[0].Rows.Count != 0)
            {
                numOfNonSpams.Text = nonSpamDS.Tables[0].Rows[0][0].ToString();
            }
            DataSet totalDS = tweetsListBll.GetTotalNumber();
            if(totalDS.Tables[0].Rows.Count != 0)
            {
                numOfUndetected.Text = (int.Parse(totalDS.Tables[0].Rows[0][0].ToString()) - int.Parse(spamDS.Tables[0].Rows[0][0].ToString()) - int.Parse(nonSpamDS.Tables[0].Rows[0][0].ToString())).ToString();
            }
            
            /*
            DataSet c50SpamDS = tweetsListBll.GetSpamTweetsCFiveO("spammer");
            if (c50SpamDS.Tables[0].Rows.Count != 0)
            {
                numOfSpams.Text = c50SpamDS.Tables[0].Rows[0][0].ToString();
            }

            DataSet c50NonSpamDS = tweetsListBll.GetSpamTweetsCFiveO("non-spammer");
            if (c50NonSpamDS.Tables[0].Rows.Count != 0)
            {
                numOfNonSpams.Text = c50NonSpamDS.Tables[0].Rows[0][0].ToString();
            }
            DataSet totalDS = tweetsListBll.GetTotalNumber();
            if (totalDS.Tables[0].Rows.Count != 0)
            {
                numOfUndetected.Text = (int.Parse(totalDS.Tables[0].Rows[0][0].ToString()) - int.Parse(c50SpamDS.Tables[0].Rows[0][0].ToString()) - int.Parse(c50NonSpamDS.Tables[0].Rows[0][0].ToString())).ToString();
            }
            */

        }

            protected void resultConbined_Click(object sender, EventArgs e)
            {

                DataSet tweetsListDS = tweetsListBll.GetAllList();
                for (int i = 0; i < tweetsListDS.Tables[0].Rows.Count; i++)
                {
                    int knnResult = 0;
                    int kknnResult = 0;
                    int naivebayesResult = 0;
                    int randomforestResult = 0;
                    int c50Result = 0;
                    int gbmResult = 0;
                    int logisticregressionResult = 0;
                    int neuralnetworkResult = 0;
                    int conbinedTotal = 0;

                    // for a single tweet.
                    if (tweetsListDS.Tables[0].Rows[i]["knnResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["knnResult"].ToString() == "non-spammer")
                        {
                            knnResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["knnResult"].ToString() == "spammer")
                        {
                            knnResult = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["kknnResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["kknnResult"].ToString() == "non-spammer")
                        {
                            kknnResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["kknnResult"].ToString() == "spammer")
                        {
                            kknnResult = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["naivebayesResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["naivebayesResult"].ToString() == "non-spammer")
                        {
                            naivebayesResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["naivebayesResult"].ToString() == "spammer")
                        {
                            naivebayesResult = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["randomforestResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["randomforestResult"].ToString() == "non-spammer")
                        {
                            randomforestResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["randomforestResult"].ToString() == "spammer")
                        {
                            randomforestResult = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["c50Result"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["c50Result"].ToString() == "non-spammer")
                        {
                            c50Result = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["c50Result"].ToString() == "spammer")
                        {
                            c50Result = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["gbmResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["gbmResult"].ToString() == "non-spammer")
                        {
                            gbmResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["gbmResult"].ToString() == "spammer")
                        {
                            gbmResult = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["logisticregressionResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["logisticregressionResult"].ToString() == "non-spammer")
                        {
                            logisticregressionResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["logisticregressionResult"].ToString() == "spammer")
                        {
                        logisticregressionResult = -1;
                        }
                    }
                    if (tweetsListDS.Tables[0].Rows[i]["neuralnetworkResult"] != null)
                    {
                        if (tweetsListDS.Tables[0].Rows[i]["neuralnetworkResult"].ToString() == "non-spammer")
                        {
                            neuralnetworkResult = 1;
                        }
                        if (tweetsListDS.Tables[0].Rows[i]["neuralnetworkResult"].ToString() == "spammer")
                        {
                            neuralnetworkResult = -1;
                        }
                    }

                    conbinedTotal = knnResult + kknnResult + naivebayesResult + randomforestResult + c50Result + gbmResult + logisticregressionResult + neuralnetworkResult;

                    if (conbinedTotal == 0)
                    {
                        tweetsListBll.UpdateIsSpamByID(tweetsListDS.Tables[0].Rows[i]["ID"].ToString(), "Undetected");
                    }
                    if (conbinedTotal > 0)
                    {
                        tweetsListBll.UpdateIsSpamByID(tweetsListDS.Tables[0].Rows[i]["ID"].ToString(), "non-spammer");
                    }
                    if (conbinedTotal < 0)
                    {
                        tweetsListBll.UpdateIsSpamByID(tweetsListDS.Tables[0].Rows[i]["ID"].ToString(), "spammer");
                    }
                }       
        }
    }
}