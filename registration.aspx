<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div class="main-1">
		<div class="container">
			<div class="register">
		  	  <div class="has-error">
                    <asp:Label runat="server" ID="lblErrors" ForeColor="Red" />
		  	  </div>
				 <div class="register-top-grid">
					<h3>PERSONAL INFORMATION</h3>
					 <div class="wow fadeInLeft" data-wow-delay="0.4s">
						<span>Name<label>*</label></span>
                         <asp:TextBox runat="server" ID="txtName" placeholder="Name" />
						
					 </div>
					 <div class="wow fadeInRight" data-wow-delay="0.4s">
						<span>Email<label>*</label></span>
                         <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" />
						
					 </div>
					 
                     <div class="wow fadeInRight" data-wow-delay="0.4s">
						 <span>Location</span>
						 <asp:TextBox runat="server" ID="txtLocation" placeholder="Location (Optional)" />
					 </div>
					 <div class="clearfix"> </div>
                       
					   <a class="news-letter" href="#">
						 <label class="checkbox"><asp:CheckBox runat="server" ID="chkSeller" /><i> </i>Sign Up as Seller</label>
					   </a>
					 </div>
				     <div class="register-bottom-grid">
						    <h3>LOGIN INFORMATION</h3>
							 <div class="wow fadeInLeft" data-wow-delay="0.4s">
								<span>Password<label>*</label></span>
								<asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
							 </div>
							 
					 </div>
				
				<div class="clearfix"> </div>
				<div class="register-but">
				   <asp:Button runat="server" ID="btnRegistrations" OnClick="btnRegistrations_Click" Text="Submit" CssClass="acount-btn "/>
					   
					<div class="clearfix"> </div>
				   
				</div>
		   </div>
		 </div>
	</div>
</asp:Content>

