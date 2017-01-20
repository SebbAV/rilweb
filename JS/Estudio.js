var Estudio =
    {

        Validar: function (opt) {

            var validado = true;
            if (opt == 1) {
                if ($('#txtTipo').val().trim() == '' || $('#txtTipo').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtCosto').val().trim() == '' || $('#txtCosto').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#cmbAparato').val() == '0') {
                    validado = false;
                }
                if (validado == false) {
                    Generica.GenerarAlerta("No dejar campos vacios", "error")
                }
                if (validado == true) {
                    Estudio.InsertarEstudio();
                }
            }
            validado = true;
            if (opt == 2) {
                if ($('#txtIDEstudio').val() == '' || $('#txtIDEstudio').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtTipo2').val().trim() == '' || $('#txtTipo2').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#txtCosto2').val().trim() == '' || $('#txtCosto2').val().trim() == ' ') {

                    validado = false;
                }
                if (validado == false) {
                    Generica.GenerarAlerta("No dejar campos vacios", "error")
                }
                if (validado == true) {
                    Estudio.updateEstudio();
                }
            }
        },
        //Validacion Lista.
        InsertarEstudio: function () {
            var valorCookie = Generica.ObtenerCookie();
            var token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var tipo = $('#txtTipo').val();
            var costo = $("#txtCosto").val();
            var aparato = $("#cmbAparato").val();
            var indicaciones = $('#taIndicaciones').val();
            var objJsonESTUDIO = {
                "Tipo": tipo,
                "Costo": costo,
                "Aparato": aparato,
                "Indicacion": indicaciones
            }
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            var objJsonSESION = {
                "Token": token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/insertarEstudio",
                data: "{'Estudio':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}",
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
                        Generica.GenerarAlerta("Estudio insertado con exito", "success")
                        Estudio.SelectEstudioTable();
                        Generica.Clear();
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }

                },
                error: function (result) {
                    Generica.GenerarAlerta("ERROR " + result.status + ' ' + result.statusText, "error")
                }
            });
        },
        //Validacion Lista
        //Al parecer listo
        SelectEstudio: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var id = $("#cmbAparato").val()

            var objJsonESTUDIO = {
                "idAparato": id
            }
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/selectEstudio",
                data: "{'Aparato':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    var datos_estudios = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                    if (datos_estudios[0].Estado == 0) {

                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('MyFirstCookieISSC', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    else if (datos_estudios[0].Estado == 1) {
                        $('#cmbEstudio').empty();
                        $('#cmbEstudio').append("<option value=" + 0 + ">" + "..." + "</option>");
                        for (var i = 0; i < datos_estudios.length; i++) {
                            var id = datos_estudios[i].Id;
                            var Tipo = datos_estudios[i].Tipo;
                            $('#cmbEstudio').append("<option value=" + id + ">" + Tipo + "</option>")
                        }
                    }
                    else {
                        Generica.GenerarAlerta("Error de Conexión", "error")
                    }
                },
                error: function (result) {
                    Generica.GenerarAlerta("ERROR " + result.status + ' ' + result.statusText, "error")
                }
            });
        },
        SelectEstudioCosto: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var id = $("#cmbEstudio").val()

            var objJsonESTUDIO = {
                "Id": id
            }
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/selectCosto",
                data: "{'Estudio':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {

                    if (msg.d.Estado == 0) {

                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('MyFirstCookieISSC', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    else if (msg.d.Estado == 1) {
                        var costo = msg.d.Costo
                        $('#txtCosto').val(costo);
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }
                },
                error: function (result) {
                    Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "error")
                }
            });
        },
        //Validacion terminada
        //Al parecer listo.
        SelectEstudioTable: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax(
           {
               url: "WebService.asmx/ConsultaEstudios",
               data: "{'Sesion':" + stringJsonSESION + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; utf-8",
               success: function (msg) {

                   var datos_estudios = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                   $("#bodyidestudios").empty();
                   if (datos_estudios[0].Estado == 0) {

                       Generica.GenerarAlerta("Sesion Caducada", "warn")
                       $.removeCookie('MyFirstCookieISSC', { path: '/' });
                       window.location.href = "Home.aspx";
                   }
                   else if (datos_estudios[0].Estado == 1) {
                       $('#tblEstudios').append("<tbody id='bodyidestudios'>");
                       for (var i = 0; i < datos_estudios.length; i++) {
                           var id = datos_estudios[i].Id;
                           var tipo = datos_estudios[i].Tipo;
                           var costo = datos_estudios[i].Costo;
                           var idAparato = datos_estudios[i].idAparato;
                           var nombreAparato = datos_estudios[i].nombreAparato;
                           $('#tblEstudios').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal2' onclick='Estudio.TableClick()'><td>" + id + "</td>" +
                                                        "<td>" + tipo + "</td>" +
                                                        "<td>" + costo + "</td> " +
                                                     //   "<td>" + idAparato + "</td> " +
                                                        "<td>" + nombreAparato + "</td> " +
                                                        " </tr>");
                       }

                   }
                   else {
                       Generica.GenerarAlerta("Error", "error")
                   }
               },
               error: function (result) {
                   Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "error")
               }
           });
        },
        SelectPrecio: function () {
            var costo = $("#cmbEstudio").val()
            $('#txtCosto').val(costo);
        },

        updateEstudio: function () {

            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var idEstudio = $('#txtIDEstudio').val();
            var tipo = $('#txtTipo2').val();
            var costo = $('#txtCosto2').val();
            var indicaciones = $('#taIndicaciones2').val();
            var objJsonESTUDIO = {
                "Id": idEstudio,
                "tipo": tipo,
                "costo": costo,
                "Indicacion": indicaciones
            }
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax(
           {
               url: "WebService.asmx/UpdateEstudios",
               data: "{'Estudio':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}",
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
                       Generica.GenerarAlerta("Estudio actualizado con extio", "success")
                       Generica.Clear();
                       Estudio.SelectEstudioTable();
                   }
                   else {
                       Generica.GenerarAlerta("Error", "error")
                   }
               },
               error: function (result) {
                   Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "")
               }
           });
        },
        deleteEstudio: function () {
            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var idEstudio = $('#txtIDEstudio').val();
            var objJsonESTUDIO = {
                "Id": idEstudio,
            }
            var objJsonSESION = {
                "Token": Token,
                "IdentificadorCredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            $.ajax(
           {
               url: "WebService.asmx/DeleteEstudios",
               data: "{'Estudio':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}",
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
                       Generica.GenerarAlerta("Estudio borrado con exito", "success")
                       Generica.Clear();
                   }
                   else {
                       Generica.GenerarAlerta("Error", "error")
                   }
               },
               error: function (result) {
                   Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "")
               }
           });
        },
        TableClick: function () {
            $('tr').click(function () {
                var $row = $(this).children();
                $('#txtIDEstudio').val($row[0].innerHTML);
                $('#txtTipo2').val($row[1].innerHTML);
                $('#txtCosto2').val($row[2].innerHTML);
            });
        },

        //--------------------------------------------------DETALLES ESTUDIO----------------------------------------------------------------------------------
        ValidarDetalles: function (opt) {
            var validado = true;
            if (opt == 1) {
                if ($('#txtID').val() == '' || $('#txtID').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#cmbAparato').val() == '0') {
                    validado = false;
                }
                if ($('#txtAportacion').val() == '' || $('#txtAportacion').val().trim() == ' ') {
                    validado = false;
                }
                if ($('#cmbEstudio').val() == '0') {
                    validado = false;
                }
                if (validado == false) {
                    Generica.GenerarAlerta("No dejar campos vacios", "error")
                }
                if (validado == true) {
                    Estudio.InsertarRegistroEstudio()
                }
            }
            validado = true;
            if (opt == 2) {
                if ($('#txtID2').val() == '') {
                    validado = false;
                }
                if ($('#txtAportacion2').val() == '') {
                    validado = false;
                }
                if ($('#cmbEstudio2').val() == '0') {
                    validado = false;
                }
                if (validado == false) {
                    Generica.GenerarAlerta("No dejar campos vacios", "error")
                }
                if (validado == true) {
                    Estudio.updateEstudio();
                }
            }
        },
        InsertarRegistroEstudio: function () {

            var valorCookie = Generica.ObtenerCookie();
            var token = valorCookie.Token;
            var idCredencial = valorCookie.Credencial;
            var Paciente = $('#txtID').val();
            var Aporte = $('#txtAportacion').val();
            var Estudio = $("#cmbEstudio").val();
            var objJsonESTUDIO = {

                "idEstudio": Estudio,
                "idPaciente": Paciente,
                "idEmpleado": idCredencial,
                "Aporte": Aporte,
            }
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            var objJsonSESION = {
                "token": token,
                "identificadorcredencial": idCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);

            $.ajax({
                url: "WebService.asmx/insertarDetallesEst",
                data: "{'DetalleEstudio':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
                    if (msg.d.Estado == 0) {

                        Generica.GenerarAlerta("Sesion Caducada", "warn")
                        $.removeCookie('MyFirstCookieISSC', { path: '/' });
                        window.location.href = "Home.aspx";
                    }
                    else if (msg.d.Estado == 1) {
                        Generica.GenerarAlerta("Estudio insertado con exito", "success")
                        Generica.Clear();
                    }
                    else {
                        Generica.GenerarAlerta("Error", "error")
                    }

                },
                error: function (result) {
                    Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "error")
                }
            });
        },
        SelectRegistroEstudio: function () {

            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            if ($('#chkEstudios').is(':checked')) {
                var tipo = 1
            }
            else {
                var tipo = 2
            }

            var total = 0;
            var objJsonSESION = {
                "token": Token,
                "identificadorcredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            $.ajax(
           {
               url: "WebService.asmx/ConsultaDetallesEstudios",
               data: "{'Tipo':" + tipo + ",'Sesion':" + stringJsonSESION + "}",
               dataType: "json",
               type: "POST",
               contentType: "application/json; utf-8",
               success: function (msg) {
                   debugger;
                   var datos_detalles = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                   $("#bodyid").empty();
                   if (datos_detalles[0].Estado == 0) {

                       Generica.GenerarAlerta("Sesion Caducada", "warn")
                       $.removeCookie('MyFirstCookieISSC', { path: '/' });
                       window.location.href = "Home.aspx";
                   }
                   else if (datos_detalles[0].Estado == 1) {
                       $('#tbl-detalles').append("<tbody id='bodyid'>");
                       for (var i = 0; i < datos_detalles.length; i++) {
                           var id = datos_detalles[i].idDetalle;
                           var nombre = datos_detalles[i].nombre;
                           var paterno = datos_detalles[i].paterno;
                           var materno = datos_detalles[i].materno;
                           var tipo = datos_detalles[i].tipoEstudio;
                           var nombreApa = datos_detalles[i].nombreAparato;
                           var costo = datos_detalles[i].costo;
                           var aportacion = datos_detalles[i].aportacion;
                           var nombreEmp = datos_detalles[i].nombreEmpleado;
                           var fecha = datos_detalles[i].fecha;
                           total = parseFloat(total) + parseFloat(aportacion);
                           $('#tbl-detalles').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Estudio.TableClick()'><td>" + id + "</td>" +
                                                        "<td>" + nombre + "</td>" +
                                                        "<td>" + paterno + "</td> " +
                                                        "<td>" + materno + "</td> " +
                                                        "<td>" + tipo + "</td> " +
                                                        "<td>" + nombreApa + "</td> " +
                                                        "<td>" + aportacion + "</td> " +
                                                        "<td>" + nombreEmp + "</td> " +
                                                        "<td>" + fecha + "</td> " +
                                                        " </tr>");

                       }
                       $('#tbl-detalles').append("<tr><td>" + "Total Aportación: " + "</td><td>" + total + "</td></tr>");
                   }
                   else {
                       Generica.GenerarAlerta("Error", "error")
                   }

               },
               error: function (result) {
                   Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "error")
               }
           });
        },

        SelectRegistroEstudioFecha: function () {

            var valorCookie = Generica.ObtenerCookie();
            var Token = valorCookie.Token;
            var IdCredencial = valorCookie.Credencial;
            var fecha = $('#txtFecha').val();
            var d = new Date(fecha);
            Date.prototype.yyyymmdd = function () {
                var mm = this.getMonth() + 1; // getMonth() is zero-based
                var dd = this.getDate();

                return [this.getFullYear(),
                        (dd > 9 ? '' : '0') + dd,
                          (mm > 9 ? '' : '0') + mm
                ].join('-');
            };
            d = d.yyyymmdd();
            debugger;
            var total = 0;
            var objJsonESTUDIO = {

                "FechaEstudio": d,

            }
            var stringJsonESTUDIO = JSON.stringify(objJsonESTUDIO);
            var objJsonSESION = {
                "token": Token,
                "identificadorcredencial": IdCredencial
            }
            var stringJsonSESION = JSON.stringify(objJsonSESION);
            var datos = "{'DetalleEstudio':" + stringJsonESTUDIO + ",'Sesion':" + stringJsonSESION + "}";
            $.ajax(
           {

               url: "WebService.asmx/BuscarDetallesEstudios",
               data: datos,
               dataType: "json",
               type: "POST",
               contentType: "application/json; utf-8",
               success: function (msg) {

                   var datos_detalles = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                   var total = 0;
                   $("#bodyid").empty();
                   $('#tbl-detalles').append("<tbody id='bodyid'>");
                   for (var i = 0; i < datos_detalles.length; i++) {
                       var id = datos_detalles[i].idDetalle;
                       var nombre = datos_detalles[i].nombre;
                       var paterno = datos_detalles[i].paterno;
                       var materno = datos_detalles[i].materno;
                       var tipo = datos_detalles[i].tipoEstudio;
                       var nombreApa = datos_detalles[i].nombreAparato;
                       var costo = datos_detalles[i].costo;
                       var aportacion = datos_detalles[i].aportacion;
                       var nombreEmp = datos_detalles[i].nombreEmpleado;
                       var fecha = datos_detalles[i].fecha;
                       total = parseFloat(total) + parseFloat(aportacion);
                       $('#tbl-detalles').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Estudio.TableClick()'><td>" + id + "</td>" +
                                                    "<td>" + nombre + "</td>" +
                                                    "<td>" + paterno + "</td> " +
                                                    "<td>" + materno + "</td> " +
                                                    "<td>" + tipo + "</td> " +
                                                    "<td>" + nombreApa + "</td> " +
                                                    "<td>" + aportacion + "</td> " +
                                                    "<td>" + nombreEmp + "</td> " +
                                                    "<td>" + fecha + "</td> " +
                                                    " </tr>");

                   }
                   $('#tbl-detalles').append("<tr><td>" + "Total Aportación: " + "</td><td>" + total + "</td></tr>");
               },
               error: function (result) {
                   Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "error")
               }
           });
        },
    }

