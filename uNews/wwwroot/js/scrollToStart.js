document.addEventListener("DOMContentLoaded", () => {
    let upBtn = document.getElementById("up");
    let upVisibility = (height) => {
        if (window.pageYOffset > height) upBtn.style.visibility = "visible";
        else upBtn.style.visibility = "hidden";
    }

    upVisibility(500);

    window.addEventListener("scroll", (e) => {
        e.preventDefault();

        upVisibility(500);
    });

    upBtn.addEventListener("click", (e) => {
        e.preventDefault();

        window.scrollTo(0, 0);
    });
});