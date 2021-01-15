using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public class BWHJsInterop
    {


        public static ValueTask<string> Prompt(string message)
        {

            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<string>(
                "BWHJsFunctions.showPrompt",
                message);
        }

        public static ValueTask<bool> Alert(string message)
        {

            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.alert",message);
            
        }


        public static ValueTask<bool> Print()
        {

            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.Print");

        }

        public static ValueTask SetFocus(string id)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetFocus", id);
        }



        public static ValueTask<bool> JsLog(string message)
        {
            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.mylog", message);

        }

        public static ValueTask<bool> LogWithTime(string message)
        {

            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.logWithTime", message);

        }

        public static ValueTask<bool> SetOnOrOff(bool OnOrOff)
        {
            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.setOnOrOff", OnOrOff);

        }

        public static ValueTask<int> GetTimezoneOffset()
        {
            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<int>(
                "BWHJsFunctions.GetTimezoneOffset");
        }

        public static ValueTask<long> GetDateMilliseconds()
        {
            BWHelperFunctions.CheckHasJsRuntime();

            return BWHWindowHelper.jsRuntime.InvokeAsync<long>(
                "BWHJsFunctions.GetDateMilliseconds");
        }

        public static ValueTask<double> GetElementActualWidth(string elementID)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualWidth", elementID);
        }

        public static ValueTask<double> GetElementActualHeight(string elementID)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualHeight", elementID);
        }

        public static ValueTask<double> GetElementActualTop(string elementID)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualTop", elementID);
        }

        public static ValueTask<double> GetElementActualLeft(string elementID)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetElementActualLeft", elementID);
        }
   
        public static void ClearConsole()
        {
            BWHelperFunctions.CheckHasJsRuntime();
            BWHWindowHelper.jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.ClearConsole");
        }


        public static void SetElementTop(string elementID, int t)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            BWHWindowHelper.jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetElementTop", elementID, t);
        }

        public static void SetElementLeft(string elementID, int l)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            BWHWindowHelper.jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetElementLeft", elementID, l);
        }

        public static void SetElementWidth(string elementID, int w)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            BWHWindowHelper.jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetElementWidth", elementID, w);
        }

        public static void SetElementHeight(string elementID, int h)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            BWHWindowHelper.jsRuntime.InvokeVoidAsync(
                "BWHJsFunctions.SetElementHeight", elementID, h);
        }

        public static ValueTask<double> GetWindowWidth()
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetWindowWidth");
        }

        public static ValueTask<double> GetWindowHeight()
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<double>(
                "BWHJsFunctions.GetWindowHeight");
        }


       
    }
}
