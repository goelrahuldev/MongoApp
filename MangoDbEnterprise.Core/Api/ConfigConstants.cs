using System.Configuration;

namespace MangoDbEnterprise.Api
{
    public static class WebConfigSettings
    {
        public static string CorsConfigurationValues
        {
            get
            {
                return ConfigurationManager.AppSettings[AppKey.CorsConfigurationValues.ToString()].ToString();
            }
        }

    }
}
