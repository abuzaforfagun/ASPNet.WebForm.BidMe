<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Single.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content0" ContentPlaceHolderID="placeHolderHeader" runat="server">
    <script src="js/imagezoom.js"></script>

						<!-- FlexSlider -->
https://cdnjs.cloudflare.com/ajax/libs/flexslider/2.5.0/jquery.flexslider.js
<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />

<script>
    // Can also be used with $(document).ready()
    $(window).load(function () {
        $('.flexslider').flexslider({
            animation: "slide",
            controlNav: "thumbnails"
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <asp:Label runat="server" ID="lblDate" />
    <div class="col-md-4 single-grid">		
		<div class="flexslider">
			<ul class="slides">
				<li runat="server" id="liItemImage" >
					<div class="thumb-image"> <img runat="server" Id="imgItem" src="images/si.jpg" data-imagezoom="true" class="img-responsive"> </div>
				</li>
				
			</ul>
		</div>
	</div>	
	<div class="col-md-4 single-grid simpleCart_shelfItem">		
		<h3><asp:Label runat="server" ID="lblTitle" /></h3>
			<p><asp:Label runat="server" ID="lblDescription" /></p>
								
				<ul class="size">
					<h3>Asking Price</h3>
					<h5 class="item_price">£ <asp:Label runat="server" ID="lblAskingPrice" /></h5>
				</ul>
                <ul class="size">
					<h3>Total Bid(s)</h3>
					<h5 class="item_price"><asp:Label runat="server" ID="lblTotalBid" /></h5>
				</ul>
                <ul class="size">
					<h3>Deadline</h3>
					<h5 class="item_price"><asp:Label runat="server" ID="lblLastDate" /></h5>
				</ul>


			<div runat="server" id="divForLoggedInuser">

                <p class="qty"> Your Budget :  </p><asp:TextBox runat="server" ID="txtYourBudget" min="1"  class="form-control input-small" />
				<div class="btn_form">
                    <asp:Button runat="server" ID="btnBidNow" Text="Bid Now" OnClick="btnBidNow_Click" CssClass="add-cart item_add" />
					
				</div>
			</div>

            <div runat="server" id="divForAlreadyBid">
                <ul class="size">
					<h3>Your Bid</h3>
					<h5 class="item_price">£ <asp:Label runat="server" ID="lblYourBid" /></h5>
				</ul>
                
			</div>

            <div runat="server" id="divDeadline">
                <p class="warning"><b>Deadline already reached.</b></p>
			</div>
            <hr />
			<div runat="server" id="divForGuest">
                <p>Please <a href ="login.aspx" >login</a> to bid</p>
			</div>

            
			<div class="tag">
				<p>Category : <a href="#"> <asp:Label runat="server" ID="lblCategory" /> </a></p>
				<p>Listing Code : <a href="#"> <asp:Label runat="server" ID="lblListingCode" /> </a></p>
			</div>
	</div>
	<div class="clearfix"> </div>
</asp:Content>

