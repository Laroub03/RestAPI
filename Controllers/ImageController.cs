using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        private static List<ImageModel> _images = new List<ImageModel>();

        [HttpGet]
        public IActionResult GetImages()
        {
            return Ok(_images);
        }

        [HttpPost]
        public IActionResult UploadImage([FromBody] ImageModel image)
        {
            _images.Add(image);
            return CreatedAtAction(nameof(GetImages), null);
        }
    }
}