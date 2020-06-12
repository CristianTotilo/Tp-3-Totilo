using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace CatalogoWeb
{
    public partial class CatalogoArticulos : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos = new List<Articulo>();
        CarritoCompras carritoCompras = new CarritoCompras();
        public List<Marca> listaMarcas = new List<Marca>();
        public List<Categoria> listaCategorias = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CatalogoNegocio negocio = new CatalogoNegocio();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                listaArticulos = negocio.listar();
                listaMarcas = marcaNegocio.listar();
                listaCategorias = categoriaNegocio.listar();
                Session[Session.SessionID + "listaArticulos"] = listaArticulos;

                if (!IsPostBack)
                {
                    string filtroMarca = Request.QueryString["filtroMarca"];
                    string filtroCategoria = Request.QueryString["filtroCategoria"];
                    if (filtroMarca != null)
                    {
                        FiltrarPorMarca(filtroMarca);
                    }
                    if (filtroCategoria != null)
                    {
                        FiltrarPorCategoria(filtroCategoria);
                    }
                }
                
                repetidor.DataSource = listaArticulos;
                repetidor.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void FiltrarPorMarca(string idMarca)
        {
            try
            {
                List<Articulo> articulosMarca = new List<Articulo>();
                articulosMarca = listaArticulos.FindAll(j => j.Marca.ID == Convert.ToInt32(idMarca));
                listaArticulos = articulosMarca;
                repetidor.DataSource = listaArticulos;
                repetidor.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void FiltrarPorCategoria(string idCategoria)
        {
            try
            {
                List<Articulo> articulosCategoria = new List<Articulo>();

                articulosCategoria = listaArticulos.FindAll(j => j.Categoria.ID == Convert.ToInt32(idCategoria));
                listaArticulos = articulosCategoria;
                repetidor.DataSource = listaArticulos;
                repetidor.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaFiltrada;
                if (txtBuscar.Text == "")
                    listaFiltrada = listaArticulos;
                else
                    listaFiltrada = listaArticulos.FindAll(articulo => articulo.Nombre.ToLower().Contains(txtBuscar.Text.Trim().ToLower()));

                listaArticulos = listaFiltrada;
                MensajeVacio();
                repetidor.DataSource = listaArticulos;
                repetidor.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected string MensajeVacio()
        {
            if (listaArticulos.Count() == 0)
                return "No se encontraron articulos!";
            else
                return "";
        }

    }
}