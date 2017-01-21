<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeEmpleadoGE.aspx.cs" Inherits="HomeEmpleadoGE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="images/icono.jpg" />


    <title>Radiologia e Imagen Lizarraga</title>

    <!-- Javascripts -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Paciente.js"></script>
    <script src="JS/Aparato.js"></script>
    <script src="js/Paciente.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="JS/Estudio.js"></script>
    <script src="JS/Logout.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body onload="Generica.ValidarCookie();Aparato.SelectAparatoCombo();Usuario.ValidarROL();">

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
            <div class="col-lg-12">
                <div class="row">
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
                                                        <input id="btnTraerConsulta" type="button" onclick="Paciente.selectPacienteCorto()" class="btn form-control" value="Consultar" />
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
                    <div class="col-lg-12">
                        <h1 class="page-header">Gestion de Estudios</h1>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading" style="background-color: #0092bc; color: white">
                                    <h3><strong>Nuevo Estudio Realizado</strong></h3>
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="form-group">
                                    </div>
                                    <div class="form-group">
                                        <label>Identificador </label>
                                        <input type="text" id="txtID" class="form-control" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <label>Nombre del Paciente </label>
                                        <div class="input-group">
                                            <input type="text" id="txtPaciente" class="form-control" aria-describedby="basic-addon2" />
                                            <span class="input-group-addon btn-primary" id="basic-addon2" data-toggle="modal" data-target="#myModal">Buscar</span>
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
                                        <label>Aparato a utilizar</label>
                                        <select class="form-control" id="cmbAparato" onchange="Estudio.SelectEstudio()">
                                            <option value="0">...</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label>Tipo de Estudio</label>
                                        <select class="form-control" id="cmbEstudio" onchange="Estudio.SelectEstudioCosto()">
                                            <option value="0">...</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label>Costo del Estudio</label>
                                        <input type="text" class="form-control" id="txtCosto" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <label>Aportacion</label>
                                        <input type="text" class="form-control" id="txtAportacion" onkeypress="return Generica.isNumber()" />
                                    </div>
                                    <div class="form-group">
                                        <input type="button" class="form-control btn-primary" onclick="Estudio.ValidarDetalles(1)" value="Agregar" />
                                    </div>
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>

                        <!-- /.col-lg-12 -->
                    </div>
                </div>
            </div>
        </div>
        <!-- /#wrapper -->
    </div>
</body>

</html>
