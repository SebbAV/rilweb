﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeEmpleadoCC.aspx.cs" Inherits="HomeEmpleadoCC" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="images/icono.jpg" />

    <script src="scripts/jquery-3.1.0.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <script src="scripts/jquery.cookie.js"></script>
    <script src="js/genericas.js"></script>
    <script src="js/Aparato.js"></script>
    <script src="js/Citas.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="js/Paciente.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />

    <title>Radiologia e Imagen Lizarraga</title>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body onload="Aparato.SelectAparatoCombo(); Cita.SelectCitasUsuarioOnLoad();Usuario.ValidarROL();">

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
        <!-- Modal Citas -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title">Cita</h2>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="form-group">
                                        <label>ID</label>
                                        <input type="text" class="form-control" id="txtID" disabled="disabled" />
                                        <label>Nombre</label>
                                        <input type="text" class="form-control" id="txtNombre" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <label>Paterno</label>
                                        <input type="text" class="form-control" id="txtPaterno" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <label>Materno</label>
                                        <input type="text" class="form-control" id="txtMaterno" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <label>Registrador</label>
                                        <input type="text" class="form-control" id="txtRegistrador" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-4">
                                            <label>Aparato</label>
                                            <input type="text" class="form-control" id="txtAparato" disabled="disabled" />
                                        </div>
                                        <div class="col-lg-4">
                                            <label>Fecha</label>
                                            <input type="text" class="form-control" id="txtFecha2" disabled="disabled" />
                                        </div>
                                        <div class="col-lg-4">
                                            <label>Hora</label>
                                            <input type="text" class="form-control" id="txtHora" disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <input id="btnModificar" type="button" class="form-control btn btn-warning" onclick="Cita.Modificar(); " value="Modificar" />
                                    </div>
                                    <div id="divHide" hidden="hidden">
                                        <div class="form-group">
                                            <label>Fecha</label>
                                            <div class="input-group" id="datepicker2">
                                                <input type="text" class="form-control" id="txtFecha3" data-date-format='dd-mm-yyyy' />
                                                <script>
                                                    $('#datepicker2 input').datepicker({}).datepicker('setDate', '#txtFecha');
                                                </script>
                                                <div class="input-group-addon">
                                                    <span class="fa fa-calendar"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Nuevo Aparato</label>
                                            <select id="cmbAparato" class="form-control" onchange="Cita.ObtenerHorasM();" hidden="hidden">
                                                <option value="">Aparatos</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label>Nueva Hora</label>
                                            <select id="cmb-horas" class="form-control" hidden="hidden">
                                                <option value="">Horas</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <input type="button" class="form-control btn btn-success" onclick="Cita.UpdateCita(); Cita.SelectCitasUsuarioFechaMod();" value="Actualizar" />
                                        </div>
                                        <div class="form-group">
                                            <input type="button" class="form-control btn btn-danger" onclick="Cita.DeleteCita(); Cita.SelectCitasUsuarioFechaMod();" value="Eliminar" />
                                        </div>
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
        <!-- /Modal Citas-->
        <div id="page-wrapper">
            <div class="col-lg-12">
                <h1 class="page-header">Gestion de Citas</h1>
            </div>
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="background-color: #0092bc; color: white">
                                <h3><strong>Citas Pendientes</strong></h3>
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
                                    <input type="button" value="Buscar" id="btnBuscar" class="form-control btn-primary" onclick="Cita.SelectCitasUsuarioFecha();" />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <label>Ver Todo</label>
                                            <input type="checkbox" id="chkBox" class="checkbox-inline" onchange="Cita.SelectCitasUsuarioOnCheck();" />
                                        </div>
                                        <div class="col-lg-4">
                                            <label>Ver Anteriores</label>
                                            <input type="checkbox" class="checkbox-inline" id="chkBoxA" onchange="Cita.SelectCitasUsuarioOnCheckA();" />
                                        </div>
                                        <div class="col-lg-4">
                                            <label>Pendientes</label>
                                            <input type="checkbox" id="chkBoxP" class="checkbox-inline" onchange="Cita.SelectCitasUsuarioOnLoad();" />
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table style="width: 100%" id="tbl-CitasPendientes" class="table table-striped table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>ID Cita</th>
                                                <th>Nombre</th>
                                                <th>Paterno</th>
                                                <th>Materno</th>
                                                <th>Aparato</th>
                                                <th>Fecha</th>
                                                <th>Hora</th>
                                                <th>Registrador</th>
                                            </tr>
                                        </thead>

                                    </table>
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
