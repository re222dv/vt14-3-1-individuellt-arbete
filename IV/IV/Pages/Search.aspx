<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="IV.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:TextBox ID="SearchBox" runat="server" />
    <asp:Button runat="server" Text="Search" OnClick="Search_Click" />
    
    <asp:ListView runat="server" ID="ArtistListView" DataKeyNames="ArtistID"
        ItemType="IV.Model.Artist"
        SelectMethod="ArtistListView_GetData">
        <LayoutTemplate>
            <h1>Artists</h1>
            <ul id="artists">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
            <div></div>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>
                    <div class="image" style='background-image: url(<%#: "/1dv406/re222dv/Content/Images/Artists/" + Item.ArtistID + "_240x100.jpg" %>)'></div>
                    <span><%# Item.Name %></span>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:ListView>
    
    <asp:ListView runat="server" ID="AlbumListView" DataKeyNames="AlbumID"
        ItemType="IV.Model.AlbumArtist"
        SelectMethod="AlbumListView_GetData">
        <LayoutTemplate>
            <h1>Albums</h1>
            <ul id="albums">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
            <div></div>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_270.jpg" %>' />
                    <span class="name"><%# Item.Name %></span>
                    <span class="artist"><%# Item.ArtistName %></span>
                    <span class="year"><%# Item.Released.Year %></span>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
