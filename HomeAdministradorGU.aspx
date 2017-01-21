<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeAdministradorGU.aspx.cs" Inherits="HomeAdministradorGU" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Radiologia e Imagen Lizarraga</title>
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
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />
</head>
<body>
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-fixed-top" onload="Usuario.ValidarROL();">
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
            <!-- Modal Usuarios -->
            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h2 class="modal-title">Consultar paciente</h2>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <label>Identificador</label>
                                            <input type="text" class="form-control" id="txtID" />
                                        </div>
                                        <div class="form-group">
                                            <label>Correo</label>
                                            <input type="text" class="form-control" id="txtCorreo" required="required" />
                                        </div>
                                        <div class="form-group">
                                            <label>Rol</label>
                                            <select class="form-control" id="selectTipoUsuarios2" onchange="Usuario.SelectUsuariosPorRol()">
                                                <option value="">Tipos de Usuario</option>
                                                <option value="2">Administrador</option>
                                                <option value="3">Usuario</option>
                                                <option value="1">Paciente</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-6">

                                                <input type="button" class="form-control btn btn-success" onclick="Usuario.UpdateUsuario()"
                                                    value="Actualizar" />
                                            </div>
                                            <div class="col-lg-6">
                                                <input type="button" class="form-control btn btn-danger" onclick="Usuario.DeleteUsuario();"
                                                    value="Eliminar" />
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
            <!-- /modal -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Gestion de Usuarios</h1>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading" style="background-color: #0092bc; color: white">
                    <h3><strong>Usuarios</strong></h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Rol</label>
                        <select class="form-control" id="selectTipoUsuarios" onchange="Usuario.SelectUsuariosPorRol()">
                            <option value="">Tipos de Usuario</option>
                            <option value="2">Administrador</option>
                            <option value="3">Usuario</option>
                            <option value="1">Paciente</option>
                        </select>
                    </div>
                    <div class="table-responsive">
                        <table style="width: 100%" class="table table-striped table-bordered table-hover" id="tbl-usuarios">
                            <thead>
                                <tr>
                                    <th>Identificador</th>
                                    <th>Correo</th>
                                    <th>Nick</th>
                                    <th>Rol</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /#wrapper -->
</body>

</html>
