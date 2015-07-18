using Abp.Web.Mvc.Views;

namespace MangoDbEnterprise.Web.Views
{
    public abstract class MangoDbEnterpriseWebViewPageBase : MangoDbEnterpriseWebViewPageBase<dynamic>
    {

    }

    public abstract class MangoDbEnterpriseWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MangoDbEnterpriseWebViewPageBase()
        {
            LocalizationSourceName = MangoDbEnterpriseConsts.LocalizationSourceName;
        }
    }
}