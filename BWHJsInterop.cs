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


        public static void CheckHasjsRuntime()
        {
            if (jsRuntime is null)
            {
                throw new Exception("BlazorWindowHelper BWHJsInterop jsRuntime is null! please inject it.");
            }
        }

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


        public static ValueTask SetFocus(string id)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetFocus", id);
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

        public static ValueTask<int> GetTimezoneOffset()
        {
            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<int>(
                "BWHJsFunctions.GetTimezoneOffset");
        }

        public static ValueTask<long> GetDateMilliseconds()
        {
            CheckHasjsRuntime();

            return jsRuntime.InvokeAsync<long>(
                "BWHJsFunctions.GetDateMilliseconds");
        }

        public static ValueTask<double> GetElementActualWidth(string elementID)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualWidth", elementID);
        }

        public static ValueTask<double> GetElementActualHeight(string elementID)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualHeight", elementID);
        }

        public static ValueTask<double> GetElementActualTop(string elementID)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualTop", elementID);
        }

        public static ValueTask<double> GetElementActualLeft(string elementID)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualLeft", elementID);
        }


        public static ValueTask<double> GetWindowWidth()
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetWindowWidth");
        }

        public static ValueTask<double> GetWindowHeight()
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetWindowHeight");
        }


        public static ValueTask<bool> LocalStorageSetItem(string key, string value)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.SetItemLocalStorage", key, value);
        }

        public static ValueTask<string> LocalStorageGetItem(string key)
        {
            CheckHasjsRuntime();
            return jsRuntime.InvokeAsync<string>(
                "BWHJsFunctions.GetItemLocalStorage", key);
        }
    }
}
