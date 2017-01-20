using issc311.clases;
using ril.clases;
using ril.clases.aparatos;
using ril.clases.deEst;
using ril.clases.estudios;
using ril.logout;
using ril.objetos;
using ril.objetos.aparatos;
using ril.objetos.aparatosestudios;
using ril.objetos.detEst;
using ril.objetos.estudios;
using ril.objetos.paciente;
using ril.objetos.usuario;
using RIL.clases;
using RIL.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    /// <summary>
    /// Metodo para Iniciar Sesion, si la respuesta del servidor es correcta se generara
    /// un token que estara validando todas las acciones del usuario activo y en caso
    /// de que se conecten con el mismo usuario dos personas, las sesion sera desactivada.
    /// </summary>
    /// <param name="Nick"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public EstadoLogin Acceso(string Nick, string Password)
    {
        Credencial cred = new Credencial();
        Login _login = new Login();
        EstadoLogin _objReturn = _login.Acceso(Nick, Password);
        if (_objReturn.Estado == TiposEstado.Aceptado)
        {
            HttpContext.Current.Session["Token"] = _objReturn.SesionInformacion.Token;
        }
        return _objReturn;
    }
    /// <summary>
    /// Cierra la Sesion actuva
    /// </summary>
    /// <param name="Token">Se manda el token que tiene el usuario, y lo desactiva en base de datos</param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public bool CerrarSesion(string Token)
    {
        HttpContext.Current.Session["Token"] = null;

        Logout _cerrar = new Logout();
        _cerrar.Desconectar(Token);

        return true;
    }
    /// <summary>
    /// Metodo para dar de alta un paciente
    /// </summary>
    /// <param name="Credencial"></param>
    /// <param name="Paciente"></param>
    [WebMethod(EnableSession = true)]
    public void RegistrarUsuario(Credencial Credencial, PacienteP Paciente)
    {
        //Lógica de base de datos 
        Register reg = new Register();
        reg.RegistrarUsuario(Paciente, Credencial);
    }
    /// <summary>
    /// Metodo Web para insertar Aparatos en base de datos
    /// </summary>
    /// <param name="Aparato">Se manda un objeto de tipo aparato que es el que se va a insertar</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta insertarAparato(Aparato Aparato, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            Aparatos aps = new Aparatos();
            aps.insertarAparato(Aparato);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }
    /// <summary>
    /// Metodo utilizado para actualizar un dato en especifico de la tabla Aparato
    /// </summary>
    /// <param name="Aparato">Se manda un objeto de tipo aparato que es el que se va a actualizar</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta updateAparato(Aparato Aparato, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            Aparatos aps = new Aparatos();
            aps.updateAparato(Aparato);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }

    /// <summary>
    /// Metodo utilizado para borrado logico un dato en especifico de la tabla Aparato
    /// </summary>
    /// <param name="Aparato">Se manda un objeto de tipo aparato que es el que se va a borrarr</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta deleteAparato(Aparato Aparato, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            Aparatos aps = new Aparatos();
            aps.deleteAparato(Aparato);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }
    /// <summary>
    /// Este metodo se utiliza para llenar de la tabla aparatos los combobox y tablas
    /// </summary>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>Regresa una lista de todos los campos encontrados en la base de datos</returns>
    [WebMethod(EnableSession = true)]
    public List<Aparato> selectAparato(Sesion Sesion)
    {
        List<Aparato> apps = new List<Aparato>();
        Aparatos ap = new Aparatos();
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            apps = ap.selectAparatoTabla();
            return apps;
        }
        else
        {
            Aparato aparato = new Aparato();
            aparato.Estado = Respuesta.Invalido;
            apps.Add(aparato);
            return apps;
        }


    }

    /// <summary>
    /// Metodo Web para insertar Estudios en base de datos
    /// </summary>
    /// <param name="Estudio">Se manda un objeto de tipo estudio que es el que se va a insertar</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta insertarEstudio(Estudio Estudio, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            Estudios est = new Estudios();
            est.insertarEstudio(Estudio);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }
    /// <summary>
    /// Metodo para buscar todos los datos encontrados en la tabla estudios
    /// </summary>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Estudio> ConsultaEstudios(Sesion Sesion)
    {
        List<Estudio> estudios = new List<Estudio>();
        Estudios est = new Estudios();
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            estudios = est.ConsultaTodos();
            return estudios;
        }
        else
        {
            Estudio estudio = new Estudio();
            estudio.Estado = Respuesta.Invalido;
            estudios.Add(estudio);
            return estudios;
        }
    }
    /// <summary>
    /// Metodo para buscar todos los datos encontrados en la tabla estudios
    /// </summary>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<DetalleEstudio_Table> BuscarDetallesEstudios(DetalleEstudio DetalleEstudio, Sesion Sesion)
    {
        List<DetalleEstudio_Table> estudios = new List<DetalleEstudio_Table>();
        DetalleEstudios est = new DetalleEstudios();
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();

        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            estudios = est.ConsultaDetallesFecha(DetalleEstudio);
            return estudios;
        }
        else
        {
            DetalleEstudio_Table estudio = new DetalleEstudio_Table();
            estudio.Estado = Respuesta.Invalido;
            estudios.Add(estudio);
            return estudios;
        }
    }
    /// <summary>
    /// Metodo utilizado para llenar los combobox, con los datos de la tabla Estudio,
    /// </summary>
    /// <param name="Aparato">Este parametro manda el aparato previamiente seleccionado
    /// y busca los estudios relacionados con este aparato</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>Regresa una lista de tipo estudo, con los datos encontrados en relacion al id del aparato que seleccionado</returns>
    [WebMethod(EnableSession = true)]
    public List<Estudio> selectEstudio(Aparato Aparato, Sesion Sesion)
    {
        List<Estudio> lstEstudios = new List<Estudio>();
        Estudios estudios = new Estudios();
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {

            lstEstudios = estudios.selectEstudio(Aparato);
            return lstEstudios;
        }
        else
        {
            Estudio estudio = new Estudio();
            estudio.Estado = Respuesta.Invalido;
            lstEstudios.Add(estudio);
            return lstEstudios;
        }


    }
    /// <summary>
    /// Metodo Web para actualizar Estudios en base de datos
    /// </summary>
    /// <param name="Estudio">Se manda un objeto de tipo estudio que es el que se va a actualizar</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta UpdateEstudios(Estudio Estudio, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            Estudios est = new Estudios();
            est.updateEstudio(Estudio);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }



    }
    /// <summary>
    /// Metodo Web para borrado logico Estudios en base de datos
    /// </summary>
    /// <param name="Estudio">Se manda un objeto de tipo estudio que es el que se va a borrar de manera logicar</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta DeleteEstudios(Estudio Estudio, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            Estudios est = new Estudios();
            est.deleteEstudio(Estudio);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }

    }
    /// <summary>
    /// Metodo utilizado para consultar el precio de un estudio desde la tabla Estudio
    /// </summary>
    /// <param name="Estudio">Se manda una variable de tipo Estudio para buscar el precio relacionado con ese estudio</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>Regresa una variable de tipo estudio</returns>
    [WebMethod]
    public Estudio selectCosto(Estudio Estudio, Sesion Sesion)
    {
        Estudios estudios = new Estudios();

        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return estudios.selectEstudioCosto(Estudio);
        }
        else
        {
            Estudio estudio = new Estudio();
            estudio.Estado = Respuesta.Invalido;
            return estudio;
        }
    }
    /// <summary>
    /// Metodo para insertar en la tabla de Detalles Estudio
    /// </summary>
    /// <param name="De">Variable de Tipo Detalle Estudio se manda con todos los datos necesarios para insertar en la tabla</param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod]
    public Respuesta insertarDetallesEst(DetalleEstudio DetalleEstudio, Sesion Sesion)
    {
        DetalleEstudios des = new DetalleEstudios();
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            des.insertarDetalleEstudios(DetalleEstudio);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }
    /// <summary>
    /// Metodo para consultar los pacientes en la tabla Pacientes
    /// </summary>
    /// <param name="Paciente">Se mandan los datos de un paciente para buscar a los pacientes deseados
    /// </param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public List<PacienteP> ConsultaPaciente(PacienteP Paciente, Sesion Sesion)
    {
        Pacientes cp = new Pacientes();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        List<PacienteP> lstPacientes = new List<PacienteP>();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cp.consultarPaciente(Paciente);
        }
        else
        {
            PacienteP pac = new PacienteP();
            pac.Estado = Respuesta.Invalido;
            lstPacientes.Add(pac);
            return lstPacientes;
        }

    }
    /// <summary>
    /// Metodo para insertar un paciente con todos sus datos
    /// </summary>
    /// <param name="Paciente"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta RegistroPaciente(PacienteP Paciente, Sesion Sesion)
    {
        Validar _validar = new Validar();
        EstadoSesion es = new EstadoSesion();
        Pacientes rp = new Pacientes();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            if (rp.Registrar(Paciente, Sesion) == Respuesta.Valido)
            {
                return Respuesta.Valido;
            }
            else
            {
                return Respuesta.Error;
            }
        }
        else
        {
            return Respuesta.Invalido;
        }
    }
    /// <summary>
    /// Metodo para obtener un paciente por su correo
    /// </summary>
    /// <param name="Paciente"></param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public PacienteP obtenerPaciente(PacienteP Paciente, Sesion Sesion)
    {
        PacienteP pac = new PacienteP();
        EstadoSesion es = new EstadoSesion();
        Pacientes cp = new Pacientes();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cp.obtenerPaciente(Paciente);
        }
        else
        {
            pac.Estado = Respuesta.Invalido;
            return pac;
        }
    }
    /// <summary>
    /// Metodo para modificar los datos del paciente
    /// </summary>
    /// <param name="Paciente"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta modificarPaciente(PacienteP Paciente, Sesion Sesion)
    {
        PacienteP pac = new PacienteP();
        Pacientes cp = new Pacientes();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            cp.modificarPaciente(Paciente);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }

    }
    /// <summary>
    /// Metodo para hacer un borrado logico de paciente
    /// en base a su id
    /// </summary>
    /// <param name="Paciente"></param>
    /// <param name="Sesion">Se manda un objeto de tipo sesion para validar si el usuario cuenta con una sesion valida y/o activa </param>
    /// <returns>regresa una respuesta,0 = Sin respuesta, 1 = Aceptado, 2 = No aceptado </returns>
    [WebMethod(EnableSession = true)]
    public Respuesta eliminarPaciente(PacienteP Paciente, Sesion Sesion)
    {
        PacienteP pac = new PacienteP();
        Pacientes cp = new Pacientes();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            cp.eliminarPaciente(Paciente);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }

    }

    [WebMethod(EnableSession = true)]
    public List<DetalleEstudio_Table> ConsultaDetallesEstudios(int Tipo, Sesion Sesion)
    {
        DetalleEstudios con = new DetalleEstudios();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return con.ConsultaDetalles(Tipo);
        }
        else
        {
            DetalleEstudio_Table de = new DetalleEstudio_Table();
            List<DetalleEstudio_Table> lstDetalle = new List<DetalleEstudio_Table>();
            de.Estado = Respuesta.Invalido;
            lstDetalle.Add(de);
            return lstDetalle;
        }
    }
    /// <summary>
    /// Metodo para obtener usuario dependiendo de su rol
    /// </summary>
    /// <param name="TipoRol"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Usuario> BuscarUsuarios(int TipoRol, Sesion Sesion)
    {
        Usuarios gu = new Usuarios();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        List<Usuario> usuarios = new List<Usuario>();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return gu.buscarTipo(TipoRol);
        }
        else
        {
            Usuario usr = new Usuario();
            usr.Estado = Respuesta.Invalido;
            usuarios.Add(usr);
            return usuarios;
        }


    }
    /// <summary>
    /// Metodo para obtener usuario 
    /// 
    /// </summary>
    /// <param name="Usuario"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Usuario BuscarUsuarioID(Usuario Usuario, Sesion Sesion)
    {
        Usuarios gu = new Usuarios();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return gu.BuscarUsuarioID(Usuario);
        }
        else
        {
            Usuario usr = new Usuario();
            usr.Estado = Respuesta.Invalido;
            return usr;
        }

    }
    [WebMethod]
    public List<AparatoEstudio> getAparatosEstudiosXML()
    {
        AparatosEstudios aes = new AparatosEstudios();
        return aes.getEstudioXML();
    }
    /// <summary>
    /// Metodo para modificar Usuario
    /// </summary>
    /// <param name="Usuario"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta ModificarUsuario(Usuario Usuario, Sesion Sesion)
    {
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        Usuarios gu = new Usuarios();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            gu.ModificarUsuario(Usuario);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }
    /// <summary>
    /// Metodo para eliminar usuario
    /// </summary>
    /// <param name="Usuario"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta EliminarUsuario(Usuario Usuario, Sesion Sesion)
    {
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        Usuarios gu = new Usuarios();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            gu.EliminarUsuario(Usuario);
            return es.SesionActiva;
        }
        else
        {
            return es.SesionActiva;
        }
    }
    /// <summary>
    /// Metodo para insertar una cita a la tabla Citas y AgendarCitas
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta InsertCitaUsuario(Cita Cita, Sesion Sesion)
    {
        Citas cc = new Citas();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            cc.InsertCitaUsuario(Cita);
            return es.SesionActiva;

        }
        else
        {
            return es.SesionActiva;
        }

    }
    /// <summary>
    /// Metodo para actualizar tabla Cita
    /// en base al identificador de cita
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta UpdateCitaUsuario(Cita Cita, Sesion Sesion)
    {
        Citas cc = new Citas();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            cc.UpdateCitaUsuario(Cita);
            return es.SesionActiva;

        }
        else
        {
            return es.SesionActiva;
        }

    }
    /// <summary>
    /// Metodo para hacer borrado logico en tabla Cita
    /// en base al identificador de Citas
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta DeleteCita(Cita Cita, Sesion Sesion)
    {
        Citas cc = new Citas();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            cc.DeleteCita(Cita);
            return es.SesionActiva;

        }
        else
        {
            return es.SesionActiva;
        }

    }
    /// <summary>
    /// Metodo para insertar cita por parte de paciente
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta InsertCitaPaciente(Cita Cita, Sesion Sesion)
    {
        Citas cc = new Citas();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            cc.InsertCitaPaciente(Cita);
            return es.SesionActiva;

        }
        else
        {
            return es.SesionActiva;
        }

    }
    /// <summary>
    /// Metodo para obetener citas por fecha
    /// 
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Cita> SelectCitasUFecha(Cita Cita, Sesion Sesion)
    {
        Cita cita;
        Citas cc = new Citas();
        List<Cita> lstCitas = new List<Cita>();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cc.ConsultarCitaPendienteUsuarioFecha(Cita);

        }
        else
        {
            cita = new Cita();
            cita.Estado = Respuesta.Invalido;
            lstCitas.Add(cita);
            return lstCitas;
        }
    }
    /// <summary>
    /// Metodo para obtener todas las citas pendientes
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Cita> SelectCitasUOnLoad(Cita Cita, Sesion Sesion)
    {
        Cita cita;
        Citas cc = new Citas();
        List<Cita> lstCitas = new List<Cita>();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cc.ConsultarCitaPendienteUsuarioOnLoad(Cita);

        }
        else
        {
            cita = new Cita();
            cita.Estado = Respuesta.Invalido;
            lstCitas.Add(cita);
            return lstCitas;
        }
    }
    /// <summary>
    /// Metodo para obtener todas las citas
    /// ya sean anteriores o pendientes
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Cita> SelectCitasUOnCheck(Cita Cita, Sesion Sesion)
    {
        Cita cita;
        Citas cc = new Citas();
        List<Cita> lstCitas = new List<Cita>();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cc.ConsultarCitaPendienteUsuarioOnCheck(Cita);

        }
        else
        {
            cita = new Cita();
            cita.Estado = Respuesta.Invalido;
            lstCitas.Add(cita);
            return lstCitas;
        }
    }
    /// <summary>
    /// Metodo para obtener la citas anteriores a partir de la fecha actual
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Cita> SelectCitasUOnCheckA(Cita Cita, Sesion Sesion)
    {
        Cita cita;
        Citas cc = new Citas();
        List<Cita> lstCitas = new List<Cita>();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cc.ConsultarCitaPendienteUsuarioOnCheckA(Cita);

        }
        else
        {
            cita = new Cita();
            cita.Estado = Respuesta.Invalido;
            lstCitas.Add(cita);
            return lstCitas;
        }
    }
    /// <summary>
    /// Metodo para obtener citas de paciente
    /// se debe mandar su id
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Cita> SelectCitasP(Cita Cita, Sesion Sesion)
    {
        Cita cita;
        Citas cc = new Citas();
        List<Cita> lstCitas = new List<Cita>();
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return cc.ConsultarCitaPendientesPaciente(Cita);

        }
        else
        {
            cita = new Cita();
            cita.Estado = Respuesta.Invalido;
            lstCitas.Add(cita);
            return lstCitas;
        }
    }

    /// <summary>
    /// Metodo para obtener horas
    /// en base a fecha y aparato
    /// </summary>
    /// <param name="Cita"></param>
    /// <param name="Sesion"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<Cita> ConsultarHoras(Cita Cita, Sesion Sesion)
    {
        Cita cita;
        EstadoSesion es = new EstadoSesion();
        Validar _validar = new Validar();
        List<Cita> lstCitas = new List<Cita>();
        Citas c = new Citas();
        es = _validar.ValidarSesion(Sesion);
        if (es.SesionActiva == Respuesta.Valido)
        {
            return c.ConsultarHoras(Cita);
        }
        else
        {
            cita = new Cita();
            cita.Estado = Respuesta.Invalido;
            lstCitas.Add(cita);
            return lstCitas;
        }
    }
    /// <summary>
    /// Método para consumir el método de registrar un paciente
    /// dentro de la clase PacientesJAVA.
    /// </summary>
    /// <param name="Paciente"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta RegistrarPaciente(PacienteJ Paciente)
    {
        PacientesJava pj = new PacientesJava();
        pj.Registrar(Paciente);
        return Respuesta.Valido;
    }

    /// <summary>
    /// Método para consumir el método de consultar un paciente
    /// por su nombre en la clase de PacientesJAVA.
    /// </summary>
    /// <param name="Paciente"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<PacienteJ> ConsultarPaciente(PacienteJ Paciente)
    {
        List<PacienteJ> lstPaciente = new List<PacienteJ>();
        PacientesJava pj = new PacientesJava();

        lstPaciente = pj.consultarPaciente(Paciente);
        return lstPaciente;
    }

    /// <summary>
    /// Método para consumir el método para modificar un paciente
    /// previamente seleccionado en la clase PacientesJAVA.
    /// </summary>
    /// <param name="Paciente"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta ModificarPaciente(PacienteJ Paciente)
    {
        PacientesJava pj = new PacientesJava();
        pj.modificarPaciente(Paciente);
        return Respuesta.Valido;
    }

    /// <summary>
    /// Método Web para consumir el método para realizar un
    /// borrado lógico en la clase de PacientesJAVA.
    /// </summary>
    /// <param name="Paciente"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Respuesta EliminarPaciente(PacienteJ Paciente)
    {
        PacientesJava pj = new PacientesJava();
        pj.eliminarPaciente(Paciente);
        return Respuesta.Valido;
    }

    /// <summary>
    /// Método Web para consumir el método para realizar una consulta
    /// de todos los registros en la clase PacientesJAVA.
    /// </summary>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<PacienteJ> ConsultarTodo()
    {
        List<PacienteJ> lstPaciente = new List<PacienteJ>();
        PacientesJava pj = new PacientesJava();
        lstPaciente = pj.ConsultarTodo();
        return lstPaciente;
    }

    /// <summary>
    /// Método Web para consumir el método para consultar los 
    /// pacientes previamente eliminados (borrado lógico) en
    /// la clase PacientesJAVA.
    /// </summary>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<PacienteJ> ConsultarEliminados()
    {

        List<PacienteJ> lstPaciente = new List<PacienteJ>();
        PacientesJava pj = new PacientesJava();
        lstPaciente = pj.consultarEliminados();
        return lstPaciente;
    }
}
