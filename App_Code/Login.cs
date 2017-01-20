using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;
using ril.conexion;
using ril.estatic;
/// <summary>
/// Summary description for Login
/// </summary>
namespace ril.clases
{
    public class Login
    {
        public objetos.EstadoLogin Acceso(string Nick, string Password)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Nick", Nick));
                _Parametros.Add(new SqlParameter("@Pwd", Password));
                sql.PrepararProcedimiento("dbo.pa_sel_AutenticarUsuario", _Parametros);
                DataTable _dt = sql.EjecutarTable();
                string Mensaje = string.Empty;
                DataTableReader dtr = _dt.CreateDataReader();
                while (dtr.Read())
                {
                    Mensaje = dtr[0].ToString();
                }
                objetos.EstadoLogin state = new objetos.EstadoLogin();
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(Mensaje);

                if (int.Parse(xdoc["Usuarios"]["Sesion"]["Valido"].InnerText) == 1)
                {
                    state.Estado = objetos.TiposEstado.Aceptado;
                    state.SesionInformacion = new objetos.Sesion();
                    state.SesionInformacion.Identificador = int.Parse(xdoc["Usuarios"]["Sesion"]["SesionInfo"]["sesi_id"].InnerText);
                    state.SesionInformacion.Token = xdoc["Usuarios"]["Sesion"]["SesionInfo"]["sesi_token"].InnerText;
                    state.mensaje = xdoc["Usuarios"]["Sesion"]["Mensaje"].InnerText;
                    state.SesionInformacion.IdentificadorCredencial = long.Parse(xdoc["Usuarios"]["Sesion"]["SesionInfo"]["IdUsuario"].InnerText);
                    state.Rol = int.Parse(xdoc["Usuarios"]["Usuario"]["usuario_rol"].InnerText);
                }
                else
                {
                    state.Estado = objetos.TiposEstado.NoAceptado;
                    state.mensaje = xdoc["Usuarios"]["Sesion"]["Mensaje"].InnerText;
                }
                return state;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.Desconectar();
                sql.Dispose();
            }
            
            
        }
    }
}

namespace ril.objetos
{
    public class EstadoLogin
    {
        public TiposEstado Estado { get; set; }
        public string mensaje { get; set; }
        public Sesion SesionInformacion { get; set; }
        public int Rol { get; set; }
    }

    public class EstadoSesion
    {
        public Respuesta SesionActiva { get; set; }
    }
    public enum TiposEstado : int
    {
        Nada = 0,
        Aceptado = 1,
        NoAceptado = 2
    }
    public class Sesion
    {
        public long Identificador { get; set; }
        public string Token { get; set; }
        public long IdentificadorCredencial { get; set; }
    }
    public class Credencial
    {
        public long Identificador { get; set; }
        public string Nombre { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
    }

    public enum Respuesta
    {
        Invalido = 0,
        Valido = 1,
        Error = 2
    }
}