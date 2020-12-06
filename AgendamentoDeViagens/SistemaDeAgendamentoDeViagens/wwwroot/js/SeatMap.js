$(".outer-seat").on("click", function () {
    $(this).toggleClass('selected-outerColor');
});

$(".inner-seat").on("click", function () {
    $(this).toggleClass('selected-innerColor');
});
