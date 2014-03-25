﻿function RegisterHoverEnabledNavBar() {
    var mq = window.matchMedia("(min-width: 768px)");

    if (mq.matches) {
        $("ul.navbar-nav li").addClass("hovernav");
    } else {
        $("ul.navbar-nav li").removeClass("hovernav");
    };

    if (matchMedia) {
        var mq = window.matchMedia("(min-width: 768px)");
        mq.addListener(WidthChange);
        WidthChange(mq);
    }

    function WidthChange(mq) {
        if (mq.matches) {
            $("ul.navbar-nav li").addClass("hovernav");
        } else {
            $("ul.navbar-nav li").removeClass("hovernav");
        }
    };
}

function RegisterActiveNavBar() {
    $(".nav li").removeClass("active");
    var url = window.location;

    $("ul.nav a").filter(function () {
        return this.href == url;
    }).parent().addClass("active");

    $("ul.nav a").filter(function () {
        return this.href == url;
    }).parent().parent().parent().filter("li").addClass("active");
}