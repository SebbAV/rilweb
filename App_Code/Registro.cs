using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ril.estatic;
using ril.conexion;
using ril.objetos.paciente;
using ril.objetos;

/// <summary>
/// Summary description for Registro
/// </summary>
namespace issc311.clases
{

    public class Register
    {
        public Register()
        {

        }
        public Register(string Nombre, string Nick, string Pwd)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Nombre", Nombre));
                _Parametros.Add(new SqlParameter("@Nick", Nick));
                _Parametros.Add(new SqlParameter("@Pwd", Pwd));
                sql.PrepararProcedimiento("dbo.InsertarCredencial", _Parametros);
                sql.EjecutarProcedimiento();
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
        public void RegistrarUsuario(PacienteP pac, Credencial cred)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Nombre", pac.Nombre));
                _Parametros.Add(new SqlParameter("@Paterno", pac.Paterno));
                _Parametros.Add(new SqlParameter("@Materno", pac.Materno));
                _Parametros.Add(new SqlParameter("@Nick", cred.Nick));
                _Parametros.Add(new SqlParameter("@Pwd", cred.Password));
                _Parametros.Add(new SqlParameter("@Correo", cred.Correo));
                sql.PrepararProcedimiento("dbo.pa_ins_RegistrarUsuario", _Parametros);
                sql.EjecutarProcedimiento();
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