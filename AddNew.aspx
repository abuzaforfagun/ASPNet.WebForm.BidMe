<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
   
    <div class="col-md-8 single-grid">
        <h2>Add New Listing</h2>
        <hr />
        <div class="form-group">
            <label>Item Code</label>
            <asp:TextBox runat="server" ID="txtItemCode" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Title</label>
            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Category</label>
            <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Price</label>
            <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Image</label>
            <asp:FileUpload runat="server" ID="uploadImage" />
        </div>

        <div class="form-group">
            <label>Description</label>
            <asp:TextBox runat="server" ID="txtDescripiton" TextMode="MultiLine" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Location</label>
            <asp:TextBox runat="server" ID="txtLocation"  CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Last Date</label>
            <asp:TextBox runat="server" ID="txtLastDate" TextMode="Date" CssClass="form-control" />
        </div>

        <asp:Button runat="server" ID="btnSaveListing" CssClass="btn btn-primary" OnClick="btnSaveListing_Click" Text="Save" />
    </div>
</asp:Content>

