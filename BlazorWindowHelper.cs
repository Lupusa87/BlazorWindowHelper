using Microsoft.JSInterop;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public static class BlazorWindowHelper
    {
        public static Action<ConsoleKey, bool, bool, bool> OnKeyUp { get; set; }

        public static Action<ConsoleKey, bool, bool, bool> OnKeyDown { get; set; }

        public static Action OnScroll { get; set; }
        public static Action OnResize { get; set; }


       
        public static void Initialize()
        {
            //it is doing nothing but withhout this call browser is giving error, because it can not find active BlazorWindowHelper
        }

        [JSInvokable]
        public static void InvokeKeyDown(object args)
        {
           
            string[] a = args.ToString().Replace("[", null).Replace("]", null).Split(",");

            bool ctrl = bool.Parse(a[1]);
            bool shift = bool.Parse(a[2]);
            bool alt = bool.Parse(a[3]);

           
            ConsoleKey consoleKey = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), a[0]);
           
            OnKeyDown?.Invoke(consoleKey, ctrl, shift, alt);
        }

        [JSInvokable]
        public static void InvokeKeyUp(object args)
        {
           
            string[] a = args.ToString().Replace("[", null).Replace("]", null).Split(",");

            bool ctrl = bool.Parse(a[1]);
            bool shift = bool.Parse(a[2]);
            bool alt = bool.Parse(a[3]);

            ConsoleKey consoleKey = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), a[0]);
      
            OnKeyUp?.Invoke(consoleKey, ctrl, shift, alt);
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
