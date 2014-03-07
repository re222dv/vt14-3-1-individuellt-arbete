<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewAlbum.aspx.cs" Inherits="IV.Pages.AlbumPages.NewAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:FormView ID="FormView" runat="server" DataKeyNames="AlbumID" ItemType="IV.Model.Album" DefaultMode="Insert"
        InsertMethod="InsertAlbum">
        <InsertItemTemplate>
            <h1>New Album</h1>
            Name <asp:TextBox ID="TextBox1" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
            Released <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Text='<%#: BindItem.Released %>'></asp:TextBox>
            Picture <asp:FileUpload ID="PicUpload" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Save" CommandName="Insert" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
