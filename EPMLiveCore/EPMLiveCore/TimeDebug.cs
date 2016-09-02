using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace EPMLiveCore
{


    public class TimeDebug
    {

        private class TimerDebugger
        {
            public DateTime StartTime = DateTime.Now;
            public DateTime EndTime = DateTime.MaxValue;
        }

        private Dictionary<string, TimerDebugger> Timers = new Dictionary<string,TimerDebugger>();
        private bool bDebug;
        private string Name;
        private DateTime StartTime;

        public TimeDebug(string name, string sbDebug)
        {
            StartTime = DateTime.Now;
            Name = name;
            bool.TryParse(sbDebug, out bDebug);
        }

        public void AddTimer()
        {
            if (bDebug)
            {
                string name = new StackFrame(1, true).GetMethod().Name;
                if(!Timers.ContainsKey(name))
                    Timers.Add(name, new TimerDebugger());
            }
        }

        public void StopTimer()
        {
            if (bDebug)
            {
                string name = new StackFrame(1, true).GetMethod().Name;
                if (Timers.ContainsKey(name))
                {
                    if(Timers[name].EndTime == DateTime.MaxValue)
                        Timers[name].EndTime = DateTime.Now;
                }
                
            }
        }

        public void StopTimers()
        {
            foreach (KeyValuePair<string, TimerDebugger> tb in Timers)
            {
                if(tb.Value.EndTime == DateTime.MaxValue)
                    tb.Value.EndTime = DateTime.Now;
            }
        }

        public void WriteTimers(System.Web.UI.HtmlTextWriter writer)
        {
            if (bDebug)
            {
                StopTimers();

                writer.WriteLine(GetHtml());
            }
        }

        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table style=\"border: 1px solid #cacaca\" cellpadding=\"5\" cellspacing=\"0\"><tr><td cospan=\"2\">Time for: " + Name + "</td></tr>");
            
            TimeSpan tsT = DateTime.Now - StartTime;

            foreach (KeyValuePair<string, TimerDebugger> tb in Timers)
            {
                if (tb.Value.EndTime == DateTime.MaxValue)
                {
                    sb.Append("<tr><td>" + tb.Key + "</td><td>No End</td></tr>");
                }
                else
                {
                    TimeSpan ts = tb.Value.EndTime - tb.Value.StartTime;

                    sb.Append("<tr><td>" + tb.Key + "</td><td>" + ts.TotalMilliseconds + " ms</td></tr>");
                }
            }

            sb.Append("<tr><td>Total Time</td><td>" + tsT.TotalMilliseconds + " ms</td></tr>");

            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
