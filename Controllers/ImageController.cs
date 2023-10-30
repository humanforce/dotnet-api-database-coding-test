using ImageConverterApi.Models;
using ImageConverterApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageConverterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IImageService _imageService;

        public ImageController(ILogger<ImageController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }


        [HttpPost]
        public IActionResult Upload(/* [FromForm] [FromBody] [FromQuery] */ ImageUploadModel model)
        {
            // TODO: Receive an image, convert it to another format (if necessary), resize it, and store it in the database.
            // Return a unique ID that can be used to query the image from the Get and Info endpoints.
            // Change the input parameters and return type of this method as required.

            throw new NotImplementedException();
        }


        [HttpGet]
        public IActionResult Get()
        {
            // TODO: Lookup an image by ID from the database and return it with the correct content type.
            // Change the input parameters and return type of this method as required.

            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Info()
        {
            // TODO: Lookup an image by ID from the database and return some basic info about it. E.g. image format, dimensions, date/time of original upload.
            // Change the input parameters and return type of this method as required.

            throw new NotImplementedException();
        }
    }
}
