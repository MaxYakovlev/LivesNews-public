document.addEventListener("DOMContentLoaded", () => {
    let categoriesTitle = document.getElementById("categories-title");
    let categories = document.getElementById("categories");
    let rollUp = document.getElementById("rollup-categories");
    let unRoll = document.getElementById("unroll-categories");

    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        // код для мобильных устройств
        categories.style.height = "50px";
        unRoll.style.display = "block";
        categories.style.height = "auto";
    }

    categoriesTitle.addEventListener("click", (e) => {
        e.preventDefault();

        if (document.documentElement.clientWidth <= 974) {
            // раскрыть категории
            if (rollUp.style.display !== "block") {
                categories.style.height = "auto";
                rollUp.style.display = "block";
                unRoll.style.display = "none";
            }
            // свернуть категории
            else {
                categories.style.height = "50px";
                rollUp.style.display = "none";
                unRoll.style.display = "block";
            }
        }
    });

    let resizeCategories = () => {
        // добавить иконку раскрытия категорий
        if (document.documentElement.clientWidth <= 974) {
            categories.style.height = "50px";
            rollUp.style.display = "none";
            unRoll.style.display = "block";
        }
        // скрыть иконки раскрытия и скрытия категория
        else {
            categories.style.height = "auto";
            rollUp.style.display = "none";
            unRoll.style.display = "none";
        }
    }

    resizeCategories();

    window.addEventListener("resize", (e) => {
        e.preventDefault();

        resizeCategories();
    });
    
});