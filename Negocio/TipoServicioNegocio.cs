using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoServicioNegocio
    {
        public List<TipoServicio> Listar()
        {
            List<TipoServicio> lista = new List<TipoServicio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT * FROM TiposServicio WHERE Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoServicio aux = new TipoServicio();
                    aux.IdTipoServicio = (int)datos.Lector["IdTipoServicio"];
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

        public void Agregar(TipoServicio t)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO TiposServicio (Descripcion) VALUES (@desc)");
                datos.SetearParametro("@desc", t.Descripcion);
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

        public void Modificar(TipoServicio t)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE TiposServicio SET Descripcion=@desc WHERE IdTipoServicio=@id");
                datos.SetearParametro("@desc", t.Descripcion);
                datos.SetearParametro("@id", t.IdTipoServicio);
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
                datos.SetearConsulta("UPDATE TiposServicio SET Activo=0 WHERE IdTipoServicio=@id");
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
