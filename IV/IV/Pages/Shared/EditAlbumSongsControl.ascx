<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAlbumSongsControl.ascx.cs" Inherits="IV.Pages.Shared.EditAlbumSongsControl" ViewStateMode="Disabled" %>

<asp:ListView ID="SongListView" runat="server" ItemType="IV.Model.Song" DataKeyNames="SongID"
    SelectMethod="SongListView_GetData" InsertItemPosition="LastItem" InsertMethod="SongListView_InsertItem"
    DeleteMethod="SongListView_DeleteItem" UpdateMethod="SongListView_UpdateItem">
    <LayoutTemplate>
        <table>
        <tr>
            <td>Number</td>
            <td>Name</td>
            <td>Length</td>
        </tr>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: Item.Number %>" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%# Item.Name %>" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: Item.LengthMinutes %>" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">Delete</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <InsertItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: BindItem.Number %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%# BindItem.Name %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: BindItem.LengthMinutes %>"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert">Add</asp:LinkButton>
            </td>
        </tr>
    </InsertItemTemplate>
    <EditItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: Item.Number %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%# Item.Name %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: Item.LengthMinutes %>"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update">Save</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </td>
        </tr>
    </EditItemTemplate>
</asp:ListView>