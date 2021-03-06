﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public static class BWHTimeAnalyzer
    {
        /// <summary>
        /// If this is set to true all added item will be loged,
        /// it is useful in case of error we will know what was last added step and identify error source easier. 
        /// </summary>
        public static bool LogAllAddition { get; set; } = false;

        public static string ReportName { get; set; } = string.Empty;


        public static bool DevelopmentMode { get; set; } = true;

        private static List<TimeTask> list = new List<TimeTask>();

        public static void Reset(string reportName="")
        {

            if (!string.IsNullOrEmpty(reportName))
            {
                ReportName = reportName.ToUpper();
            }
            else
            {
                ReportName = string.Empty;
            }

            if (!DevelopmentMode)
                return;

            list = new List<TimeTask>();
        }


        public static void Add(string Par_Name, MethodBase Par_Method, string Par_Description = "NA")
        {
            if (!DevelopmentMode)
                return;

            TimeTask t = new TimeTask
            {
                ID = list.Count + 1,
                Name = Par_Name,
                Description = Par_Description,
                Method = BWHelperFunctions.getMethodName(Par_Method),
                StartDate = DateTime.Now,
            };

            list.Add(t);

            if (LogAllAddition)
            {
                BWHJsInterop.JsLog("added new TimeAnalyzer item - " + t.ID + "   " + t.Name + "   " + t.Description + "   " + t.Method + "   " + t.StartDate.ToString("HH:mm:ss.fff"));
            }
        }


        public static void LogAll()
        {

            if (!DevelopmentMode)
                return;

            if (list.Any())
            {
                Calculate();


                BWHJsInterop.JsLog("=============== time report - " + ReportName+ " ==============");
                BWHJsInterop.JsLog("N === Name === Description === Method === Start === End === Duration === Percentage");
                foreach (var item in list)
                {
                    BWHJsInterop.JsLog(item.ID + "   " + item.Name + "   " + item.Description + "   " + item.Method + "   " + item.StartDate.ToString("HH:mm:ss.fff") + "   " + item.EndDate.ToString("HH:mm:ss.fff") + "   " + item.Duration.ToString(@"hh\:mm\:ss\.fff") + "   " + item.Percentage + "%");
                }
                BWHJsInterop.JsLog("=============== report end ==============");

                Reset();
            }
            else
            {
                BWHJsInterop.JsLog("===!!! Was called log method but list is empty !!!===");
            }
        }


       

        private static void Calculate()
        {

            for (int i = 1; i < list.Count; i++)
            {

                TimeTask t0 = list[i - 1];
                TimeTask t1 = list[i];


                t0.EndDate = t1.StartDate;
                t0.Duration = t0.EndDate - t0.StartDate;


            }


            TimeTask t = list.Last();
            t.EndDate = DateTime.Now;
            t.Duration = t.EndDate - t.StartDate;



            double total = list.Sum(x => x.Duration.TotalMilliseconds);


            foreach (var item in list)
            {
                item.Percentage = Math.Round(item.Duration.TotalMilliseconds * 100.0 / total, 2);

            }


            list.Add(new TimeTask
            {
                Name = "total",
                StartDate = list.Min(x => x.StartDate),
                EndDate = list.Max(x => x.EndDate),
                Duration = list.Max(x => x.EndDate) - list.Min(x => x.StartDate),
                Percentage = 100.0,
            });
        }
    }

    internal class TimeTask
    {
        internal int ID { get; set; }
        internal DateTime StartDate { get; set; }
        internal DateTime EndDate { get; set; }
        internal TimeSpan Duration { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal string Method { get; set; }
        internal double Percentage { get; set; }

    }



}
