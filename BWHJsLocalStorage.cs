using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public static class BWHJsLocalStorage
    {

        public static IJSRuntime jsRuntime { get; set; }

        public static bool SetItem(string key, string data)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("LocalStorage.GetItem key is null or empty!!!");
            }

            jsRuntime.InvokeVoidAsync("localStorage.setItem", key, data);

            return true;
        }

        public static ValueTask<string> GetItem(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("LocalStorage.GetItem key is null or empty!!!");
            }

            return jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

        }
    }
}
