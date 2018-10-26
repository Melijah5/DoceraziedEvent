using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Pic")]
    
    public class PicController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("{id}")]
        public IActionResult GetImage(int id)
        {
            var webRoot =_env.WebRootPath;
           var path = Path.Combine(webRoot + "/Pic/", "Event-" + id + ".jpg");
           var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/jpg");

        }
    }
}