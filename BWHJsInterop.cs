using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public class BWHJsInterop
    {

        public static IJSRuntime jsRuntime { get; set; }

        public static bool IsReady { get; set; }

        public static ValueTask<string> Prompt(string message)
        {

            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<string>(
                "BWHJsFunctions.showPrompt",
                message);
        }

        public static ValueTask<bool> Alert(string message)
        {

            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.alert",message);
            
        }


        public static ValueTask<bool> JsLog(string message)
        {
            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.mylog", message);

        }

        public static ValueTask<bool> LogWithTime(string message)
        {

            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.logWithTime", message);

        }

        public static ValueTask<bool> SetOnOrOff(bool OnOrOff)
        {
            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.setOnOrOff", OnOrOff);

        }



        public static void CheckHasjsRuntime()
        {
            if (jsRuntime is null)
            {
                throw new Exception("BlazorWindowHelper BWHJsInterop jsRuntime is null! please inject it.");
            }
        }

  }
}
