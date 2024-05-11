using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TextWeb.Data.Abstract;
using TextWeb.Entity;

namespace TextWeb.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IPageRepository _pageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public AdminController(IPageRepository pageRepository, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _pageRepository = pageRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("PageList")]
        public async Task<List<Page>> PageList()
        {
            var response = await _pageRepository.GetAllAsync();
            return response;
        }

        [HttpPost]
        [Route("PageCreate")]
        public async Task<Page> PageCreate([FromBody] Page page)
        {
            var response = await _pageRepository.CreateAsync(page);
            return response;
        }

        [HttpGet]
        [Route("PageShow/{id}")]
        public async Task<Page> PageShow(int id)
        {
            var response = await _pageRepository.GetByIdAsync(id);
            return response;
        }

        [HttpGet]
        [Route("PageEdit/{id}")]
        public async Task<Page> PageEdit(int id)
        {
            var response = await _pageRepository.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        [Route("PageEdit")]
        public async Task<Page> PageEdit([FromBody] Page page)
        {
            var response = await _pageRepository.UpdateAsync(page);
            return response;
        }

        [HttpGet]
        [Route("CategoryList")]
        public async Task<List<Category>> CategoryList()
        {
            var response = await _categoryRepository.GetAllAsync();
            return response;
        }

        [HttpPost]
        [Route("CategoryCreate")]
        public async Task<Category> CategoryCreate([FromBody] Category category)
        {
            var response = await _categoryRepository.CreateAsync(category);
            return response;
        }

        [HttpGet]
        [Route("CategoryShow/{id}")]
        public async Task<Category> CategoryShow(int id)
        {
            var response = await _categoryRepository.GetByIdAsync(id);
            return response;
        }

        [HttpGet]
        [Route("CategoryEdit/{id}")]
        public async Task<Category> CategoryEdit(int id)
        {
            var response = await _categoryRepository.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        [Route("CategoryEdit")]
        public async Task<Category> CategoryeEdit([FromBody] Category category)
        {
            var response = await _categoryRepository.UpdateAsync(category);
            return response;
        }

        [HttpPost]
        [Route("ProductCreate")]
        public async Task<Product> ProductCreate([FromBody] Product Product)
        {
            var response = await _productRepository.CreateAsync(Product);
            return response;
        }

        [HttpGet]
        [Route("ProductShow/{id}")]
        public async Task<Product> ProductShow(int id)
        {
            var response = await _productRepository.GetByIdAsync(id);
            return response;
        }

        [HttpGet]
        [Route("ProductEdit/{id}")]
        public async Task<Product> ProductEdit(int id)
        {
            var response = await _productRepository.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        [Route("ProductEdit")]
        public async Task<Product> ProducteEdit([FromBody] Product Product)
        {
            var response = await _productRepository.UpdateAsync(Product);
            return response;
        }

        [HttpGet]
        [Route("ProductsByCategory/{id}")]
        public async Task<List<Product>> ProductsByCategory (int id)
        {
            var response = await _productRepository.ProductsByCategory(id);
            return response;
        }

    }
}
