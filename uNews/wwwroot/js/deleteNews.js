let deleteButtons = document.getElementsByClassName("delete");
let upBtn = document.getElementById("up");

for (let i = 0; i < deleteButtons.length; i++) {
    deleteButtons[i].addEventListener("click", async () => {
        let id = deleteButtons[i].parentElement.querySelector(".delete").getAttribute("id");

        let response = await fetch("/news/deleteonenews?id=" + id, {
            method: 'POST'
        });

        if (response.ok) window.location.reload();
    });
}