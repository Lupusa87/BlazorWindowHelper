using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public class BWHJsInteropLocalStorage
    {

        public static ValueTask<bool> SetItem(string key, string value)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.SetItemLocalStorage", key, value);
        }


        public static ValueTask<bool> CheckIfKeyExists(string key)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.CheckIfKeyExistsLocalStorage", key);
        }

        public static ValueTask<string> GetItem(string key)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<string>(
                "BWHJsFunctions.GetItemLocalStorage", key);
        }




        public static ValueTask<bool> RemoveItem(string key)
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.RemoveItemLocalStorage", key);
        }
        public static ValueTask<bool> Clear()
        {
            BWHelperFunctions.CheckHasJsRuntime();
            return BWHWindowHelper.jsRuntime.InvokeAsync<bool>("BWHJsFunctions.ClearLocalStorage");
        }
    }
}
