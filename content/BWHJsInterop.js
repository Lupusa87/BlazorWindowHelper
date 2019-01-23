
document.onkeyup = function (evt) {
    evt = evt || window.event;

    DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeKeyUp', evt.keyCode);

};


window.addEventListener("scroll", onScroll, false);
window.addEventListener("resize", onResize, false);


function onScroll() {

    DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnScroll');

}

function onResize() {

    DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnResize');

}


window.BWHJsFunctions = {
    showPrompt: function (message) {
    return prompt(message, 'Type anything here');
    },
    alert: function (message) {
        alert(message);
        return true;
    },
    log: function (message) {
        console.log(message);
        return true;
    },
    logWithTime: function (message) {
        console.log(getTime() +" " + message);
        return true;
    }
};
