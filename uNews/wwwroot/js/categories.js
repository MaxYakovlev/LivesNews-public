document.addEventListener("DOMContentLoaded", () => {
    let categoriesTitle = document.getElementById("categories-title");
    let categories = document.getElementById("categories");
    let rollUp = document.getElementById("rollup-categories");
    let unRoll = document.getElementById("unroll-categories");

    categories.style.height = "50px";
    unRoll.style.display = "block";

    categoriesTitle.addEventListener("click", (e) => {
        e.preventDefault();

            // раскрыть категории
        if (rollUp.style.display !== "block") {
            if (document.documentElement.clientWidth <= 320) {
                categories.style.height = "2590px";
            }
            else if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                // код для мобильных устройств
                categories.style.height = "2580px";
                unRoll.style.display = "block";
            }

            rollUp.style.display = "block";
            unRoll.style.display = "none";
        }            
        else { // свернуть категории
            categories.style.height = "50px";

            rollUp.style.display = "none";
            unRoll.style.display = "block";
        }
    });
    
});