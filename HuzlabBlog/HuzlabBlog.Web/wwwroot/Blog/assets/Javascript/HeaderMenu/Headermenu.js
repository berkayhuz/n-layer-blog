var menuButton = document.getElementById('menuButton');
var headerdropdownmenu = document.getElementById('header-dropdown-menu');

menuButton.addEventListener('click', function() {
    headerdropdownmenu.style.display = 'block';
});

document.addEventListener('click', function(event) {
    if (event.target !== menuButton && !headerdropdownmenu.contains(event.target)) {
        headerdropdownmenu.style.display = 'none';
    }
});