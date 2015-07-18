using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MangoDbEnterprise.API.Helper;
using MangoDbEnterprise.Domain.Entities.Todo;
using MangoDbEnterprise.Repositories;
using Swashbuckle.Swagger;

namespace MangoDbEnterprise.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TodoController : BaseController
    {
        private readonly ITodoService _todoService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenceService"></param>
        /// <param name="todoService"></param>
        public TodoController(IReferenceService referenceService ,ITodoService todoService) 
            : base(referenceService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/tasks")]
        [ResponseType(typeof(List<Todo>))]
        public ApiResult<Todo[]> Get(string required, string title = ApiConstants.DefaultEmptyStringValue)
        {
            return this.CreateResponse(_todoService.Select(x => x).ToArray());
        }

    }
}
