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
    public partial class Principal : System.Web.UI.MasterPage
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Session[Session.SessionID + "listaArticulos"] = listaArticulos;
            List<Articulo> listaFiltrada;
            try
            {
                if (txtBusqueda.Text == "")
                {
                    listaFiltrada = lista;
                }
                else
                {
                    listaFiltrada = lista.FindAll(slot => slot.Codigo.ToLower().Contains(txtBusqueda.Text.ToLower()) || slot.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) || slot.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()) || slot.Marca.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()) || slot.Categoria.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()) || slot.Precio.ToString().ToLower().Contains(txtBusqueda.Text.ToLower()));

                }
                dgvArticulo.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}