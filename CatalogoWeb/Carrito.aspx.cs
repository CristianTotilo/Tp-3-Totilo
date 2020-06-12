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
        public bool flag;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                listaArticulos = (List<Articulo>)Session[Session.SessionID + "listaArticulos"];

                if ((CarritoCompras)Session[Session.SessionID + "CarritoCompras"] == null)
                {
                    Session[Session.SessionID + "CarritoCompras"] = carritoCompras;
                    carritoCompras.ID = "carrito-" + Session.SessionID;
                    carritoCompras = (CarritoCompras)Session[Session.SessionID + "CarritoCompras"];
                }
                else
                {
                    carritoCompras = (CarritoCompras)Session[Session.SessionID + "CarritoCompras"];
                }
                string idArticulo = Request.QueryString["idsum"];
                if (!IsPostBack)
                {

                    if (carritoCompras != null)
                    {

                        if (idArticulo != null)
                        {
                            AgregarAlCarrito(idArticulo);

                        }

                    }

                    string idEliminar = Request.QueryString["eliminar"];
                    if (idEliminar != null)
                    {
                        carritoCompras.eliminarItem(Convert.ToInt32(idEliminar));
                        Session[Session.SessionID + "CarritoCompras"] = carritoCompras;
                    }

                    cargarRepeater();

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
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
                    Articulo articuloParaAgregar = new Articulo();
                    articuloParaAgregar = listaArticulos.Find(articulo => articulo.ID == Convert.ToInt32(IdArticulo));
                    carritoCompras.agregarItem(articuloParaAgregar);
                    carritoCompras.CantidadItems += 1;
                    Session["CarritoCompras" + Session.SessionID] = carritoCompras;
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