var Usuario =
    {
        ValidarROL: function () {
            var valorCookie = Generica.ObtenerCookie();
            var rol = valorCookie.Rol;
            var x = document.getElementById('menuAdmin');
            if (rol == 2) {
                x.style.visibility = 'visible';
            }
        },
        TableClick: function () {
            $('tr').click(function () {
                var $row = $(this).children();
                $('#txtID').val($row[0].innerHTML);
                $('#txtCorreo').val($row[1].innerHTML);
                $('#selectTipoUsuarios2').val($row[3].innerHTML);
            });
        },
        SelectUsuariosPorRol: function () {
            var tipo = $('#selectTipoUsuarios').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax(
                {
                    url: "WebService.asmx/BuscarUsuarios",
                    type: "POST",
                    data: "{'TipoRol' : '" + tipo + "','Sesion':" + stringJsonSESION + "}",
                    //url: "http://localhost:64816/lista-usuarios/" +tipo,
                    dataType: "json",
                    contentType: "application/json; utf-8",
                    success: function (msg) {
                        var datos_usuarios = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                        $("#bodyid").empty();
                        if (datos_usuarios[0].Estado == 0) {
                            Generica.GenerarAlerta("Sesion Caducada", "warn")
                            alert("La sesion ha caducado.");
                            $.removeCookie('Verificador', { path: '/' });
                            window.location.href = "Home.aspx";
                        }
                        else {
                            $('#tbl-usuarios').append("<tbody id='bodyid'>");
                            for (var i = 0; i < datos_usuarios.length; i++) {
                                var identificador = datos_usuarios[i].Identificador;
                                var correo = datos_usuarios[i].Correo;
                                var nick = datos_usuarios[i].Nick;
                                var pwd = datos_usuarios[i].Password;
                                var rol = datos_usuarios[i].Rol;
                                var estatus = datos_usuarios[i].Estatus;

                                $('#tbl-usuarios').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Usuario.TableClick()'><td>" + identificador + "</td>" +
                                                             "<td>" + correo + "</td>" +
                                                             "<td>" + nick + "</td>" +
                                                             "<td>" + rol + "</td>" +
                                                             "</tr>");
                            }
                        }
                    },
                    error: function (result) {
                        
                    }

                });
        },
        SelectUsuarioPorID: function () {
            var id = $('#txtBuscar').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            if (id === "") {
                Generica.GenerarAlerta("Llena el campo para buscar.", "warn");
            }
            else {
                var objJsonUsuario = {
                    "Identificador": id
                }
                var objJsonSESION = {
                    "Token": Token,
                    "IdentificadorCredencial": idCredencial
                }
                var stringJsonSESION = JSON.stringify(objJsonSESION);
                var stringJsonUsuario = JSON.stringify(objJsonUsuario);
                var datos = "{'Usuario': " + stringJsonUsuario + ",'Sesion':" + stringJsonSESION + "}";
                $.ajax({
                    url: "WebService.asmx/BuscarUsuarioID",
                    data: datos,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; utf-8",
                    success: function (msg) {
                        if (msg.d.Estado == 1) {
                            $('#txtID').val(msg.d.Identificador);
                            $('#txtNick').val(msg.d.Nick);
                            $('#txtRol').val(msg.d.Rol);
                            $('#txtCorreo').val(msg.d.Correo);
                        } else if (msg.d.Estado == 2) {
                            Generica.GenerarAlerta("Error", "error");
                        }
                        else if (msg.d.Estado == 0) {
                            Generica.GenerarAlerta("Sesion Caducada", "warn");
                            $.removeCookie('Verificador', { path: '/' });
                            window.location.href = "Home.aspx";
                        }
                    },
                    error: function (msg) {
                        Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText);
                    }
                });
            }
        },
        UpdateUsuario: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var id = $('#txtID').val();
            var rol = $('#selectTipoUsuarios2').val();
            var correo = $('#txtCorreo').val();
            var objJsonUsuario = {
                "Identificador": id,
                "Rol": rol,
                "Correo": correo
            }
            var stringJsonUsuario = JSON.stringify(objJsonUsuario);
            var objJsonSESION = {
                "Token": Token,
                "Identificador": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos = "{'Usuario': " + stringJsonUsuario + ",'Sesion':" + stringJsonSESION + "}";
            $.ajax(
               {
                   url: "WebService.asmx/ModificarUsuario",
                   data: datos,
                   dataType: "json",
                   type: "POST",
                   contentType: "application/json; utf-8",
                   success: function (msg) {
                       if (msg.d == 1) {
                           Generica.GenerarAlerta("Usuario Modificado", "success");
                       } if (msg.d == 2) {
                           Generica.GenerarAlerta("Error", "error");
                       }
                       if (msg.d == 0) {
                           Generica.GenerarAlerta("Sesion Caducada", "warn");
                           $.removeCookie('Verificador', { path: '/' });
                           window.location.href = "Home.aspx";
                       }
                       Generica.Clear();
                   },
                   error: function (msg) {
                       Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText);
                   }
               });
        },
        DeleteUsuario: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var id = $('#txtID').val();
            var objJsonUsuario = {
                "Identificador": id,
            }
            var stringJsonUsuario = JSON.stringify(objJsonUsuario);
            var objJsonSESION = {
                "Token": Token,
                "Identificador": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos = "{'Usuario': " + stringJsonUsuario + ",'Sesion':" + stringJsonSESION + "}";
            $.ajax(
               {
                   url: "WebService.asmx/EliminarUsuario",
                   data: datos,
                   dataType: "json",
                   type: "POST",
                   contentType: "application/json; utf-8",
                   success: function (msg) {
                       if (msg.d == 1) {
                           Generica.GenerarAlerta("Usuario Eliminado", "success");
                       } else if (msg.d == 2) {
                           Generica.GenerarAlerta("Error", "error");
                       }
                       else if (msg.d == 0) {
                           Generica.GenerarAlerta("Sesion Caducada", "warn");
                           $.removeCookie('Verificador', { path: '/' });
                           window.location.href = "Home.aspx";
                       }
                       Generica.Clear();
                   },
                   error: function (msg) {
                       Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText)
                   }
               });
        },
        prueba: function () {
            
            var tab = $('#tbl-usuarios').val();
            var id = $('#txtBuscar').val();
            var nick = $('#txtNick').val(tab.Nick);
            //var rol = $('#txtRol').val();
        }
    }

