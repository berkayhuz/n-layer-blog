document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("header-menu-dropdown-user-profile-button-click");
    const dropdownContent = document.getElementById("header-menu-dropdown-user-profile-content");

    button.addEventListener("click", function () {
        dropdownContent.style.display = (dropdownContent.style.display === "block") ? "none" : "block";
    });

    document.addEventListener("click", function (event) {
        if (!dropdownContent.contains(event.target) && event.target !== button) {
            dropdownContent.style.display = "none";
        }
    });
});