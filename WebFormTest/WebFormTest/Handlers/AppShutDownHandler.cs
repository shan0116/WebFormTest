using System.Web;

namespace WebFormTest.Handlers
{
    public class AppShutDownHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<h1 style='Color:blue; font-size:15px;'>This page is under maintainace. Please try later</h1>");
        }
    }
}