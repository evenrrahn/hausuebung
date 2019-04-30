using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace myMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Cheese>> Get()
        {
            return new[] { Cheese.CreateCowCheese(6, "Kuhkäse"), Cheese.CreateGoatCheese(0, "Cabrales")};
        }
    }
}
