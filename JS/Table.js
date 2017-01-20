jQuery(document).ready(function () {
    $('tr').click(function () {
        var $row = $(this).children();
        $('#txtID').val($row[0].innerHTML);
        $('#txtAparato').val($row[1].innerHTML);
        $('#txtModelo').val($row[2].innerHTML);
        $('#txtObservaciones').val($row[3].innerHTML);
    });
});