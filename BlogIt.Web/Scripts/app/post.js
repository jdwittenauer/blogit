﻿var post = (function (window, document, localStorage, $) {
    return {
        savePost: function (e) {
            var requestUrl = $("#save").data("request-url");
            var redirectUrl = $("#save").data("redirect-url");

            $.post(
                requestUrl,
                {
                    Title: $("#title").val(),
                    Content: $("#content").val(),
                    AuthorID: $("#authorID").val(),
                    BlogID: $("#blogID").val()
                },
                function () {
                    window.location.replace(redirectUrl);
                }
            );
        },

        registerSavePostEvent: function () {
            $("#save").click(this.savePost);
        }
    }
})(window, document, localStorage, jQuery);