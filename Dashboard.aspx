<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div class="col-md-8 single-grid">
        <div class="col-md-12">
            <h2>You Bids for</h2>
            <table class="table table-responsive  table-hover">
                <thead>
                    <th>SL</th>
                    <th>Image</th>
                    <th>Title</th>
                    <th>Item Code</th>
                    <th>Price</th>
                    <th>Your Bid</th>
                    <th>Total Bids</th>
                    <th>Status</th>
                </thead>
                <tbody>
                    <asp:Label runat="server" ID="lblYourBidsContainer" />
                </tbody>
                <tfoot>
                    <th>SL</th>
                    <th>Image</th>
                    <th>Title</th>
                    <th>Item Code</th>
                    <th>Price</th>
                    <th>Your Bid</th>
                    <th>Total Bids</th>
                    <th>Status</th>
                </tfoot>
            </table>
        </div>
        <div class="clearfix"></div>
    </div>
</asp:Content>

