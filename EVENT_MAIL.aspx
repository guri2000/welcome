<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EVENT_MAIL.aspx.vb" Inherits="EVENT_MAIL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="refresh" content="43200">
    <title>Autoemail</title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
     <%-- <asp:Timer runat="server" id="UpdateTimer" interval="480000" ontick="BTN1_Click" />--%>
    <asp:Button ID="BTN1" Text="SEND MAIL" runat="server" Enabled ="false" />
    
    </div>
    </form>
</body>
</html>
