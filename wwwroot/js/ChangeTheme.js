var btn = document.getElementById("theme-button");
var link = document.getElementById("theme-link");

btn.addEventListener("click", function () { ChangeTheme(); });

function ChangeTheme() {
    let lightTheme = "/css/light.css";
    let darkTheme = "/css/dark.css";

    var currTheme = link.getAttribute("href");
    var Topic = "";

    if (currTheme == lightTheme) {
        currTheme = darkTheme;
        Topic = "dark";
    }
    else {
        currTheme = lightTheme;
        Topic = "light";
    }

    link.setAttribute("href", currTheme);

    //Save(Topic);
}
