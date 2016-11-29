using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.Data;

namespace TwitterSpamDetection.Views
{
    public partial class DataDisplay : PageBase
    {
        BLL.t_ind_tweetslist tweetListBll = new BLL.t_ind_tweetslist();

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
            FetchCurpage("curpage", AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblTweetSender.Text = StringClass.EncodeString(tweetSender.Text.Trim());
            lblTweetContent.Text = StringClass.EncodeString(tweetContent.Text.Trim());
            AspNetPager1.CurrentPageIndex = 1;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            tweetsList_ItemDataBinding();
        }

        protected void tweetsList_ItemDataBinding()
        {
            string tweetSender = StringClass.EncodeString(lblTweetSender.Text.Trim());
            string tweetContent = StringClass.EncodeString(lblTweetContent.Text.Trim());

            int totalCount = 0;

            DataTable dt = tweetListBll.GetTweetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, tweetSender, tweetContent, ref totalCount);
            AspNetPager1.RecordCount = totalCount > (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize ? totalCount : AspNetPager1.CurrentPageIndex * AspNetPager1.PageSize;
            this.tweetList.DataSource = dt.Rows;
            this.tweetList.DataBind();
            if (dt.Rows.Count == 0)
            {
                Literal_tweetList.Text = "<table width=100%><tr style=height:18px bgcolor=#FFFFFF><td align='center'><font color=red>Sorry, there is not relevent record found！<font></td></tr></table>";
            }
            else
            {
                Literal_tweetList.Text = "";
            }
            AspNetPager1.CustomInfoHTML = "Totally:<font color=\"blue\"><b>" + totalCount.ToString() + " </b></font> records";
            AspNetPager1.CustomInfoHTML += " <font color=\"red\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b></font>";
            AspNetPager1.CustomInfoHTML += "of <font color=\"blue\"><b>" + AspNetPager1.PageCount.ToString() + "  </b></font>pages";
        }

        int tweetListNum = 1;
        protected void tweetList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("ulcNum")).Text = tweetListNum.ToString();
                ((Label)e.Item.FindControl("ulcName")).Text = ((DataRow)e.Item.DataItem)["CreatedByUser"].ToString();
                ((Label)e.Item.FindControl("ulcCreatedAt")).Text = ((DataRow)e.Item.DataItem)["TweetCreatedDate"].ToString();
                ((Label)e.Item.FindControl("ulcFavorites")).Text = ((DataRow)e.Item.DataItem)["FavoritesCount"].ToString();
                ((Label)e.Item.FindControl("ulcContent")).Text = ((DataRow)e.Item.DataItem)["TweetContent"].ToString();
                if((((DataRow)e.Item.DataItem)["IsSpam"].ToString() == "") || ((DataRow)e.Item.DataItem)["IsSpam"].ToString() == null)
                {
                    ((Label)e.Item.FindControl("ulcIsSpam")).Text = "Undetected";
                }
                if (((DataRow)e.Item.DataItem)["IsSpam"].ToString() == "Undetected")
                {
                    ((Label)e.Item.FindControl("ulcIsSpam")).Text = "Undetected";
                }
                if (((DataRow)e.Item.DataItem)["IsSpam"].ToString() == "spammer")
                {
                    ((Label)e.Item.FindControl("ulcIsSpam")).Text = "Spam";
                }
                if (((DataRow)e.Item.DataItem)["IsSpam"].ToString() == "non-spammer")
                {
                    ((Label)e.Item.FindControl("ulcIsSpam")).Text = "Non-spam";
                }
                ((LinkButton)e.Item.FindControl("ulcDetail")).CommandArgument = ((DataRow)e.Item.DataItem)["ID"].ToString();
                tweetListNum++;
            }
        }

        protected void ulcViewDetail_Click(object sender, EventArgs e)
        {
            string tweetID = ((LinkButton)sender).CommandArgument;
            if (LTP.Common.CheckInput.CheckGUID(tweetID))
            {
               Response.Redirect("TweetDetails.aspx?ID=" + tweetID);
            }
            else
            {
                LTP.Common.WindowClass.WindowBack("The Tweet ID is invalid!");
            }
        }
    }
}