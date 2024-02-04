var app = document.getElementsByTagName("BODY")[0];

// Sayfa yüklendiðinde kontrol et
if (localStorage.theme === "dark") {
    app.setAttribute("light-mode", "dark");
    updateSelectedTheme("theme-moon");
} else {
    app.setAttribute("light-mode", "light");
    updateSelectedTheme("theme-sun");
}

function toggleTheme() {
    if (localStorage.theme === "dark") {
        localStorage.theme = "light";
        app.setAttribute("light-mode", "light");
        updateSelectedTheme("theme-sun");
    } else {
        localStorage.theme = "dark";
        app.setAttribute("light-mode", "dark");
        updateSelectedTheme("theme-moon");
    }
}

// Açýk tema düðmesine týklandýðýnda
document.getElementById("theme-sun").addEventListener("click", function (event) {
    event.preventDefault();
    localStorage.theme = "light";
    app.setAttribute("light-mode", "light");
    updateSelectedTheme("theme-sun");
});

// Koyu tema düðmesine týklandýðýnda
document.getElementById("theme-moon").addEventListener("click", function (event) {
    event.preventDefault();
    localStorage.theme = "dark";
    app.setAttribute("light-mode", "dark");
    updateSelectedTheme("theme-moon");
});

// Seçili temayý güncelleyen iþlev
function updateSelectedTheme(selectedThemeId) {
    var themes = document.querySelectorAll(".theme-select a");
    themes.forEach(function (theme) {
        theme.classList.remove("selected-theme");
    });
    var selectedTheme = document.getElementById(selectedThemeId);
    selectedTheme.classList.add("selected-theme");
}