/* SERVERINDEX SCRIPTS */

$(document).ready(function () {
    var table = document.getElementById("channels");
    var trs = table.getElementsByTagName("tr")[0];
    var cellVal = trs.cells[0];
    var cellA = cellVal.getElementsByTagName("a")[0];
    cellA.click();
});

function outFunc() {
    var tooltip = document.getElementById("myTooltip");
    tooltip.style.bottom = "10%";
    tooltip.innerHTML = "Copy to clipboard";
}

function channelClicked(id) {
    var element = document.getElementById(id);
    var table = document.getElementById("channels");

    table.style.backgroundColor = "#2F3136";
    for (var i = 0; i < table.rows.length; i++) {
        var trs = table.getElementsByTagName("tr")[i];
        var cellVal = trs.cells[0];
        cellVal.style.backgroundColor = "#2F3136";
    }
    element.style.backgroundColor = "#36393F";
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