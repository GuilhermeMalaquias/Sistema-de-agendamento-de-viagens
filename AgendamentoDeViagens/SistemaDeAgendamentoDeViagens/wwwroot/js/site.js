// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Buscar CEP
jQuery(function ($) {
    $("input[name='CEP_pas']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("https://ws.apicep.com/cep.json?", { code: cep_code }, function (result) {
            if (result.status == 200) {
                $("input[name='CEP_pas']").val(result.code);
                $("input[name='Bairro_pas']").val(result.district);
                $("input[name='Cidade_pas']").val(result.city);
                $("input[name='UF_pas']").val(result.state);
            }
            else if (result.status == 404) {
                $.get("https://cep.awesomeapi.com.br/json/" + cep_code, function (ret) {
                   
                   
                    $("input[name='CEP_pas']").val(ret.cep);
                    $("input[name='Bairro_pas']").val(ret.district);
                    $("input[name='Cidade_pas']").val(ret.city);
                    $("input[name='UF_pas']").val(ret.state);
                });
            }
        });    
    });
});

document.getElementById("Bairro_pas").readOnly = true
document.getElementById("Cidade_pas").readOnly = true
document.getElementById("UF_pas").readOnly = true