var Cerrar =
{
    cerrarSesion: function () {
        var valorCookie = Generica.ObtenerCookie();
        var token = valorCookie.Token;
        var datos = "{'Token': '" + token + "'}";
        $.ajax(
        {
            url: "Webservice.asmx/CerrarSesion",
            data: datos,
            dataType: "json",
            type: "POST",
            contentType: "application/json; utf-8",
            success: function (msg) {
                if (true) {
                    Generica.GenerarAlerta("Cerrando Sesion ", "warn")
                    $.removeCookie('MyFirstCookieISSC', { path: '/' });
                    window.location.href = "Home.aspx";
                }
                else {
                    Generica.GenerarAlerta("Error al Cerrar Sesion", "error")
                }
            },
            error: function (result) {
                Generica.GenerarAlerta("Error :" + result.status + ' ' + result.statusText, "error")
            }

        });

    }

}