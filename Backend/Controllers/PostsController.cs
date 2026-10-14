using backend.DTOs;
using backend.services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _titlesService;

        public PostsController(IPostService titlesServices)
        {
            _titlesService = titlesServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDTO>> Get() => await _titlesService.Get();
    }
}
