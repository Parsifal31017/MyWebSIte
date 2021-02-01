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

//let name = "Theme";
//let value = "Topic"

//document.cookie = encodeURIComponent(name) + '=' + encodeURIComponent(value);

//alert(document.cookie); 

////Для того чтобы создать cookie можно воспользоваться следующей функцией:
//function setCookie(name, value, options) {
//    options = options || {}; //по умолчанию нет параметров (допустимые: expires, domain, secure, path)
//    var expires = options.expires;
  
//    if (typeof expires == "number" && expires) { //если указано время жизни, и это число
//      var d = new Date();
//      d.setTime(d.getTime() + expires * 1000); //expires в секундах
//      expires = options.expires = d;
//    }
//    if (expires && expires.toUTCString) {
//      options.expires = expires.toUTCString();
//    }
  
//    value = encodeURIComponent(value); 
//    var data = name + "=" + value; //строка в формате cookie имеет вид "имя_куки=значение"
  
//    for (var propName in options) {   //дописываем параметры кук (domain, secure, path)
//      data += "; " + propName;
//      var propValue = options[propName];
//      if (propValue !== true) {
//        data += "=" + propValue;
//      }
//    }
  
//    document.cookie = data; //сохраняем куку
//  }

//  // возвращает куки с указанным name,
//// или undefined, если ничего не найдено
//function getCookie(name) {
//  let matches = document.cookie.match(new RegExp(
//    "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
//  ));
//  return matches ? decodeURIComponent(matches[1]) : undefined;
//  }