jQuery(document).ready(function () {
    $('#btnRegister').click(function () {
        /*
        var nombre = $('#txtNombre').val();
        var nick = $('#txtNick').val();
        var pwd = hex_sha1($('#txtPwd').val());
        MiFuncionJS2(nombre, nick, pwd);
        */
        var nombre = $('#txtNombre').val();
        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var IdCredencial = valorCookie.Credencial;
        var nick = $('#txtNick').val();
        var pwd = hex_sha1($('#txtPwd').val());
        GuardarCredencial(token, IdCredencial, nick, pwd, nombre);
    })
});

function MiFuncionJS2(nombre, nick, pwd) {
    var token = $.cookie('MyFirstCookieISSC');
    var idCreador = $.cookie('ID')

    var datos = "{'Nombre': '" + nombre + "','Nick': '" + nick + "','Password': '" + pwd + "','idCreador': '" + idCreador + "'}";

    $.ajax(
        {
            //url: "htp://localhost/WSJQuery1/WSJQueryREST.asmx/ListarUsuarios"
            url: "WebService.asmx/Registrar",
            data: datos,
            dataType: "json",
            type: "POST",
            contentType: "application/json; utf-8",
            success: function (msg) {
                Generica.GenerarAlerta("Registrado con éxito.", "success");
                Generica.Clear();
            },
            error: function (result) {
                Generica.GenerarAlerta("Error en el registro.", "error");
                Generica.Clear();
            }
        });
};

function GuardarCredencial(Token, IdCredencial, nick, pwd, nombre) {
    var objJsonCREDENCIAL = {
        "Nombre": nombre,
        "Nick": nick,
        "Password": pwd
    }
    var stringJsonCREDENCIAL = JSON.stringify(objJsonCREDENCIAL);
    var objJsonSESION = {
        "Token": Token,
        "IdentificadorCredencial": IdCredencial
    }
    var stringJsonSESION = JSON.stringify(objJsonSESION);

    $.ajax({
        //url: "http://localhost/WSQuery1/WSQueryREST.asmx/ListarUsuario"
        //url: "WebService.asmx/GuardarCredencial",
        url: "WebService.asmx/GuardarCredencialObjeto",
        //datos: dato,
        data: "{'Credencial':" + stringJsonCREDENCIAL + ",'Sesion':" + stringJsonSESION + "}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; utf-8",
        success: function (msg) {
            if (msg.d.SesionActiva == 0) {
                Generica.GenerarAlerta("Sesion Caducada", "warn")
                $.removeCookie('MyFirstCookieISSC', { path: '/' });
                window.location.href = "Home.aspx";
            }
            if (msg.d.SesionActiva == 1) {
                Generica.GenerarAlerta("Usuario Registrado", "error");
            } else {
                Generica.GenerarAlerta("Error", "error");
            }
            Generica.Clear();
        },
        error: function (result) {
            Generica.GenerarAlerta("Error :" + result.status + ' ' + result.statusText, "error");
        }
    });
};