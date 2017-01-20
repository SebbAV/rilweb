
using RIL.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ril.objetos.usuario;
using System.Globalization;
using System.Threading;
using ril.objetos;
using ril.estatic;
using ril.conexion;

/// <summary>
/// Summary description for Citas
/// </summary>
namespace RIL.clases
{
    public class Citas
    {

        public Citas()
        {

        }
        /// <summary>
        /// Metodo para Consultar cita pendientes
        /// fecha actual en adelante
        /// </summary>
        /// <param name="Cita"></param>
        /// <returns></returns>
        public List<Cita> ConsultarCitaPendienteUsuarioOnLoad(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            Cita cita;
            List<Cita> citas = new List<Cita>();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                con.PrepararProcedimiento("dbo.pa_sel_Citas", _Parametros);
                DataTable dt = con.EjecutarTable();
                DateTime date;
                if (dt.Rows.Count == 0)
                {
                    cita = new Cita();
                    cita.Estado = Respuesta.Error;
                    cita.Identificador = 0;
                    cita.NombrePaciente = ".";
                    cita.PaternoPaciente = ".";
                    cita.MaternoPaciente = ".";
                    cita.Aparato = ".";
                    cita.FechaPlan = ".";
                    cita.Hora = ".";
                    cita.NombreUsuario = ".";
                    citas.Add(cita);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cita = new Cita();

                    cita.Estado = Respuesta.Valido;
                    cita.Identificador = long.Parse(dt.Rows[i]["cita_id"].ToString());
                    cita.NombrePaciente = dt.Rows[i]["Nombre"].ToString();
                    cita.PaternoPaciente = dt.Rows[i]["Paterno"].ToString();
                    cita.MaternoPaciente = dt.Rows[i]["Materno"].ToString();
                    cita.Aparato = dt.Rows[i]["Aparato"].ToString();
                    date = (DateTime)dt.Rows[i]["cita_fechaPlan"];
                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    cita.FechaPlan = date.ToShortDateString();
                    cita.Hora = dt.Rows[i]["Hora"].ToString();
                    cita.NombreUsuario = dt.Rows[i]["Registrador"].ToString();


                    citas.Add(cita);
                }
                return citas;
            }
            catch (Exception ex)
            {
                throw ex;
                //Al comprobar funcionalidad descomentar para mostrar alerta al Usuario
                /*cita = new Cita();
                cita.Estado = Respuesta.Error;
                citas.Add(cita);*/

            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }

        }
        /// <summary>
        /// Metodo para consultar citas pendientes
        /// fecha actual en adelante
        /// </summary>
        /// <param name="Cita"></param>
        /// <returns></returns>
        public List<Cita> ConsultarCitaPendienteUsuarioOnCheck(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            Cita cita;
            List<Cita> citas = new List<Cita>();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                con.PrepararProcedimiento("dbo.pa_sel_CitasAll", _Parametros);
                DataTable dt = con.EjecutarTable();
                DateTime date;
                if (dt.Rows.Count == 0)
                {
                    cita = new Cita();
                    cita.Estado = Respuesta.Error;
                    cita.Identificador = 0;
                    cita.NombrePaciente = ".";
                    cita.PaternoPaciente = ".";
                    cita.MaternoPaciente = ".";
                    cita.Aparato = ".";
                    cita.FechaPlan = ".";
                    cita.Hora = ".";
                    cita.NombreUsuario = ".";
                    citas.Add(cita);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cita = new Cita();

                    cita.Estado = Respuesta.Valido;
                    cita.Identificador = long.Parse(dt.Rows[i]["cita_id"].ToString());
                    cita.NombrePaciente = dt.Rows[i]["Nombre"].ToString();
                    cita.PaternoPaciente = dt.Rows[i]["Paterno"].ToString();
                    cita.MaternoPaciente = dt.Rows[i]["Materno"].ToString();
                    cita.Aparato = dt.Rows[i]["Aparato"].ToString();
                    date = (DateTime)dt.Rows[i]["cita_fechaPlan"];
                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    cita.FechaPlan = date.ToShortDateString();
                    cita.Hora = dt.Rows[i]["Hora"].ToString();
                    cita.NombreUsuario = dt.Rows[i]["Registrador"].ToString();


                    citas.Add(cita);
                }
                return citas;
            }
            catch (Exception ex)
            {
                throw ex;
                //Al comprobar funcionalidad descomentar para mostrar alerta al Usuario
                /*cita = new Cita();
                cita.Estado = Respuesta.Error;
                citas.Add(cita);*/

            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }

        }
        /// <summary>
        /// Metodo para ver citas anteriores
        /// </summary>
        /// <param name="Cita"></param>
        /// <returns></returns>
        public List<Cita> ConsultarCitaPendienteUsuarioOnCheckA(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            Cita cita;
            List<Cita> citas = new List<Cita>();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                con.PrepararProcedimiento("dbo.pa_sel_CitasAnt", _Parametros);
                DataTable dt = con.EjecutarTable();
                DateTime date;
                if (dt.Rows.Count == 0)
                {
                    cita = new Cita();
                    cita.Estado = Respuesta.Error;
                    cita.Identificador = 0;
                    cita.NombrePaciente = ".";
                    cita.PaternoPaciente = ".";
                    cita.MaternoPaciente = ".";
                    cita.Aparato = ".";
                    cita.FechaPlan = ".";
                    cita.Hora = ".";
                    cita.NombreUsuario = ".";
                    citas.Add(cita);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cita = new Cita();

                    cita.Estado = Respuesta.Valido;
                    cita.Identificador = long.Parse(dt.Rows[i]["cita_id"].ToString());
                    cita.NombrePaciente = dt.Rows[i]["Nombre"].ToString();
                    cita.PaternoPaciente = dt.Rows[i]["Paterno"].ToString();
                    cita.MaternoPaciente = dt.Rows[i]["Materno"].ToString();
                    cita.Aparato = dt.Rows[i]["Aparato"].ToString();
                    date = (DateTime)dt.Rows[i]["cita_fechaPlan"];
                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    cita.FechaPlan = date.ToShortDateString();
                    cita.Hora = dt.Rows[i]["Hora"].ToString();
                    cita.NombreUsuario = dt.Rows[i]["Registrador"].ToString();


                    citas.Add(cita);
                }
                return citas;
            }
            catch (Exception ex)
            {
                throw ex;
                //Al comprobar funcionalidad descomentar para mostrar alerta al Usuario
                /*cita = new Cita();
                cita.Estado = Respuesta.Error;
                citas.Add(cita);*/

            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }

        }
        /// <summary>
        /// Metodo para consultar cita por fecha
        /// se llena fecha planeada a objeto cita
        /// </summary>
        /// <param name="Cita"></param>
        /// <returns></returns>
        public List<Cita> ConsultarCitaPendienteUsuarioFecha(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            Cita cita;
            List<Cita> citas = new List<Cita>();
            DateTime date;
            try
            {
                DateTime dateF = DateTime.Parse(Cita.FechaPlan);
                int day = dateF.Day;
                int month = dateF.Month;
                int year = dateF.Year;
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Fecha", year + "-" + day + "-" + month));
                con.PrepararProcedimiento("dbo.pa_sel_CitasFecha", _Parametros);
                DataTable dt = con.EjecutarTable();
                if (dt.Rows.Count == 0)
                {
                    cita = new Cita();
                    cita.Estado = Respuesta.Error;
                    cita.Identificador = 0;
                    cita.NombrePaciente = ".";
                    cita.PaternoPaciente = ".";
                    cita.MaternoPaciente = ".";
                    cita.Aparato = ".";
                    cita.FechaPlan = ".";
                    cita.Hora = ".";
                    cita.NombreUsuario = ".";
                    citas.Add(cita);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cita = new Cita();

                    cita.Estado = Respuesta.Valido;
                    cita.Identificador = long.Parse(dt.Rows[i]["cita_id"].ToString());
                    cita.NombrePaciente = dt.Rows[i]["Nombre"].ToString();
                    cita.PaternoPaciente = dt.Rows[i]["Paterno"].ToString();
                    cita.MaternoPaciente = dt.Rows[i]["Materno"].ToString();
                    cita.Aparato = dt.Rows[i]["Aparato"].ToString();
                    date = (DateTime)dt.Rows[i]["cita_fechaPlan"];
                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    cita.FechaPlan = date.ToShortDateString();
                    cita.Hora = dt.Rows[i]["Hora"].ToString();
                    cita.NombreUsuario = dt.Rows[i]["Registrador"].ToString();


                    citas.Add(cita);
                }
                return citas;
            }
            catch (Exception ex)
            {
                throw ex;
                //Al comprobar funcionalidad descomentar para mostrar alerta al Usuario
                /*cita = new Cita();
                cita.Estado = Respuesta.Error;
                citas.Add(cita);*/

            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }

        }
        /// <summary>
        /// Metodo para consultar citas pendiente paciente
        /// </summary>
        /// <param name="Cita"></param>
        /// <returns></returns>
        public List<Cita> ConsultarCitaPendientesPaciente(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            Cita cita;
            List<Cita> citas = new List<Cita>();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@ID", Cita.IdentificadorRegistro));
                con.PrepararProcedimiento("dbo.pa_sel_CitasPaciente", _Parametros);
                DataTable dt = con.EjecutarTable();
                DateTime date;
                if (dt.Rows.Count == 0)
                {
                    cita = new Cita();
                    cita.Estado = Respuesta.Error;
                    cita.Identificador = 0;
                    cita.Aparato = ".";
                    cita.FechaPlan = ".";
                    cita.Hora = ".";
                    citas.Add(cita);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cita = new Cita();

                    cita.Estado = Respuesta.Valido;
                    cita.Identificador = long.Parse(dt.Rows[i]["cita_id"].ToString());
                    cita.Aparato = dt.Rows[i]["aparato_descripcion"].ToString();
                    date = (DateTime)dt.Rows[i]["cita_fechaPlan"];
                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    cita.FechaPlan = date.ToShortDateString();
                    cita.Hora = dt.Rows[i]["hora_hora"].ToString();



                    citas.Add(cita);
                }
                return citas;
            }
            catch (Exception ex)
            {
                throw ex;
                //Al comprobar funcionalidad descomentar para mostrar alerta al Usuario
                /*cita = new Cita();
                cita.Estado = Respuesta.Error;
                citas.Add(cita);*/

            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }

        }
        /// <summary>
        /// Metodo para obtener horas
        /// se basa en idAparato y fecha
        /// </summary>
        /// <param name="Cita"></param>
        /// <returns></returns>
        public List<Cita> ConsultarHoras(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            Cita cita;
            List<Cita> citas = new List<Cita>();

            try
            {
                DateTime date = DateTime.Parse(Cita.FechaPlan);
                int day = date.Day;
                int month = date.Month;
                int year = date.Year;
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Fecha", year + "-" + day + "-" + month));
                _Parametros.Add(new SqlParameter("@IdAparato", Cita.IdentificadorAparato));
                con.PrepararProcedimiento("dbo.pa_sel_AgendaCitas", _Parametros);
                DataTable dt = con.EjecutarTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cita = new Cita();
                    cita.Estado = Respuesta.Valido;
                    cita.Identificador = long.Parse(dt.Rows[i]["hora_id"].ToString());
                    cita.Hora = dt.Rows[i]["hora_hora"].ToString();
                    cita.EstadoHora = int.Parse(dt.Rows[i]["estado"].ToString());
                    citas.Add(cita);
                }

                return citas;
            }
            catch (Exception ex)
            {
                cita = new Cita();
                cita.Estado = Respuesta.Error;
                citas.Add(cita);
                return citas;
            }
            finally
            {
                con.Desconectar();
                con.Dispose();
            }

        }
        /// <summary>
        /// Metodo para insertar cita 
        /// se manda el id de empleado para el reporte
        /// </summary>
        /// <param name="Cita"></param>
        public void InsertCitaUsuario(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            try
            {
                DateTime date = DateTime.Parse(Cita.FechaPlan);
                int day = date.Day;
                int month = date.Month;
                int year = date.Year;
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@IdUsuario", Cita.IdentificadorRegistro));
                _Parametros.Add(new SqlParameter("@IdPaciente", Cita.IdentificadorPaciente));
                _Parametros.Add(new SqlParameter("@IdAparato", Cita.IdentificadorAparato));
                _Parametros.Add(new SqlParameter("@Fecha", year + "-" + day + "-" + month));
                _Parametros.Add(new SqlParameter("@IdHora", Cita.IdentificadorHora));
                con.PrepararProcedimiento("dbo.pa_ins_AgendarCita", _Parametros);
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
        /// <summary>
        /// Metodo para insertar cita paciente
        /// se utiliza cookie de credencial para reporte
        /// </summary>
        /// <param name="Cita"></param>
        public void InsertCitaPaciente(Cita Cita)
        {
            SqlConexion con = new SqlConexion();

            try
            {
                DateTime date = DateTime.Parse(Cita.FechaPlan);
                int day = date.Day;
                int month = date.Month;
                int year = date.Year;
                string fecha = year + "-" + month + "-" + day;
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@IdUsuario", Cita.IdentificadorRegistro));
                _Parametros.Add(new SqlParameter("@IdAparato", Cita.IdentificadorAparato));
                _Parametros.Add(new SqlParameter("@Fecha", year + "-" + day + "-" + month));
                _Parametros.Add(new SqlParameter("@IdHora", Cita.IdentificadorHora));
                con.PrepararProcedimiento("dbo.pa_ins_CitaPaciente", _Parametros);
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
        /// <summary>
        /// Metodo para actualizar cita 
        /// </summary>
        /// <param name="Cita"></param>
        public void UpdateCitaUsuario(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            try
            {
                DateTime date = DateTime.Parse(Cita.FechaPlan);
                int day = date.Day;
                int month = date.Month;
                int year = date.Year;
                CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@IdUsuario", Cita.IdentificadorRegistro));
                _Parametros.Add(new SqlParameter("@IdCita", Cita.Identificador));
                _Parametros.Add(new SqlParameter("@IdAparato", Cita.IdentificadorAparato));
                _Parametros.Add(new SqlParameter("@Fecha", year + "-" + day + "-" + month));
                _Parametros.Add(new SqlParameter("@IdHora", Cita.IdentificadorHora));
                con.PrepararProcedimiento("dbo.pa_upd_Cita", _Parametros);
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
        /// <summary>
        /// Metodo para eliminar cita
        /// </summary>
        /// <param name="Cita"></param>
        public void DeleteCita(Cita Cita)
        {
            SqlConexion con = new SqlConexion();
            try
            {
                con.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@IdCita", Cita.Identificador));
                con.PrepararProcedimiento("dbo.pa_del_Cita", _Parametros);
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
namespace RIL.objetos
{
    public class Cita
    {
        public Respuesta Estado { get; set; }
        public long Identificador { get; set; }
        public long IdentificadorPaciente { get; set; }
        public long IdentificadorRegistro { get; set; }
        public long IdentificadorHora { get; set; }
        public int IdentificadorAparato { get; set; }
        public string NombrePaciente { get; set; }
        public string PaternoPaciente { get; set; }
        public string MaternoPaciente { get; set; }
        public string NombreUsuario { get; set; }
        public string FechaPlan { get; set; }
        public string FechaRegistro { get; set; }
        public string Aparato { get; set; }
        public string Hora { get; set; }
        public int EstadoHora { get; set; }
    }
}