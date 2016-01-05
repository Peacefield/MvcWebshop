$(document).ready(function () {
    
    $('#uitklap-menu').click(function () {
        $("#navigation").toggle("blind", [], 100);
    });


    $(window).resize(function () {
        if (window.outerHeight)
            var width = window.outerWidth;
        else
            var width = document.body.clientWidth;

        if (width > 1024) {
            $('#navigation').css("display", "block");
        }
        else {
            $('#navigation').css("display", "none");
        }
    });

});