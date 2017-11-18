<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div class="content">
        <div class="main-1">
            <div class="container">
                <div class="login-page">
                    <div class="account_grid">
                        <div class="col-md-6 login-left">
                            <h3>NEW CUSTOMERS</h3>
                            <p>By creating an account, you will be able to move through the bid for any project and you also can add your own listing from your seller account and more.</p>
                            <a class="acount-btn" href="registration.aspx">Create an Account</a>
                        </div>
                        <div class="col-md-6 login-right">
                            

                            <h3>REGISTERED CUSTOMERS</h3>
                            <asp:Label runat="server" ID="lblRegistrationSuccess" CssClass="success" ForeColor="Green" />
                            
                            <asp:Label runat="server" ID="lblWarning" CssClass="warning" ForeColor="Red" />
                            <p>If you have an account with us, please log in.</p>

                            <div>
                                <span>Email Address<label>*</label></span>
                                <asp:TextBox runat="server" ID="txtEmail" />
                                    
                            </div>
                            <div>
                                <span>Password<label>*</label></span>
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
                                    
                            </div>
                                <br />
                            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Login" />
                                
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

