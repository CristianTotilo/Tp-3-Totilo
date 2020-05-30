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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CatalogoNegocio negocio = new CatalogoNegocio();
            try
            {
                if (!IsPostBack)
                {
                    ddlArticulo.DataSource = negocio.listar();
                    ddlArticulo.DataTextField = "Nombre";
                    ddlArticulo.DataValueField = "Id";
                    ddlArticulo.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            lblSeleccion.Text = "El id del articulo seleccionado es: " + ddlArticulo.SelectedItem.Value;
        }
    }
}
