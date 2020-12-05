// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function calcularIdade(Data_nasc_pas) {
    var nascimento = Data_nasc_pas;
    var dataNascimento = new Date(parseInt(nascimento[2], 10),
        parseInt(nascimento[1], 10) - 1,
        parseInt(nascimento[0], 10));

    var diferenca = Date.now() - dataNascimento.getTime();
    var idade = new Date(diferenca);

    return Math.abs(idade.getUTCFullYear() - 1970);
}