var Cita =
    {
        Validar: function (opt) {
            var validado = true;
            if (opt == 1) {
                if ($('#txtFecha').val().trim() == '' || $('#txtFecha').val().trim() == ' ') {
            
                    validado = false;
                }
                if ($('#cmbAparato').val() == '0') {
                
                    validado = false;
                }
                if ($('#cmb-horas').val() == '0') {
               
                    validado = false;
                }
                if (validado == true) {
                    Aparato.InsertarAparato();
                }
            }
            if (validado == false) {
                Generica.GenerarAlerta("¡Atención! Faltan campos por llenar", "error");
            }
            validado = true;
            if (opt == 2) {
                if ($('#txtFecha').val() == '' || $('#txtFecha').val().trim() == ' ') {
                  
                    validado = false;
                }
                if ($('#cmbAparato').val() == '0') {
                  
                    validado = false;
                }
                if ($('#cmb-horas').val() == '0') {
                 
                    validado = false;
                }
                if (validado == true) {
                    Aparato.InsertarAparato();
                   
                }
                if (validado == true) {
                    Aparato.InsertarAparato();
                }
            }
            if (validado == false) {
                Generica.GenerarAlerta("¡Atención! Faltan campos por llenar", "error");
            }
        },
        ConsultarCitasPendientes: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonCita =
                {
                    "IdentificadorRegistro": idCredencial
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos = "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}";
            $.ajax({
                url: "WebService.asmx/SelectCitasP",
                data: datos,
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    $('#bodyid').empty();
                    var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_citas[0].Estado == 0) {
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
                    }
                    else {
                        $('#tbl-CitasPendientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_citas.length; i++) {
                            var identificador = datos_citas[i].Identificador;
                            var FechaPlan = datos_citas[i].FechaPlan;
                            var Aparato = datos_citas[i].Aparato;
                            var Hora = datos_citas[i].Hora;
                            $('#tbl-CitasPendientes').append("<tr  class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Cita.TableClick2()'><td>" + identificador + "</td>" +
                                                         "<td>" + Aparato + "</td>" +
                                                         "<td>" + FechaPlan + "</td>" +
                                                         "<td>" + Hora + "</td></tr>");
                        }
                    }
                },
                error: function (msg) {
                    Generica.GenerarAlerta("ERROR" + msg.status + ' ' + msg.statusText, "error");
                }
            });
        },
        SelectCitasUsuarioFecha: function () {
            var fecha = $('#txtFecha').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonCita =
                {
                    "FechaPlan": fecha
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos =
            $.ajax({
                url: "WebService.asmx/SelectCitasUFecha",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    $('#bodyid').empty();
                    var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_citas[0].Estado == 0) {
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
 
                    }
                    else {
                        $('#tbl-CitasPendientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_citas.length; i++) {

                            var Identificador = datos_citas[i].Identificador;
                            var Nombre = datos_citas[i].NombrePaciente;
                            var Paterno = datos_citas[i].PaternoPaciente;
                            var Materno = datos_citas[i].MaternoPaciente;
                            var Aparato = datos_citas[i].Aparato;
                            var FechaPlan = datos_citas[i].FechaPlan;
                            var Hora = datos_citas[i].Hora;
                            var Registrador = datos_citas[i].NombreUsuario;

                            $('#tbl-CitasPendientes').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Cita.TableClick()'><td>" + Identificador + "</td>" +
                                                         "<td>" + Nombre + "</td>" +
                                                         "<td>" + Paterno + "</td>" +
                                                         "<td>" + Materno + "</td>" +
                                                         "<td>" + Aparato + "</td>" +
                                                         "<td>" + FechaPlan + "</td>" +
                                                         "<td>" + Hora + "</td>" +
                                                         "<td>" + Registrador + "</td></tr>");
                        }
                    }
                },
                error: function (msg) {
                    Generica.GenerarAlerta("ERROR " + msg.status + ' ' + msg.statusText, "error");
                }
            });
        },
        SelectCitasUsuarioOnLoad: function () {
            $('#chkBoxA').prop('checked', false);
            $('#chkBox').prop('checked', false);
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonCita =
                {
                    Identificador: 0001
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos =
            $.ajax({
                url: "WebService.asmx/SelectCitasUOnLoad",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    $('#bodyid').empty();
                    var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_citas[0].Estado == 0) {
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
                    }
                    else {
                        $('#tbl-CitasPendientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_citas.length; i++) {

                            var Identificador = datos_citas[i].Identificador;
                            var Nombre = datos_citas[i].NombrePaciente;
                            var Paterno = datos_citas[i].PaternoPaciente;
                            var Materno = datos_citas[i].MaternoPaciente;
                            var Aparato = datos_citas[i].Aparato;
                            var FechaPlan = datos_citas[i].FechaPlan;
                            var Hora = datos_citas[i].Hora;
                            var Registrador = datos_citas[i].NombreUsuario;

                            $('#tbl-CitasPendientes').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Cita.TableClick()'><td>" + Identificador + "</td>" +
                                                         "<td>" + Nombre + "</td>" +
                                                         "<td>" + Paterno + "</td>" +
                                                         "<td>" + Materno + "</td>" +
                                                         "<td>" + Aparato + "</td>" +
                                                         "<td>" + FechaPlan + "</td>" +
                                                         "<td>" + Hora + "</td>" +
                                                         "<td>" + Registrador + "</td></tr>");
                        }
                    }
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText, "")
                }
            });
        },
        SelectCitasUsuarioOnCheck: function () {
            $('#chkBoxA').prop('checked', false);
            $('#chkBoxP').prop('checked', false);
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonCita =
                {
                    Identificador: 0001
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos =
            $.ajax({
                url: "WebService.asmx/SelectCitasUOnCheck",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    $('#bodyid').empty();
                    var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_citas[0].Estado == 0) {
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    else {
                        $('#tbl-CitasPendientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_citas.length; i++) {

                            var Identificador = datos_citas[i].Identificador;
                            var Nombre = datos_citas[i].NombrePaciente;
                            var Paterno = datos_citas[i].PaternoPaciente;
                            var Materno = datos_citas[i].MaternoPaciente;
                            var Aparato = datos_citas[i].Aparato;
                            var FechaPlan = datos_citas[i].FechaPlan;
                            var Hora = datos_citas[i].Hora;
                            var Registrador = datos_citas[i].NombreUsuario;

                            $('#tbl-CitasPendientes').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Cita.TableClick()'><td>" + Identificador + "</td>" +
                                                         "<td>" + Nombre + "</td>" +
                                                         "<td>" + Paterno + "</td>" +
                                                         "<td>" + Materno + "</td>" +
                                                         "<td>" + Aparato + "</td>" +
                                                         "<td>" + FechaPlan + "</td>" +
                                                         "<td>" + Hora + "</td>" +
                                                         "<td>" + Registrador + "</td></tr>");
                        }
                    }
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText, "Error");
                }
            });
        },
        SelectCitasUsuarioOnCheckA: function () {
            $('#chkBox').prop('checked', false);
            $('#chkBoxP').prop('checked', false);
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonCita =
                {
                    Identificador: 0001
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos =
            $.ajax({
                url: "WebService.asmx/SelectCitasUOnCheckA",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    $('#bodyid').empty();
                    var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_citas[0].Estado == 0) {
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
                    }
                    else {
                        $('#tbl-CitasPendientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_citas.length; i++) {

                            var Identificador = datos_citas[i].Identificador;
                            var Nombre = datos_citas[i].NombrePaciente;
                            var Paterno = datos_citas[i].PaternoPaciente;
                            var Materno = datos_citas[i].MaternoPaciente;
                            var Aparato = datos_citas[i].Aparato;
                            var FechaPlan = datos_citas[i].FechaPlan;
                            var Hora = datos_citas[i].Hora;
                            var Registrador = datos_citas[i].NombreUsuario;

                            $('#tbl-CitasPendientes').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Cita.TableClick()'><td>" + Identificador + "</td>" +
                                                         "<td>" + Nombre + "</td>" +
                                                         "<td>" + Paterno + "</td>" +
                                                         "<td>" + Materno + "</td>" +
                                                         "<td>" + Aparato + "</td>" +
                                                         "<td>" + FechaPlan + "</td>" +
                                                         "<td>" + Hora + "</td>" +
                                                         "<td>" + Registrador + "</td></tr>");
                        }
                    }
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText, "Error");
                }
            });
        },
        SelectCitasUsuarioFechaMod: function () {
            var fecha = $('#txtFecha3').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var objJsonCita =
                {
                    "FechaPlan": fecha
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos =
            $.ajax({
                url: "WebService.asmx/SelectCitasUFecha",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    $('#bodyid').empty();
                    var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                    if (datos_citas[0].Estado == 0) {
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
                    }
                    else {
                        $('#tbl-CitasPendientes').append("<tbody id='bodyid'>");
                        for (var i = 0; i < datos_citas.length; i++) {

                            var Identificador = datos_citas[i].Identificador;
                            var Nombre = datos_citas[i].NombrePaciente;
                            var Paterno = datos_citas[i].PaternoPaciente;
                            var Materno = datos_citas[i].MaternoPaciente;
                            var Aparato = datos_citas[i].Aparato;
                            var FechaPlan = datos_citas[i].FechaPlan;
                            var Hora = datos_citas[i].Hora;
                            var Registrador = datos_citas[i].NombreUsuario;

                            $('#tbl-CitasPendientes').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Cita.TableClick()'><td>" + Identificador + "</td>" +
                                                         "<td>" + Nombre + "</td>" +
                                                         "<td>" + Paterno + "</td>" +
                                                         "<td>" + Materno + "</td>" +
                                                         "<td>" + Aparato + "</td>" +
                                                         "<td>" + FechaPlan + "</td>" +
                                                         "<td>" + Hora + "</td>" +
                                                         "<td>" + Registrador + "</td></tr>");
                        }
                    }
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error: " + msg.status + ' ' + msg.statusText, "error")
                }
            });
        },
        InsertCita: function () {
            
            var IdPaciente = $('#txtID').val();
            var IdAparato = $('#cmbAparato').val();
            var fecha = /*$('#datepicker').datepicker({ dateFormat: 'dd-mm-YYYY' }).val();*/ $('#txtFecha').val();
            var IdHora = $('#cmb-horas').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;

            var objJsonCita =
                {
                    "IdentificadorPaciente": IdPaciente,
                    "IdentificadorAparato": IdAparato,
                    "FechaPlan": fecha,
                    "IdentificadorHora": IdHora,
                    "IdentificadorRegistro": idCredencial
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/InsertCitaUsuario",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 1) {
                        Generica.GenerarAlerta("Cita agendada correctamente", "success")
                    }
                    else if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                    } else if (msg.d == 2) {
                        Generica.GenerarAlerta("Error", "error")
                    }
                    Generica.Clear();
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error :" + msg.status + ' ' + msg.statusText, "error")
                }
            });
        },
        InsertCitaPaciente: function () {
            var IdAparato = $('#cmbAparato').val();
            var fecha = $('#txtFecha').val();
            var IdHora = $('#cmb-horas').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;

            var objJsonCita =
                {
                    "IdentificadorAparato": IdAparato,
                    "FechaPlan": fecha,
                    "IdentificadorHora": IdHora,
                    "IdentificadorRegistro": idCredencial
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/InsertCitaPaciente",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 1) {
                        Generica.GenerarAlerta("Cita agendada con éxito.", "success")
                    }
                    else if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                    } else if (msg.d == 2) {
                        Generica.GenerarAlerta("Error", "error")
                    }
                    Generica.Clear();
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error : " + msg.status + ' ' + msg.statusText, "error")
                }
            });
        },
        ObtenerHoras: function () {
            
            var fecha = $('#txtFecha').val();
            if (fecha == "") {
                Generica.GenerarAlerta("Igresa una Fecha Primero", "warn")
            }
            else {

                var aparato = $('#cmbAparato').val();
                var valorCookie = Generica.ObtenerCookie();
                var Token = valorCookie.Token;
                var idCredencial = valorCookie.Credencial;
                var objJsonCita = {
                    "FechaPlan": fecha,
                    "IdentificadorAparato": aparato
                }
                var stringJsonCita = JSON.stringify(objJsonCita);
                var objJsonSESION = {
                    "Token": Token,
                    "IdentificadorCredencial": idCredencial
                }
                var stringJsonSESION = JSON.stringify(objJsonSESION);
                $.ajax({
                    url: "WebService.asmx/ConsultarHoras",
                    data: "{'Cita':" + stringJsonCita + ",'Sesion':" + stringJsonSESION + "}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; utf-8",
                    success: function (msg) {
                        var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                        if (datos_citas[0].Estado == 0) {
                            $.removeCookie('Verificador', { path: '/' });
                            window.location.href = "Home.aspx";
                            Generica.GenerarAlerta("Sesion Caducada", "warn")
                        }
                        else {

                            $('#cmb-horas').empty();
                            $('#cmb-horas').append("<option>" + "..." + "</option>");

                            for (var i = 0; i < datos_citas.length; i++) {
                                if (datos_citas[i].EstadoHora == 0) {
                                    $('#cmb-horas').append("<option disabled='disabled' style='background-color:red;color:white;' value=" + 0 + ">" + datos_citas[i].Hora + "</option>");
                                } else {
                                    $('#cmb-horas').append("<option value=" + datos_citas[i].Identificador + ">" + datos_citas[i].Hora + "</option>");
                                }
                            }
                        }
                    },
                    error: function (msg) {
                        Generica.GenerarAlerta("Error :" + msg.status + ' ' + msg.statusText, "")
                    }
                });
            }


        },
        ObtenerHorasM: function () {
            var fecha = $('#txtFecha3').val();
            if (fecha == "") {
                Generica.GenerarAlerta("Ingresa una fecha primero", "Error");
            }
            else {

                var aparato = $('#cmbAparato').val();
                var valorCookie = Generica.ObtenerCookie();
                var Token = valorCookie.Token;
                var idCredencial = valorCookie.Credencial;
                var objJsonCita = {
                    "FechaPlan": fecha,
                    "IdentificadorAparato": aparato
                }
                var stringJsonCita = JSON.stringify(objJsonCita);
                var objJsonSESION = {
                    "Token": Token,
                    "IdentificadorCredencial": idCredencial
                }
                var stringJsonSESION = JSON.stringify(objJsonSESION);
                $.ajax({
                    url: "WebService.asmx/ConsultarHoras",
                    data: "{'Cita':" + stringJsonCita + ",'Sesion':" + stringJsonSESION + "}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; utf-8",
                    success: function (msg) {
                        var datos_citas = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d;
                        if (datos_citas[0].Estado == 0) {
                            $.removeCookie('Verificador', { path: '/' });
                            window.location.href = "Home.aspx";
                            Generica.GenerarAlerta("Sesion Caducada", "warn")
                        }
                        else {

                            $('#cmb-horas').empty();
                            $('#cmb-horas').append("<option>" + "..." + "</option>");

                            for (var i = 0; i < datos_citas.length; i++) {
                                if (datos_citas[i].EstadoHora == 0) {
                                    $('#cmb-horas').append("<option disabled='disabled' style='background-color:red;color:white;' value=" + 0 + ">" + datos_citas[i].Hora + "</option>");
                                } else {
                                    $('#cmb-horas').append("<option value=" + datos_citas[i].Identificador + ">" + datos_citas[i].Hora + "</option>");
                                }
                            }
                        }
                    },
                    error: function (msg) {
                        Generica.GenerarAlerta("Error :" + msg.status + ' ' + msg.statusText, "");
                    }
                });
            }


        },
        UpdateCita: function () {
            var IdCita = $('#txtID').val();
            var IdAparato = $('#cmbAparato').val();
            var fecha = $('#txtFecha3').val();
            var IdHora = $('#cmb-horas').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;

            var objJsonCita =
                {
                    "Identificador": IdCita,
                    "IdentificadorAparato": IdAparato,
                    "FechaPlan": fecha,
                    "IdentificadorHora": IdHora,
                    "IdentificadorRegistro": idCredencial
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/UpdateCitaUsuario",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 1) {
                        Generica.GenerarAlerta("Cita modificada con éxito", "success");
                    }
                    else if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn");
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                    } else if (msg.d == 2) {
                        Generica.GenerarAlerta("Error", "error")
                    }
                    Generica.Clear();
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error :" + msg.status + ' ' + msg.statusText, "");
                }
            });
        },
        DeleteCita: function () {
            var IdCita = $('#txtID').val();
            var IdAparato = $('#cmbAparato').val();
            var fecha = $('#txtFecha3').val();
            var IdHora = $('#cmb-horas').val();
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;

            var objJsonCita =
                {
                    "Identificador": IdCita,
                }
            var stringJsonCITA = JSON.stringify(objJsonCita);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax({
                url: "WebService.asmx/DeleteCita",
                data: "{'Cita':" + stringJsonCITA + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d == 1) {
                        Generica.GenerarAlerta("Cita eliminada con éxito", "success")                        
                    }
                    else if (msg.d == 0) {
                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('Verificador', { path: '/' });
                        window.location.href = "Home.aspx";
                    } else if (msg.d == 2) {
                        Generica.GenerarAlerta("Error", "error")
                    }
                    Generica.Clear();
                },
                error: function (msg) {
                    Generica.GenerarAlerta("Error :" + msg.status + ' ' + msg.statusText, "error")
                }
            });
        },
        TableClick: function () {
            $('tr').click(function () {
                var $row = $(this).children();
                $('#txtID').val($row[0].innerHTML);
                $('#txtNombre').val($row[1].innerHTML);
                $('#txtPaterno').val($row[2].innerHTML);
                $('#txtMaterno').val($row[3].innerHTML);
                $('#txtAparato').val($row[4].innerHTML);
                $('#txtFecha2').val($row[5].innerHTML);
                $('#txtFecha3').val($row[5].innerHTML);
                $('#txtHora').val($row[6].innerHTML);
                $('#txtRegistrador').val($row[7].innerHTML);

                $('#cmbAparato').hide();
                $('#cmb-horas').hide();
                $('#divHide').hide();
                $('#btnModificar').show();
            });
        },
        TableClick2: function () {
            $('tr').click(function () {
                var $row = $(this).children();
                $('#txtID').val($row[0].innerHTML);
                $('#txtAparato').val($row[1].innerHTML);
                $('#txtFecha2').val($row[2].innerHTML);
                $('#txtHora').val($row[3].innerHTML);
                $('#cmbAparato').hide();
                $('#cmb-horas').hide();
                $('#divHide').hide();
                $('#btnModificar').show();
            });
        },
        Modificar: function () {
            $('#divHide').show();
            $('#cmbAparato').show();
            $('#cmb-horas').show();
            $('#btnModificar').hide();
        }
    }