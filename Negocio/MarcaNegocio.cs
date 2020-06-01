using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> listado = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearQuery("select Id, Descripcion from MARCAS");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Marca aux = new Marca();
                    aux.ID = datos.lector.GetInt32(0);
                    aux.Descripcion = datos.lector.GetString(1);

                    listado.Add(aux);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}


