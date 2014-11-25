var blog = (function (window, document, localStorage, $) {
    return {
        saveBlog: function (e) {
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
        },

        newPost: function (e) {
            e.preventDefault();
            var requestUrl = $(this).prop("href");
            var blogID = $("#blogID").val();
            var authorID = localStorage.getItem("user.id");

            window.location.replace(requestUrl + "/" + authorID + "/" + blogID);
        },

        saveComment: function (e) {
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
        },

        registerSaveBlogEvent: function () {
            $("#save").click(this.saveBlog);
        },

        registerNewPostEvent: function () {
            $("#newPost").click(this.newPost);
        },

        registerSaveCommentEvent: function () {
            $(".pager li a").click(this.saveComment);
        }
    }
})(window, document, localStorage, jQuery);