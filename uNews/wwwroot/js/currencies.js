document.addEventListener("DOMContentLoaded", () => {
    let currenciesTitle = document.getElementById("currency-title");
    let currencies = document.getElementById("currencies-container");
    let rollUp = document.getElementById("rollup-currency");
    let unRoll = document.getElementById("unroll-currency");

    if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974)
        currencies.style.height = "210px";
    else currencies.style.height = "180px";

    unRoll.style.display = "block";

    currenciesTitle.addEventListener("click", (e) => {
        e.preventDefault();

        // раскрыть категории
        if (rollUp.style.display !== "block") {
            if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                // код для мобильных устройств
                unRoll.style.display = "block";
                currencies.style.height = "2270px";
            }
            else if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974)
                currencies.style.height = "2620px";
            else if (document.documentElement.clientWidth <= 974)
                currencies.style.height = "2240px";
            else currencies.style.height = "2270px";

            rollUp.style.display = "block";
            unRoll.style.display = "none";
        }
        // свернуть категории
        else {
            if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974)
                currencies.style.height = "210px";
            else currencies.style.height = "180px";

            setTimeout(() => {
                rollUp.style.display = "none";
                unRoll.style.display = "block";
            }, 600);
        }
    });

    window.addEventListener("resize", () => {
        if (document.documentElement.clientWidth <= 1182 && document.documentElement.clientWidth > 974)
            currencies.style.height = "210px";
        else currencies.style.height = "180px";
    });
});