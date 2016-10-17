<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PushNotificationCustomService.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Push Notification Custom Service</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="UriTextBox" runat="server" Width="402px"></asp:TextBox>

        <asp:Button ID="ToastButton" runat="server" Text="Toast"  />
        <asp:Button ID="TileButton" runat="server" Text="Tile"  />
        <asp:Button ID="RawButton" runat="server" Text="Raw" OnClick="RawButton_Click" />
    </div>

    </form>
</body>
</html>
