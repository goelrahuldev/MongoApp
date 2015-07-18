using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MangoDbEnterprise.Domain.Entities.Todo;
using MangoDbEnterprise.Repositories;
using MangoDbEnterprise.WebAPI.Common;

namespace MangoDbEnterprise.WebAPI.Controllers
{
    /// <summary>
    /// TodoAPI
    /// </summary>
    public class TodoController : BaseController
    {
        private readonly ITodoService _todoService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenceService"></param>
        /// <param name="todoService"></param>
        public TodoController(IReferenceService referenceService, ITodoService todoService)
            : base(referenceService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Get All tasks
        /// </summary>
        /// <returns></returns>
        /// <remarks> Returns all Association(s) id, name and link to details of the Association(s)
        /// 
        /// Requirements References
        /// - 1.01.01.06.01
        /// 
        /// Supported Response Codes:
        /// Response Code - 200 - OK: The request has been successfully processed by the server.
        /// Response Code - 204 - No Content: There is no content matching the input request.
        /// Response Code - 404 - Content not found / No resource: The requested resource could not be found.
        /// </remarks>
        /// <response code="200">Bad request: The request could not be understood by the server due to malformed syntax.</response>
        /// <response code="400">Bad request: The request could not be understood by the server due to malformed syntax.</response>
        /// <response code="500">Internal Server Error: The server encountered an unexpected condition which prevented it from fulfilling the request.</response>
        [HttpGet]
        public ApiResult<List<Todo>>  Get()
        {
            return this.CreateResponse(_todoService.Select(x => x).ToList());
        }

    }
}
