function RegisterHoverEnabledNavBar() {
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
    $("#navbar ul li").removeClass("active");
    var url = window.location;

    $("#navbar ul.nav a").filter(function () {
        return this.href === url;
    }).parent().addClass("active");

    $("#navbar ul.nav a").filter(function () {
        return this.href === url;
    }).parent().parent().parent().filter("li").addClass("active");
}

function CheckUserLoginCredentials() {
    var userID = localStorage["author.id"];
    var userName = localStorage["author.name"];

    if (userID === null && window.location.href.toString().indexOf("login") === -1) {
        if ($("#authorID").length > 0) {
            // Set the current user
            localStorage["author.id"] = $("#authorID").val();
            localStorage["author.name"] = $("#authorName").val();
        }
        else {
            // Redirect to login page
            window.location.replace($("#loginUrl").val());
        }
    }
    else {
        // TODO
    }
}