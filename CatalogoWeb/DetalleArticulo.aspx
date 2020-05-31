<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="CatalogoWeb.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-sm">
                <div class="card" style="width: 50%">
                    <img src="<% = articulo.ImagenURL %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <div class="container" style="background-color: ghostwhite; background-clip: border-box; text-align: center">
                            <h2 class="card-title"><% = articulo.Nombre %></h2>
                            <h4 class="card-title">Categoria: <% = articulo.Categoria %></h4>
                            <h4 class="card-title">Marca: <% = articulo.Marca %></h4>
                        <div class="container" style="background-color:#fff200; background-clip: border-box; text-align: center">
                            <h4 class="card-title">Precio: $<% = articulo.Precio %></h4>
                        </div>
                        </div>
                        <div class="container" style="background-color: ghostwhite; background-clip: border-box;>
                            <p class="card-text">Descripcion: </br> <% = articulo.Descripcion %></p>
                        </div>
                        <a class="btn btn-info btn-lg btn-block" href="CatalogoArticulos.aspx">Volver al catalogo</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
