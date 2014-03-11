<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="IV.Pages.Albums" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <asp:ListView runat="server" DataKeyNames="AlbumID"
        ItemType="IV.Model.AlbumArtist"
        SelectMethod="ListView_GetData">
        <LayoutTemplate>
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
