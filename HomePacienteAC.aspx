<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePacienteAC.aspx.cs" Inherits="HomePacienteAC" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- JQuery -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <!-- Boostrap JS -->
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <!-- JavaScripts -->
    <script src="Scripts/jssha1.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Logout.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="JS/Aparato.js"></script>
    <script src="js/Citas.js"></script>
    <script src="js/Paciente.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <!-- Bootstrap CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="css/bootstrap-datepicker.min.css" rel="stylesheet" />

    <!-- CSS -->
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

<body onload="Aparato.SelectAparatoCombo();">

    <div id="wrapper">
     <nav class="navbar navbar-default navbar-fixed-top">
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
            <div class="row">
                <div class="col-lg-12">
                      <h1 class="page-header">Gestion de Citas</h1>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading" style="background-color: #0092bc; color: white">
                    <h3><strong>Agendar Cita</strong></h3>
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
                        <select id="cmbAparato" class="form-control" onchange="Cita.ObtenerHoras();">
                            <option value="0">Aparatos</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label>Horario disponible</label>
                        <select id="cmb-horas" class="form-control">
                            <option value="0">Horas</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <input type="button" id="btnInsertCita" onclick="Cita.InsertCitaPaciente()" value="Agendar" class="form-control btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /#wrapper -->
</body>

</html>

