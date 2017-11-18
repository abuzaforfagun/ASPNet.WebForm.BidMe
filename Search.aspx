<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHolderHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    
    <div class="gallery">
        <div class="container">
            <h2 runat="server" id="lblSearchKeywords"></h2>
            <div class="gallery-grids">
                
                <asp:Label runat="server" id="lblRecentListingContainer" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

