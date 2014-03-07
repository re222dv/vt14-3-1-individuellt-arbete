<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="IV.Pages.AlbumDetails" %>

<%@ Register Src="~/Pages/Shared/AlbumSongsControl.ascx" TagPrefix="uc" TagName="AlbumSongsControl" %>
<%@ Register Src="~/Pages/Shared/EditAlbumSongsControl.ascx" TagPrefix="uc" TagName="EditAlbumSongsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="AlbumFormView" runat="server" ItemType="IV.Model.AlbumArtist" DataKeyNames="AlbumID"
        SelectMethod="AlbumFormView_GetItem" UpdateMethod="AlbumFormView_UpdateItem">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_250.jpg" %>' />
            <h1><%#: Item.Name %></h1>
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>
                <h2><%#: Item.ArtistName %></h2>
            </asp:HyperLink>
            <%#: Item.Released.Year %>
            
            <uc:AlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" />

            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDelete", new {id = Item.AlbumID}) %>'>Delete</asp:HyperLink>
        </ItemTemplate>
        <EditItemTemplate>
            Name <asp:TextBox ID="TextBox1" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
            Released <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Text='<%# Bind("Released", "{0:yyyy-MM-dd}")%>'></asp:TextBox>
            Picture <asp:FileUpload ID="PicUpload" runat="server" />
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Save</asp:LinkButton>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>Cancel</asp:HyperLink>

            <uc:EditAlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" ArtistID="<%#: Item.ArtistID %>" />
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
