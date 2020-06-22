using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public class BWHJsInterop
    {

        public static IJSRuntime jsRuntime { get; set; }


        public static void CheckHasJsRuntime()
        {
            if (jsRuntime is null)
            {
                throw new Exception("BlazorWindowHelper BWHJsInterop jsRuntime is null! please inject it.");
            }
        }

        public static ValueTask<string> Prompt(string message)
        {

            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<string>(
                "BWHJsFunctions.showPrompt",
                message);
        }

        public static ValueTask<bool> Alert(string message)
        {

            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.alert",message);
            
        }


        public static ValueTask<bool> Print()
        {

            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.Print");

        }

        public static ValueTask SetFocus(string id)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetFocus", id);
        }



        public static ValueTask<bool> JsLog(string message)
        {
            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.mylog", message);

        }

        public static ValueTask<bool> LogWithTime(string message)
        {

            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.logWithTime", message);

        }

        public static ValueTask<bool> SetOnOrOff(bool OnOrOff)
        {
            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.setOnOrOff", OnOrOff);

        }

        public static ValueTask<int> GetTimezoneOffset()
        {
            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<int>(
                "BWHJsFunctions.GetTimezoneOffset");
        }

        public static ValueTask<long> GetDateMilliseconds()
        {
            CheckHasJsRuntime();

            return jsRuntime.InvokeAsync<long>(
                "BWHJsFunctions.GetDateMilliseconds");
        }

        public static ValueTask<double> GetElementActualWidth(string elementID)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualWidth", elementID);
        }

        public static ValueTask<double> GetElementActualHeight(string elementID)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualHeight", elementID);
        }

        public static ValueTask<double> GetElementActualTop(string elementID)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualTop", elementID);
        }

        public static ValueTask<double> GetElementActualLeft(string elementID)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualLeft", elementID);
        }


        public static ValueTask<double> GetWindowWidth()
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetWindowWidth");
        }

        public static ValueTask<double> GetWindowHeight()
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetWindowHeight");
        }


       
    }
}
