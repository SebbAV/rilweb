var AparatoEstudio = {
    GenerarXML: function () {
        
        $.ajax({
            url: "WebService.asmx/getAparatosEstudiosXML",
            dataType: "json",
            type: "POST",
            contentType: "application/json; utf-8",
            success: function (msg) {
                
                var datos_aparatos = (typeof msg.d) == 'string' ? eval('(' + msg.d + ')') : msg.d
                if (datos_aparatos[0] != null) {
                    $('#collapse').append("<div class='col-lg-12'><div class='panel-group' id='accordion'>");
                    for (var i = 0; i < datos_aparatos.length; i++) {
                        descripcion = datos_aparatos[i].descripcion;
                        $('#accordion').append("<div class='panel panel-default'>"
                                + " <div class='panel-heading' style='background-color:#0092bc; color:white'>"
                                + " <h4 class='panel-title'>"
                                + "<a data-toggle='collapse' data-parent='#accordion' href='#collapse" + i + "'>"
                                + "<h4>" + descripcion + "<div class='col-sm-1'><span class='glyphicon glyphicon-triangle-bottom'><span></h4></a></h4>"
                                + "</div><div id='collapse" + i + "' class='panel-collapse'>"
                                + "<div class='panel-body'><div class='table-responsive'>"
                                + "<table width='100%' class='table table-bordered'>"
                                + "<tbody class='table-striped' id='tb" + i + "'>");
                        for (var j = 0; j < datos_aparatos[i].estudios.length; j++) {

                            $('#tb' + i).append("<tr><td>" + datos_aparatos[i].estudios[j] + "</td></tr>")

                        }
                        $('#accordion').append("</tbody></table></div></div></div></div>");
                    }
                    $('#collapse').append("</div></div>");
                }
                else {
                    Generica.GenerarAlerta("Error de Conexion", "error")
                }

            },
            error: function (result) {
                Generica.GenerarAlerta("ERROR" + result.status + ' ' + result.statusText, "error")
            }
        });
    },
}