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

    alert( document.cookie );
}

document.cookie = "theme=Topic"; // обновляем только куки с именем 'user'
alert(document.cookie); // показываем все куки

// специальные символы (пробелы), требуется кодирование
let name = "my name";
let value = "John Smith"

// кодирует в my%20name=John%20Smith
document.cookie = encodeURIComponent(name) + '=' + encodeURIComponent(value);

alert(document.cookie); // ...; my%20name=John%20Smith

// возвращает куки с указанным name,
// или undefined, если ничего не найдено
function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }

  function setCookie(name, value, options = {}) {

    options = {
      path: '/',
      // при необходимости добавьте другие значения по умолчанию
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
  
  // Пример использования:
  setCookie('theme', 'Topic', {secure: true, 'max-age': 5000});

  function deleteCookie(name) {
    setCookie(name, "", {
      'max-age': -1
    })
  }