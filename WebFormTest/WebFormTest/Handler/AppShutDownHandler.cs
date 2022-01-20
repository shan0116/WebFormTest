using System.Web;

namespace WebFormTest.Handler
{
    public class AppShutDownHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<h1 style='Color:blue; font-size:15px;'>Our website is under maintainace. Please try after some time</h1>");
        }
    }
}