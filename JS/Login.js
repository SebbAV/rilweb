var Login = {
    Login: function()
    {
        var nick = $('#txtUser').val();
        var pwd = hex_sha1($('#txtPwd').val());
        var datos = "{'Nick': '" + nick + "','Password': '" + pwd + "'}";
        $.ajax(
            {
                
                // url: "https://www.rilizarraga.com/WebService.asmx/Acceso",
                url: "WebService.asmx/Acceso",
                data: datos,
                dataType: "json",
                type: "POST",
                contentType: "application/json; utf-8",
                success: function (msg) {
          
                    if (msg.d.Estado == 1) {
                        var strToken = msg.d.SesionInformacion.Token;
                        var idCredencial = msg.d.SesionInformacion.IdentificadorCredencial;
                        var rol = msg.d.Rol;
                        var JSONToken = { Token: strToken, Credencial: idCredencial, Rol: rol }
                        $.cookie('Verificador', JSON.stringify(JSONToken), { expires: 1, path: '/' });
                        //Recuperar los valores
                        var cookieJson = JSON.parse($.cookie('Verificador'));
                        var token_ = cookieJson.Token;
                        var IdCredencial_ = cookieJson.Credencial;
                        $.cookie('CookieToken', strToken, { expires: 1, path: '/' });
                        $.cookie('CookieID', idCredencial, { expires: 1, path: '/' });
                        $.cookie('CookieROL', rol, { expires: 1, path: '/' });
                        
                        switch (rol) {
                            case 1:
                                window.location.href = "HomePaciente.aspx";
                                break;
                            case 2:
                                window.location.href = "HomeEmpleado.aspx";
                                break;
                            case 3:
                                window.location.href = "HomeEmpleado.aspx";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        Generica.GenerarAlerta("Favor de revisar que su Usuario Y/O Contraseñas sean correctas", "error")
                },
                error: function (result) {
                    Generica.GenerarAlerta("Error :" + result.status + ' ' + result.statusText, "error")
                }
            });
    },
}

