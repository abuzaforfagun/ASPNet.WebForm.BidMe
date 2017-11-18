<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div class="banner-section">
        <div class="container">
            <div class="banner-grids">
                <div class="col-md-6 banner-grid">
                    <h2><asp:Label runat="server" ID="lblBannerTitle" /></h2>
                    <p><asp:Label runat ="server" ID="lblDescription" /></p>
                    
                    <a runat="server" id="anchorBannerProductLink" href="single.aspx?id="  class="button">bid now </a>
                </div>
                <div class="col-md-6 banner-grid1">
                    <img runat="server" id="imgBanner" src="images/p2.png" class="img-responsive" alt="" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="banner-bottom">
        <div class="gallery-cursual">
            <!--requried-jsfiles-for owl-->
            <script src="js/owl.carousel.js"></script>
            <script>
                $(document).ready(function () {
                    $("#owl-demo").owlCarousel({
                        items: 3,
                        lazyLoad: true,
                        autoPlay: true,
                        pagination: false,
                    });
                });
            </script>
            <!--requried-jsfiles-for owl -->

            <!--sreen-gallery-cursual-->
        </div>
    </div>
    <div class="gallery">
        <div class="container">
            <h3>Recent Listings</h3>
            <div class="gallery-grids">
                
                <asp:Label runat="server" id="lblRecentListingContainer" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

