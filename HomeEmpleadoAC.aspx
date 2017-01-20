<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="images/icono.jpg"/>


    <script src="scripts/jquery-3.1.0.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <script src="scripts/jquery.cookie.js"></script>
    <script src="js/genericas.js"></script>
    <script src="js/Aparato.js"></script>
    <script src="js/Citas.js"></script>
    <script src="js/Paciente.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />
    <link href="css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <title>Radiologia e Imagen Lizarraga</title>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body onload="Aparato.SelectAparatoCombo();Usuario.ValidarROL();">
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-fixed-top">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <a class="navbar-brand" href="Home.aspx">
                    <img src="images/logoril.jpg" class="img-responsive" alt="RIL" />
                </a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <!-- Top Menu Items -->
            <ul class="nav navbar-right top-nav">
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-lg fa-user-circle" aria-hidden="true">&nbsp;</i> <b class="fa fa-angle-down"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="Home.aspx" onclick="Cerrar.cerrarSesion()"><i class="fa fa-fw fa-power-off"></i>Cerrar Sesion</a></li>
                    </ul>
                </li>
            </ul>
            <!-- Sidebar Menu Items - These collapse to the responsive navigation menu on small screens -->
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                    <li>
                        <a href="HomeEmpleadoAP.aspx"><i class="fa fa-fw fa fa-cogs"></i>Aparatos</a>
                    </li>
                    <li>
                        <a href="#" data-toggle="collapse" data-target="#submenu-1"><i class="fa fa-fw fa-search"></i>Gestion Estudios <i class="fa fa-fw fa-angle-down pull-right"></i></a>
                        <ul id="submenu-1" class="collapse">
                            <li><a href="HomeEmpleadoGE.aspx"><i></i>Nuevo Estudio</a></li>
                            <li><a href="HomeEmpleadoGEBuscar.aspx"><i></i>Ver Estudios Realizados</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" data-toggle="collapse" data-target="#submenu-2"><i class="fa fa-fw fa-address-card"></i>Gestion de Citas<i class="fa fa-fw fa-angle-down pull-right"></i></a>
                        <ul id="submenu-2" class="collapse">
                            <li><a href="HomeEmpleadoAC.aspx"><i></i>Nueva Cita</a></li>
                            <li><a href="HomeEmpleadoCC.aspx"><i></i>Citas Pendientes</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" data-toggle="collapse" data-target="#submenu-3"><i class="fa fa-fw fa-address-book"></i>Gestion de Pacientes<i class="fa fa-fw fa-angle-down pull-right"></i></a>
                        <ul id="submenu-3" class="collapse">
                            <li><a href="HomeEmpleadoGP.aspx"><i></i>Registrar Paciente</a></li>
                            <li><a href="HomeEmpleadoGPBuscar.aspx"><i></i>Ver Pacientes</a></li>
                        </ul>
                    </li>
                    <li id="menuAdmin" style="visibility: hidden">
                        <a href="HomeAdministradorGU.aspx"><i class="fa fa-fw fa fa-cogs"></i>Gestion de Usuarios</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </nav>

        <div id="page-wrapper">
            <div class="col-lg-12">
                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Gestion Paciente</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel-default">
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <input id="txtNombre" type="text" class="form-control" />
                                                </div>
                                                <div class="form-group">
                                                    <input id="btnTraerConsulta" type="button" onclick="Paciente.selectPacienteCorto()" class="btn-success form-control" value="Consultar" />
                                                </div>
                                                <table style="width: 100%" class="table table-striped table-bordered table-hover" id="tblPacientes">
                                                    <thead>
                                                        <tr>
                                                            <td>Identificador</td>
                                                            <td>Nombre</td>
                                                            <td>Paterno</td>
                                                            <td>Materno</td>
                                                            <td>Correo</td>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /Modal-->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Gestion de Citas</h1>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading" style="background-color: #0092bc; color: white">
                                    <h3><strong>Nueva Cita</strong></h3>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">
                                        <label>Fecha</label>
                                        <div class="input-group" id="datepicker">
                                            <input type="text" class="form-control" id="txtFecha" data-date-format='dd-mm-yyyy' />
                                            <script>
                                                $('#datepicker input').datepicker({}).datepicker('setDate', '#txtFecha');
                                            </script>
                                            <div class="input-group-addon">
                                                <span class="fa fa-calendar"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Seleccionar Aparato</label>
                                        <select id="cmbAparato" class="form-control" onchange="Cita.ObtenerHoras();">
                                            <option value="">Aparatos</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label>Hora de la Cita</label>
                                        <select id="cmb-horas" class="form-control">
                                            <option value="">Horas</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <h4>Obtener Paciente</h4>
                                    </div>
                                    <div class="form-group">
                                        <label>Identificador </label>
                                        <input type="text" id="txtID" class="form-control" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <label>Nombre del Paciente </label>
                                        <div class="input-group">
                                            <input type="text" id="txtPaciente" class="form-control" aria-describedby="basic-addon2" />
                                            <span class="input-group-addon btn btn-primary" id="basic-addon2" data-toggle="modal" data-target="#myModal">Buscar</span>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Apellido Paterno </label>

                                        <input type="text" id="txtPaterno" class="form-control" aria-describedby="basic-addon2" />

                                    </div>
                                    <div class="form-group">
                                        <label>Apellido Materno </label>

                                        <input type="text" id="txtMaterno" class="form-control" aria-describedby="basic-addon2" />

                                    </div>
                                    <div class="form-group">
                                        <input type="button" id="btnInsertCita" onclick="Cita.InsertCita()" value="Agendar" class="form-control btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

