using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaRepuestoNegocio
    {
        public List<CategoriaRepuesto> Listar()
        {
            List<CategoriaRepuesto> lista = new List<CategoriaRepuesto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT * FROM CategoriasRepuesto WHERE Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    CategoriaRepuesto aux = new CategoriaRepuesto();
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(CategoriaRepuesto c)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO CategoriasRepuesto (Descripcion) VALUES (@desc)");
                datos.SetearParametro("@desc", c.Descripcion);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(CategoriaRepuesto c)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE CategoriasRepuesto SET Descripcion=@desc WHERE IdCategoria=@id");
                datos.SetearParametro("@desc", c.Descripcion);
                datos.SetearParametro("@id", c.IdCategoria);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE CategoriasRepuesto SET Activo=0 WHERE IdCategoria=@id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
