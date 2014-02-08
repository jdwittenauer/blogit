function CreateActiveBootstrapMenu() {
    $(".nav li").removeClass("active");
    var url = window.location;

    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('active');
}