<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CatalogoArticulos.aspx.cs" Inherits="CatalogoWeb.CatalogoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="CatalogoArticulos" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Catalogo de Articulos</h1>
    <asp:DropDownList runat="server" ID="cboArticulos" />

    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="card" style="width: 18rem; max-height:600px; max-width: 300px;">
                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre")%></h5>
                        <p class="card-text"><%#Eval("Descripcion")%></p>
                    </div>
                    <a class="btn btn-primary" href="PokemonDetail.aspx?idpkm=<%#Eval("Id")%>">Seleccionar</a>
                    <asp:Button ID="btnArgumento" CssClass="btn btn-primary" Text="Argumento to Back" CommandArgument='<%#Eval("Id")%>' CommandName="idPokemon" runat="server" OnClick="btnArgumento_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <style>
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
    </asp:GridView>



</asp:Content>
