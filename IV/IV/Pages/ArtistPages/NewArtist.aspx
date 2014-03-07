<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewArtist.aspx.cs" Inherits="IV.Pages.ArtistPages.NewArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:FormView ID="FormView" runat="server" DataKeyNames="ArtistID" ItemType="IV.Model.Artist" DefaultMode="Insert"
        InsertMethod="InsertArtist">
        <InsertItemTemplate>
            <h1>New Artist</h1>
            Name <asp:TextBox ID="TextBox1" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
            Formed <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Text='<%#: BindItem.Formed %>'></asp:TextBox>
            Description <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%#: BindItem.Description %>'></asp:TextBox>
            Picture <asp:FileUpload ID="PicUpload" runat="server" />
            <asp:Button runat="server" Text="Save" CommandName="Insert" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>