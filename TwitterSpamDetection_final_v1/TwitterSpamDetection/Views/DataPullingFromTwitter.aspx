<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataPullingFromTwitter.aspx.cs" Inherits="TwitterSpamDetection.Views.DataPullingFromTwitter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head runat="server">
    <title>Twitter Spam Detection System -- Pull Data</title>
    <!-- #include file="./Shared/TopReference.html" -->
</head>
<body>
    <div class="main-wrapper">
        <div class="app" id="app">
            <form id="dataPulling_form" runat="server">
                <!-- Main Header -->
                <cuc:MainTop ID="ucTop" runat="server" />
                <div class="sidebar-overlay" id="sidebar-overlay"></div>
                <article class="content dashboard-page">
                    <div class="title-block">
                        <h1 class="title">Pull Data From Twitter</h1>
                        <p class="title-description">Get tweets from your twitter account </p>
                    </div>
                    <section class="section">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-block">
                                        <div class="card-title-block">
                                             <h3 class="title">By clicking the following button, you can pull the latest 200 tweets from your timeline.</h3> 
                                        </div>
                                        <section class="section">
                                            <asp:Button ID="DataPulling" CssClass="btn btn-primary btn-lg" runat="server" Text="Pull Data" OnClick="DataPulling_Click" />&nbsp;
                                            <asp:Button ID="ViewPulledData" CssClass="btn btn-primary btn-lg" runat="server" Text="View Data" OnClick="ViewData_Click" />
                                            <br />
                                            <asp:Label ID="DataPullingIndication" runat="server" Text=""></asp:Label>
                                        </section>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </article>
            </form>
            <!-- #include file="./Shared/BottomReference.html" -->
</body>
</html>
