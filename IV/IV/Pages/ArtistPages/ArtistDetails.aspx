<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="IV.Pages.ArtistDetails" %>

<%@ Register Src="~/Pages/Shared/AlbumSongsControl.ascx" TagPrefix="uc" TagName="AlbumSongsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="ArtistFormView" runat="server" ItemType="IV.Model.Artist" DataKeyNames="ArtistID"
        SelectMethod="ArtistFormView_GetItem" UpdateMethod="ArtistFormView_UpdateItem">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Artists/" + Item.ArtistID + "_250x250.jpg" %>' />
            <h1><%#: Item.Name %></h1>
            <%#: Item.Formed.ToString("yyyy") %>

            <p><%#: Item.Description %></p>

            <asp:ListView ID="AlbumListView" runat="server" ItemType="IV.Model.Album" DataKeyNames="AlbumID"
                SelectMethod="AlbumListView_GetData">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_80.jpg" %>' />
                    <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                        <h2><%#: Item.Name %></h2>
                    </asp:HyperLink>
                    <span><%#: Item.Released.Year %></span>
                    <uc:AlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" />
                </ItemTemplate>
            </asp:ListView>
            
            <asp:LinkButton runat="server" CommandName="Edit">Edit</asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDelete", new {id = Item.ArtistID}) %>'>Delete</asp:HyperLink>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Artists/" + Item.ArtistID + "_250x250.jpg" %>' />

            Name <asp:TextBox ID="TextBox1" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
            Formed <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Text='<%# Bind("Formed", "{0:yyyy-MM-dd}")%>'></asp:TextBox>
            Description <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%# BindItem.Description %>'></asp:TextBox>
            Picture <asp:FileUpload ID="PicUpload" runat="server" />
            
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumNew", new {artistId = Item.ArtistID}) %>'>Add Album</asp:HyperLink>
            <asp:ListView ID="AlbumListView" runat="server" ItemType="IV.Model.Album" DataKeyNames="AlbumID"
                SelectMethod="AlbumListView_GetData">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                        <span><%#: Item.Name %></span>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:ListView>
            
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Save</asp:LinkButton>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>Cancel</asp:HyperLink>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
