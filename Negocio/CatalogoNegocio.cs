using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class CatalogoNegocio
    {
        public List<Articulo> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> Listado = new List<Articulo>();

            try
            {
                datos.setearQuery("select A.Id,A.Codigo,A.Nombre,A.Descripcion,M.Id[IDmarca],M.Descripcion[Marca],C.Id[IDcategoria],C.Descripcion[Categoria],A.ImagenUrl,A.Precio from ARTICULOS as A left join CATEGORIAS as C on A.IdCategoria = C.Id left join MARCAS as M on A.IdMarca = M.Id");
             
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Articulo Articulo = new Articulo();
                    Marca marca = new Marca();
                    Categoria categoria = new Categoria();
                    Articulo.Marca = marca;
                    Articulo.Categoria = categoria;

                    
                    Articulo.ID = datos.lector.GetInt32(0);

                    if (!DBNull.Value.Equals(datos.lector["Codigo"])) //Tuve que hacer esta validacion porque la de !convert.IsDBNull no funciono
                        Articulo.Codigo = datos.lector.GetString(1);
                    else
                        Articulo.Codigo = "N/A";

                    if (!DBNull.Value.Equals(datos.lector["Nombre"]))
                        Articulo.Nombre = datos.lector.GetString(2);//aux.Nombre = (string)lector["Nombre"]; alternativa
                    else
                        Articulo.Nombre = "N/A";

                    if (!DBNull.Value.Equals(datos.lector["Descripcion"]))
                        Articulo.Descripcion = datos.lector.GetString(3);
                    else
                        Articulo.Descripcion = "N/A";

                    if (!DBNull.Value.Equals(datos.lector["IDmarca"]))
                        Articulo.Marca.ID = (int)datos.lector.GetInt32(4); //lector["Descripcion"].ToString(); alternativa 
                    else
                        Articulo.Marca.ID = 0;

                    if (!DBNull.Value.Equals(datos.lector["Marca"]))
                        Articulo.Marca.Descripcion = datos.lector.GetString(5); //lector["Descripcion"].ToString(); alternativa 
                    else
                        Articulo.Marca.Descripcion = "N/A";

                    if (!DBNull.Value.Equals(datos.lector["IDcategoria"]))
                        Articulo.Categoria.ID = (int)datos.lector.GetInt32(6);
                    else
                        Articulo.Categoria.ID = 0;

                    if (!DBNull.Value.Equals(datos.lector["Categoria"]))
                        Articulo.Categoria.Descripcion = datos.lector.GetString(7);
                    else
                        Articulo.Categoria.Descripcion = "N/A";

                    if (!DBNull.Value.Equals(datos.lector["ImagenUrl"]))
                        Articulo.ImagenURL = datos.lector.GetString(8);
                    else
                        Articulo.ImagenURL = "N/A";

                    if (!DBNull.Value.Equals(datos.lector["Precio"]))
                        Articulo.Precio = (decimal)datos.lector.GetDecimal(9);
                    else
                        Articulo.Precio = 0;
                       
                    Listado.Add(Articulo);

                }

                    return Listado;
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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
               
                datos.setearQuery ("insert into ARTICULOS (Codigo, Nombre, Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) Values (@Codigo,@Nombre,@Descripcion,@Marca,@Categoria,@ImagenUrl,@Precio)");
                // comando.Parameters.Clear();
                if (nuevo.Codigo == "" )
                    nuevo.Codigo = "N/A";
                datos.agregarParametro("@Codigo", nuevo.Codigo);

                if (nuevo.Nombre == "")
                    nuevo.Nombre = "N/A";
                datos.agregarParametro("@Nombre", nuevo.Nombre);

                if (nuevo.Descripcion == "")
                    nuevo.Descripcion = "N/A";
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);

                if(nuevo.Marca != null)
                    datos.agregarParametro("@Marca", nuevo.Marca.ID.ToString());
                else
                    datos.agregarParametro("@Marca", "1");//deberia haber un id marca en la DB con descripcion N/A

                if (nuevo.Categoria != null)
                    datos.agregarParametro("@Categoria", nuevo.Categoria.ID.ToString());
                else
                    datos.agregarParametro("@Categoria", "1");//deberia haber un id categoria en la DB con descripcion N/A

                if (nuevo.ImagenURL=="")
                    nuevo.ImagenURL = "N/A";
                datos.agregarParametro("@ImagenUrl", nuevo.ImagenURL);
                datos.agregarParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion ,IdMarca = @Marca,IdCategoria = @Categoria,ImagenUrl = @ImagenUrl,Precio= @Precio where Id = @Id");
                datos.agregarParametro("@Id",articulo.ID);
                datos.agregarParametro("@Codigo",articulo.Codigo);
                datos.agregarParametro("@Nombre",articulo.Nombre);
                datos.agregarParametro("@Descripcion",articulo.Descripcion);
                datos.agregarParametro("@Marca",articulo.Marca.ID.ToString());
                datos.agregarParametro("@Categoria",articulo.Categoria.ID.ToString());
                datos.agregarParametro("@ImagenUrl",articulo.ImagenURL);
                datos.agregarParametro("@Precio",articulo.Precio.ToString());
                datos.ejecutarAccion(); 

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery(" delete from ARTICULOS where id=@Id");
                datos.agregarParametro("@Id", id);
                datos.ejecutarAccion();
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
