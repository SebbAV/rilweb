<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePacienteCP.aspx.cs" Inherits="HomePacienteCP" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="JS/Logout.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="JS/Aparato.js"></script>
    <script src="js/Citas.js"></script>
    <script src="js/Paciente.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

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

<body onload="Cita.ConsultarCitasPendientes()">

    <div id="wrapper">
        <nav class="navbar navbar-default navbar-fixed-top" onload="Usuario.ValidarROL();">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Home.aspx">
                    <img src="images/logoril.jpg" class="img-responsive" alt="RIL" />
                </a>
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
                        <a href="#" data-toggle="collapse" data-target="#submenu-1"><i class="fa fa-fw fa-address-card"></i>Gestion de Citas<i class="fa fa-fw fa-angle-down pull-right"></i></a>
                        <ul id="submenu-1" class="collapse">
                            <li><a href="HomePacienteAC.aspx"><i></i>Agendar Cita</a></li>
                            <li><a href="HomePacienteCP.aspx"><i></i>Consultar Cita</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </nav>
        <div id="page-wrapper">
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
                                        <br />

                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <input type="button" class="form-control btn btn-danger" onclick="Cita.DeleteCita(); Cita.ConsultarCitasPendientes();" value="Cancelar" />
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
            <!-- / Wrapper-->
            <div class="page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Gestion de Usuarios</h1>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h3><strong>Citas Pendientes</strong></h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="table-responsive">
                                <table id="tbl-CitasPendientes" style="width: 100%" class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>ID Cita</th>
                                            <th>Tipo Estudio</th>
                                            <th>Fecha Cita</th>
                                            <th>Hora</th>
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
</body>

</html>

