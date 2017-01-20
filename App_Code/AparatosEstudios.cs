using ril.conexion;
using ril.estatic;
using ril.objetos.aparatos;
using ril.objetos.aparatosestudios;
using ril.objetos.estudios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for AparatosEstudios
/// </summary>
public class AparatosEstudios
{
    public AparatosEstudios()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<AparatoEstudio> getEstudioXML()
    {
        SqlConnection conn = new SqlConnection(RilStatic.ReturnConnectionString());
        try
        {
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.pa_sel_AparatoEstudioXML", conn);

            XmlDocument xdoc = new XmlDocument();
            XmlDocument xd = new XmlDocument();
            XmlReader xml = cmd.ExecuteXmlReader();
            //if (xml.Read())
            //   xdoc.Load(xml);

            //xd = xdoc;
            List<string> lstEstudio = new List<string>();
            AparatoEstudio ap = new AparatoEstudio();
            List<AparatoEstudio> lstAp = new List<AparatoEstudio>();
            string temp;
            while (xml.Read())
            {
                if (xml.Name == "Aparato")
                {
                    ap = new AparatoEstudio();
                    XmlReader inner = xml.ReadSubtree();

                    ap.descripcion = xml.GetAttribute("nameaparato");

                    while (inner.Read())
                    {
                        if (xml.Name == "Estudio")
                        {

                            temp = xml.GetAttribute("name");
                            if (temp == null)
                            {

                            }
                            else
                            {

                                ap.estudios.Add(temp);
                            }

                        }
                    }
                    lstAp.Add(ap);

                }
            }
            
            return lstAp;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }
}
namespace ril.objetos.aparatosestudios
{
    public class AparatoEstudio
    {
        public string descripcion { get; set; }
        public List<string> estudios { get; set; }
        public AparatoEstudio()
        {
            this.estudios = new List<string>();
        }
    }
}