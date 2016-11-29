<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TwitterSpamDetection.Views.index" %>

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
                    <asp:Label ID="numOfSpams" runat="server"></asp:Label>
                    <asp:Label ID="numOfNonSpams" runat="server"></asp:Label>
                    <asp:Label ID="numOfUndetected" runat="server"></asp:Label>

                    <asp:Label ID="knn1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="knn10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="knn100kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="kknn1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="kknn10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="kknn100kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="gbm1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="gbm10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="gbm100kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="lg1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="lg10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="lg100kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="rf1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="rf10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="rf100kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="nb1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="nb10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="nb100kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="nnet1kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="nnet10kTrainingTime" runat="server"></asp:Label>
                    <asp:Label ID="nnet100kTrainingTime" runat="server"></asp:Label>

                    <asp:Label ID="pullHistoryOne" runat="server"></asp:Label>
                    <asp:Label ID="pullHistoryTwo" runat="server"></asp:Label>
                    <asp:Label ID="pullHistoryThree" runat="server"></asp:Label>
                    <asp:Label ID="pullHistoryFour" runat="server"></asp:Label>
                    <asp:Label ID="pullHistoryFive" runat="server"></asp:Label>
                    <asp:Label ID="TotalNumOne" runat="server"></asp:Label>
                    <asp:Label ID="TotalNumTwo" runat="server"></asp:Label>
                    <asp:Label ID="TotalNumThree" runat="server"></asp:Label>
                    <asp:Label ID="TotalNumFour" runat="server"></asp:Label>
                    <asp:Label ID="TotalNumFive" runat="server"></asp:Label>

                </div>
                <div class="sidebar-overlay" id="sidebar-overlay"></div>
                <article class="content dashboard-page">
                    <div class="title-block">
                        <h1 class="title">Twitter Data Overview</h1>
                        <p class="title-description">View tweets and Spams </p>
                    </div>
                    <section class="section">
                        <div class="row">
                            <!-- Pie Chart Area -->
                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-block">
                                        <div class="card-title-block">
                                            <h3 class="title">
                                                Spam/Non-spam Ratio
                                            </h3>
                                        </div>
                                        <section class="example">
                                             <canvas id="spam-non-spam-pie-chart"></canvas>
                                        </section>
                                    </div>
                                </div>
                            </div>
                            <!-- Pie Chart Area -->

                            <!-- Bar Chart Area -->
                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-block">
                                        <div class="card-title-block">
                                            <h3 class="title">
                                                Data Pulling History
                                            </h3>
                                        </div>
                                        <section class="example">
                                             <canvas id="data-pulling-history-line-chart"></canvas>
                                        </section>
                                    </div>
                                </div>
                            </div>
                            <!-- Bar Chart Area -->
                        </div>
                    </section>
                    <!-- Algorithms Training Time Comparison -->
                    <section class="section">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card sameheight-item" data-exclude="xs">
                                    <div class="card-header card-header-sm bordered">
                                        <div class="header-block">
                                            <h3 class="title">Training Time Comparison</h3> </div>
                                        <ul class="nav nav-tabs pull-right" role="tablist">
                                            <li class="nav-item"> <a class="nav-link active" href="#training_1k" role="tab" data-toggle="tab">1k Training</a> </li>
                                            <li class="nav-item"> <a class="nav-link" href="#training_10k" role="tab" data-toggle="tab">10kTraining</a> </li>
                                            <li class="nav-item"> <a class="nav-link" href="#training_100k" role="tab" data-toggle="tab">100k Training</a> </li>
                                        </ul>
                                    </div>
                                    <div class="card-block">
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane fade active in" id="training_1k">
                                                <p class="title-description"> Training Time Comparison Across 7 Algorithms Using 1k Tweets </p>
                                                <canvas id="training-bar-chart-onek"></canvas>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="training_10k">
                                                <p class="title-description"> Training Time Comparison Across 7 Algorithms Using 10k Tweets </p>
                                                <canvas id="training-bar-chart-tenk"></canvas>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="training_100k">
                                                <p class="title-description"> Training Time Comparison Across 7 Algorithms Using 100k Tweets </p>
                                                <canvas id="training-bar-chart-hundredk"></canvas>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                    <section class="section">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-block">
                                        <div class="card-title-block">
                                             <h3 class="title">By clicking the following button, you can conbine the detection results of all the algorithms.</h3> 
                                        </div>
                                        <section class="section">
                                            <asp:Button ID="resultConbined" CssClass="btn btn-primary btn-lg" runat="server" Text="Conbine Detection Result" OnClick="resultConbined_Click" />&nbsp;
                                        </section>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </article>
            </form>
            <script>     
                // Pie Chart Area //
                var spam = $("#numOfSpams").text(); // Red
                var nonSpam = $("#numOfNonSpams").text(); // Blue
                var undetected = $("#numOfUndetected").text(); // Yellow
                // For a pie chart
                new Chart(document.getElementById("spam-non-spam-pie-chart"), {
                    type: 'pie',
                    data: {
                        labels: [
                            "Spam",
                            "Non-spam",
                            "Undetected"
                        ],
                        datasets: [
                            {
                                data: [spam, nonSpam, undetected],
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
                    //options: options,
                    animation: {
                        animateScale: true
                    }
                });
                // Pie Chart Area //

                // Line Chart Area //
                var pullOne = $("#pullHistoryOne").text(); // 
                var pullTwo = $("#pullHistoryTwo").text(); // 
                var pullThree = $("#pullHistoryThree").text(); // 
                var pullFour = $("#pullHistoryFour").text(); //
                var pullFive = $("#pullHistoryFive").text(); //

                var totalNumOne = $("#TotalNumOne").text();
                var totalNumTwo = $("#TotalNumTwo").text();
                var totalNumThree = $("#TotalNumThree").text();
                var totalNumFour = $("#TotalNumFour").text();
                var totalNumFive = $("#TotalNumFive").text();

                new Chart(document.getElementById("data-pulling-history-line-chart"), {
                    type: 'line',
                    data: {
                        labels: [
                            pullOne,
                            pullTwo,
                            pullThree,
                            pullFour,
                            pullFive
                        ],
                        datasets: [
                            {
                                label: "Pulling Data History",
                                fill: true,
                                lineTension: 0.1,
                                backgroundColor: "rgba(75,192,192,0.4)",
                                borderColor: "rgba(75,192,192,1)",
                                borderCapStyle: 'butt',
                                borderDash: [],
                                borderDashOffset: 0.0,
                                borderJoinStyle: 'miter',
                                pointBorderColor: "rgba(75,192,192,1)",
                                pointBackgroundColor: "#fff",
                                pointBorderWidth: 1,
                                pointHoverRadius: 5,
                                pointHoverBackgroundColor: "rgba(75,192,192,1)",
                                pointHoverBorderColor: "rgba(220,220,220,1)",
                                pointHoverBorderWidth: 2,
                                pointRadius: 1,
                                pointHitRadius: 20,
                                data: [totalNumOne, totalNumTwo, totalNumThree, totalNumFour, totalNumFive],
                                spanGaps: false,
                            }],
                        borderWidth: 1,
                    },
                    //options: options,
                    animation: {
                        animateScale: true
                    }
                });
                // Line Chart Area //

                // Training Time Comparison Bar Chart 1k//
                var knn_1k = $("#knn1kTrainingTime").text(); // 
                var kknn_1k = $("#kknn1kTrainingTime").text(); // 
                var gbm_1k = $("#gbm1kTrainingTime").text(); // 
                var lg_1k = $("#lg1kTrainingTime").text(); // 
                var rf_1k = $("#rf1kTrainingTime").text(); // 
                var nb_1k = $("#nb1kTrainingTime").text(); // 
                var nnet_1k = $("#nnet1kTrainingTime").text(); // 
                // For a bar chart
                new Chart(document.getElementById("training-bar-chart-onek"), {
                    type: 'bar',
                    data: {
                        labels: [
                            "kNN",
                            "kkNN",
                            "Gradient Boosting Model (GBM)",
                            "Logistic Regression",
                            "Random Forest",
                            "Naive Bayes",
                            "Neural Network"
                        ],
                        datasets: [
                            {
                                label: "Algorithms Training Time Comparison (Seconds)",
                                data: [knn_1k, kknn_1k, gbm_1k, lg_1k, rf_1k, nb_1k, nnet_1k],
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.7)',
                                    'rgba(54, 162, 235, 0.7)',
                                    'rgba(255, 206, 86, 0.7)',
                                    'rgba(75, 192, 192, 0.7)',
                                    'rgba(153, 102, 255, 0.7)',
                                    'rgba(255, 159, 64, 0.7)',
                                    'rgba(205, 109, 14, 0.7)'
                                ],
                                hoverBackgroundColor: [
                                    'rgba(255,99,132,1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)',
                                    'rgba(205, 109, 14, 1)'
                                ]
                            }],
                        borderWidth: 1,
                    },
                    //options: options,
                    animation: {
                        animateScale: true
                    }
                });
                // Training Time Comparison Bar Chart 10k//

                // Training Time Comparison Bar Chart 1k//
                var knn_10k = $("#knn10kTrainingTime").text(); // 
                var kknn_10k = $("#kknn10kTrainingTime").text(); // 
                var gbm_10k = $("#gbm10kTrainingTime").text(); // 
                var lg_10k = $("#lg10kTrainingTime").text(); // 
                var rf_10k = $("#rf10kTrainingTime").text(); // 
                var nb_10k = $("#nb10kTrainingTime").text(); // 
                var nnet_10k = $("#nnet10kTrainingTime").text(); // 
                // For a bar chart
                new Chart(document.getElementById("training-bar-chart-tenk"), {
                    type: 'bar',
                    data: {
                        labels: [
                            "kNN",
                            "kkNN",
                            "Gradient Boosting Model (GBM)",
                            "Logistic Regression",
                            "Random Forest",
                            "Naive Bayes",
                            "Neural Network"
                        ],
                        datasets: [
                            {
                                label: "Algorithms Training Time Comparison (Seconds)",
                                data: [knn_10k, kknn_10k, gbm_10k, lg_10k, rf_10k, nb_10k, nnet_10k],
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.7)',
                                    'rgba(54, 162, 235, 0.7)',
                                    'rgba(255, 206, 86, 0.7)',
                                    'rgba(75, 192, 192, 0.7)',
                                    'rgba(153, 102, 255, 0.7)',
                                    'rgba(255, 159, 64, 0.7)',
                                    'rgba(205, 109, 14, 0.7)'
                                ],
                                hoverBackgroundColor: [
                                    'rgba(255,99,132,1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)',
                                    'rgba(205, 109, 14, 1)'
                                ]
                            }],
                        borderWidth: 1,
                    },
                    //options: options,
                    animation: {
                        animateScale: true
                    }
                });
                // Training Time Comparison Bar Chart 10k//

                // Training Time Comparison Bar Chart 100k//
                var knn_100k = $("#knn100kTrainingTime").text(); // 
                var kknn_100k = $("#kknn100kTrainingTime").text(); // 
                var gbm_100k = $("#gbm100kTrainingTime").text(); // 
                var lg_100k = $("#lg100kTrainingTime").text(); // 
                var rf_100k = $("#rf100kTrainingTime").text(); // 
                var nb_100k = $("#nb100kTrainingTime").text(); // 
                var nnet_100k = $("#nnet100kTrainingTime").text(); // 
                // For a bar chart
                new Chart(document.getElementById("training-bar-chart-hundredk"), {
                    type: 'bar',
                    data: {
                        labels: [
                            "kNN",
                            "kkNN",
                            "Gradient Boosting Model (GBM)",
                            "Logistic Regression",
                            "Random Forest",
                            "Naive Bayes",
                            "Neural Network"
                        ],
                        datasets: [
                            {
                                label: "Algorithms Training Time Comparison (Seconds)",
                                data: [knn_100k, kknn_100k, gbm_100k, lg_100k, rf_100k, nb_100k, nnet_100k],
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.7)',
                                    'rgba(54, 162, 235, 0.7)',
                                    'rgba(255, 206, 86, 0.7)',
                                    'rgba(75, 192, 192, 0.7)',
                                    'rgba(153, 102, 255, 0.7)',
                                    'rgba(255, 159, 64, 0.7)',
                                    'rgba(205, 109, 14, 0.7)'
                                ],
                                hoverBackgroundColor: [
                                    'rgba(255,99,132,1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)',
                                    'rgba(205, 109, 14, 1)'
                                ]
                            }],
                        borderWidth: 1,
                    },
                    //options: options,
                    animation: {
                        animateScale: true
                    }
                });
                // Training Time Comparison Bar Chart 100k//               
            </script>
            <!-- #include file="./Shared/BottomReference.html" -->
</body>
</html>
