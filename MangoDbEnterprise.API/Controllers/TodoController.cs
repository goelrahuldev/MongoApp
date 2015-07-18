using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MangoDbEnterprise.API.Helper;
using MangoDbEnterprise.Domain.Entities.Todo;
using MangoDbEnterprise.Repositories;

namespace MangoDbEnterprise.API.Controllers
{
    public class TodoController : BaseController
    {
        private readonly ITodoService _todoService;
        public TodoController(IReferenceService referenceService ,ITodoService todoService) 
            : base(referenceService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ApiResult<Todo[]> Get()
        {
            return this.CreateResponse(_todoService.Select(x => x).ToArray());
        }

    }
}
