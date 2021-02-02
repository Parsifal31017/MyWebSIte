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

    Save ( document.cookie );
}

document.cookie = "theme=Topic"; 
alert(document.cookie);

  function setCookie(name, value, options = {}) {

    options = {
      path: '/',
      ...options
    };
  
    if (options.expires instanceof Date) {
      options.expires = options.expires.toUTCString();
    }
  
    let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);
  
    for (let optionKey in options) {
      updatedCookie += "; " + optionKey;
      let optionValue = options[optionKey];
      if (optionValue !== true) {
        updatedCookie += "=" + optionValue;
      }
    }
  
    document.cookie = updatedCookie;
  }
  
  setCookie('theme', 'Topic', {secure: true, 'max-age': 5000});

  function deleteCookie(name) {
    setCookie(name, "", {
      'max-age': -1
    })
  }