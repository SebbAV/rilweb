var Generica = {
    ObtenerCookie: function () {
        var cookieJson = JSON.parse($.cookie('Verificador'));
        return cookieJson;
    },
    ValidarCookie: function () {
        if ($.cookie('CookieToken') == null) {
            window.location.href = "Login.aspx";
        }
    },
    GenerarAlerta: function (mensaje, tipo) {
        $.notify(mensaje, {
            globalPosition: 'top center',
            className: tipo
        });
    },
    Clear: function () {
        $("input[type='text']").val("");
    },
    isNumber: function (evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }
};