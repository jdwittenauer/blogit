function RegisterNewPostEvents() {
    $("#save").click(function () {
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
    });
}