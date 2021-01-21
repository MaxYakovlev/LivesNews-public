let times = document.getElementsByClassName("time");

for (let i = 0; i < times.length; i++) {
    if (times[i].textContent.indexOf('+') !== -1)
        times[i].textContent = times[i].textContent.substring(0, times[i].textContent.lastIndexOf('+'));
}