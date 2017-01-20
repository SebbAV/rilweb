<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="images/icono.jpg">
    <title>Acerca de nosotros</title>

    <!-- JavaScripts -->
    <script src="Scripts/jquery-3.1.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Login.js"></script>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/modern-business.css" rel="stylesheet">
    <link href="css/login.css" rel="stylesheet" />
    <link href="css/navbar.css" rel="stylesheet" />
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
        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-fixed-top">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <a class="navbar-brand" href="Home.aspx">
                    <img src="images/logoril.jpg" class="img-responsive" alt="RIL" />
                </a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

            </div>
            <!-- Top Menu Items -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right ">
                    <li>
                        <a href="/">Inicio</a>
                    </li>
                    <li>
                        <a href="about.aspx">Quiénes Somos</a>
                    </li>
                    <li>
                        <a href="Estudios.aspx">Estudios</a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <span class="glyphicon glyphicon-user"></span>
                            Acceder <b class="caret"></b></a>
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
            </div>
        </nav>

    </div>

    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h1 class="page-header">Acerca de nosotros
                </h1>

            </div>
        </div>
        <!-- /.row -->

        <!-- Nuestra Historia -->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Nuestra historia:

                </h2>
                <p>
                    Nuestra historia comienza en Xalapa Veracruz, donde Pedro Ramírez Lizarraga abre su primera clínica especializada 
                   en Radiología en 1984 en la calle Zempoala, teniendo un repertorio corto de aparatos pero siendo de los pocos existentes
                    en la zona. 
                </p>
                <p>
                    La clínica tuvo un éxito casi inmediato y con el tiempo más aparatos y personal calificado fueron agregándose
                   al equipo de trabajo, para el año 2000 nuestro equipo ya contaba con 23 personas y 6 aparatos diferentes con estudios
                    variados en cada uno, hoy en día nuestro personal supera los 30 colaboradores y contamos con más de 60 estudios diferentes
                    siempres disponibles al público.
                </p>
            </div>
            <div class="col-md-10">
                <img src="images/imagen-1.jpg" style="width: 100%" />
            </div>
        </div>
        <!-- /.row -->
        <!-- Convenios -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Nuestros convenios</h2>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6">
                <img class="img-responsive customer-img" src="images/SeleccionWeb/issste.png" alt="ISSSTE" style="margin-top: 50px">
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6">
                <img class="img-responsive customer-img" src="images/SeleccionWeb/UV.png" alt="Universidad Veracruzana">
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
