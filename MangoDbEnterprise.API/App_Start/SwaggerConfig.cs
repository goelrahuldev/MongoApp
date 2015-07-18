using System.Web.Http;
using WebActivatorEx;
using MangoDbEnterprise.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MangoDbEnterprise.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1",
                            string.Format("{0} v{1}", AppContants.AppName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocExpansion(DocExpansion.List);
                        c.EnableDiscoveryUrlSelector();
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\MangoDbEnterprise.API.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}