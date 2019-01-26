using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public class BWHJsInterop
    {
        public static Task<string> Prompt(string message)
        {
           
            return JSRuntime.Current.InvokeAsync<string>(
                "BWHJsFunctions.showPrompt",
                message);
        }

        public static Task<bool> Alert(string message)
        {
            return JSRuntime.Current.InvokeAsync<bool>(
                "BWHJsFunctions.alert",message);
            
        }

        public static Task<bool> Log(string message)
        {
            return JSRuntime.Current.InvokeAsync<bool>(
                "BWHJsFunctions.log", message);

        }

        public static Task<bool> LogWithTime(string message)
        {
            return JSRuntime.Current.InvokeAsync<bool>(
                "BWHJsFunctions.logWithTime", message);

        }

        public static Task<bool> SetOnOrOff(bool OnOrOff)
        {

            return JSRuntime.Current.InvokeAsync<bool>(
                "BWHJsFunctions.setOnOrOff", OnOrOff);

        }
        
    }
}
