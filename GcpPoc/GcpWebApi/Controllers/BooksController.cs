using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFirestoreService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GcpWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> logger;

        public BooksController(ILogger<BooksController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            this.logger.LogInformation("This information was logged with ASP.NET Core instrumentation library for Google Stackdriver.");
            
            var firestoreClient = new CloudFirestoreClient();
            var books = await firestoreClient.GetBooks().ToListAsync();
            return books;
        }
    }
}
