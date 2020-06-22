using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWindowHelper.Classes
{
    public class BWHKeyboardState
    {
        public ConsoleKey consoleKey { get; private set; }

        public bool ctrl { get; private set; }

        public bool shift { get; private set; }

        public bool alt { get; private set; }

        public bool IsCurrentOrOld { get; private set; } //current means key is down now, old means last state if it needed

        public BWHKeyboardState(ConsoleKey pConsoleKey, bool pCtrl, bool pShift, bool pAlt, bool pIsCurrentOrOld)
        {
            consoleKey = pConsoleKey;
            ctrl = pCtrl;
            shift = pShift;
            alt = pAlt;
            IsCurrentOrOld = pIsCurrentOrOld;
        }
    }
}
