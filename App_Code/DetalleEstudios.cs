
using ril.conexion;
using ril.estatic;
using ril.objetos;
using ril.objetos.detEst;
using RIL.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DetalleEstudios
/// </summary>
/// 
namespace ril.clases.deEst
{
    public class DetalleEstudios
    {
        public List<DetalleEstudio_Table> ConsultaDetalles(int Tipo)
        {
            List<DetalleEstudio_Table> detalles = new List<DetalleEstudio_Table>();

            SqlConexion con = new SqlConexion();
            DetalleEstudio_Table d = new DetalleEstudio_Table();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                con.PrepararProcedimiento("dbo.pa_sel_DetallesEstudios", _Parametros);
                _Parametros.Add(new SqlParameter("@Tipo", Tipo));
                DataTableReader dt = con.EjecutarTableReader(CommandType.StoredProcedure);


                while (dt.Read())
                {
                    d = new DetalleEstudio_Table();

                    d.idDetalle = dt.GetInt64(0);
                    d.nombre = dt.GetString(1);
                    d.paterno = dt.GetString(2);
                    d.materno = dt.GetString(3);
                    d.tipoEstudio = dt.GetString(4);
                    d.nombreAparato = dt.GetString(5);
                    d.aportacion = (double)dt.GetDecimal(6);
                    d.nombreEmpleado = dt.GetString(7);
                    d.fecha = dt.GetDateTime(8).ToShortDateString();
                    d.Estado = Respuesta.Valido;

                    detalles.Add(d);
                }

            }
            catch (Exception ex)
            {
                d.Estado = Respuesta.Error;
                Console.Write(ex.Message);
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }
            return detalles;
        }

        //Trae todos los detalles de estudios buscando por fecha
        public List<DetalleEstudio_Table> ConsultaDetallesFecha(DetalleEstudio DetalleEstudio)
        {
            List<DetalleEstudio_Table> detalles = new List<DetalleEstudio_Table>();

            SqlConexion con = new SqlConexion();
            DetalleEstudio_Table d = new DetalleEstudio_Table();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();

                _Parametros.Add(new SqlParameter("@Fecha",DetalleEstudio.FechaEstudio));
                con.PrepararProcedimiento("dbo.pa_sel_buscarDetallesEstudios", _Parametros);
                DataTableReader dt = con.EjecutarTableReader(CommandType.StoredProcedure);


                while (dt.Read())
                {
                    d = new DetalleEstudio_Table();

                    d.idDetalle = dt.GetInt64(0);
                    d.nombre = dt.GetString(1);
                    d.paterno = dt.GetString(2);
                    d.materno = dt.GetString(3);
                    d.tipoEstudio = dt.GetString(4);
                    d.nombreAparato = dt.GetString(5);
                    d.aportacion = (double)dt.GetDecimal(6);
                    d.nombreEmpleado = dt.GetString(7);
                    d.fecha = dt.GetDateTime(8).ToShortDateString();
                    d.Estado = Respuesta.Valido;

                    detalles.Add(d);
                }

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
            return detalles;
        }
        public void insertarDetalleEstudios(DetalleEstudio De)
        {
            try
            {

                SqlConexion sql = new SqlConexion();
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@IdEstudio", De.idEstudio));
                _Parametros.Add(new SqlParameter("@IdPaciente", De.idPaciente));
                _Parametros.Add(new SqlParameter("@IdEmpleado", De.idEmpleado));
                _Parametros.Add(new SqlParameter("@Aporte", De.Aporte));
                sql.PrepararProcedimiento("dbo.pa_ins_DetalleEst", _Parametros);
                sql.EjecutarProcedimiento();
                sql.Dispose();
                sql.Desconectar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

namespace ril.objetos.detEst
{
    public class DetalleEstudio_Table
    {
        public long idDetalle { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string tipoEstudio { get; set; }
        public string nombreAparato { get; set; }
        public double costo { get; set; }
        public double aportacion { get; set; }
        public string nombreEmpleado { get; set; }
        public string fecha { get; set; }
        public double total { get; set; }
        public Respuesta Estado { get; set; }
    }
    public class DetalleEstudio
    {
        public long idDetalle { get; set; }
        public long idEstudio { get; set; }
        public string idPaciente { get; set; }
        public long idEmpleado { get; set; }
        public double Aporte { get; set; }
        public string FechaEstudio { get; set; }
        public string Cedula { get; set; }
        public Respuesta Estado { get; set; }

    }
}
