using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CatalogoWeb
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //private void txtArticulo_TextChanged(object sender, EventArgs e)
        //{
        //    listaArticulos = (List<Articulo>)Session[Session.SessionID + "listaArticulos"];
        //    List<Articulo> listaFiltrada;
        //    try
        //    {
        //        if (txtArticulo.Text == "")
        //        {
        //            listaFiltrada = listaArticulos;
        //        }
        //        else
        //        {
        //            listaFiltrada = listaArticulos.FindAll(slot => slot.Codigo.ToLower().Contains(txtArticulo.Text.ToLower()) || slot.Nombre.ToLower().Contains(txtArticulo.Text.ToLower()) || slot.Descripcion.ToLower().Contains(txtArticulo.Text.ToLower()) || slot.Marca.Descripcion.ToLower().Contains(txtArticulo.Text.ToLower()) || slot.Categoria.Descripcion.ToLower().Contains(txtArticulo.Text.ToLower()) || slot.Precio.ToString().ToLower().Contains(txtArticulo.Text.ToLower()));

        //        }
        //        Session[Session.SessionID + "listaArticulos"] = listaFiltrada;
        //    }
        //    catch (Exception ex)
        //    {

        //        Session.Add("Error", ex.ToString());
        //        Response.Redirect("Error.aspx");
        //    }
        //}
    }
}