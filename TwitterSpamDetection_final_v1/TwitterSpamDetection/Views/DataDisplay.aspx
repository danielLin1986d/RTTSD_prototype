<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataDisplay.aspx.cs" Inherits="TwitterSpamDetection.Views.DataDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head runat="server">
    <title>Twitter Spam Detection System -- Data Display</title>
    <!-- #include file="./Shared/TopReference.html" -->
</head>
<body>
    <div class="main-wrapper">
        <div class="app" id="app">
            <form id="viewData_form" runat="server">
                <!-- Main Header -->
                <cuc:MainTop ID="ucTop" runat="server" />
                <div class="sidebar-overlay" id="sidebar-overlay"></div>
                <div id="divHidden" style="display: none;">
                    <asp:Label ID="lblTweetSender" runat="server"></asp:Label>
                    <asp:Label ID="lblTweetContent" runat="server"></asp:Label>
                </div>
                <article class="content dashboard-page">
                    <div class="title-block">
                        <h1 class="title">Twitter Data Display</h1>
                        <p class="title-description">View tweets from a different perspective </p>
                    </div>
                    <section class="section">
                        <table border="0" class="" width="auto">
                            <tr>
                                <td style="font-size: 16px;">
                                    <div class="admin_input_cell">
                                        Tweet Sender：
                                    </div>
                                </td>
                                <td style="padding-right: 8px;">
                                    <asp:TextBox ID="tweetSender" runat="server" CssClass="input_120"
                                        Width="150px"></asp:TextBox>
                                </td>
                                <td style="font-size: 16px;">
                                    <div class="admin_input_cell">
                                        Tweet Content：
                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox ID="tweetContent" runat="server" CssClass="input_120"
                                        Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm"
                                        OnClick="btnSearch_Click" Style="margin: 0 0 2px 9px;" Text="Search" />
                                </td>
                            </tr>
                        </table>
                    </section>
                    <section class="section">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <table class="table table-hover">
                                      <thead>
                                          <tr>
                                              <th class="hidden-xs">
                                                  NUM 
                                              </th>
                                              <th>
                                                  Created By 
                                              </th>                              
                                              <th class="hidden-xs">
                                                  Created At
                                              </th>
                                              <th>
                                                  Favorites
                                              </th>
                                              <th>
                                                  Tweet Content                          
                                                </th>
                                              <th>
                                                  Spam/Non-spam
                                              </th>
                                              <th>
                                                  <div style="margin-left:3px;">
                                                      Operation</div>
                                              </th>
                                          </tr>
                                      </thead>
                                      <asp:Repeater ID="tweetList" runat="server" OnItemDataBound="tweetList_ItemDataBound">
                                          <ItemTemplate>
                                              <tr ID="tweetListCell" runat="server" onmouseout="this.style.background='#ffffff';" onmouseover="this.style.background='#dddddd';">
                                                  <td class="hidden-xs">
                                                      <asp:Label ID="ulcNum" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                      <asp:Label ID="ulcName" runat="server"></asp:Label>
                                                  </td>
                                                  <td class="hidden-xs">
                                                      <asp:Label ID="ulcCreatedAt" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                      <asp:Label ID="ulcFavorites" runat="server"></asp:Label>
                                                  </td>
                                                                                                    <td>
                                                      <asp:Label ID="ulcContent" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                      <asp:Label ID="ulcIsSpam" runat="server"></asp:Label>
                                                  </td>
                                                  <td>
                                                      <div style="margin-left:3px;">
                                                          <asp:LinkButton ID="ulcDetail" runat="server" CssClass="btn btn-oval btn-info"  Text="Details" OnClick="ulcViewDetail_Click"></asp:LinkButton>
                                                      </div>
                                                  </td>
                                              </tr>
                                          </ItemTemplate>
                                      </asp:Repeater>
                                  </table>
                                  <div style="width: 100%;">
                                       <asp:Literal ID="Literal_tweetList" runat="server"></asp:Literal>
                                  </div>
                                  <div class="pagination" style="width: 95%; font-size:14px;">
                                        <webdiyer:AspNetPager ID="AspNetPager1" OnPageChanged="AspNetPager1_PageChanged"
                                        AlwaysShow="true" runat="server" PageSize="10" NumericButtonCount="5" ShowCustomInfoSection="Right"
                                        PagingButtonSpacing="5" HorizontalAlign="Right" SubmitButtonText="Jump To" SubmitButtonClass="inputsubmit"
                                        NumericButtonTextFormatString="[{0}]" NextPageText="Next" FirstPageText="First" CssClass="anpager"
                                        CurrentPageButtonClass="cpb" LastPageText="Last" PrevPageText="Previous">
                                    </webdiyer:AspNetPager>
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
