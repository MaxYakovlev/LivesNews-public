let countElement = document.getElementById("count");
let count = +countElement.textContent;

let select = document.getElementById("fields-select");
let searchInput = document.getElementById("search");
let rows = document.getElementsByClassName("rows");

let indexSelected = select.selectedIndex,
    option = select.querySelectorAll('option')[indexSelected];

let searchValue, selectValue = option.getAttribute("value");

searchInput.addEventListener("input", () => {
    searchValue = searchInput.value.toLowerCase();
    search(searchValue, selectValue);
});

select.addEventListener("change", () => {
    indexSelected = select.selectedIndex,
        option = select.querySelectorAll('option')[indexSelected];
    selectValue = option.getAttribute("value");

    search(searchValue, selectValue);
});

let search = (searchValue, selectValue) => {
    count = 0;

    if (searchValue === "") {
        for (let i = 0; i < rows.length; i++) {
            rows[i].style.display = "table-row";
            count++;
        }
    }
    else if (searchValue !== undefined && searchValue !== null) {
        for (let i = 0; i < rows.length; i++) {
            if (selectValue === "all") {
                let childs = rows[i].querySelectorAll(".one-row");

                for (let j = 0; j < childs.length; j++) {
                    if (childs[j].textContent.toLowerCase().indexOf(searchValue) > -1) {
                        rows[i].style.display = "table-row";
                        count++;
                        break;
                    }
                    else {
                        rows[i].style.display = "none";
                    }
                }
            }
            else {
                if (rows[i].querySelector("." + selectValue).textContent.toLowerCase().indexOf(searchValue) > -1) {
                    rows[i].style.display = "table-row";
                    count++;
                }
                else {
                    rows[i].style.display = "none";
                }
            }
        }
    }

    countElement.textContent = count;
}