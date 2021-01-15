using BlazorWindowHelper.Classes;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWindowHelper
{
    public static class BWHKeyboardHelper
    {

        public static BWHKeyboardState keyboardState=new BWHKeyboardState(ConsoleKey.Escape, false,false,false,false);

        public static event Action<BWHKeyboardState> OnKeyUp;

        public static event Action<BWHKeyboardState> OnKeyDown;

        [JSInvokable]
        public static void InvokeKeyDown(object args)
        {

            string[] a = args.ToString().Replace("[", null).Replace("]", null).Split(",");

            bool ctrl = bool.Parse(a[1]);
            bool shift = bool.Parse(a[2]);
            bool alt = bool.Parse(a[3]);

            ConsoleKey consoleKey = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), a[0]);

            keyboardState = new BWHKeyboardState(consoleKey, ctrl, shift, alt, true);
            OnKeyDown?.Invoke(keyboardState);
        }

        [JSInvokable]
        public static void InvokeKeyUp(object args)
        {

            string[] a = args.ToString().Replace("[", null).Replace("]", null).Split(",");

            bool ctrl = bool.Parse(a[1]);
            bool shift = bool.Parse(a[2]);
            bool alt = bool.Parse(a[3]);

            ConsoleKey consoleKey = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), a[0]);

            keyboardState = new BWHKeyboardState(consoleKey, ctrl, shift, alt, false);
            OnKeyUp?.Invoke(keyboardState);
        }

    }
}
