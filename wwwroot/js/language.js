var btn = document.getElementById("theme-button");
var link = document.getElementById("theme-link");

btn.addEventListener("click", function () { Language(); });

function Language() {
    let lightTheme = "/css/light.css";//ru
    let darkTheme = "/css/dark.css";//en

    var currLanguage = link.getAttribute("href");
    var Language = "";

    if (currLanguage == lightTheme) {
        currLanguage = darkTheme;
        Language = "en";
    }
    else {
        currLanguage = lightTheme;
        Language = "ru";
    }

    link.setAttribute("href", currLanguage);

    //Save(Topic);
}