let upBtn = document.getElementById("up");

let upVisibility = (height) => {
    if (window.pageYOffset > height) upBtn.style.display = "block";
    else upBtn.style.display = "none";
}

upVisibility(750);

window.addEventListener("scroll", (e) => {
    e.preventDefault();

    upVisibility(750);
});

upBtn.addEventListener("click", (e) => {
    e.preventDefault();

    window.scrollTo(0, 0);
});