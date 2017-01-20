
var Aparato = {
    Validar: function (opt) {

        var validado = true;
        if (opt == 1) {
            if ($('#txtAparato').val() == '' || $('#txtAparato').val().trim() == ' ') {
                validado = false;
            }
            if ($('#txtModelo').val().trim() == '' || $('#txtModelo').val().trim() == ' ') {
                validado = false;
            }
            if ($('#txtObservaciones').val().trim() == '' || $('#txtObservaciones').val().trim() == ' ') {
                validado = false;
            }
            if (validado == false) {
                Generica.GenerarAlerta("No dejar campos vacios", "error")
            }
            if (validado == true) {
                Aparato.InsertarAparato();


            }
        }
        validado = true;
        if (opt == 2) {
            if ($('#txtAparato2').val().trim() == '' || $('#txtAparato2').val().trim() == ' ') {
                validado = false;
            }
            if ($('#txtModelo2').val().trim == '' || $('#txtModelo2').val().trim == ' ') {
                validado = false;
            }
            if ($('#txtObservaciones2').val().trim() == '' || $('#txtObservaciones2').val().trim() == ' ') {
                validado = false;
            }
            if (validado == false) {
                Generica.GenerarAlerta("No dejar campos vacios", "error")
            }
            if (validado == true) {
                Aparato.UpdateAparato();

            }
        }
    },
    InsertarAparato: function () {
        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var IdCredencial = valorCookie.Credencial;
        var aparato = $('#txtAparato').val();
        var modelo = $("#txtModelo").val();
        var observaciones = $("#txtObservaciones").val();
        var objJsonAPARATO = {
            "Descripcion": aparato,
            "Modelo": modelo,
            "Observaciones": observaciones

        }
        var stringJsonAPARATO = JSON.stringify(objJsonAPARATO);
        var objJsonSESION = {
            "Token": token,
            "IdentificadorCredencial": IdCredencial
        }
        var stringJsonSESION = JSON.stringify(objJsonSESION);

        $.ajax({
            url: "WebService.asmx/insertarAparato",
            data: "{'Aparato':" + stringJsonAPARATO + ",'Sesion':" + stringJsonSESION + "}",
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
                    Generica.GenerarAlerta("Producto Insertado", "success")
                    Generica.Clear();
                    Aparato.SelectAparatoTabla();
                    Aparato.SelectAparatoCombo();
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
    SelectAparatoCombo: function () {
        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var IdCredencial = valorCookie.Credencial;
        var objJsonSESION = {
            "Token": token,
            "IdentificadorCredencial": IdCredencial
        }
        var stringJsonSESION = JSON.stringify(objJsonSESION);

        $.ajax({
            url: "WebService.asmx/selectAparato",
            data: "{'Sesion':" + stringJsonSESION + "}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; utf-8",
            success: function (msg) {
                var datos_aparatos = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                if (datos_aparatos[0].Estado == 0) {

                    Generica.GenerarAlerta("Sesion Caducada", "warn")
                    $.removeCookie('MyFirstCookieISSC', { path: '/' });
                    window.location.href = "Home.aspx";
                }
                else if (datos_aparatos[0].Estado == 1) {
                    $('#cmbAparato').empty();
                    $('#cmbAparato').append("<option value=" + 0 + ">" + "..." + "</option>");
                    for (var i = 0; i < datos_aparatos.length; i++) {
                        var idAparato = datos_aparatos[i].idAparato;
                        var descripcion = datos_aparatos[i].Descripcion;
                        $('#cmbAparato').append("<option value=" + idAparato + ">" + descripcion + "</option>")

                    }
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
    SelectAparatoTabla: function () {
        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var IdCredencial = valorCookie.Credencial;
        var objJsonSESION = {
            "Token": token,
            "IdentificadorCredencial": IdCredencial
        }
        var stringJsonSESION = JSON.stringify(objJsonSESION);
        $.ajax({
            url: "WebService.asmx/selectAparato",
            data: "{'Sesion':" + stringJsonSESION + "}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; utf-8",
            success: function (msg) {
                var datos_aparatos = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                $("#bodyid").empty();
                if (datos_aparatos[0].Estado == 0) {

                    Generica.GenerarAlerta("Sesion Caducada", "warn")
                    $.removeCookie('MyFirstCookieISSC', { path: '/' });
                    window.location.href = "Home.aspx";
                }
                else if (datos_aparatos[0].Estado == 1) {
                    $('#tblAparatos').append("<tbody id='bodyid'>");
                    for (var i = 0; i < datos_aparatos.length; i++) {
                        var idAparato = datos_aparatos[i].idAparato;
                        var descripcion = datos_aparatos[i].Descripcion;
                        var modelo = datos_aparatos[i].Modelo;
                        var observaciones = datos_aparatos[i].Observaciones;

                        $('#tblAparatos').append("<tr class='gradeX odd' role='row' data-toggle='modal' data-target='#myModal' onclick='Aparato.TableClick();'><td>" + idAparato + "</td>"
                                                    + "<td>" + descripcion + "</td>"
                                                    + "<td>" + modelo + "</td>"
                                                    + "<td>" + observaciones + "</td></tr>");
                    }
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
    UpdateAparato: function () {

        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var IdCredencial = valorCookie.Credencial;
        var id = $('#txtID').val();
        var aparato = $('#txtAparato2').val();
        var modelo = $("#txtModelo2").val();
        var observaciones = $("#txtObservaciones2").val();
        var objJsonAPARATO = {
            "idAparato": id,
            "Descripcion": aparato,
            "Modelo": modelo,
            "Observaciones": observaciones

        }
        var stringJsonAPARATO = JSON.stringify(objJsonAPARATO);
        var objJsonSESION = {
            "Token": token,
            "IdentificadorCredencial": IdCredencial2
        }
        var stringJsonSESION = JSON.stringify(objJsonSESION);

        $.ajax({
            url: "WebService.asmx/updateAparato",
            data: "{'Aparato':" + stringJsonAPARATO + ",'Sesion':" + stringJsonSESION + "}",
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
                    Generica.GenerarAlerta("Aparato actualizado con Exito", "success")
                    Generica.Clear();
                    Aparato.SelectAparatoTabla();
                    Aparato.SelectAparatoCombo();
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
    DeleteAparato: function () {

        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var IdCredencial = valorCookie.Credencial;
        var id = $('#txtID').val();
        var objJsonAPARATO = {
            "idAparato": id,

        }
        var stringJsonAPARATO = JSON.stringify(objJsonAPARATO);
        var objJsonSESION = {
            "Token": token,
            "IdentificadorCredencial": IdCredencial
        }
        var stringJsonSESION = JSON.stringify(objJsonSESION);

        $.ajax({
            url: "WebService.asmx/deleteAparato",
            data: "{'Aparato':" + stringJsonAPARATO + ",'Sesion':" + stringJsonSESION + "}",
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
                    Generica.GenerarAlerta("Aparato Borrado con Exito", "success")
                    Generica.Clear();
                    Aparato.SelectAparatoCombo(); Aparato.SelectAparatoTabla();
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
    TableClick: function () {
        $('.table tbody tr').click(function () {
            var $row = $(this).children();
            $('#txtID').val($row[0].innerHTML);
            $('#txtAparato2').val($row[1].innerHTML);
            $('#txtModelo2').val($row[2].innerHTML);
            $('#txtObservaciones2').val($row[3].innerHTML);
        });
    },


}