var author = (function (window, document, localStorage, $) {
    return {
        highlightLoggedInAuthor: function () {
            var userID = localStorage.getItem("user.id");

            if (userID !== null) {
                $("table tr td:first-child").each(function () {
                    if ($(this).html() === userID) {
                        $(this).parent().addClass("bg-info");
                    }
                });
            }
        },

        registerSaveAuthorEvent: function () {
            $("#save").click(function () {
                var id = $("#id").val();
                var requestUrl = $("#save").data("request-url");
                var redirectUrl = $("#save").data("redirect-url");

                if (id == "00000000-0000-0000-0000-000000000000") {
                    // New author
                    $.post(
                        requestUrl,
                        {
                            Name: $("#name").val(),
                            Age: $("#age").val(),
                            City: $("#city").val(),
                            State: $("#state").val()
                        },
                        function () {
                            window.location.replace(redirectUrl);
                        }
                    );
                }
                else {
                    // Update to existing author
                    $.ajax({
                        type: "PUT",
                        url: requestUrl + "/" + id,
                        data: {
                            Name: $("#name").val(),
                            Age: $("#age").val(),
                            City: $("#city").val(),
                            State: $("#state").val()
                        },
                        success: function () {
                            window.location.replace(redirectUrl);
                        }
                    });
                }
            });
        }
    }
})(window, document, localStorage, jQuery);