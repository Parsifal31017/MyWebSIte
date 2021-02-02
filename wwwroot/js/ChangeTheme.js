const link = document.getElementById('theme-link');
const lightTheme = '/css/light.css';
const darkTheme = '/css/dark.css';
let currentTheme = localStorage.getItem('theme');

(function(){
    if( !currentTheme ) {
        currentTheme = lightTheme;
        localStorage.setItem('theme', currentTheme);
    }
    link.setAttribute('href', currentTheme);
})();

document.getElementById('theme-button').addEventListener('click', e => {
    e.preventDefault();
    if( currentTheme == darkTheme ) {
        currentTheme = lightTheme;
    }else {
        currentTheme = darkTheme;
    }
    link.setAttribute('href', currentTheme);
    localStorage.setItem('theme', currentTheme);
});