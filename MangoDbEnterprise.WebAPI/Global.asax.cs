using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MangoDbEnterprise.Api;
using Newtonsoft.Json;

namespace MangoDbEnterprise.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");


            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();

            var jSettings = new JsonSerializerSettings();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var configValues = WebConfigSettings.CorsConfigurationValues;
            var rootRequestPath = HttpContext.Current.Request.Headers["Origin"];

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                if (string.IsNullOrEmpty(rootRequestPath) || !configValues.Contains(rootRequestPath)) return;
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers",
                    "Content-Type, Accept, authorization, access-control-allow-headers");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", rootRequestPath);
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1740");
                HttpContext.Current.Response.End();
            }
            else
            {
                if (!string.IsNullOrEmpty(rootRequestPath))
                {
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", rootRequestPath);
                }
            }

        }

    }
}
