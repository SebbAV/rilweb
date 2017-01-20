var Paciente =
    {
        Validar: function (opt) {
            var validado = true;
            if (opt == 1) {
                if ($('#txtNombre').val().trim() == '' || $('#txtNombre').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtPaterno').val().trim() == '' || $('#txtPaterno').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtMaterno').val().trim() == '' || $('#txtMaterno').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtTelefono').val().trim() == '' || $('#txtTelefono').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtFechaNac').val().trim() == '' || $('#txtFechaNac').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtDomicilio').val().trim() == '' || $('#txtDomicilio').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtCp').val().trim() == '' || $('#txtCp').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtRfc').val().trim() == '' || $('#txtRfc').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtCorreo').val().trim() == '' || $('#txtCorreo').val().trim() == ' ') {
                    validado = false;
                }

                if (validado == false) {
                    Generica.GenerarAlerta("No dejar campos vacios", "error")
                }
                if (validado == true) {
                    Paciente.insertPaciente();
                }
            }
            validado = true;
            if (opt == 2) {
                if ($('#txtID').val().trim() == '' || $('#txtID').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtNombreM').val().trim() == '' || $('#txtNombreM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtPaternoM').val().trim() == '' || $('#txtPaternoM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtMaternoM').val().trim() == '' || $('#txtMaternoM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtTelefonoM').val().trim() == '' || $('#txtTelefonoM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtFechaNacM').val().trim() == '' || $('#txtFechaNacM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtDomicilioM').val().trim() == '' || $('#txtDomicilioM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtCpM').val().trim() == '' || $('#txtCpM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtRfcM').val().trim() == '' || $('#txtRfcM').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtCorreoM').val().trim() == '' || $('#txtCorreoM').val().trim() == ' ') {
                    validado = false;
                }
                if (validado == true) {
                    Estudio.updateEstudio();
                }
            }
        },
        selectPaciente: function () {


            var valorCookie = Generica.ObtenerCookie();
            var token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var nombre = $('#txtNombre').val();

            var objJsonPACIENTE = {
                "Nombre": nombre
            }
            var stringJsonPACIENTE = JSON.stringify(objJsonPACIENTE);
            var objJsonSESION = {
                "token": token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/ConsultaPaciente",
                data: "{'Paciente':" + stringJsonPACIENTE + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    //Operador ternario: forma corta de un if
                    var datos_paciente = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_paciente[0].Estado == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        window.location.href = "Home.aspx";
                    }
                    else if (datos_paciente[0].Estado == 1) {
                        $("#bodyid").empty();
                        $('#tblPacientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_paciente.length; i++) {
                            var identificador = datos_paciente[i].Identificador;
                            var nombre = datos_paciente[i].Nombre;
                            var paterno = datos_paciente[i].Paterno;
                            var materno = datos_paciente[i].Materno;
                            var telefono = datos_paciente[i].Telefono;
                            var domicilio = datos_paciente[i].Domicilio;
                            var cp = datos_paciente[i].CodigoPostal;
                            var rfc = datos_paciente[i].RFC;
                            var fechaNacimiento = datos_paciente[i].FechaNacimiento;
                            //Codigo para poner fecha JSON en formato normal.

                            var correo = datos_paciente[i].Correo;

                            $('#tblPacientes').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Paciente.TableClickCompleto()'><td>" + identificador + "</td>"
                                                        + "<td>" + nombre + "</td>"
                                                        + "<td>" + paterno + "</td>"
                                                        + "<td>" + materno + "</td>"
                                                        + "<td>" + telefono + "</td>"
                                                        + "<td>" + domicilio + "</td>"
                                                        + "<td>" + cp + "</td>"
                                                        + "<td>" + rfc + "</td>"
                                                        + "<td>" + fechaNacimiento + "</td>"
                                                        + "<td>" + correo + "</td></tr>");
                        }
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error :" + result.status + ' ' + result.status, "error")
                }
            });

        },
        selectPacienteCorto: function () {


            var valorCookie = Generica.ObtenerCookie();
            var token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var nombre = $('#txtNombre').val();

            var objJsonPACIENTE = {
                "Nombre": nombre
            }
            var stringJsonPACIENTE = JSON.stringify(objJsonPACIENTE);
            var objJsonSESION = {
                "token": token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/ConsultaPaciente",
                data: "{'Paciente':" + stringJsonPACIENTE + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    //Operador ternario: forma corta de un if
                    var datos_paciente = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_paciente[0].Estado == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "error");
                        window.location.href = "Home.aspx";
                    }
                    else if (datos_paciente[0].Estado == 1) {
                        //    $('#tblPacientes').empty();
                        $("#bodyid").empty();
                        $('#tblPacientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_paciente.length; i++) {
                            var identificador = datos_paciente[i].Identificador;
                            var nombre = datos_paciente[i].Nombre;
                            var paterno = datos_paciente[i].Paterno;
                            var materno = datos_paciente[i].Materno;
                            var correo = datos_paciente[i].Correo;

                            $('#tblPacientes').append("<tr class='gradeX odd' role='row' onclick='Paciente.TableClick()'><td>" + identificador + "</td>"
                                                        + "<td>" + nombre + "</td>"
                                                        + "<td>" + paterno + "</td>"
                                                        + "<td>" + materno + "</td>"
                                                        + "<td>" + correo + "</td></tr>");
                        }
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error :" + result.status + ' ' + result.statusText, "")

                }
            });

        },
        getPaciente: function () {

            var id = $('#txtID').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            if (id == "") {
                Generica.GenerarAlerta("Ingresa un correo para obtener paciente.", "warn")
            }
            var objJsonPACIENTE = {
                "Correo": id
            }
            var stringJsonPACIENTE = JSON.stringify(objJsonPACIENTE);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/obtenerPaciente",
                data: "{'Paciente':" + stringJsonPACIENTE + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d.Estado == 1) {
                        $('#txtid').val(msg.d.Identificador);
                        $('#txtNombre2').val(msg.d.Nombre);
                        $('#txtPaterno').val(msg.d.Paterno);
                        $('#txtMaterno').val(msg.d.Materno);
                        $('#txtTelefono').val(msg.d.Telefono);
                        $('#txtFechaNacimiento').val(msg.d.FechaNacimiento);
                        $('#txtDomicilio').val(msg.d.Domicilio);
                        $('#txtCp').val(msg.d.CodigoPostal);
                        $('#txtRfc').val(msg.d.RFC);
                    } else if (msg.d.Estado == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
                        alert("La sesion ha caducado.");
                        window.location.href = "Home.aspx";
                    }
                    else if (msg.d.Estado == 2) {
                        Generica.GenerarAlerta("No existe", "error")
                    }
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error: " + result.status + ' ' + result.statusText, "error")
                }
            });
        },
        updatePaciente: function () {

            var id = $('#txtID').val();
            var nombre = $('#txtNombreM').val();
            var paterno = $('#txtPaternoM').val();
            var materno = $('#txtMaternoM').val();
            var telefono = $('#txtTelefonoM').val();
            var fechaNacimiento = $('#txtFechaNacM').val();
            var domicilio = $('#txtDomicilioM').val();
            var codigoPostal = $('#txtCpM').val();
            var rfc = $('#txtRfcM').val();
            var correo = $('#txtCorreoM').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonPACIENTE =
             {
                 "Identificador": id,
                 "Nombre": nombre,
                 "Paterno": paterno,
                 "Materno": materno,
                 "Telefono": telefono,
                 "FechaNacimiento": fechaNacimiento,
                 "Domicilio": domicilio,
                 "CodigoPostal": codigoPostal,
                 "RFC": rfc,
                 "Correo": correo
             }
            var stringJsonPACIENTE = JSON.stringify(objJsonPACIENTE);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/modificarPaciente",
                data: "{'Paciente':" + stringJsonPACIENTE + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('MyFirstCookieISSC', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    else if (msg.d == 1) {
                        Generica.GenerarAlerta("Paciente actualizado exitosamente", "success")
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }
                    Generica.Clear();
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error: " + result.status + ' ' + result.statusText, "")
                }
            });
        },
        deletePaciente: function () {
            var id = $('#txtID').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonPaciente =
                {
                    "Identificador": id
                }
            var stringJsonPACIENTE = JSON.stringify(objJsonPaciente);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/eliminarPaciente",
                data: "{'Paciente':" + stringJsonPACIENTE + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('MyFirstCookieISSC', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    else if (msg.d == 1) {
                        Generica.GenerarAlerta("Paciente eliminado", "success")
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }

                    Generica.Clear();
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error :" + result.status + ' ' + result.statusText, "error")
                }
            });

        },
        insertPaciente: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;

            var idCredencial = valorCookie.Credencial;
            var Nombre = $('#txtNombre').val();
            var Paterno = $('#txtPaterno').val();
            var Materno = $('#txtMaterno').val();
            var Telefono = $('#txtTelefono').val();
            var FechaNacimiento = $('#txtFechaNac').val();
            var Domicilio = $('#txtDomicilio').val();
            var CodigoPostal = $('#txtCp').val();
            var Rfc = $('#txtRfc').val();
            var Correo = $('#txtCorreo').val();

            var objJsonPACIENTE = {
                "Nombre": Nombre,
                "Paterno": Paterno,
                "Materno": Materno,
                "Telefono": Telefono,
                "FechaNacimiento": FechaNacimiento,
                "Domicilio": Domicilio,
                "CodigoPostal": CodigoPostal,
                "RFC": Rfc,
                "Correo": Correo,
            }
            var stringJsonPACIENTE = JSON.stringify(objJsonPACIENTE);



            var objJsonSESION = {
                "token": Token,
                "idCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/RegistroPaciente",
                data: "{'Paciente':" + stringJsonPACIENTE + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('MyFirstCookieISSC', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    if (msg.d == 1) {
                        Generica.GenerarAlerta("Se guardó correctamente", "success")
                    } else if (msg.d == 2) {
                        Generica.GenerarAlerta("Error", "error")
                    }
                    Generica.Clear();
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error : " + result.status + ' ' + result.statusText, "error")
                }
            });
        },
        TableClick: function () {
            $('tr').click(function () {
                var $row = $(this).children();
                $('#txtID').val($row[0].innerHTML);
                $('#txtPaciente').val($row[1].innerHTML);
                $('#txtPaterno').val($row[2].innerHTML);
                $('#txtMaterno').val($row[3].innerHTML);
            });
        },
        TableClickCompleto: function () {
            $('tr').click(function () {
                var $row = $(this).children();
                $('#txtID').val($row[0].innerHTML);
                $('#txtNombreM').val($row[1].innerHTML);
                $('#txtPaternoM').val($row[2].innerHTML);
                $('#txtMaternoM').val($row[3].innerHTML);
                $('#txtTelefonoM').val($row[4].innerHTML);
                $('#txtDomicilioM').val($row[5].innerHTML);
                $('#txtCpM').val($row[6].innerHTML);
                $('#txtRfcM').val($row[7].innerHTML);
                $('#txtFechaNacM').val($row[8].innerHTML);
                $('#txtCorreoM').val($row[9].innerHTML);
            });
        },


    }
