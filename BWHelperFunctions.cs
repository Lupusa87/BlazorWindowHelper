using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlazorWindowHelper
{
    public static class BWHelperFunctions
    {
        public static async void CheckIfMobile()
        {
            double w = await BWHJsInterop.GetWindowWidth();

            double h = await BWHJsInterop.GetWindowHeight();


            if (h > w)
            {

                await BWHJsInterop.Alert("Sorry this app isn't designed for mobile screen, please use desktop. You see this because screen height is more than width.");
            }
        }


        public static string getMethodName(MethodBase Par_Method)
        {
            return Par_Method.Name + "." + Par_Method.DeclaringType.FullName;
        }
    }
}
