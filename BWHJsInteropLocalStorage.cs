using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public class BWHJsInteropLocalStorage
    {
        public static IJSRuntime jsRuntime { get; set; }


        public static void CheckHasJsRuntime()
        {
            if (jsRuntime is null)
            {
                throw new Exception("BlazorWindowHelper BWHJsInterop jsRuntime is null! please inject it.");
            }
        }

        public static ValueTask<bool> LocalStorageSetItem(string key, string value)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.SetItemLocalStorage", key, value);
        }


        public static ValueTask<bool> LocalStorageCheckIfKeyExists(string key)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.CheckIfKeyExistsLocalStorage", key);
        }

        public static ValueTask<string> LocalStorageGetItem(string key)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<string>(
                "BWHJsFunctions.GetItemLocalStorage", key);
        }




        public static ValueTask<bool> LocalStorageRemoveItem(string key)
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<bool>(
                "BWHJsFunctions.RemoveItemLocalStorage", key);
        }
        public static ValueTask<bool> LocalStorageClear()
        {
            CheckHasJsRuntime();
            return jsRuntime.InvokeAsync<bool>("BWHJsFunctions.ClearLocalStorage");
        }
    }
}
