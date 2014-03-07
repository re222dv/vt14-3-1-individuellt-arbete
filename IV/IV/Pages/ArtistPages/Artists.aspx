<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Artists.aspx.cs" Inherits="IV.Pages.Artists" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <asp:ListView runat="server" DataKeyNames="ArtistID"
        ItemType="IV.Model.Artist"
        SelectMethod="ListView_GetData">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Artists/" + Item.ArtistID + "_80x80.jpg" %>' />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>
                    <%# Item.Name %>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
