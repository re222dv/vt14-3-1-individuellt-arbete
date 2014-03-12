<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewArtist.aspx.cs" Inherits="IV.Pages.ArtistPages.NewArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="FormView" runat="server" DataKeyNames="ArtistID" ItemType="IV.Model.Artist" DefaultMode="Insert"
        InsertMethod="InsertArtist" RenderOuterTable="false">
        <InsertItemTemplate>
            <div id="artistEdit">
                <div>
                    <span>Name</span> <asp:TextBox ID="Name" runat="server" Text='<%#: BindItem.Name %>' MaxLength="20" Columns="20" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Name is requiered" ControlToValidate="Name" Display="None" />
                </div>
                <div>
                    <span>Formed</span> <asp:TextBox ID="Formed" runat="server" TextMode="Date" Text='<%#: BindItem.Formed %>' MaxLength="10" Columns="10" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Formed is requiered" ControlToValidate="Formed" Display="None" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Formed is not a valid date" ControlToValidate="Formed" Display="None" ValidationExpression="^\d{4}-((0[1-9])|(1[0-2]))-(([0-2]\d)|(3[01]))$" />
                </div>
                <div>
                    <span>Picture</span> <asp:FileUpload ID="PicUpload" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Picture is requiered" ControlToValidate="PicUpload" Display="None" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Picture must be a jpeg" ControlToValidate="PicUpload" Display="None" ValidationExpression="^.+\.[jJ][pP][eE]?[gG]$" />
                </div>
                <div>
                    <span>Description</span>
                </div>
                <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Text='<%#: BindItem.Description %>' />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Description is requiered" ControlToValidate="Description" Display="None" />
            </div>
            
            <div id="controls">
                <asp:LinkButton runat="server" CommandName="Insert">Save</asp:LinkButton>
                <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("Artists") %>'>Cancel</asp:HyperLink>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>