using System;
using Microsoft.JSInterop;

namespace BlazorWindowHelper
{
    public static class BWHWindowHelper
    {

        public static Action OnScroll { get; set; }
        public static Action OnResize { get; set; }

        public static Action OnUnload { get; set; }

        [JSInvokable]
        public static void InvokeOnScroll()
        {
            OnScroll?.Invoke();
        }

        [JSInvokable]
        public static void InvokeOnResize()
        {
            OnResize?.Invoke();
        }

        [JSInvokable]
        public static void InvokeOnUnload()
        {
            Console.WriteLine("unloading from .net");
            OnUnload?.Invoke();
        }

    }
}
