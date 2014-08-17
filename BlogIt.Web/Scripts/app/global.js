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

function RegisterLogOutFunction() {
    $("#logOut").click(function (e) {
        e.preventDefault();
        localStorage.clear();
        window.location.replace($("#loginUrl").val());
    });
}

function CheckUserLoginCredentials() {
    var userID = localStorage.getItem("user.id");
    var userName = localStorage.getItem("user.name");

    if ((userID === null) && window.location.href.toString().indexOf("login") === -1) {
        // User not set
        if ($("#userID").length > 0 && $("#userID").val().length > 0) {
            // Have credentials, set the current user
            localStorage.setItem("user.id", $("#userID").val());
            localStorage.setItem("user.name", $("#userName").val());
            $("#user").text($("#userName").val());
        }
        else {
            // No credentials, redirect to login page
            window.location.replace($("#loginUrl").val());
        }
    }
    else if ((userID === null)) {
        // User not set, at login page
        $("#user").text("Log In");
    }
    else {
        // User already set
        $("#user").text(userName);
    }
}