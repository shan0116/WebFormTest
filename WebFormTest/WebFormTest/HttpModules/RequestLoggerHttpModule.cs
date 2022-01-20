using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebFormTest.HttpModules
{
    public class RequestLoggerHttpModule : IHttpModule
    {

        private StreamWriter sw;
        private string filePath = @"c:\logger.txt";
        public void Dispose()
        {
            //clean-up code here.  
        }

        public void Init(HttpApplication context)
        {
            // custom logging implementation, hooking event in init Method 
            context.BeginRequest += new EventHandler(this.Application_BeginRequest);
            context.EndRequest += new EventHandler(this.Application_EndRequest);
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                sw = new StreamWriter(filePath);
            }
            else
            {
                sw = File.AppendText(filePath);
            }
            sw.WriteLine("User sent request at {0}", DateTime.UtcNow);
            sw.Close();
        }

        public void Application_EndRequest(Object source, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                sw = new StreamWriter(filePath);
            }
            else
            {
                sw = File.AppendText(filePath);
            }
            sw.WriteLine("User request completed at {0}", DateTime.UtcNow);
            sw.Close();
        }
    }
}