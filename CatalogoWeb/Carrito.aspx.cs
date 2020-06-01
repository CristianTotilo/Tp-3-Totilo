using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CatalogoWeb
{
    public partial class Carrito : System.Web.UI.Page
    {
        public CarritoCompras carritoCompras = new CarritoCompras();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarRepeater();
            }
        }
        private void cargarRepeater()
        {
            try
            {

                var articuloSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);

                carritoCompras = (CarritoCompras)Session[Session.SessionID + "carritoCompras"];
                //carritoCompras.listaItems = (List<Item>)Session[Session.SessionID + "listaItems"];
                //var itemELiminar = Request.QueryString["idEliminar"];

                //if (itemELiminar != null)
                //{
                //    Item itemEliminar = carritoCompras.listaItems.Find(J => J.ID == int.Parse(itemELiminar));
                //    carritoCompras.listaItems.Remove(itemEliminar);
                //    Session[Session.SessionID + "carrito"] = carritoCompras.listaItems;
                //    repetidor.DataSource = carritoCompras.listaItems;
                //    repetidor.DataBind();

                //}
                //else
                if (Request.QueryString["idart"] != null)
                {
                    List<Articulo> listaOriginal = (List<Articulo>)Session[Session.SessionID + "listaArticulos"];
                    var artSelect = Convert.ToInt32(Request.QueryString["idart"]);
                    Articulo articulo = listaOriginal.Find(J => J.ID == artSelect);
                    carritoCompras.agregarItem(articulo);

                    if (carritoCompras.listaItems == null)
                    {
                        carritoCompras.listaItems = new List<Item>();
                    }
                    carritoCompras.agregarItem(articulo);
                    Session[Session.SessionID + "carritoCompras"] = carritoCompras;
                    repetidor.DataSource = carritoCompras;
                    repetidor.DataBind();
                }



            }
            catch (Exception)
            {
                Session["Error" + Session.SessionID] = "No agregaste articulos al carrito";
                Response.Redirect("Error");
            }
        }
    }
    //public Carrito carrito = new Carrito();
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    carrito = (Carrito)Session["Carrito" + Session.SessionID];
    //    if (carrito != null)
    //    {
    //        listaCarrito.DataSource = carrito.ListaDeElementos;
    //        listaCarrito.DataBind();
    //    }
    //    string ID_elemento = Request.QueryString["eliminar"];
    //    if (ID_elemento != null)
    //    {
    //        if (ID_elemento == "todo")
    //        {
    //            List<ElementoCarrito> listaVacia = new List<ElementoCarrito>();
    //            carrito.ListaDeElementos = listaVacia;
    //        }
    //        else
    //        {
    //            carrito.EliminarElemento(Convert.ToInt32(ID_elemento));
    //        }
    //        Response.Redirect("VerCarrito.aspx");
    //    }
    //}
    //protected int ContarCarrito()
    //{
    //    if (carrito == null)
    //        return 0;
    //    return carrito.getCantidad();
    //}
    //protected double SubtotalCarrito()
    //{
    //    if (carrito == null)
    //        return 0;
    //    return carrito.Subtotal();
    //}
}