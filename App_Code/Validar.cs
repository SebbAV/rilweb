using ril.conexion;
using ril.estatic;
using ril.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Validar
/// </summary>
public class Validar
{
    public EstadoSesion ValidarSesion(Sesion Sesion)
    {
        SqlConexion sql = new SqlConexion();
        try
        {
            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@TokenSesion", Sesion.Token));
            sql.PrepararProcedimiento("dbo.pa_sel_ValidarAccesoSesion", _Parametros);
            DataTable _dt = sql.EjecutarTable();
            string Mensaje = string.Empty;
            DataTableReader dtr = _dt.CreateDataReader();
            while (dtr.Read())
            {
                Mensaje = dtr[0].ToString();
            }
            EstadoSesion es = new EstadoSesion();
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(Mensaje);

            if (int.Parse(xdoc["Usuario"]["Validez"]["Valido"].InnerText) == 1)
            {

                es.SesionActiva = Respuesta.Valido;
            }
            else
            {
                es.SesionActiva = Respuesta.Invalido;
            }
            return es;
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