<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Periodico1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="txtTema" />
        <asp:TextBox runat="server" ID="txtIcono" />
        <asp:Button Text="Guadar Tema" runat="server" ID="btnGuardarTema" OnClick="btnGuardarTema_Click" />
        <asp:Button Text="Crear Todo" runat="server" ID="btnCrearTodo" OnClick="btnCrearTodo_Click" />
    </div>
    <div>
        <asp:Button Text="Consultar Temas" runat="server" ID="btnConsultarTemas" OnClick="btnConsultarTemas_Click" />
        <asp:GridView runat="server" ID="gridTemas"></asp:GridView>
    </div>
        
    </form>
</body>
</html>
