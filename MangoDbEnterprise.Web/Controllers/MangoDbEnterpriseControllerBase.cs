using Abp.Web.Mvc.Controllers;

namespace MangoDbEnterprise.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class MangoDbEnterpriseControllerBase : AbpController
    {
        protected MangoDbEnterpriseControllerBase()
        {
            LocalizationSourceName = MangoDbEnterpriseConsts.LocalizationSourceName;
        }
    }
}