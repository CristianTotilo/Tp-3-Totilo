<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CatalogoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4 style="text-align: center;"><%=MensajeCarritoVacio()%></h4>

    <div class="container">
        <asp:Repeater runat="server" ID="repetidorCarrito">
            <ItemTemplate>
                <div class="card">
                    <img src="<%#Eval("Articulo.imagenUrl") %>" class="card-img-top" style="display: block; height: 200px; width: 200px; margin-left: auto; margin-right: auto;" alt="<%#Eval("articulo.Nombre")%>">
                    <div class="card-body">
                        <h5 class="card-title" style="text-align: center;"><%#Eval("Articulo.Nombre")%></h5>
                        <p class="card-text" style="text-align: center;"><%#Eval("Articulo.Descripcion")%></p>
                        <p class="card-text" style="text-align: center; font-size: large;"><%#Eval("Cantidad")%> x $<%#Convert.ToDouble(Eval("articulo.Precio"))%></p>
                        <p class="card-text" style="text-align: center; font-size: large;">Total: <strong>$<%#Convert.ToDouble(Eval("Articulo.Precio"))*Convert.ToInt32(Eval("Cantidad"))%></strong></p>
                        <div class="container" style="text-align: center; padding: 5px;">
                            <div class="row" style="display: inline-block">
                                
                                <a href="Carrito.aspx?eliminar=<%#Eval("ID")%>" class="btn btn-danger">Eliminar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="container" style="background-color:gold; background-clip: border-box; text-align: center ; border-style:solid;">
        <h1 class="h2" style="text-align: center; font-weight: 600;"><%= ContarCarrito()%> Articulos &nbsp;| &nbsp; TOTAL: $<%= SubtotalCarrito()%></h1>
    </div>
    </br>
    <div>
    <h1<a class="btn btn-success btn-lg btn-block" href="Carrito.aspx?comprar=<%#Eval("ID")%>" >Comprar</a></h1>
         </div>
    <div>
    <h1><a class="btn btn-info btn-lg btn-block" href="CatalogoArticulos.aspx">Volver al Catalogo de articulos</a></h1>

    </div>
</asp:Content>
