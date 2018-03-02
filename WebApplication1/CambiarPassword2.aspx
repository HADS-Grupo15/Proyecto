<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarPassword2.aspx.vb" Inherits="WebApplication1.PassChange2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <br /><br /><br />
    <div style="text-align:center">  
    <h2 style="color:Highlight">CAMBIAR CONTRASEÑA</h2>
    <form id="formPassChange2" runat="server" ><br /><br />
        <asp:Label ID="lblCOd" runat="server" Text="Código de validación:" style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtCod" runat="server" Width="186px" style="text-align:center;border-color:Highlight;border-right:none;border-left:none;border-top:none"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCod" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><br />
        <br />
        <asp:Label ID="lblPassw" runat="server" Text="Nueva Contraseña: " style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtPassw" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassw" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><br />        
        <asp:Label ID="lblPassw2" runat="server" Text="Repetir contraseña: " style="font-size:larger;"></asp:Label><br /><br />
        <asp:TextBox ID="txtPassw2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassw2" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><br /><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassw" ControlToValidate="txtPassw2" ErrorMessage="Las contraseñas introducidas no coinciden" SetFocusOnError="true"></asp:CompareValidator>
        <br /><br />           
        <asp:Button ID="submit" runat="server" Text="Aceptar" Width="120px" style="border-radius:3px" BackColor="#0099FF" BorderColor="#0033CC" BorderStyle="Double" ForeColor="White" Height="35px"/><br /><br />
        </form>
        <p>
            <asp:Label runat="server" ID="ans" Text="Query sin ejecutar aun"></asp:Label>
        </p>
    <div>
        <asp:HyperLink ID="hyperPass" runat="server">¿No has recibido ningun código?</asp:HyperLink><br /><br />
        <asp:HyperLink ID="hyperRegister" runat="server">¿Aún no te has registrado?</asp:HyperLink><br />
    </div>
   </div>
</body>
</html>
