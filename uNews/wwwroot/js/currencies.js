document.addEventListener("DOMContentLoaded", () => {
    let currenciesTitle = document.getElementById("currency-title");
    let rollUp = document.getElementById("rollup-currency");
    let unRoll = document.getElementById("unroll-currency");

    currenciesTitle.addEventListener("click", (e) => {
        e.preventDefault();

        // раскрыть категории
        if (rollUp.style.display !== "block") {
            rollUp.style.display = "block";
            unRoll.style.display = "none";
        }
        else {// свернуть категории
            rollUp.style.display = "none";
            unRoll.style.display = "block";
        }
    });
});