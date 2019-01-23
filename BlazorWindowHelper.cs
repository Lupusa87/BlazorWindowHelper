using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public static class BlazorWindowHelper
    {
        public static Action<ConsoleKey> OnKeyUp { get; set; }
        public static Action OnScroll { get; set; }
        public static Action OnResize { get; set; }
       
        [JSInvokable]
        public static void InvokeKeyUp(int e)
        {
            ConsoleKey consoleKey = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), e.ToString());
          
            OnKeyUp?.Invoke(consoleKey);
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


    }
}
