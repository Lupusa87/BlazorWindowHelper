using System;
using System.Diagnostics;
using Microsoft.JSInterop;

namespace BlazorWindowHelper
{
    public static class BWHWindowHelper
    {
        public static IJSRuntime jsRuntime { get; set; }

        public static Action OnScroll { get; set; }
        public static Action OnResize { get; set; }

        public static Action OnUnload { get; set; }

        public static Action<bool> OnVisibilityChange { get; set; }


        [JSInvokable]
        public static void InvokeOnVisibilityChange(bool b)
        {
            OnVisibilityChange?.Invoke(b);
        }

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
            OnUnload?.Invoke();
        }

    }
}
