<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>
<html lang="es">

<head>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="images/icono.jpg" />
    <title>Radiologia e Imagen Lizarraga</title>

    <!-- JavaScripts -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jssha1.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="JS/Genericas.js"></script>
    <script src="JS/Login.js"></script>
    <script src="Scripts/notify.js"></script>
    <script src="Scripts/notify.min.js"></script>

    <script src="JS/AparatoEstudio.js"></script>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/login.css" rel="stylesheet" />
    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />
    <link href="css/full-slider.css" rel="stylesheet">


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>

    <nav class="navbar navbar-default navbar-fixed-top">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">

            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#collapsenvb">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" rel="home" href="#" >
                <img style="max-width: 150px; margin-top: -5px;" src="images/logoril.jpg">
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

    <!-- Full Page Image Background Carousel Header -->
    <header id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for Slides -->
        <div class="carousel-inner">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image: url('http://placehold.it/1900x1080&text=Slide One');"></div>
                <div class="carousel-caption">
                    <h2>Caption 1</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image: url('http://placehold.it/1900x1080&text=Slide Two');"></div>
                <div class="carousel-caption">
                    <h2>Caption 2</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image: url('http://placehold.it/1900x1080&text=Slide Three');"></div>
                <div class="carousel-caption">
                    <h2>Caption 3</h2>
                </div>
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>

    </header>

    <!-- Page Content -->
    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Estudios
                </h1>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Resonancia Magnética</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            El más reciente avance tecnológico de la medicina para el diagnóstico preciso de múltiples enfermedades aún en etapas iniciales.
                        </p>

                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Mastografía Digital</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            El mejor método para la detección oportuna de cáncer mamario, con un equipo totalmente automatizado que mejora las técnicas
        de diagnóstico y la experiencia del paciente.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Tomografía Axial</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Equipo de última generación helicoidal que potencializa la calidad de los estudios y los tiempos de los mismos.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Densitometría Ósea</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Imágenes de alta resolución para el diagnóstico y detección oportuna de osteoporosis y osteopenia, en cadera, columna, y
        cuerpo completo, así como índice de masa corporal.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Ultrasonido 3D y 4D</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Alta calidad en definición de imagen para un diagnostico optimo y confiable.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Rayos X Digital</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            El equipo más moderno con accesorios y películas de alta definición para radiología general y estudios contrastados.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Análisis Clínicos</h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Contamos con equipos totalmente nuevo y automatizados para brindarle resultados más rápidos y confiables.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #0092bc; color: white">
                        <h4><i class="fa fa-fw fa-compass"></i>Cirugía Vascular </h4>
                    </div>
                    <div class="panel-body">
                        <p>
                            Corrección de problemas de circulación de la sangre en vasos sanguíneos.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="form-group">
                    <a href="Estudios.aspx" class="btn btn-primary form-control"><strong>Conoce todos nuestros estudios</strong></a>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header" style="font-size: 42px">Contacto</h2>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-group">
                            </div>
                            <div class="form-group" style="text-align: left">

                                <div class="col-md-12">

                                    <h3>Direccion Radiología e Imagen:</h3>

                                    <label>
                                        Priv. de Jóse Antonio #6
                                Segundo piso Frac Los Ángeles
                                     Xalapa,Veracruz
                                    </label>
                                </div>
                                <div class="form-group">

                                    <div class="col-md-12">
                                        <label>Telefono</label>
                                        <label>Tel. (228) 819 99 05</label>
                                    </div>
                                </div>
                                <div class="form-group">

                                    <div class="col-md-12">
                                        <h3>Análisis Clinicos:</h3>
                                        <label>
                                            Cempola #50
                                        </label>
                                        <label>
                                            Xalapa,Veracruz
                                        </label>
                                    </div>
                                    <br />

                                    <div class="col-md-12">
                                        <label>Telefono</label>
                                        <label>
                                            Tel. (228) 812 20 60,
                                (228) 812 20 61
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m17!1m11!1m3!1d722.7767000174606!2d-96.91095596377572!3d19.523638773308736!2m2!1f0!2f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x85db3204c9f3c16b%3A0x6a66fd1e576b433b!2sRadiologia+e+Imagen+Lizarraga!5e1!3m2!1sen!2smx!4v1479082020979"
                        onload="this.width=screen.width;this.height=screen.height;" style="border: 0; width: 100%; height: 400px"></iframe>
                </div>
            </div>
            <!-- /.row -->

            <hr>
            <!-- Footer -->
            <footer>
                <div class="row">
                    <div class="col-lg-12">
                        <p>Copyright &copy; rilizarraga.com 2016</p>
                    </div>
                </div>
            </footer>

        </div>

    </div>
    <!-- /.container -->

    <!-- Script to Activate the Carousel -->
    <script>
        $('.carousel').carousel({
            interval: 4000 //changes the speed
        })
    </script>
</body>

</html>
