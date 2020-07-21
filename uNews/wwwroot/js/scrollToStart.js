document.addEventListener("DOMContentLoaded", () => {

    let searchContainer = document.getElementById("search-container");
    let upBtn = document.getElementById("up");

    if (window.pageYOffset > 500) {
        upBtn.style.visibility = "visible";
    }
    else {
        upBtn.style.visibility = "hidden";
    }

    upBtn.style.marginLeft = searchContainer.clientWidth - 64 + "px";
    upBtn.style.marginTop = document.documentElement.clientHeight - 320 + "px";

    window.addEventListener("resize", () => {
        upBtn.style.marginLeft = searchContainer.clientWidth - 64 + "px";
        upBtn.style.marginTop = document.documentElement.clientHeight - 320 + "px";
    });

    window.addEventListener("scroll", (e) => {
        e.preventDefault();

        if (window.pageYOffset > 500) {
            upBtn.style.visibility = "visible";
        }
        else {
            upBtn.style.visibility = "hidden";
        }
    });

    upBtn.addEventListener("click", (e) => {
        e.preventDefault();

        window.scrollTo(0, 0);
    });
});