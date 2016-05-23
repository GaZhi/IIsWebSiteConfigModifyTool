<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ConfigModify.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Native api SOA1.0环境配置工具</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblErrorMessage" ForeColor="Red" runat="server" Text=""></asp:Label><br/>
        <b>ReleaseInfo.config.info</b> EnvType：<asp:Label ID="lblInfoEnvType" runat="server" Text=""></asp:Label><br/>
        <b>ReleaseInfo.config.ini</b> EnvType：<asp:Label ID="lblIniEnvType" runat="server" Text=""></asp:Label><br/>

      New EnvType:<asp:TextBox ID="tbNewEnvType" runat="server"></asp:TextBox> &nbsp;&nbsp; <asp:Button ID="btnRun" runat="server" Text="Modify" OnClick="btnRun_Click" />
    </div>
        
    </form>
</body>
</html>
