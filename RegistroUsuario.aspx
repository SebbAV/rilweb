<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroUsuario.aspx.cs" Inherits="RegistroUsuario" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="images/icono.jpg">
    <title>Registrarse</title>

    <!-- JavaScripts -->
    <script src="Scripts/jquery-3.1.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Login.js"></script>
    <script src="JS/RegistroUsuario.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/login.css" rel="stylesheet" />


    <!-- Custom CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/modern-business.css" rel="stylesheet">
    <link href="css/sidebar.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>

    <div class="wrapper">
        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-fixed-top">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">

                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#collapsenvb">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" rel="home" href="#" title="Buy Sell Rent Everyting">
                    <img style="max-width: 150px; margin-top: -5px;" src="logoril.jpg">
                </a>
            </div>
            <!-- Top Menu Items -->
            <div class="collapse navbar-collapse" id="collapsenvb">
                <ul class="nav navbar-nav navbar-right " style="margin-right: 10px">
                    <li>
                        <a href="/">Inicio</a>
                    </li>
                    <li>
                        <a href="about.aspx">Quiénes Somos</a>
                    </li>
                    <li>
                        <a href="Estudios.aspx">Estudios</a>
                    </li>
                </ul>
            </div>
            <ul class="nav navbar-right top-nav">

                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-lg fa-user-circle" aria-hidden="true">&nbsp;</i> <b class="fa fa-angle-down"></b></a>
                    <ul id="login-dp" class="dropdown-menu">
                        <li>
                            <div class="row">
                                <div class="col-md-12">
                                    <label style="font-size: 15px; margin-left: 40%;">Login</label>
                                    <form class="form" method="post" action="login" accept-charset="UTF-8" id="login-nav">
                                        <div class="form-group">
                                            <label class="sr-only">Usuario</label>
                                            <input type="text" id="txtUser" class="form-control" placeholder="Nombre de Usuario" required>
                                        </div>
                                        <div class="form-group">
                                            <label class="sr-only">Contraseña</label>
                                            <input type="password" id="txtPwd" class="form-control" placeholder="Contraseña" required>
                                            <!--       <div class="help-block text-center"><a href="">¿Haz olvidado tu contraseña?</a></div>-->
                                        </div>
                                        <div class="form-group">
                                            <input type="button" id="btnLogin" class="btn btn-primary btn-block" value="Entrar" onclick="Login.Login()" />
                                        </div>

                                    </form>
                                </div>
                                <div class="bottom text-center">
                                    ¿No tienes una cuenta? <a href="RegistroUsuario.aspx">
                                        <br />
                                        <b>Registrarse ahora</b></a>
                                </div>
                            </div>
                        </li>
                    </ul>
                </li>
            </ul>
        </nav>

    </div>


    <!-- Page Content -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h1 class="page-header">Crea tu cuenta
                </h1>

            </div>
        </div>
        <!-- /.row -->

        <!-- Intro Content -->
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="col-md-6">
                            <strong style="font-size: 20px">Datos personales</strong>
                            <div class="form-group">
                                <label>Nombre:</label>
                                <input id="txtNombre" class="form-control" type="text" placeholder="Ingrese su nombre" />
                            </div>
                            <div class="form-group">
                                <label>Apellido Paterno:</label>
                                <input id="txtPaterno" class="form-control" type="text" placeholder="Ingrese su apellido paterno">
                            </div>
                            <div class="form-group">
                                <label>Apellido Materno:</label>
                                <input id="txtMaterno" class="form-control" type="text" placeholder="Ingrese su apellido materno" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <strong style="font-size: 20px">Datos de cuenta</strong>
                            <div class="form-group">
                                <label>Dirección de correo electrónico:</label>
                                <input id="txtCorreo" class="form-control" type="text" placeholder="Ingrese su correo electrónico *" />
                            </div>
                            <div class="form-group">
                                <label>Nombre de usuario (seudónimo):</label>
                                <input id="txtNick" class="form-control" type="text" placeholder="Ingrese su seudónimo *" />
                            </div>
                            <div class="form-group">
                                <label>Contraseña:</label>
                                <input id="txtPassword" class="form-control" type="text" placeholder="Ingrese su contraseña *" />
                            </div>
                        </div>
                        <div class="form-group">
                            <input id="btnRegistrar" class="form-control btn" type="button" value="Registrarse" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; rilizarraga.com 2016</p>
                </div>
            </div>
        </footer>

    </div>
    <!-- /.container -->
</body>

</html>
