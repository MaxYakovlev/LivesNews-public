document.addEventListener("DOMContentLoaded", () => {
    let categoriesTitle = document.getElementById("categories-title");
    let categories = document.getElementById("categories");
    let rollUp = document.getElementById("rollup-categories");
    let unRoll = document.getElementById("unroll-categories");

    if (document.documentElement.clientWidth > 1182) {
        categories.style.height = "2680px";
    }
    else if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974) {
        categories.style.height = "2820px";
    }
    else if (document.documentElement.clientWidth <= 974) {
        categories.style.height = "45px";
        rollUp.style.display = "none";
        unRoll.style.display = "block";
    }

    categoriesTitle.addEventListener("click", (e) => {

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
            }, 700);
        }

        e.preventDefault();
    });

    window.addEventListener("resize", (e) => {
        e.preventDefault();

        if (document.documentElement.clientWidth > 1182) {
            categories.style.height = "2680px";
            rollUp.style.display = "none";
            unRoll.style.display = "none";
        }
        else if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974) {
            categories.style.height = "2820px";
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

});