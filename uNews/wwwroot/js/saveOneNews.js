document.addEventListener("DOMContentLoaded", () => {
    let readLaterButtons = document.getElementsByClassName("read-later");

    for (let i = 0; i < readLaterButtons.length; i++) {
        readLaterButtons[i].addEventListener("click", async () => {
            let formData = new FormData();

            let url = readLaterButtons[i].parentElement.querySelector(".source-link").getAttribute("href");
            formData.append("url", url);

            let title = readLaterButtons[i].parentElement.querySelector(".card-title").textContent;
            formData.append("title", title);

            let description = readLaterButtons[i].parentElement.querySelector(".card-text");
            if (description !== null)
                formData.append("description", description.textContent);

            let author = readLaterButtons[i].parentElement.querySelector(".author");
            if (author !== null)
                formData.append("author", author.textContent);

            let category = readLaterButtons[i].parentElement.querySelector(".category").textContent;
            formData.append("category", category);

            let date = readLaterButtons[i].parentElement.querySelector(".time").textContent;
            formData.append("date", date);

            let imageLink = readLaterButtons[i].parentElement.querySelector(".card-img-top");
            if (imageLink !== null)
                formData.append("imageLink", imageLink.getAttribute("src"));

            let saveModalLabel = document.getElementById("saveModalLabel");

            let response = await fetch("/news/saveonenews", {
                method: 'POST',
                body: formData
            });

            let result = await response.json();

            saveModalLabel.textContent = result.message;

            $('#saveModal').modal('show');

            if (response.ok) {
                setTimeout(() => {
                    $('#saveModal').modal('hide');
                }, 1000);
            }
            else {
                setTimeout(() => {
                    $('#saveModal').modal('hide');
                }, 1800);
            }
            
        });
    }
});