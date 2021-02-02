const link = document.getElementById('language-link');
const enLanguage = '/css/light.css';
const ruLanguage = '/css/dark.css';
let currentLanguage = localStorage.getItem('language');

(function(){
    if( !currentLanguage ) {
        currentLanguage = lightLanguage;
        localStorage.setItem('language', currentLanguage);
    }
    link.setAttribute('href', currentLanguage);
})();

document.getElementById('language-button').addEventListener('click', e => {
    e.preventDefault();
    if( currentLanguage == ruLanguage ) {
        currentTLanguage = enLanguage;
    }else {
        currentLanguage = ruLanguage;
    }
    link.setAttribute('href', currentLanguage);
    localStorage.setItem('language', currentLanguage);
});