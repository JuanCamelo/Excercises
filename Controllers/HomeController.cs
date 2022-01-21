using Exercises.Contract;
using Exercises.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        
        public HomeController(IHomeService homeService)
            => _homeService = homeService;

        [HttpPost("Excercise1")]
        public async Task<ResponseOne> PostAsync(RequestOne model)
            => await _homeService.PostAsync(model);

        [HttpPost("Excercise2")]
        public async Task<dynamic> PostAsync(RequestTwo data)
            => await _homeService.PostAsync(data);

    }
}
