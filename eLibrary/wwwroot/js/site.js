// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function RedirectAfterDelayFn() {
    var seconds = 5;
    var dvCountDown = document.getElementById("CountDown");
    var lblCount = document.getElementById("CountDownLabel");
    dvCountDown.style.display = "block";
    lblCount.innerHTML = seconds;
    setInterval(function () {
        seconds--;
        lblCount.innerHTML = seconds;
        if (seconds == 0) {
            dvCountDown.style.display = "none";
            window.location = "/Account/Login";
        }
    }, 1000);
})();