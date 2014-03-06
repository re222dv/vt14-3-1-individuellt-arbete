<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="IV.Pages.AlbumDetails" %>

<%@ Register Src="~/Pages/Shared/AlbumSongsControl.ascx" TagPrefix="uc" TagName="AlbumSongsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="AlbumFormView" runat="server" ItemType="IV.Model.AlbumArtist" DataKeyNames="AlbumID"
        SelectMethod="AlbumFormView_GetItem">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_250.jpg" %>' />
            <h1><%#: Item.Name %></h1>
            <h2><%#: Item.ArtistName %></h2>
            <%#: Item.Released.Year %>
            
            <uc:AlbumSongsControl ID="AlbumControl1" runat="server" AlbumID="<%#: Item.AlbumID %>" />

            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDelete", new {id = Item.AlbumID}) %>'>Delete</asp:HyperLink>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
