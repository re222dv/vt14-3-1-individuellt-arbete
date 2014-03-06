<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ArtistDelete.aspx.cs" Inherits="IV.Pages.ArtistPages.ArtistDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        <asp:FormView ID="ArtistFormView" runat="server" ItemType="IV.Model.Artist" DataKeyNames="ArtistID"
                      SelectMethod="ArtistFormView_GetItem">
        <ItemTemplate>
            <p>Do you realy want to delete the artist '<%#: Item.Name %>'?<br />
                <strong>Warning! This will also delete all albums and all songs by this artist.</strong>
            </p>
            <asp:LinkButton runat="server" OnClick="Delete">Yes</asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>No</asp:HyperLink>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
