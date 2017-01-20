using ril.conexion;
using ril.estatic;
using ril.objetos.aparatos;
using ril.objetos.estudios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Estudios
/// </summary>
namespace ril.clases.estudios
{
    public class Estudios
    {
        public void insertarEstudio(Estudio e)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                if (e.Indicacion == "" || e.Indicacion == " " || e.Indicacion == null)
                {
                    e.Indicacion = "--Sin indicaciones--";
                }
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Tipo", e.Tipo));
                _Parametros.Add(new SqlParameter("@Costo", e.Costo));
                _Parametros.Add(new SqlParameter("@Aparato", e.Aparato));
                _Parametros.Add(new SqlParameter("@Indicacion", e.Indicacion));
                sql.PrepararProcedimiento("dbo.pa_ins_Estudio", _Parametros);
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

        public void updateEstudio(Estudio e)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                if (e.Indicacion == "" || e.Indicacion == " " || e.Indicacion == null)
                {
                    e.Indicacion = "Sin indicaciones";
                }
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@EstudioId", e.Id));
                _Parametros.Add(new SqlParameter("@EstudioTipo", e.Tipo));
                _Parametros.Add(new SqlParameter("@EstudioCosto", e.Costo));
                _Parametros.Add(new SqlParameter("@Indicacion", e.Indicacion));
                sql.PrepararProcedimiento("dbo.pa_upd_Estudio", _Parametros);
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
        public void deleteEstudio(Estudio e)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@EstudioId", e.Id));
                sql.PrepararProcedimiento("dbo.pa_del_Estudio", _Parametros);
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
        public List<Estudio> selectEstudio(Aparato Aparato)
        {
            List<Estudio> ests = new List<Estudio>();
            SqlConexion sql = new SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@IdAparato", Aparato.idAparato));
                sql.PrepararProcedimiento("dbo.pa_sel_Estudio", _Parametros);
                DataTableReader dt = sql.EjecutarTableReader(CommandType.StoredProcedure);
                Estudio e = new Estudio();
                while (dt.Read())
                {
                    e = new Estudio();
                    e.Id = dt.GetInt64(0);
                    e.Tipo = dt.GetString(1);
                    e.Costo = (double)dt.GetDecimal(2);
                    e.Estado = objetos.Respuesta.Valido;
                    ests.Add(e);

                }


                return ests;
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
        public Estudio selectEstudioCosto(Estudio Estudio)
        {
            SqlConexion sql = new SqlConexion();
            try
            {

                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@idEstudio", Estudio.Id));
                sql.PrepararProcedimiento("dbo.pa_sel_EstudioCosto", _Parametros);
                DataTableReader dt = sql.EjecutarTableReader(CommandType.StoredProcedure);
                Estudio e = new Estudio();
                while (dt.Read())
                {
                    e = new Estudio();
                    e.Costo = (double)dt.GetDecimal(0);
                    e.Estado = objetos.Respuesta.Valido;

                }

                return e;
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
        public List<Estudio> ConsultaTodos()
        {
            List<Estudio> estudios = new List<Estudio>();

            SqlConexion con = new SqlConexion();
            Estudio e = new Estudio();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                con.PrepararProcedimiento("dbo.pa_sel_consultarEstudios", _Parametros);
                DataTableReader dt = con.EjecutarTableReader(CommandType.StoredProcedure);


                while (dt.Read())
                {
                    e = new Estudio();


                    e.Id = dt.GetInt64(0);
                    e.Tipo = dt.GetString(1);
                    e.Costo = (double)dt.GetDecimal(2);
                    e.idAparato = dt.GetInt64(3);
                    e.nombreAparato = dt.GetString(4);
                    e.Estado = objetos.Respuesta.Valido;

                    estudios.Add(e);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }
            return estudios;

        }
    }
}
namespace ril.objetos.estudios
{
    public class Estudio
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public double Costo { get; set; }
        public string Indicacion { get; set; }
        public long Aparato { get; set; }
        public long idAparato { get; set; }
        public string nombreAparato { get; set; }
        public Respuesta Estado { get; set; }
    }
}
