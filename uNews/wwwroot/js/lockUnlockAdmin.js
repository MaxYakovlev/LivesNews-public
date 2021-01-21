let lockButtons = document.getElementsByClassName("lock-btn");
let unlockButtons = document.getElementsByClassName("unlock-btn");

for (let i = 0; i < lockButtons.length; i++) {
    lockButtons[i].addEventListener("click", async () => {
        let id = lockButtons[i].getAttribute("id");

        let response = await fetch("/admin/lockuser?id=" + id, {
            method: 'POST'
        });

        if (response.ok) {
            window.location.reload();
        }
    });
}

for (let i = 0; i < unlockButtons.length; i++) {
    unlockButtons[i].addEventListener("click", async () => {
        let id = unlockButtons[i].getAttribute("id");

        let response = await fetch("/admin/unlockuser?id=" + id, {
            method: 'POST'
        });

        if (response.ok) {
            window.location.reload();
        }
    });
}