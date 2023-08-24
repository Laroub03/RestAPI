using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class ImagesController : ControllerBase
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                var files = Request.Form.Files;

                if (files == null || files.Count == 0)
                {
                    return BadRequest("No files were uploaded.");
                }

                var base64Images = new List<string>();

                foreach (var file in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        var bytes = memoryStream.ToArray();
                        var base64 = Convert.ToBase64String(bytes);
                        base64Images.Add(base64);
                    }
                }

                return Ok(base64Images);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
