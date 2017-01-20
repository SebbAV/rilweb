using ril.conexion;
using ril.estatic;
using ril.objetos;
using ril.objetos.usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuarios
/// </summary>
namespace RIL.clases
{
    public class Usuarios
    {
        public Usuarios()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<Usuario> buscarTipo(int Tipo)
        {
            Usuario usr;
            List<Usuario> usuarios = new List<Usuario>();
            SqlConexion con = new SqlConexion();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Tipo", Tipo));
                con.PrepararProcedimiento("dbo.pa_sel_Usuario", _Parametros);
                DataTable dt = con.EjecutarTable();
                if (dt.Rows.Count == 0)
                {
                    usr = new Usuario()
                    {
                        Estado = Respuesta.Error,
                        Identificador = 0,
                        Nick = "No existe",
                        Password = "No existe",
                        Rol = 0,
                        Correo = "No existe",
                        Estatus = 0

                    };
                    usuarios.Add(usr);
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usr = new Usuario()
                        {
                            Estado = Respuesta.Valido,

                            Identificador = long.Parse(dt.Rows[i]["usuario_id"].ToString()),
                            Nick = dt.Rows[i]["usuario_nick"].ToString(),
                            Password = dt.Rows[i]["usuario_pwd"].ToString(),
                            Rol = int.Parse(dt.Rows[i]["usuario_rol"].ToString()),
                            Correo = dt.Rows[i]["usuario_correo"].ToString(),
                            Estatus = int.Parse(dt.Rows[i]["usuario_estatus"].ToString())
                        };
                        usuarios.Add(usr);
                    }

                }
            }
            catch (Exception ex)
            {
                usr = new Usuario();
                usr.Estado = Respuesta.Error;
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }
            return usuarios;
        }
        public Usuario BuscarUsuarioID(Usuario Usuario)
        {
            Usuario state = new Usuario();
            SqlConexion con = new SqlConexion();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@ID", Usuario.Identificador));
                con.PrepararProcedimiento("dbo.pa_sel_UsuarioID", _Parametros);
                DataTable dt = con.EjecutarTable();
                if (dt.Rows.Count == 0)
                {
                    state = new Usuario()
                    {
                        Estado = Respuesta.Error
                    };
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        state = new Usuario()
                        {
                            Estado = Respuesta.Valido,
                            Identificador = long.Parse(dt.Rows[i]["usuario_id"].ToString()),
                            Nick = dt.Rows[i]["usuario_nick"].ToString(),
                            Rol = int.Parse(dt.Rows[i]["usuario_rol"].ToString()),
                            Correo = dt.Rows[i]["usuario_correo"].ToString()
                        };
                        return state;
                    }
                }

            }
            catch (Exception ex)
            {
                state = new Usuario();
                state.Estado = Respuesta.Error;
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }
            return state;

        }
        public void ModificarUsuario(Usuario Usuario)
        {
            SqlConexion con = new SqlConexion();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@ID", Usuario.Identificador));
                _Parametros.Add(new SqlParameter("@Rol", Usuario.Rol));
                _Parametros.Add(new SqlParameter("@Correo", Usuario.Correo));
                con.PrepararProcedimiento("pa_upd_Usuario", _Parametros);
                con.EjecutarProcedimiento();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }
        }
        public void EliminarUsuario(Usuario Usuario)
        {
            SqlConexion con = new SqlConexion();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@ID", Usuario.Identificador));
                con.PrepararProcedimiento("pa_del_Usuario", _Parametros);
                con.EjecutarProcedimiento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }
        }

    }
}
namespace ril.objetos.usuario
{
    public class Usuario
    {
        public long Identificador { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public int Rol { get; set; }
        public int Estatus { get; set; }
        public Respuesta Estado { get; set; }
    }
}