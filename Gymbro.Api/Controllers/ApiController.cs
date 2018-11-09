using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gymbro.Api.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {       
        [HttpGet("hw")]
        public IActionResult HelloWorld()
        {
            var response = new { message = "Hello, world" };
            return Json(response);
        }        
    }
}
