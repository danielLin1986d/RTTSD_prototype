<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainTop.ascx.cs" Inherits="TwitterSpamDetection.Views.Shared.MainTop" %>

<header class="header">
    <div class="header-block header-block-collapse hidden-lg-up">
        <button class="collapse-btn" id="sidebar-collapse-btn"><i class="fa fa-bars"></i></button>
    </div>
    <div class="header-block header-block-search hidden-sm-down">
        Twitter Spam Detection (TSD) System
    </div>
    <div class="header-block header-block-nav">
        <ul class="nav-profile">
            <li class="profile dropdown">
                <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                    <div class="img" style="background-image: url('../dist/images/user1.png')"></div>
                    <asp:Label CssClass="name" ID="userNamelb" runat="server"></asp:Label>
                </a>
                <div class="dropdown-menu profile-dropdown-menu" aria-labelledby="dropdownMenu1">
                    <a class="dropdown-item" href="#"><i class="fa fa-user icon"></i>Profile </a>
                    <a class="dropdown-item" href="#"><i class="fa fa-gear icon"></i>Settings </a>
                    <div class="dropdown-divider"></div>
                    <asp:LinkButton ID="LogOut" runat="server" Text="" CssClass="dropdown-item" OnClick="SignOut"><i class="fa fa-power-off icon"></i>Logout </asp:LinkButton>
                </div>
            </li>
        </ul>
    </div>
</header>
<aside class="sidebar">
    <div class="sidebar-container">
        <div class="sidebar-header">
            <div class="brand">
                <div class="logo"><span class="l l1"></span><span class="l l2"></span><span class="l l3"></span><span class="l l4"></span><span class="l l5"></span></div>
                TSD System
            </div>
        </div>
        <nav class="menu">
            <ul class="nav metismenu" id="sidebar-menu">
                <li id="first_group_menu">
                    <a href="index.aspx"><i class="fa fa-home"></i>Dashboard </a>
                </li>
                <li id="second_group_menu">
                    <a id="dataManagementLink" href="javascript:void(0);"><i class="fa fa-th-large"></i>Data Management <i class="fa arrow"></i></a>
                    <ul>
                        <li id="dataPulling"><a href="DataPullingFromTwitter.aspx">Pull Data From Twitter
                        </a></li>
                        <li id="dataDisplay"><a href="DataDisplay.aspx">Data Display
                        </a></li>
                    </ul>
                </li>
                <li id="third_group_menu">
                    <a href="javascript:void(0);"><i class="fa fa-bar-chart"></i>Model Management <i class="fa arrow"></i></a>
                    <ul>
                        <li id="modelTraiing"><a href="charts-flot.html">Model Training
                        </a></li>
                        <li id="modelManagement"><a href="charts-morris.html">Detection Model Management
                        </a></li>
                    </ul>
                </li>
                <!--
                <li>
                    <a href=""><i class="fa fa-table"></i>Tables <i class="fa arrow"></i></a>
                    <ul>
                        <li><a href="static-tables.html">Static Tables
                        </a></li>
                        <li><a href="responsive-tables.html">Responsive Tables
                        </a></li>
                    </ul>
                </li>
                <li>
                    <a href="forms.html"><i class="fa fa-pencil-square-o"></i>Forms </a>
                </li>
                <li>
                    <a href=""><i class="fa fa-desktop"></i>UI Elements <i class="fa arrow"></i></a>
                    <ul>
                        <li><a href="buttons.html">Buttons
                        </a></li>
                        <li><a href="cards.html">Cards
                        </a></li>
                        <li><a href="typography.html">Typography
                        </a></li>
                        <li><a href="icons.html">Icons
                        </a></li>
                        <li><a href="grid.html">Grid
                        </a></li>
                    </ul>
                </li>
                <li>
                    <a href=""><i class="fa fa-file-text-o"></i>Pages <i class="fa arrow"></i></a>
                    <ul>
                        <li><a href="login.html">Login
                        </a></li>
                        <li><a href="signup.html">Sign Up
                        </a></li>
                        <li><a href="reset.html">Reset
                        </a></li>
                        <li><a href="error-404.html">Error 404 App
                        </a></li>
                        <li><a href="error-404-alt.html">Error 404 Global
                        </a></li>
                        <li><a href="error-500.html">Error 500 App
                        </a></li>
                        <li><a href="error-500-alt.html">Error 500 Global
                        </a></li>
                    </ul>
                </li>
                -->
            </ul>
        </nav>
    </div>
</aside>
