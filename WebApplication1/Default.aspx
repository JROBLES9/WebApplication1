<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <asp:TextBox ID="TextBoxCodigo" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBoxDescripcion" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBoxMarca" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBoxExistencia" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:Label ID="LabelEstado" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:FileUpload ID="FileUploadImagen" runat="server" />
    <br />

</asp:Content>
