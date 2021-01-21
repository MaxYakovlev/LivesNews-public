let categoriesTitle = document.getElementById("categories-title");
let categories = document.getElementById("categories");
let rollUp = document.getElementById("rollup-categories");
let unRoll = document.getElementById("unroll-categories");

if (document.documentElement.clientWidth > 1182) {
    categories.style.height = "2650px";
}
else if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974) {
    categories.style.height = "2920px";
}
else if (document.documentElement.clientWidth <= 974) {
    categories.style.height = "45px";
    rollUp.style.display = "none";
    unRoll.style.display = "block";
}

categoriesTitle.addEventListener("click", (e) => {
    e.preventDefault();

    if (document.documentElement.clientWidth <= 974 && rollUp.style.display !== "block") {
        categories.style.height = "2590px";

        // раскрыть категории
        rollUp.style.display = "block";
        unRoll.style.display = "none";
    }
    else if (document.documentElement.clientWidth <= 974 && unRoll.style.display !== "block") {
        categories.style.height = "45px";

        // свернуть категории
        setTimeout(() => {
            rollUp.style.display = "none";
            unRoll.style.display = "block";
        }, 300);
    }
});

window.addEventListener("resize", (e) => {
    e.preventDefault();

    if (document.documentElement.clientWidth > 1182) {
        categories.style.height = "2650px";
        rollUp.style.display = "none";
        unRoll.style.display = "none";
    }
    else if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974) {
        categories.style.height = "2920px";
        rollUp.style.display = "none";
        unRoll.style.display = "none";
    }
    else if (document.documentElement.clientWidth <= 974) {
        if (categories.style.height !== "45px") {
            categories.style.height = "2580px";
            rollUp.style.display = "block";
            unRoll.style.display = "none";
        }
    }
});