using ril.conexion;
using ril.estatic;
using ril.objetos.aparatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Aparatos
/// </summary>
namespace ril.clases.aparatos
{
    public class Aparatos
    {
        public void insertarAparato(Aparato A)
        {
            SqlConexion sql = new SqlConexion();
            try
            {              
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@Descripcion", A.Descripcion));
                _Parametros.Add(new SqlParameter("@Modelo", A.Modelo));
                _Parametros.Add(new SqlParameter("@Observaciones", A.Observaciones));
                sql.PrepararProcedimiento("dbo.pa_ins_Aparato", _Parametros);
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
        public void updateAparato(Aparato A)
        {
            SqlConexion sql = new SqlConexion();
            try
            {              
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@AparatoId", A.idAparato));
                _Parametros.Add(new SqlParameter("@AparatoDesco", A.Descripcion));
                _Parametros.Add(new SqlParameter("@Observaciones", A.Observaciones));
                _Parametros.Add(new SqlParameter("@Modelo", A.Modelo));
                sql.PrepararProcedimiento("dbo.pa_upd_Aparato", _Parametros);
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
        public void deleteAparato(Aparato A)
        {
            SqlConexion sql = new SqlConexion();
            try
            {
                
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                _Parametros.Add(new SqlParameter("@AparatoId", A.idAparato));
                sql.PrepararProcedimiento("dbo.pa_del_Aparato", _Parametros);
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
        public List<Aparato> selectAparato()
        {
            List<Aparato> aps = new List<Aparato>();
            SqlConexion sql = new SqlConexion();
            try
            {
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                sql.PrepararProcedimiento("dbo.pa_sel_Aparato", _Parametros);
                DataTableReader dt = sql.EjecutarTableReader(CommandType.StoredProcedure);
                Aparato a = new Aparato();
                while (dt.Read())
                {
                    a = new Aparato();
                    a.idAparato = dt.GetInt64(0);
                    a.Descripcion = dt.GetString(1);
                    a.Estado = objetos.Respuesta.Valido;
                    aps.Add(a);
                }

                
                return aps;
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
        public List<Aparato> selectAparatoTabla()
        {
            List<Aparato> aps = new List<Aparato>();
            SqlConexion sql = new SqlConexion();
            try
            {               
                sql.Conectar(RilStatic.ReturnConnectionString());
                List<SqlParameter> _Parametros = new List<SqlParameter>();
                sql.PrepararProcedimiento("dbo.pa_sel_Aparato", _Parametros);
                DataTableReader dt = sql.EjecutarTableReader(CommandType.StoredProcedure);
                Aparato a = new Aparato();
                while (dt.Read())
                {
                    a = new Aparato();
                    a.idAparato = dt.GetInt64(0);
                    a.Descripcion = dt.GetString(1);
                    a.Modelo = dt.GetString(2);
                    a.Observaciones = dt.GetString(3);
                    a.Estatus = dt.GetInt16(4);
                    a.Estado = objetos.Respuesta.Valido;
                    aps.Add(a);
                }               
                return aps;
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
namespace ril.objetos.aparatos
{
    public class Aparato
    {
        public long idAparato { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Observaciones { get; set; }
        public int Estatus { get; set; }
        public Respuesta Estado { get; set; }
    }
}
