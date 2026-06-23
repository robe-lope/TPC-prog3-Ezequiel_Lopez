using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaRepuestoNegocio
    {
        public List<MarcaRepuesto> Listar()
        {
            List<MarcaRepuesto> lista = new List<MarcaRepuesto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT * FROM MarcasRepuesto WHERE Activo = 1");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    MarcaRepuesto aux = new MarcaRepuesto();
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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

        public void Agregar(MarcaRepuesto m)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO MarcasRepuesto (Nombre) VALUES (@nombre)");
                datos.SetearParametro("@nombre", m.Nombre);
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

        public void Modificar(MarcaRepuesto m)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE MarcasRepuesto SET Nombre=@nombre WHERE IdMarca=@id");
                datos.SetearParametro("@nombre", m.Nombre);
                datos.SetearParametro("@id", m.IdMarca);
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
                datos.SetearConsulta("UPDATE MarcasRepuesto SET Activo=0 WHERE IdMarca=@id");
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
