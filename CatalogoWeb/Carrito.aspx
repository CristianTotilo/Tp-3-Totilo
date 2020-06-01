<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CatalogoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <asp:Repeater runat="server" ID="repetidor">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Categoria</th>
                        <th scope="col">Accion</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td><%#Eval("item.Articulo.Nombre")%></td>
                    <td>><%#Eval("item.Articulo.Categoria")%></td>
                    <td><%--<a href="Carrito.aspx?idEliminar=<% = item.ID.ToString() %>" class="btn btn-primary">Quitar</a>--%></td>
               <%-- </tr>
            </tbody>
        </ItemTemplate>
        </table>
    </asp:Repeater>--%>

    <div class="panel panel-default">
        <asp:Repeater ID="repetidor" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Nombre</th>
                            <th>Categoria</th>
                            <th>Accion</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th><%#Eval("listaItems.ID")%></th>
                    <td>><%#Eval("listaItems.Articulo.Nombre")%></td>
                    <td>><%#Eval("listaItems.Articulo.Categoria")%></td>
                    <td><%--<a href="Carrito.aspx?idEliminar=<% = item.ID.ToString() %>" class="btn btn-primary">Quitar</a>--%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
               
            </FooterTemplate>
        </asp:Repeater>
    </div>


    <%--<div class="container">
               <div class="row">
                    <div class="col">
                        <table class="table">
                            <tr>
                                <td>Nombre</td>
                                <td>Tipo</td>
                                <td>Accion</td>
                            </tr>

                            <%foreach (var item in listaItems)
                                {
                    %>

                            <tr>
                                <td><% = item.Articulo.Nombre %></td>
                                <td><% = item.Articulo.Categoria %></td>
                                <td><a href="Carrito.aspx?idEliminar=<% = item.ID.ToString() %>" class="btn btn-primary">Quitar</a></td>
                            </tr>


                            <% } %>
                        </table>

                    </div>

                </div>
            </div>--%>
</asp:Content>
