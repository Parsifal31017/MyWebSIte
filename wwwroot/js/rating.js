const link = document.getElementById('star-1-link');
const link = document.getElementById('star-2-link');
const link = document.getElementById('star-3-link');
const link = document.getElementById('star-4-link');
const link = document.getElementById('star-5-link');
const lightRating = '/css/rating.css';
let currentRating = localStorage.getItem('rating');

(function(){
    if( !currentRating ) {
        currentRating = lightRating;
        localStorage.setItem('rating', currentRating);
    }
    link.setAttribute('href', currentRating);
})();

document.getElementById('star-1').addEventListener('click', e => {
    e.preventDefault();
    if( currentRating == lightRating ) {
        currentRating = lightRating;
    }
    link.setAttribute('href', currentRating);
    localStorage.setItem('rating', currentRating);
});

document.getElementById('star-2').addEventListener('click', e => {
    e.preventDefault();
    if( currentRating == lightRating ) {
        currentRating = lightRating;
    }
    link.setAttribute('href', currentRating);
    localStorage.setItem('rating', currentRating);
});

document.getElementById('star-3').addEventListener('click', e => {
    e.preventDefault();
    if( currentRating == lightRating ) {
        currentRating = lightRating;
    }
    link.setAttribute('href', currentRating);
    localStorage.setItem('rating', currentRating);
});

document.getElementById('star-4').addEventListener('click', e => {
    e.preventDefault();
    if( currentRating == lightRating ) {
        currentRating = lightRating;
    }
    link.setAttribute('href', currentRating);
    localStorage.setItem('rating', currentRating);
});

document.getElementById('star-5').addEventListener('click', e => {
    e.preventDefault();
    if( currentRating == lightRating ) {
        currentRating = lightRating;
    }
    link.setAttribute('href', currentRating);
    localStorage.setItem('rating', currentRating);
});