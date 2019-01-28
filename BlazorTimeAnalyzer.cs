using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorWindowHelper
{
    public static class BlazorTimeAnalyzer
    {

        private static List<TimeTask> list = new List<TimeTask>();

        public static void Reset()
        {
            list = new List<TimeTask>();
        }


        public static void Add(string Par_Name, MethodBase Par_Method, string Par_Description = "NA")
        {

            TimeTask t = new TimeTask
            {
                ID = list.Count + 1,
                Name = Par_Name,
                Description = Par_Description,
                Method = getMethod(Par_Method),
                StartDate = DateTime.Now,
            };

            list.Add(t);
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


        public static void Log()
        {
            Calculate();


            BWHJsInterop.Log("=============== time report ==============");
            BWHJsInterop.Log("N === Name === Description === Method === Start === End === Duration === Percentage");
            foreach (var item in list)
            {
                BWHJsInterop.Log(item.ID + "   " + item.Name + "   " + item.Description + "   " + item.Method + "   " + item.StartDate.ToString("HH:mm:ss.fff") + "   " + item.EndDate.ToString("HH:mm:ss.fff") + "   " + item.Duration.ToString(@"hh\:mm\:ss\.fff") + "   " + item.Percentage + "%");
            }
            BWHJsInterop.Log("==========================================");

            Reset();
        }


        public static string getMethod(MethodBase Par_Method)
        {
            return Par_Method.Name + "." + Par_Method.DeclaringType.FullName;
        }
    }

    public class TimeTask
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Method { get; set; }
        public double Percentage { get; set; }

    }



}
