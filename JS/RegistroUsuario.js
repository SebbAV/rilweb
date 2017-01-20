jQuery(document).ready(function () {
    $('#btnRegistrar').click(function () {
        var nombre = $('#txtNombre').val();
        var paterno = $('#txtPaterno').val();
        var materno = $('#txtMaterno').val();
        var nick = $('#txtNick').val();
        var pwd = hex_sha1($('#txtPassword').val());
        var correo = $('#txtCorreo').val();
        
        Registrar(nombre, paterno, materno, nick, pwd, correo);
        
    });
});

function Registrar(nombre, paterno, materno, nick, pwd, correo) {
    var objJsonCREDENCIAL = {
        "Nick": nick,
        "Password": pwd,
        "Correo": correo
    }
    var stringJsonCREDENCIAL = JSON.stringify(objJsonCREDENCIAL);

    var objJsonPACIENTE = {
        "Nombre": nombre,
        "Paterno": paterno,
        "Materno": materno
    }
    var stringJsonPACIENTE = JSON.stringify(objJsonPACIENTE);
    $.ajax({
        url: "WebService.asmx/RegistrarUsuario",
        data: "{'Credencial':" + stringJsonCREDENCIAL + ",'Paciente':" + stringJsonPACIENTE + "}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; utf-8",
        success: function (msg) {
            if (msg.d = 1)
            {
                Generica.GenerarAlerta("Usuario Registrado", "success");
            }
            
        },
        error: function (result) {
            Generica.GenerarAlerta("Error:" + result.status + ' ' + result.statusText, "error");
        }
    });
};

