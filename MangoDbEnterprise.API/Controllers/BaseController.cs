using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MangoDbEnterprise.Repositories;

namespace MangoDbEnterprise.API.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IReferenceService _referenceService;
        public BaseController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }
    }
}
