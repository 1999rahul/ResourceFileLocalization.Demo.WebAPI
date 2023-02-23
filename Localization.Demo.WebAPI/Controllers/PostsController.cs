using Localization.Demo.WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Localization.Demo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> stringLocalizer;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;

        public PostsController(IStringLocalizer<PostsController> postsControllerLocalizer,
                               IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            this.stringLocalizer = postsControllerLocalizer;
            this.sharedResourceLocalizer = sharedResourceLocalizer;
        }
        [HttpGet("PostsControllerResource")]

        public IActionResult GetUsingPostsControllerResource()
        {
            var goodbye = stringLocalizer["Goodbye"];
            var welcome = stringLocalizer["Welcome to Dotnet World"];
            var hello = stringLocalizer["Hello"];

            var responseType = "Controller Resource Structure";

            return Ok(new { goodbye = goodbye.Value, welcome = welcome.Value, hello= hello.Value, responseType=responseType });
        }

        [HttpGet]
        [Route("PostsControllerSharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var goodbye = sharedResourceLocalizer["Goodbye"];
            var welcome = sharedResourceLocalizer["Welcome to Dotnet World"];
            var hello = sharedResourceLocalizer["Hello"];
            var responseType = "Shared Resource Structure";

            return Ok(new { goodbye = goodbye.Value, welcome = welcome.Value, hello = hello.Value, responseType=responseType });
        }
    }
}
