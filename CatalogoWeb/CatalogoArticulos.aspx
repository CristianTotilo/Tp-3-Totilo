<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CatalogoArticulos.aspx.cs" Inherits="CatalogoWeb.CatalogoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="CatalogoArticulos" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="Default.aspx">Catalogo de Articulos 2020</a>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="Carrito.aspx">Carrito <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="CatalogoArticulos.aspx">Ver catalogo</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Categorias</a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <%foreach (var categoria in listaCategorias)
                            {%>
                        <a class="dropdown-item" href="CatalogoArticulos.aspx?filtroCategoria=<%= categoria.ID%>"><%= categoria.Descripcion%></a>
                        <%}%>
                    </div>
                </li>
                 <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Marcas</a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <%foreach (var marca in listaMarcas)
                            {%>
                        <a class="dropdown-item" href="CatalogoArticulos.aspx?filtroMarca=<%= marca.ID%>"><%= marca.Descripcion%></a>
                        <%}%>
                    </div>
                </li>
            </ul>
            <%-- <asp:TextBox CssClass="form-control mr-sm-2" ID="txtBuscar" runat="server"></asp:TextBox>
                <asp:Button CssClass="btn btn-outline-light my-2 my-sm-0" Font-Bold="true" ID="btnBuscar" runat="server" Text="Buscar" OnClick=" btnBuscar_Click" />--%>
            <%--<form class="form-inline my-2 my-lg-0">
                <asp:TextBox runat="server" AutoPostBack="true" ID="txtArticulo" OnTextChanged="txtArticulo_TextChanged" />
                <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Buscar">
                <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Buscar</button>
                <a href="Principal.Master">Principal.Master</a>
            </form>--%>
        </div>
    </nav>


    <div class="container-fluid" style="background-image: url(https://wallpaperaccess.com/full/2482231.jpg)">
        <h1 style="text-align:center;"><%=MensajeVacio()%> </h1>
        <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
            <asp:Repeater runat="server" ID="repetidor">
                <ItemTemplate>
                    <div class="card bg-light mb-3" style="width: 18rem; max-height: 600px; max-width: 300px;">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <h6 class="card-title">Precio: $<%#Eval("Precio")%></h6>
                        </div>
                        <div class="btn-group" role="group" aria-label="Basic example" style="align-content: center">
                            <a class="btn btn-warning" href="DetalleArticulo.aspx?idart=<%#Eval("ID")%>">Detalle</a>
                            <a class="btn btn-success" href="Carrito.aspx?idsum=<%#Eval("ID") %>">Agregar al carrito</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%-- <style>
        .oculto {
            display: none;
        }
    </style>

    <asp:GridView CssClass="table" ID="dgvArticulos" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnRowCommand="dgvArticulos_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="Opcion" ButtonType="Link" Text="Seleccionar" CommandName="Select" />
            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="PokeNombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Caracteristicas" DataField="Descripcion" />
        </Columns>
    </asp:GridView>--%>
</asp:Content>
