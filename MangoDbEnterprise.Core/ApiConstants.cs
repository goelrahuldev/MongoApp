namespace MangoDbEnterprise
{
    public class ApiConstants
    {
        public const string StatusCode = "statusCode";
        public const string ReturnedBy = "returned-by";
        public const string AppName = "MongoDb";
        public const string ProcessedIn = "processed-in";

        public const string DefaultEmptyStringValue = "";

#region Swagger Constants
        public const string SwaggerVersion = "1.0";
        public const string WebApiNamespace = "MangoDbEnterprise.WebAPI";
        public const string SwashBuckleExtension = "MangoDbEnterprise.WebAPI.Content.SwashBuckleExtension.js";
        public const string XmlCommentPath = @"{0}\bin\USGA.GHIN.WebAPI.XML";
#endregion
    }
    public enum ServiceStatus
    {
        /// <summary>
        /// Indicative of success response
        /// </summary>
        Success,

        /// <summary>
        /// Indicative of failed response
        /// </summary>
        Failed,

        Created,
        RequestNotValid,
        Exception
    }
    public enum AppKey
    {
        CorsConfigurationValues
    }

}
