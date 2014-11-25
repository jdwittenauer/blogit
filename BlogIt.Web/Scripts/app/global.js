var app = (function (window, document, localStorage, $) {
    return {
        hoverableNavBar: function () {
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
        },

        activeNavBar: function () {
            $(".nav li").removeClass("active");
            var url = window.location;

            $("ul.nav a").filter(function () {
                return this.href == url;
            }).parent().addClass("active");

            $("ul.nav a").filter(function () {
                return this.href == url;
            }).parent().parent().parent().filter("li").addClass("active");
        },

        checkUserLoginCredentials: function () {
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
        },

        logOut: function (e) {
            e.preventDefault();
            localStorage.clear();
            window.location.replace($("#loginUrl").val());
        },

        registerLogOutEvent: function () {
            $("#logOut").click(this.logOut);
        }
    }
})(window, document, localStorage, jQuery);