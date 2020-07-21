document.addEventListener("DOMContentLoaded", () => {
    let search = document.getElementById("search");
    let news = document.getElementsByClassName("col-sm-6");
    let count = 0;
    let countNews = document.getElementById("count");

    search.addEventListener("input", () => {
        let input = search.value;
        for (let i = 0; i < news.length; i++) {
            let title = news[i].querySelector(".card-title");
            let text = news[i].querySelector(".card-text");

            if (text) {
                if (title.textContent.toLowerCase().indexOf(input.toLowerCase()) === -1 && text.textContent.toLowerCase().indexOf(input.toLowerCase()) === -1) {
                    news[i].style.display = "none";
                    count++;
                }
                else news[i].style.display = "block";
            }
            else {
                if (title.textContent.toLowerCase().indexOf(input.toLowerCase()) === -1) {
                    news[i].style.display = "none";
                    count++;
                }
                else news[i].style.display = "block";
            }
        }

        countNews.innerHTML = "Всего: " + (news.length - count);
        count = 0;
    });
});