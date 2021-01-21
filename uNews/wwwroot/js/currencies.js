let currenciesTitle = document.getElementById("currency-title");
let rollUpCurrency = document.getElementById("rollup-currency");
let unRollCurrency = document.getElementById("unroll-currency");

currenciesTitle.addEventListener("click", (e) => {
    e.preventDefault();

    // раскрыть категории
    if (rollUpCurrency.style.display !== "block") {
        rollUpCurrency.style.display = "block";
        unRollCurrency.style.display = "none";
    }
    else {// свернуть категории
        rollUpCurrency.style.display = "none";
        unRollCurrency.style.display = "block";
    }
});