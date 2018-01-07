$(document).ready(function () {

    //alert("teste");
    //MASCARA DE CPF
    $(function () {
        $("#maskcpf").mask("999.999.999-99");
    });

    //MASCARA DE TELEFONE
    $(function () {
        $("#masktelefone").mask('(99) 99999-9999');
    });

    //MASCARA DE DATA
    $(function () {
        $("#maskdata").mask("99/99/9999");
    });

    //MASCARA PARA VALIDAR EMAIL
    $(function (email) {
        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return expr.test(email);
    });

    ////ALERT DE COMPRA 
    //$(function () {
    //    swal("Compra Efetuada com Sucesso!", "RadicaLand!", "success");
    //});
});