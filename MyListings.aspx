<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeFile="MyListings.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div class="col-md-9 single-grid">
        <h2>My Listings</h2><br />
        <table class="table table-responsive  table-hover">
            <thead>
                <th>SL</th>
                <th>Image</th>
                <th>Title</th>
                <th>Item Code</th>
                <th>Price</th>
                <th>Total Bid(s)</th>
                <th>Lowest</th>
                <th>End Date</th>
            </thead>
            <tbody>
                <asp:Label runat="server" ID="lblYourListingsContainer" />
            </tbody>
            <tfoot>
                <th>SL</th>
                <th>Image</th>
                <th>Title</th>
                <th>Item Code</th>
                <th>Price</th>
                <th>Total Bid(s)</th>
                <th>Lowest</th>
                <th>End Date</th>
            </tfoot>
        </table>
    </div>
</asp:Content>

