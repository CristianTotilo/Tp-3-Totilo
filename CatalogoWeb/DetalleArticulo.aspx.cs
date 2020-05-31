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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogoNegocio negocio = new CatalogoNegocio();
            List<Articulo> lista;
            try
            {
                lista = negocio.listar();
                
                var articuloSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
                articulo = lista.Find(J => J.ID == articuloSeleccionado);
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }


        }
    }
}