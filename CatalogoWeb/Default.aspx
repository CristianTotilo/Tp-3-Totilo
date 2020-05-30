<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>DEFAULT</h1>
    <asp:Label Text="Desplegable de Articulo" runat="server" />
    <asp:DropDownList runat="server" ID="ddlArticulo"></asp:DropDownList>
    <asp:Button Text="Seleccionar Articulo" ID="btnSeleccionar" runat="server" onClick="btnSeleccionar_Click" />
    <asp:Label Text="nada seleccionado" ID="lblSeleccion" runat="server" />
</asp:Content>
