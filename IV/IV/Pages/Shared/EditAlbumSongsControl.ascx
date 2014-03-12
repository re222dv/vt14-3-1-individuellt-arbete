<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAlbumSongsControl.ascx.cs" Inherits="IV.Pages.Shared.EditAlbumSongsControl" ViewStateMode="Disabled" %>

<asp:ListView ID="SongListView" runat="server" ItemType="IV.Model.Song" DataKeyNames="SongID"
    SelectMethod="SongListView_GetData" InsertItemPosition="LastItem" InsertMethod="SongListView_InsertItem"
    DeleteMethod="SongListView_DeleteItem" UpdateMethod="SongListView_UpdateItem">
    <LayoutTemplate>
        <asp:ValidationSummary validationGroup="insert" runat="server" />
        <asp:ValidationSummary validationGroup="update" runat="server" />
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
                <asp:TextBox ID="Number" runat="server" Text="<%#: BindItem.Number %>" MaxLength="2" Columns="2" validationGroup="insert" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Number is requiered" ControlToValidate="Number" Display="None" validationGroup="insert" />
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Number must be a number" ControlToValidate="Length" Display="None" ValidationExpression="^\d?\d$" validationGroup="insert" />
            </td>
            <td>
                <asp:TextBox ID="Name" runat="server" Text="<%# BindItem.Name %>" MaxLength="30" Columns="30" validationGroup="insert" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Name is requiered" ControlToValidate="Name" Display="None" validationGroup="insert" />
            </td>
            <td>
                <asp:TextBox ID="Length" runat="server" Text="<%#: BindItem.LengthMinutes %>" MaxLength="4" Columns="4" validationGroup="insert" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Length is requiered" ControlToValidate="Length" Display="None" validationGroup="insert" />
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Length must be in the format mm:ss" ControlToValidate="Length" Display="None" ValidationExpression="^\d?\d:[0-5]\d$" validationGroup="insert" />
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" validationGroup="insert">Add</asp:LinkButton>
            </td>
            <td></td>
        </tr>
    </InsertItemTemplate>
    <EditItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="Number" runat="server" Text="<%#: Item.Number %>" MaxLength="2" Columns="2" validationGroup="update" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Number is requiered" ControlToValidate="Number" Display="None" validationGroup="update" />
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Number must be a number" ControlToValidate="Length" Display="None" ValidationExpression="^\d?\d$" validationGroup="update" />
            </td>
            <td>
                <asp:TextBox ID="Name" runat="server" Text="<%# Item.Name %>" MaxLength="30" Columns="30" validationGroup="update" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Name is requiered" ControlToValidate="Name" Display="None" validationGroup="update" />
            </td>
            <td>
                <asp:TextBox ID="Length" runat="server" Text="<%#: Item.LengthMinutes %>" MaxLength="4" Columns="4" validationGroup="update" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Length is requiered" ControlToValidate="Length" Display="None" validationGroup="update" />
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Length must be in the format mm:ss" ControlToValidate="Length" Display="None" ValidationExpression="^\d?\d:[0-5]\d$" validationGroup="update" />
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" validationGroup="update">Save</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </td>
        </tr>
    </EditItemTemplate>
</asp:ListView>