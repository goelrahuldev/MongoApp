using System;
using System.Globalization;
using System.Web.Http;
using MangoDbEnterprise.WebAPI;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MangoDbEnterprise.WebAPI
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Register the swagger using the method
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.IgnoreObsoleteActions();
                    c.SingleApiVersion(ApiConstants.SwaggerVersion, ApiConstants.WebApiNamespace);
                    c.IncludeXmlComments(GetXmlCommentsPath());

                })
                .EnableSwaggerUi(c =>
                {
                    c.InjectJavaScript(thisAssembly, ApiConstants.SwashBuckleExtension);
                });
        }

        /// <summary>
        /// Get Api XML path
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            return String.Format(CultureInfo.InvariantCulture, ApiConstants.XmlCommentPath,
                AppDomain.CurrentDomain.BaseDirectory);
        }
    }

}