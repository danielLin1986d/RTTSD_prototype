<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TweetDetails.aspx.cs" Inherits="TwitterSpamDetection.Views.TweetDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head runat="server">
    <title>Twitter Spam Detection System</title>
    <!-- #include file="./Shared/TopReference.html" -->
    <script type="text/javascript" src="../dist/js/Chart.js"></script>
</head>
<body>
    <div class="main-wrapper">
        <div class="app" id="app">
            <form id="index_form" runat="server">
                <!-- Main Header -->
                <cuc:MainTop ID="ucTop" runat="server" />
                <div id="divHidden" style="display:none;">
                    <asp:Label ID="lblTweetID" runat="server"></asp:Label>

                    <asp:Label ID="proOfSpams" runat="server"></asp:Label>
                    <asp:Label ID="proOfNonSpams" runat="server"></asp:Label>
                    <asp:Label ID="proOfUndetected" runat="server"></asp:Label>
                </div>
                  <div class="sidebar-overlay" id="sidebar-overlay"></div>
                    <article class="content dashboard-page">
                        <div class="title-block">
                            <h1 class="title">Tweet Details (StatusID: <asp:Label ID="TweetStatusID" runat="server"></asp:Label>)</h1>
                            <p class="title-description">Know more about this tweet.</p>
                        </div>
                        <section class="section">
                            <div class="row sameheight-container">
                                <div class="col-md-12">
                                    <div class="card card-info">
                                        <div class="card-header">
                                            <div class="header-block">
                                                <p class="title"> Profile Related Details </p>
                                            </div>
                                        </div>
                                        <div class="card-block">
                                            <table class="table table-striped table-hover">
                                                <thead>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="width:20%"><strong> This tweet was sent by: </strong></td>
                                                        <td style="width:80%"><asp:Label ID="CreatedByUser" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Profile Created at: </strong></td>
                                                        <td><asp:Label ID="AccountCreatedDate" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Account Age: </strong></td>
                                                        <td> This account has been existed for <asp:Label ID="AccountAge" runat="server"></asp:Label> days </td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Followed by: </strong></td>
                                                        <td><asp:Label ID="FollowersCount" runat="server"></asp:Label> user(s).</td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Friends: </strong></td>
                                                        <td><asp:Label ID="FriendsCount" runat="server"></asp:Label> user(s).</td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Favorited by: </strong></td>
                                                        <td><asp:Label ID="FavoritesCount" runat="server"></asp:Label> user(s).</td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> The number of tweets sent by this account: </strong></td>
                                                        <td><asp:Label ID="StatusesCount" runat="server"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <!-- <div class="card-footer"> Card Footer </div> -->
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="card card-info">
                                        <div class="card-header">
                                            <div class="header-block">
                                                <p class="title"> Tweet Details </p>
                                            </div>
                                        </div>
                                        <div class="card-block">
                                            <table class="table table-striped table-hover">
                                                <thead>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="width:20%"><strong> Tweet Content: </strong></td>
                                                        <td style="width:80%"><asp:Label ID="TweetContent" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Retweet times: </strong></td>
                                                        <td><asp:Label ID="RetweetCount" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> This tweet has been liked by: </strong></td>
                                                        <td><asp:Label ID="FavoriteCount" runat="server"></asp:Label> user(s).</td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> This tweet has been mentioned by: </strong></td>
                                                        <td><asp:Label ID="UserMentionsCount" runat="server"></asp:Label> user(s).</td>
                                                    </tr>
                                                   <tr>
                                                        <td><strong> The number of URLs: </strong></td>
                                                        <td><asp:Label ID="UrlsCount" runat="server"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <!-- <div class="card-footer"> Card Footer </div> -->
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="card card-success">
                                        <div class="card-header">
                                            <div class="header-block">
                                                <p class="title"> The Probability of Being Spam </p>
                                            </div>
                                        </div>
                                        <div class="card-block">
                                            <section  class="example">
                                                <canvas id="the_probability_of_being_spam"></canvas>
                                            </section>
                                        </div>
                                        <!-- <div class="card-footer"> Card Footer </div> -->
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="card card-warning">
                                        <div class="card-header">
                                            <div class="header-block">
                                                <p class="title"> Detection Results of Each Classifier </p>
                                            </div>
                                        </div>
                                        <div class="card-block">
                                             <table class="table table-striped table-hover">
                                                <thead>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="width:65%"><strong> k Nearest Neighbor: </strong></td>
                                                        <td style="width:35%"><asp:Label ID="knn" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Weighted k Nearest Neighbor: </strong></td>
                                                        <td><asp:Label ID="kknn" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Naive Bayes: </strong></td>
                                                        <td><asp:Label ID="nb" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Random Forest: </strong></td>
                                                        <td><asp:Label ID="rf" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> C5.0: </strong></td>
                                                        <td><asp:Label ID="c50" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Stochastic Grediant Boost Machine: </strong></td>
                                                        <td><asp:Label ID="gbm" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Logistic Regress: </strong></td>
                                                        <td><asp:Label ID="logr" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong> Neural Network: </strong></td>
                                                        <td><asp:Label ID="nnet" runat="server"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <!-- <div class="card-footer"> Card Footer </div> -->
                                    </div>
                                </div>

                            </div>
                        </section>
                    </article>     
                    <script>
                        // Pie Chart Area //
                        var spam = $("#proOfSpams").text(); // Red
                        var nonSpam = $("#proOfNonSpams").text(); // Blue
                        var undetected = $("#proOfUndetected").text(); // Yellow

                        var spamResult = parseInt(spam) / (parseInt(spam) + parseInt(nonSpam)) * 100;
                        var nonSpamResult = parseInt(nonSpam) / (parseInt(spam) + parseInt(nonSpam)) * 100;
                        // For a pie chart
                        new Chart(document.getElementById("the_probability_of_being_spam"), {
                            type: 'doughnut',
                            data: {
                                labels: [
                                    "The Probability of Being Spam",
                                    "The Probability of Being Non-spam",
                                    "Undetected"
                                ],
                                datasets: [
                                    {
                                        data: [spamResult, nonSpamResult, undetected],
                                        backgroundColor: [
                                            "#FF6384",
                                            "#36A2EB",
                                            "#FFCE56"
                                        ],
                                        hoverBackgroundColor: [
                                            "#FF6384",
                                            "#36A2EB",
                                            "#FFCE56"
                                        ]
                                    }]
                            },                           
                            animation: {
                                animateScale: true
                            }
                        });
                        // Pie Chart Area //
                    </script>      
            </form>
           <!-- #include file="./Shared/BottomReference.html" -->
</body>
</html>
