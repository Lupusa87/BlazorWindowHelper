
document.onkeyup = function (evt) {
    evt = evt || window.event;
    //console.log("js invoked onkeyup");
    DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeKeyUp', evt.keyCode);

};

//window.onhashchange = function () {
//    console.log("js invoked Onnavigate " + window.location.href);
//    

//};



window.addEventListener("scroll", onScroll, false);
window.addEventListener("resize", onResize, false);

//window.addEventListener('popstate', function (e) {
//    DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnUrlChange', window.location.href);
//});

function onScroll() {
    //console.log("js invoked onscroll");
    DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnScroll');

}

function onResize() {
    //console.log("js invoked onresize");
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
    }
};
