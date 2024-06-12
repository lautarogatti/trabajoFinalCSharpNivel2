using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT a.Id IdArticulo, Codigo, Nombre, a.Descripcion, m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria, ImagenUrl, Precio FROM articulos AS a, marcas AS m, categorias AS c WHERE IdMarca = m.Id AND IdCategoria = c.Id");
            try
            {
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["IdArticulo"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    articulos.Add(aux);
                }
                return articulos;
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
                datos.setearConsulta("INSERT into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl,Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @UrlImagen, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        public void eliminar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE from ARTICULOS WHERE Id = @IdArticulo");
                datos.setearParametro("@IdArticulo", articulo.Id);
                datos.ejecutarAccion();
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

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", articulo.UrlImagen);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);

                datos.ejecutarAccion();
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

        public List<Articulo> filtrar(string campo, string criterio, string clave)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> listaFiltrada = new List<Articulo>();
            string consulta = "SELECT a.Id IdArticulo, Codigo, Nombre, a.Descripcion, m.Id IdMarca, m.Descripcion Marca, c.Id IdCategoria, c.Descripcion Categoria, ImagenUrl, Precio FROM articulos AS a, marcas AS m, categorias AS c WHERE IdMarca = m.Id AND IdCategoria = c.Id AND ";

            switch (campo)
            {
                case "Código":
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo LIKE '" + clave + "%'";
                            break;
                        case "Termina con":
                            consulta += "Codigo LIKE '%" + clave + "'";
                            break;
                        case "Es igual a":
                            consulta += "Codigo LIKE '" + clave + "'";
                            break;
                        case "Contiene":
                            consulta += "Codigo LIKE '%" + clave + "%'";
                            break;
                    }
                    break;

                case "Nombre":
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre LIKE '" + clave + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre LIKE '%" + clave + "'";
                            break;
                        case "Es igual a":
                            consulta += "Nombre LIKE '" + clave + "'";
                            break;
                        case "Contiene":
                            consulta += "Nombre LIKE '%" + clave + "%'";
                            break;
                    }
                    break;

                case "Descripción":
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "a.Descripcion LIKE '" + clave + "%'";
                            break;
                        case "Termina con":
                            consulta += "a.Descripcion LIKE '%" + clave + "'";
                            break;
                        case "Es igual a":
                            consulta += "a.Descripcion LIKE '" + clave + "'";
                            break;
                        case "Contiene":
                            consulta += "a.Descripcion LIKE '%" + clave + "%'";
                            break;
                    }
                    break;

                case "Marca":
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Marca LIKE '" + clave + "%'";
                            break;
                        case "Termina con":
                            consulta += "Marca LIKE '%" + clave + "'";
                            break;
                        case "Es igual a":
                            consulta += "Marca LIKE '" + clave + "'";
                            break;
                        case "Contiene":
                            consulta += "Marca LIKE '%" + clave + "%'";
                            break;
                    }
                    break;

                case "Categoría":
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Categoria LIKE '" + clave + "%'";
                            break;
                        case "Termina con":
                            consulta += "Categoria LIKE '%" + clave + "'";
                            break;
                        case "Es igual a":
                            consulta += "Categoria LIKE '" + clave + "'";
                            break;
                        case "Contiene":
                            consulta += "Categoria LIKE '%" + clave + "%'";
                            break;
                    }
                    break;

                case "Precio":
                    switch (criterio)
                    {
                        case "Menor a":
                            consulta += "Precio < '" + clave + "'";
                            break;
                        case "Mayor a":
                            consulta += "Precio > '" + clave + "'";
                            break;
                        case "Igual a":
                            consulta += "Precio = '" + clave + "'";
                            break;
                    }
                    break;
            }

            datos.setearConsulta(consulta);
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.Id = (int)datos.Lector["IdArticulo"];
                aux.Codigo = (string)datos.Lector["Codigo"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.Marca = new Marca();
                aux.Marca.Id = (int)datos.Lector["IdMarca"];
                aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                aux.Categoria = new Categoria();
                aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                aux.Precio = (decimal)datos.Lector["Precio"];

                listaFiltrada.Add(aux);
            }
            return listaFiltrada;
        }
    }
}
