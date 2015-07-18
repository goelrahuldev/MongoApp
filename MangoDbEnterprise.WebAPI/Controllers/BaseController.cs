using System.Web.Http;
using MangoDbEnterprise.Repositories;

namespace MangoDbEnterprise.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : ApiController
    {
        /// </summary>

        private readonly  IReferenceService _referenceService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenceService"></param>
        public BaseController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }
 
    }
}