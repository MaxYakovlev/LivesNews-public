document.addEventListener("DOMContentLoaded", () => {
    let currenciesTitle = document.getElementById("currency-title");
    let currencies = document.getElementById("currencies-container");
    let rollUp = document.getElementById("rollup-currency");
    let unRoll = document.getElementById("unroll-currency");

    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        // код для мобильных устройств
        currencies.style.height = "180px";
        unRoll.style.display = "block";
        currencies.style.height = "auto";
    }

    currenciesTitle.addEventListener("click", (e) => {
        e.preventDefault();

        // раскрыть категории
        if (rollUp.style.display !== "block") {
            currencies.style.height = "auto";
            rollUp.style.display = "block";
            unRoll.style.display = "none";
        }
        // свернуть категории
        else {
            currencies.style.height = "180px";
            rollUp.style.display = "none";
            unRoll.style.display = "block";
        }
    });

    let resizeCurrencies = () => {
        // добавить иконку раскрытия категорий
        if (document.documentElement.clientWidth <= 974) {
            currencies.style.height = "180px";
            rollUp.style.display = "none";
            unRoll.style.display = "block";
        }
        // скрыть иконки раскрытия и скрытия категория
        else {
            currencies.style.height = "180px";
            rollUp.style.display = "none";
        }
    }

    resizeCurrencies();

    window.addEventListener("resize", (e) => {
        e.preventDefault();

        resizeCurrencies();
    });

});