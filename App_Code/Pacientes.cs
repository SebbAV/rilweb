using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ril.objetos.paciente;
using ril.conexion;
using ril.estatic;
using ril.objetos;

/// <summary>
/// Summary description for ConsultaPaciente
/// </summary>
/// 
public class Pacientes
{
    public List<PacienteP> consultarPaciente(PacienteP PacienteP)
    {
        SqlConexion sql = new SqlConexion();
        sql.Conectar(RilStatic.ReturnConnectionString());
        List<SqlParameter> _Parametros = new List<SqlParameter>();
        _Parametros.Add(new SqlParameter("@Nombre", PacienteP.Nombre));
        sql.PrepararProcedimiento("dbo.pa_sel_Paciente", _Parametros);
        List<PacienteP> lstPaciente = new List<PacienteP>();
        PacienteP pac = null;
        DateTime date = new DateTime();
        int dia;
        int mes;
        int anio;
        try
        {
            DataTable dt = sql.EjecutarTable();
            if (dt.Rows.Count <= 0)
            {
                DateTime fecha = new DateTime(01, 01, 0001);
                pac = new PacienteP()
                {
                    Identificador = 0,
                    Estado = Respuesta.Valido,
                    Nombre = "no existe",
                    Paterno = "no existe",
                    Materno = "no existe",
                    Telefono = "no existe",
                    Domicilio = "no existe",
                    CodigoPostal = "no existe",
                    RFC = "no existe",
                    FechaNacimiento = "00/00/0000",
                    Correo = "no existe",
                };


                lstPaciente.Add(pac);
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    date = (DateTime)dt.Rows[i]["FechaNacimiento"];
                    dia = date.Day;
                    mes = date.Month;
                    anio = date.Year;
                    pac = new PacienteP()
                    {
                        Estado = Respuesta.Valido,
                        Identificador = int.Parse(dt.Rows[i]["idPaciente"].ToString()),
                        Nombre = dt.Rows[i]["Nombre"].ToString(),
                        Paterno = dt.Rows[i]["Paterno"].ToString(),
                        Materno = dt.Rows[i]["Materno"].ToString(),
                        Telefono = dt.Rows[i]["Telefono"].ToString(),
                        Domicilio = dt.Rows[i]["Domicilio"].ToString(),
                        CodigoPostal = dt.Rows[i]["CodigoPostal"].ToString(),
                        RFC = dt.Rows[i]["RFC"].ToString(),
                        FechaNacimiento = anio + "-" + mes + "-" + dia,
                        Correo = dt.Rows[i]["Correo"].ToString(),
                    };
                    lstPaciente.Add(pac);
                }
            }
        }
        catch (Exception e)
        {
            pac = new PacienteP()
            {
                Estado = Respuesta.Error,
                Identificador = 0
            };
            lstPaciente.Add(pac);
        }
        finally
        {
            sql.Desconectar();
            sql.Dispose();
        }
        return lstPaciente;
    }
    public PacienteP obtenerPaciente(PacienteP PacienteP)
    {
        SqlConexion con = new SqlConexion();
        PacienteP state = new PacienteP();
        DateTime date = new DateTime();
        int dia;
        int mes;
        int anio;
        try
        {
            con.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@Correo", PacienteP.Correo));
            con.PrepararProcedimiento("dbo.pa_sel_PacienteObtenerCorreo", _Parametros);

            DataTable dt = con.EjecutarTable();
            if (dt.Rows.Count == 0)
            {
                state = new PacienteP();
                state.Estado = Respuesta.Error;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {



                date = (DateTime)dt.Rows[i]["persona_fechaNacimiento"];
                dia = date.Day;
                mes = date.Month;
                anio = date.Year;
                state = new PacienteP()
                {
                    Estado = Respuesta.Valido,
                    Identificador = int.Parse(dt.Rows[i]["paciente_id"].ToString()),
                    Nombre = dt.Rows[i]["persona_nombre"].ToString(),
                    Paterno = dt.Rows[i]["persona_paterno"].ToString(),
                    Materno = dt.Rows[i]["persona_materno"].ToString(),
                    FechaNacimiento = anio + "-" + mes + "-" + dia,
                    Telefono = dt.Rows[i]["persona_telefono"].ToString(),
                    Domicilio = dt.Rows[i]["persona_domicilio"].ToString(),
                    CodigoPostal = dt.Rows[i]["persona_cp"].ToString(),
                    RFC = dt.Rows[i]["persona_rfc"].ToString(),
                    Correo = dt.Rows[i]["usuario_correo"].ToString(),
                };

            };
            return state;


        }
        catch (Exception ex)
        {
            state.Estado = Respuesta.Error;
        }
        finally
        {
            con.Desconectar();
            con.Dispose();
        }
        return state;

    }
    public void modificarPaciente(PacienteP PacienteP)
    {
        SqlConexion sql = new SqlConexion();
        try
        {

            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@ID", PacienteP.Identificador));
            _Parametros.Add(new SqlParameter("@Nombre", PacienteP.Nombre));
            _Parametros.Add(new SqlParameter("@Paterno", PacienteP.Paterno));
            _Parametros.Add(new SqlParameter("@Materno", PacienteP.Materno));
            _Parametros.Add(new SqlParameter("@Telefono", PacienteP.Telefono));
            _Parametros.Add(new SqlParameter("@FechaNacimiento", PacienteP.FechaNacimiento));
            _Parametros.Add(new SqlParameter("@Domicilio", PacienteP.Domicilio));
            _Parametros.Add(new SqlParameter("@CodigoPostal", PacienteP.CodigoPostal));
            _Parametros.Add(new SqlParameter("@RFC", PacienteP.RFC));
            sql.PrepararProcedimiento("dbo.pa_upd_Paciente", _Parametros);
            sql.EjecutarProcedimiento();
            //   return Respuesta.Valido;
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
    public void eliminarPaciente(PacienteP PacienteP)
    {
        SqlConexion sql = new SqlConexion();
        try
        {
            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@ID", PacienteP.Identificador));
            sql.PrepararProcedimiento("dbo.pa_del_Paciente", _Parametros);
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
    public Respuesta Registrar(PacienteP PacienteP, Sesion Sesion)
    {
        SqlConexion sql = new SqlConexion();
        try
        {
            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@Nombre", PacienteP.Nombre));
            _Parametros.Add(new SqlParameter("@Paterno", PacienteP.Paterno));
            _Parametros.Add(new SqlParameter("@Domicilio", PacienteP.Domicilio));
            _Parametros.Add(new SqlParameter("@Materno", PacienteP.Materno));
            _Parametros.Add(new SqlParameter("@Telefono", PacienteP.Telefono));
            _Parametros.Add(new SqlParameter("@Rfc", PacienteP.RFC));
            _Parametros.Add(new SqlParameter("@Correo", PacienteP.Correo));
            _Parametros.Add(new SqlParameter("@Cp", PacienteP.CodigoPostal));
            _Parametros.Add(new SqlParameter("@FechaNacimiento", PacienteP.FechaNacimiento));
            sql.PrepararProcedimiento("dbo.pa_ins_Paciente", _Parametros);
            sql.EjecutarProcedimiento();
            return Respuesta.Valido;

        }
        catch (Exception ex)
        {
            return Respuesta.Error;
        }
        finally
        {
            sql.Desconectar();
            sql.Dispose();
        }
    }
}
namespace ril.objetos.paciente
{
    public class PacienteP
    {
        public Respuesta Estado { get; set; }
        public long Identificador { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string Correo { get; set; }
        public string CodigoPostal { get; set; }
        public string RFC { get; set; }
    }
}
