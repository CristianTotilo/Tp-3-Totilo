<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CatalogoArticulos.aspx.cs" Inherits="CatalogoWeb.CatalogoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="CatalogoArticulos" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="background-image: url(https://wallpaperaccess.com/full/2482231.jpg)">

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
