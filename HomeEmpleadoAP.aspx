<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Javascripts -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/notify.min.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Aparato.js"></script>
    <script src="JS/Estudio.js"></script>
    <script src="JS/Usuario.js"></script>
    <script src="JS/Logout.js"></script>


    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

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

<body onload="Generica.ValidarCookie();Aparato.SelectAparatoTabla();Aparato.SelectAparatoCombo();Estudio.SelectEstudioTable();Usuario.ValidarROL();">

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
            <!-- Modal Aparatos -->
            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h2 class="modal-title">Gestion de Aparatos</h2>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <label>ID</label>
                                            <input type="text" class="form-control" id="txtID" />
                                            <label>Tipo de Aparato</label>
                                            <input type="text" class="form-control" id="txtAparato2" required="required" />
                                        </div>
                                        <div class="form-group">
                                            <label>Modelo del Aparato</label>
                                            <input type="text" class="form-control" id="txtModelo2" required="required" />
                                        </div>
                                        <div class="form-group">
                                            <label>Observaciones</label>
                                            <input type="text" class="form-control" id="txtObservaciones2" required="required" />
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-6">

                                                <input type="button" class="form-control btn btn-success" onclick="Aparato.Validar(2);"
                                                    value="Actualizar" />
                                            </div>
                                            <div class="col-lg-6">
                                                <input type="button" class="form-control btn btn-danger" onclick="Aparato.DeleteAparato();" value="Eliminar" />
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
            <!-- /Modal Aparatos-->
            <!-- Modal Estudios -->
            <div id="myModal2" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h2 class="modal-title">Gestion de Estudios</h2>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <label>ID</label>
                                            <input type="text" class="form-control" id="txtIDEstudio" name="field1" />
                                            <label>Tipo de Estudio</label>
                                            <input type="text" class="form-control" id="txtTipo2" name="field2" />
                                        </div>
                                        <div class="form-group">
                                            <label>Costo</label>
                                            <input type="text" class="form-control" id="txtCosto2" name="field3" />
                                        </div>
                                        <div class="form-group">
                                            <label>Indicaciones</label>
                                            <textarea class="form-control" id="taIndicaciones2"></textarea>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-6">
                                                <input type="button" class="form-control btn btn-success" onclick="Estudio.Validar(2);" value="Actualizar" />
                                            </div>
                                            <div class="col-lg-6">
                                                <input type="button" class="form-control btn btn-danger" onclick=" Estudio.deleteEstudio();"
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
            <!-- /Modal Estudios-->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Gestion de Estudios</h1>
                </div>
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #0092bc; color: white">
                            <h3><strong>Aparatos</strong></h3>
                        </div>
                        <!-- Panel Body -->
                        <div class="panel-body">

                            <div class="form-group">
                            </div>

                            <div class="form-group">
                                <label>Tipo de Aparato</label>
                                <input type="text" class="form-control" id="txtAparato" name="field1">
                            </div>
                            <div class="form-group">
                                <label>Modelo del Aparato</label>
                                <input type="text" class="form-control" id="txtModelo" name="field1">
                            </div>
                            <div class="form-group">
                                <label>Observaciones</label>
                                <input type="text" class="form-control" id="txtObservaciones" name="field1">
                            </div>
                            <div class="form-group">
                                <input type="button" class="form-control btn-primary" onclick="Aparato.Validar(1);" value="Insertar" />
                            </div>
                            <table style="width: 100%" class="table table-striped table-bordered table-hover" id="tblAparatos">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Tipo de Aparato</th>
                                        <th>Modelo</th>
                                        <th>Observaciones</th>
                                    </tr>
                                </thead>
                            </table>
                            <!-- /.table -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-6 -->
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #0092bc; color: white">
                            <h3><strong>Estudios</strong></h3>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">

                            <div class="form-group">
                            </div>

                            <div class="form-group">
                                <label>Tipo de Estudio</label>
                                <input type="text" class="form-control" id="txtTipo">
                            </div>
                            <div class="form-group">
                                <label>Costo</label>
                                <input type="text" class="form-control" id="txtCosto" onkeypress="return Generica.isNumber()">
                            </div>

                            <div class="form-group">
                                <label>Aparato Requerido</label>
                                <select class="form-control" id="cmbAparato">
                                    <option value="0">...</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label>Indicaciones</label>
                                <textarea class="form-control" id="taIndicaciones">
                                </textarea>
                            </div>
                            <div class="form-group">
                                <input type="button" class="form-control btn-primary" onclick="Estudio.Validar(1)" value="Insertar" />
                            </div>
                            <table style="width: 100%" class="table table-striped table-bordered table-hover" id="tblEstudios">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Tipo de Estudio</th>
                                        <th>Costo</th>
                                        <th>Nombre del Aparato</th>
                                    </tr>
                                </thead>
                            </table>
                            <!-- /.table -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-6 -->
            </div>
            <!-- Row -->
        </div>
        <!-- /page wrapper -->
    </div>
    <!-- /wrapper -->
</body>

</html>
