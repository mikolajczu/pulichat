let serverName = "";
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

/* LAYOUT THEME SCRIPT */
const home = document.getElementById("home");
const buttons = home.getElementsByTagName("button");

for (let button of buttons) {
    button.addEventListener("click", function () {
        var item = button.value;

        $.post("Home/SetTheme", {
            data: item
        });

        setTimeout(function () {
            location.reload();
        }, 300);
    });
}

/* SERVERINDEX SCRIPTS */

function outFunc() {
    var tooltip = document.getElementById("myTooltip");
    tooltip.style.bottom = "10%";
    tooltip.innerHTML = "Copy to clipboard";
}

function channelClicked(id, serverId) {
    var data1 = id + " " + serverId;
    $.post("../../Servers/SetChannel", {
        data: data1
    });
}

function userServerPartialClicked(isClicked) {
    var element = document.getElementById("UserServerPartial");
    element.style.display = "none";
    if (isClicked == 1) {
        element.style.display = "block";
    }
}

function changeRadiusOfButton(or) {
    var button = document.getElementById("configureButton");

    if (or == 0) {
        button.style.borderBottomLeftRadius = "0";
        button.style.borderBottomRightRadius = "0";
    }
    else {
        button.style.borderBottomLeftRadius = "10px";
        button.style.borderBottomRightRadius = "10px";
    }
}

function updateScroll() {
    chat.scrollTop = element.scrollHeight;
}