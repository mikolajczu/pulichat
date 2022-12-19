let isClicked1 = 0;

$(document).click(function () {
    if (isClicked1 == 0) {
        var element = document.getElementById("UserServerPartial");
        element.style.display = "none";
    }
    isClicked1 = 0;
});

$("#ServerUsersPartial a").click(function () {
    isClicked1 = 1;
});