<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewAlbum.aspx.cs" Inherits="IV.Pages.AlbumPages.NewAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="FormView" runat="server" DataKeyNames="AlbumID" ItemType="IV.Model.Album" DefaultMode="Insert"
        InsertMethod="InsertAlbum" RenderOuterTable="False">
        <InsertItemTemplate>
            <div id="artistEdit">
                <div>
                    <span>Name</span> <asp:TextBox ID="Name" runat="server" Text='<%#: BindItem.Name %>' MaxLength="35" Columns="35"/>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Name is requiered" ControlToValidate="Name" Display="None" />
                </div>
                <div>
                    <span>Released</span> <asp:TextBox ID="Released" runat="server" TextMode="Date" Text='<%#: BindItem.Released %>' MaxLength="10" Columns="10" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Released is requiered" ControlToValidate="Released" Display="None" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Released is not a valid date" ControlToValidate="Released" Display="None" ValidationExpression="^\d{4}-((0[1-9])|(1[0-2]))-(([0-2]\d)|(3[01]))$" />
                </div>
                <div>
                    <span>Picture</span> <asp:FileUpload ID="PicUpload" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Picture is requiered" ControlToValidate="PicUpload" Display="None" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Picture must be a jpeg" ControlToValidate="PicUpload" Display="None" ValidationExpression="^.+\.[jJ][pP][eE]?[gG]$" />
                </div>
            </div>
            
            <div id="controls">
                <asp:LinkButton runat="server" CommandName="Insert">Save</asp:LinkButton>
                <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Page.RouteData.Values["artistId"]}) %>'>Cancel</asp:HyperLink>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
