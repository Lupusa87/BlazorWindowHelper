var OnOrOff = false;

document.onkeyup = function (evt) {

    if (OnOrOff===true) {
        evt = evt || window.event;
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeKeyUp', [evt.keyCode, evt.ctrlKey, evt.shiftKey, evt.altKey]);
    }
};


document.onkeydown = function (evt) {

    if (OnOrOff === true) {
        evt = evt || window.event;
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeKeyDown', [evt.keyCode, evt.ctrlKey, evt.shiftKey, evt.altKey]);
    }
};


window.addEventListener("scroll", onScroll, false);
window.addEventListener("resize", onResize, false);
window.addEventListener("unload", onUnload, false);

function onScroll() {
    if (OnOrOff === true) {
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnScroll');
    }
}

function onResize() {
    if (OnOrOff === true) {
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnResize');
    }
}

function onUnload() {
    if (OnOrOff === true) {
        console.log("unloading from js");
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnUnload');
    }
}

window.BWHJsFunctions = {
    showPrompt: function (message) {
    return prompt(message, 'Type anything here');
    },
    alert: function (message) {
        alert(message);
        return true;
    },
    Print: function () {
        window.print();
        return true;
    },
    mylog: function (message) {
        console.log(message);
        return true;
    },
    logWithTime: function (message) {
        console.log(getTime() +" " + message);
        return true;
    },
    SetFocus: function (id) {
        if (document.getElementById(id) !== null) {
            document.getElementById(id).focus();
        }
    },
    setOnOrOff: function (b) {
        OnOrOff = b;
        return true;
    },
    GetTimezoneOffset: function () {
        return new Date().getTimezoneOffset() / 60;
    },
    GetDateMilliseconds: function () {
        return new Date().getTime();
    },
    GetElementActualWidth: function (el) {
        if (document.getElementById(el) !== null) {
            let rect = document.getElementById(el).getBoundingClientRect();
            return rect.width;
        }
        else {
            return 0;
        }
    },
    GetElementActualHeight: function (el) {

        if (document.getElementById(el) !== null) {
            let rect = document.getElementById(el).getBoundingClientRect();
            return rect.height;
        }
        else {
            return 0;
        }
    },
    GetElementActualTop: function (el) {
        if (document.getElementById(el) !== null) {
            let rect = document.getElementById(el).getBoundingClientRect();
            return rect.top;
        }
        else {
            return 0;
        }
    },
    GetElementActualLeft: function (el) {
        if (document.getElementById(el) !== null) {
            let rect = document.getElementById(el).getBoundingClientRect();
            return rect.left;
        }
        else {
            return 0;
        }
    },
    GetWindowWidth: function () {
        return window.innerWidth
            || document.documentElement.clientWidth
            || document.body.clientWidth;

    },
    GetWindowHeight: function () {
        return window.innerHeight
            || document.documentElement.clientHeight
            || document.body.clientHeight;

    },
    SetItemLocalStorage: function (k, v) {
        localStorage.setItem(k, v);
        return true;
    },
    GetItemLocalStorage: function (k) {
        return localStorage.getItem(k);
    },
    RemoveItemLocalStorage: function (k) {
        var v = localStorage.getItem(k);
        if (v === null) {
            return false;
        }
        else {
            localStorage.removeItem(k);
            return true;
        }
    },
    CheckIfKeyExistsLocalStorage: function (k) {
        var v = localStorage.getItem(k);
        if (v === null) {
            return false;
        }
        else {
            return true;
        }
    },
    ClearLocalStorage: function () {
        localStorage.clear();
        return true;
    },
};
