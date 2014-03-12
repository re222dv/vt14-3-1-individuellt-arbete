<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewAlbum.aspx.cs" Inherits="IV.Pages.AlbumPages.NewAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="FormView" runat="server" DataKeyNames="AlbumID" ItemType="IV.Model.Album" DefaultMode="Insert"
        InsertMethod="InsertAlbum" RenderOuterTable="False">
        <InsertItemTemplate>
            <div id="artistEdit">
                <div>
                    <span>Name</span> <asp:TextBox ID="TextBox1" runat="server" Text='<%#: BindItem.Name %>' MaxLength="35" Columns="35"/>
                </div>
                <div>
                    <span>Released</span> <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Text='<%#: BindItem.Released %>' MaxLength="10" Columns="10" />
                </div>
                <div>
                    <span>Picture</span> <asp:FileUpload ID="PicUpload" runat="server" />
                </div>
            </div>
            
            <div id="controls">
                <asp:LinkButton runat="server" CommandName="Insert">Save</asp:LinkButton>
                <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Page.RouteData.Values["artistId"]}) %>'>Cancel</asp:HyperLink>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
