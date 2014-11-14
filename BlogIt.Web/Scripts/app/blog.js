var blog = (function (window, document, localStorage, $) {
    return {
        registerSaveBlogEvent: function () {
            $("#save").click(function () {
                var requestUrl = $("#save").data("request-url");
                var redirectUrl = $("#save").data("redirect-url");

                $.post(
                    requestUrl,
                    {
                        Name: $("#name").val(),
                        Category: $("#category").val()
                    },
                    function () {
                        window.location.replace(redirectUrl);
                    }
                );
            });
        },

        registerNewPostEvent: function () {
            $("#newPost").click(function (e) {
                e.preventDefault();
                var requestUrl = $(this).prop("href");
                var blogID = $("#blogID").val();
                var authorID = localStorage.getItem("user.id");

                window.location.replace(requestUrl + "/" + authorID + "/" + blogID);
            });
        },

        registerSaveCommentEvent: function () {
            $(".pager li a").click(function (e) {
                e.preventDefault();
                var requestUrl = $(this).prop("href");
                var newCommentUrl = $(this).data("partial-url");
                var $comments = $(this).parents(".blog-post").find("div").first();
                var $textArea = $(this).parents(".blog-post").find("textarea").first();
                var postID = $(this).parents(".blog-post").find("[name='PostID']").val();
                var authorID = localStorage.getItem("user.id");

                $.post(
                    requestUrl,
                    {
                        Content: $textArea.val(),
                        PostID: postID,
                        AuthorID: authorID
                    },
                    function (comment) {
                        $.get(newCommentUrl + "/" + comment.ID, function (html) {
                            $comments.append($(html).fadeIn('slow'));
                            $textArea.val("");
                        });
                    },
                    "json"
                );
            });
        }
    }
})(window, document, localStorage, jQuery);