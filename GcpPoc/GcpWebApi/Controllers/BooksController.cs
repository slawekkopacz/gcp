using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFirestoreService;
using Microsoft.AspNetCore.Mvc;

namespace GcpWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var firestoreClient = new CloudFirestoreClient();
            var books = await firestoreClient.GetBooks().ToListAsync();
            return books;
        }
    }
}
