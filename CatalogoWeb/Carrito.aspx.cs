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
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public CarritoCompras carritoCompras = new CarritoCompras();

        protected void Page_Load(object sender, EventArgs e)
        {

            listaArticulos = (List<Articulo>)Session[Session.SessionID + "listaArticulos"];
            string idArticulo = Request.QueryString["idsum"];
            if (idArticulo != null)
            {
                AgregarAlCarrito(idArticulo);
            }
            if (!IsPostBack)
            {
                cargarRepeater();
            }
        }
        protected void cargarRepeater()
        {
            try
            {
                //var articuloSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
                //carritoCompras = (CarritoCompras)Session["carritoCompras" + Session.SessionID];
                if (carritoCompras != null)
                {
                    repetidorCarrito.DataSource = carritoCompras.listaItems;
                    repetidorCarrito.DataBind();
                }
                //string ID_elemento = Request.QueryString["eliminar"];
                //if (ID_elemento != null)
                //{
                //    if (ID_elemento == "todo")
                //    {
                //        List<ElementoCarrito> listaVacia = new List<ElementoCarrito>();
                //        carrito.ListaDeElementos = listaVacia;
                //    }
                //    else
                //    {
                //        carrito.EliminarElemento(Convert.ToInt32(ID_elemento));
                //    }
                //    Response.Redirect("VerCarrito.aspx");
                //}

            }
            catch (Exception)
            {
                Session["Error" + Session.SessionID] = "No agregaste articulos al carrito";
                Response.Redirect("Error");
            }

        }

        protected void AgregarAlCarrito(string IdArticulo)
        {
            try
            {
                Articulo articuloParaAgregar = new Articulo();
                articuloParaAgregar = listaArticulos.Find(articulo => articulo.ID == Convert.ToInt32(IdArticulo));
                carritoCompras.agregarItem(articuloParaAgregar);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected int ContarCarrito()
        {
            if (carritoCompras == null)
                return 0;
            return carritoCompras.getCantidad();
        }
        protected double SubtotalCarrito()
        {
            if (carritoCompras == null)
                return 0;
            return carritoCompras.precioTotal();
        }
        protected string MensajeCarritoVacio()
        {
            if (ContarCarrito() == 0)
                return "No se agrego ningun articulo al carrito!";
            else
                return "";
        }
    }
}