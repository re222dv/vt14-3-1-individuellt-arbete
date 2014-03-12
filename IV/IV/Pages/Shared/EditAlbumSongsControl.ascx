<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAlbumSongsControl.ascx.cs" Inherits="IV.Pages.Shared.EditAlbumSongsControl" ViewStateMode="Disabled" %>

<asp:ListView ID="SongListView" runat="server" ItemType="IV.Model.Song" DataKeyNames="SongID"
    SelectMethod="SongListView_GetData" InsertItemPosition="LastItem" InsertMethod="SongListView_InsertItem"
    DeleteMethod="SongListView_DeleteItem" UpdateMethod="SongListView_UpdateItem">
    <LayoutTemplate>
        <table id="songs">
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>Length</th>
                <th></th>
                <th></th>
            </tr>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: Item.Number %>" Enabled="false" MaxLength="2" Columns="2" />
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%# Item.Name %>" Enabled="false" MaxLength="30" Columns="30" />
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: Item.LengthMinutes %>" Enabled="false" MaxLength="4" Columns="4" />
            </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('Do you realy want to remove this song?');">Delete</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <InsertItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: BindItem.Number %>" MaxLength="2" Columns="2" />
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%# BindItem.Name %>" MaxLength="30" Columns="30" />
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: BindItem.LengthMinutes %>" MaxLength="4" Columns="4" />
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert">Add</asp:LinkButton>
            </td>
            <td></td>
        </tr>
    </InsertItemTemplate>
    <EditItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: Item.Number %>" MaxLength="2" Columns="2" />
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%# Item.Name %>" MaxLength="30" Columns="30" />
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: Item.LengthMinutes %>" MaxLength="4" Columns="4" />
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