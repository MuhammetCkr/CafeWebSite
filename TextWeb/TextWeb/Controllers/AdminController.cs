using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TextWeb.Data.Abstract;
using TextWeb.Entity;

namespace TextWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IPageRepository _pageRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public AdminController(IPageRepository pageRepository, IProductRepository productRepository, UserManager<User> userManager, IUserRepository userRepository)
        {
            _pageRepository = pageRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("/Admin/PageCreate")]
        public  Page PageCreate([FromBody]Page page)
        {
            var response = _pageRepository.CreateAsync(page);
            return response;
        }

    }
}
