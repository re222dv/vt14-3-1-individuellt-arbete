<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Artists.aspx.cs" Inherits="IV.Pages.Artists" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <asp:ListView runat="server" DataKeyNames="ArtistID"
        ItemType="IV.Model.Artist"
        SelectMethod="ListView_GetData">
        <LayoutTemplate>
            <ul id="artists">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>
                    <div class="image" style='background-image: url(<%#: "../Content/Images/Artists/" + Item.ArtistID + ".jpg" %>)'></div>
                    <span><%# Item.Name %></span>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
