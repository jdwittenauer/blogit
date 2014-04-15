function RegisterNewBlogEvents() {
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
                // Success
                window.location.replace(redirectUrl);
            }
        );
    });
}

function RegisterBlogDetailEvents() {

}