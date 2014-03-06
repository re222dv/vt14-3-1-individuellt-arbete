<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="IV.Pages.Albums" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <asp:ListView runat="server" DataKeyNames="AlbumID"
        ItemType="IV.Model.AlbumArtist"
        SelectMethod="ListView_GetData">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_80.jpg" %>' />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                    <%# Item.Name %> <%# Item.ArtistName %>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
