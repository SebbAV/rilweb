using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ril.estatic;

namespace ril.logout
{
    public class Logout
    {
        public void Desconectar(string token)
        {
            conexion.SqlConexion sql = new conexion.SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@token", token));
                sql.PrepararProcedimiento("dbo.pa_sel_CerrarSesion", _Parametros);
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
        public Logout()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
