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
        public List<Articulo> listaArticulos { get; set; }
        CarritoCompras carritoCompras = new CarritoCompras();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CatalogoNegocio negocio = new CatalogoNegocio();
                listaArticulos = negocio.listar();

                Session[Session.SessionID + "listaArticulos"] = listaArticulos;
                if (!IsPostBack)
                { 
                    repetidor.DataSource = listaArticulos;
                    repetidor.DataBind();
                }
                if ((CarritoCompras)Session["CarritoCompras" + Session.SessionID] != null)
                {
                    carritoCompras.ID = "carrito-" + Session.SessionID;
                    carritoCompras = (CarritoCompras)Session["CarritoCompras" + Session.SessionID];
                }
                //string idArticulo = Request.QueryString["idsum"];
                //if (idArticulo != null)
                //{
                //    AgregarAlCarrito(idArticulo);
                //}

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        //protected void AgregarAlCarrito(string IdArticulo)
        //{
        //    try
        //    {
        //        Articulo articuloParaAgregar = new Articulo();
        //        articuloParaAgregar = listaArticulos.Find(articulo => articulo.ID == Convert.ToInt32(IdArticulo));
        //        carritoCompras.agregarItem(articuloParaAgregar);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}