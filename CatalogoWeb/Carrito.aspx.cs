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
            if (!IsPostBack)
            {
                if (idArticulo != null)
                {

                    AgregarAlCarrito(idArticulo);

                }

                cargarRepeater();
            }
        }
        protected void cargarRepeater()
        {
            try
            {

                carritoCompras = (CarritoCompras)Session["CarritoCompras" + Session.SessionID];
                if (carritoCompras != null)
                {
                    repetidorCarrito.DataSource = carritoCompras.listaItems;
                    repetidorCarrito.DataBind();
                }
                else
                {
                    MensajeCarritoVacio();
                }
                string ID_item = Request.QueryString["eliminar"];
                if (ID_item != null)
                {
                    carritoCompras.eliminarItem(Convert.ToInt32(ID_item));

                    Response.Redirect("Default.aspx");
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void AgregarAlCarrito(string IdArticulo)
        {

            try
            {
                if (carritoCompras.getCantidad() == 0)
                {
                    Articulo articuloParaAgregar = new Articulo();
                    articuloParaAgregar = listaArticulos.Find(articulo => articulo.ID == Convert.ToInt32(IdArticulo));
                    carritoCompras.agregarItem(articuloParaAgregar);
                    carritoCompras.CantidadItems += 1;
                    Session["CarritoCompras" + Session.SessionID] = carritoCompras;
                }
                else
                {
                    carritoCompras = (CarritoCompras)Session["CarritoCompras" + Session.SessionID];
                    Articulo articuloParaAgregar = new Articulo();
                    articuloParaAgregar = listaArticulos.Find(articulo => articulo.ID == Convert.ToInt32(IdArticulo));
                    carritoCompras.agregarItem(articuloParaAgregar);
                    carritoCompras.CantidadItems += 1;
                    Session["CarritoCompras" + Session.SessionID] = carritoCompras;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
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