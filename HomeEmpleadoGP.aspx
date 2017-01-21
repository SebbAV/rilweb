<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeEmpleadoGP.aspx.cs" Inherits="HomeEmpleadoGC" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Radiologia e Imagen Lizarraga</title>

    <!-- Javascripts -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Aparato.js"></script>
    <script src="JS/Estudio.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="JS/Paciente.js"></script>
    <script src="JS/Logout.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/boostrap-datepicker.css" rel="stylesheet" />
    <link href="css/bootstrap-datepicker.min.css" rel="stylesheet" />

    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body onload="Usuario.ValidarROL();">

    <div id="wrapper">
        <nav class="navbar navbar-default navbar-fixed-top">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <a class="navbar-brand" href="Home.aspx">
                   <img style="max-width: 150px; margin-top: -5px;" src="images/logoril.jpg" alt="RIL"/>
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
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Pacientes</h1>
                </div>
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #0092bc; color: white">
                            <h3><strong>Nuevo Paciente</strong></h3>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                            </div>

                            <div class="form-group">
                                <label>Nombre</label>
                                <input type="text" class="form-control" id="txtNombre">
                            </div>
                            <div class="form-group">
                                <label>Apellido Paterno </label>
                                <input type="text" class="form-control" id="txtPaterno">
                            </div>

                            <div class="form-group">
                                <label>Apellido Materno</label>
                                <input type="text" class="form-control" id="txtMaterno">
                            </div>
                            <div class="form-group">
                                <label>Correo Electronico</label>
                                <input type="text" class="form-control" id="txtCorreo">
                            </div>
                            <div class="form-group">
                                <label>Telefono </label>
                                <input type="text" class="form-control" id="txtTelefono">
                            </div>
                            <div class="form-group">
                                <label>Fecha de Nacimiento</label>
                                <div class="input-group" id="contenedor-datepicker">
                                    <input type="text" class="form-control" id="txtFechaNac">
                                    <script>
                                        $('#contenedor-datepicker input').datepicker({
                                        });
                                    </script>
                                    <div class="input-group-addon btn-primary">
                                        <span class="fa fa-calendar"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Domicilio</label>
                                <input type="text" class="form-control" id="txtDomicilio">
                            </div>

                            <div class="form-group">
                                <label>Codigo Postal</label>
                                <input type="text" class="form-control" id="txtCp">
                            </div>
                            <div class="form-group">
                                <label>RFC</label>
                                <input type="text" class="form-control" id="txtRfc">
                            </div>
                            <div class="form-group">
                                <input type="button" class="form-control btn-primary" value="Registrar" onclick="Paciente.Validar(1)" />
                            </div>
                        </div>

                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
    </div>
    <!-- /#wrapper -->
</body>

</html>
