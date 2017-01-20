using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ril.objetos.paciente;
using ril.estatic;
using System.Configuration;
using ril.conexion;
using ril.objetos;

/// <summary>
/// Summary description for ConsultaPaciente
/// </summary>
/// 
public class PacientesJava
{
    public List<PacienteJ> consultarPaciente(PacienteJ paciente)
    {
        SqlConexion sql = new SqlConexion();
        sql.Conectar(RilStatic.ReturnConnectionString());
        List<SqlParameter> _Parametros = new List<SqlParameter>();
        _Parametros.Add(new SqlParameter("@Nombre", paciente.Nombre));
        sql.PrepararProcedimiento("dbo.pa_sel_PacienteJAVA", _Parametros);
        List<PacienteJ> lstPaciente = new List<PacienteJ>();
        PacienteJ pac = null;
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
                pac = new PacienteJ()
                {
                    Identificador = 0,
                    Nombre = "no existe",
                    Paterno = "no existe",
                    Materno = "no existe",
                    Telefono = "no existe",
                    Domicilio = "no existe",
                    CodigoPostal = "no existe",
                    RFC = "no existe",
                    FechaNacimiento = "00/00/0000",
                    Correo = "no existe",
                    Fotografia = "no existe"
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
                    pac = new PacienteJ()
                    {
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
                        Fotografia = dt.Rows[i]["Fotografia"].ToString()
                    };
                    lstPaciente.Add(pac);
                }
            }
        }
        catch (Exception e)
        {
            pac = new PacienteJ()
            {
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

    public Respuesta modificarPaciente(PacienteJ PacienteJ)
    {
        SqlConexion sql = new SqlConexion();
        try
        {
            DateTime fechaNacimiento = DateTime.Parse(PacienteJ.FechaNacimiento);
            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@ID", PacienteJ.Identificador));
            _Parametros.Add(new SqlParameter("@Nombre", PacienteJ.Nombre));
            _Parametros.Add(new SqlParameter("@Paterno", PacienteJ.Paterno));
            _Parametros.Add(new SqlParameter("@Materno", PacienteJ.Materno));
            _Parametros.Add(new SqlParameter("@Telefono", PacienteJ.Telefono));
            _Parametros.Add(new SqlParameter("@FechaNacimiento", fechaNacimiento));
            _Parametros.Add(new SqlParameter("@Domicilio", PacienteJ.Domicilio));
            _Parametros.Add(new SqlParameter("@CodigoPostal", PacienteJ.CodigoPostal));
            _Parametros.Add(new SqlParameter("@RFC", PacienteJ.RFC));
            _Parametros.Add(new SqlParameter("@Fotografia", PacienteJ.Fotografia));
            _Parametros.Add(new SqlParameter("@Correo", PacienteJ.Correo));
            _Parametros.Add(new SqlParameter("@Estatus", PacienteJ.Estatus));
            sql.PrepararProcedimiento("dbo.pa_upd_PacienteJAVA", _Parametros);
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
    public Respuesta eliminarPaciente(PacienteJ PacienteJ)
    {
        SqlConexion sql = new SqlConexion();
        try
        {
            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            _Parametros.Add(new SqlParameter("@ID", PacienteJ.Identificador));
            sql.PrepararProcedimiento("dbo.pa_del_PacienteJAVA", _Parametros);
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
    public Respuesta Registrar(PacienteJ PacienteJ)
    {
        SqlConexion sql = new SqlConexion();
        try
        {
            sql.Conectar(RilStatic.ReturnConnectionString());
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            DateTime fechaNacimiento = DateTime.Parse(PacienteJ.FechaNacimiento);
            _Parametros.Add(new SqlParameter("@Nombre", PacienteJ.Nombre));
            _Parametros.Add(new SqlParameter("@Paterno", PacienteJ.Paterno));
            _Parametros.Add(new SqlParameter("@Domicilio", PacienteJ.Domicilio));
            _Parametros.Add(new SqlParameter("@Materno", PacienteJ.Materno));
            _Parametros.Add(new SqlParameter("@Telefono", PacienteJ.Telefono));
            _Parametros.Add(new SqlParameter("@Rfc", PacienteJ.RFC));
            _Parametros.Add(new SqlParameter("@Cp", PacienteJ.CodigoPostal));
            _Parametros.Add(new SqlParameter("@FechaNacimiento", fechaNacimiento));
            _Parametros.Add(new SqlParameter("@Fotografia", PacienteJ.Fotografia));
            _Parametros.Add(new SqlParameter("@Correo", PacienteJ.Correo));
            _Parametros.Add(new SqlParameter("@Estatus", PacienteJ.Estatus));
            sql.PrepararProcedimiento("dbo.pa_ins_PacienteJAVA", _Parametros);
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

    public List<PacienteJ> ConsultarTodo()
    {
        List<PacienteJ> pacientes = new List<PacienteJ>();
        PacienteJ pac = new PacienteJ();
        string cadena = ConfigurationManager.ConnectionStrings["ServidorBD"].ConnectionString;
        SqlConexion sql = new SqlConexion();
        List<SqlParameter> lstParametros = new List<SqlParameter>();

        try
        {
            sql.Conectar(cadena);
            sql.PrepararProcedimiento("dbo.pa_sel_PacienteAllJAVA", lstParametros);
            DataTable dt = sql.EjecutarTable();

            foreach (DataRow row in dt.Rows)
            {
                pac = new PacienteJ();

                pac.Identificador = long.Parse(row["idPaciente"].ToString());
                pac.Nombre = row["Nombre"].ToString();
                pac.Paterno = row["Paterno"].ToString();
                pac.Materno = row["Materno"].ToString();
                pac.FechaNacimiento = row["FechaNacimiento"].ToString();
                pac.Domicilio = row["Domicilio"].ToString();
                pac.RFC = row["RFC"].ToString();
                pac.Estatus = int.Parse(row["Estatus"].ToString());
                pac.Telefono = row["Telefono"].ToString();
                pac.Fotografia = row["Fotografia"].ToString();
                pac.CodigoPostal = row["CodigoPostal"].ToString();
                pac.Correo = row["Correo"].ToString();
                pacientes.Add(pac);
            }
        }
        catch (Exception ex)
        {
            pacientes = null;
        }


        sql.Desconectar();
        sql.Dispose();

        return pacientes;
    }

    public List<PacienteJ> consultarEliminados()
    {
        List<PacienteJ> pacientes = new List<PacienteJ>();
        PacienteJ pac = new PacienteJ();
        string cadena = ConfigurationManager.ConnectionStrings["ServidorBD"].ConnectionString;
        SqlConexion sql = new SqlConexion();
        List<SqlParameter> lstParametros = new List<SqlParameter>();

        try
        {
            sql.Conectar(cadena);
            sql.PrepararProcedimiento("dbo.pa_sel_PacienteEliminadosJAVA", lstParametros);
            DataTable dt = sql.EjecutarTable();

            foreach (DataRow row in dt.Rows)
            {
                pac = new PacienteJ();

                pac.Identificador = long.Parse(row["idPaciente"].ToString());
                pac.Nombre = row["Nombre"].ToString();
                pac.Paterno = row["Paterno"].ToString();
                pac.Materno = row["Materno"].ToString();
                pac.FechaNacimiento = row["FechaNacimiento"].ToString();
                pac.Domicilio = row["Domicilio"].ToString();
                pac.RFC = row["RFC"].ToString();
                pac.Estatus = int.Parse(row["Estatus"].ToString());
                pac.Telefono = row["Telefono"].ToString();
                pac.Fotografia = row["Fotografia"].ToString();
                pac.CodigoPostal = row["CodigoPostal"].ToString();
                pac.Correo = row["Correo"].ToString();
                pacientes.Add(pac);
            }
        }
        catch (Exception ex)
        {
            pacientes = null;
        }


        sql.Desconectar();
        sql.Dispose();

        return pacientes;
    }
}
namespace ril.objetos.paciente
{
    public class PacienteJ
    {
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
        //public Respuesta Estado { get; set; }
        public string Fotografia { get; set; }
        public int Estatus { get; set; }
    }

}


