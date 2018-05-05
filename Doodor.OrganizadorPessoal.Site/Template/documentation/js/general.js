$(function($) {

    'use strict';

    window.prettyPrint && prettyPrint();

    $('a[href^="#"]').click(function(e) {

        e.preventDefault();

        var target = $(this).attr('href');
        if (target == '#') return;

        $('body, html').animate({
            scrollTop: $(target).offset().top
        }, 750);

    });

    $(window).load(function() {

    });

});