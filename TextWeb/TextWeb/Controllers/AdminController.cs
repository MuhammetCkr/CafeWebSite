using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TextWeb.Data.Abstract;
using TextWeb.Entity;
using Newtonsoft.Json;
using TextWeb.Model;

namespace TextWeb.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IPageRepository _pageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISettingsRepository _settingsRepository;

        public AdminController(IPageRepository pageRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, ISettingsRepository settingsRepository)
        {
            _pageRepository = pageRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _settingsRepository = settingsRepository;
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

        [HttpDelete]
        [Route("CategoryDelete/{id}")]
        public async Task<Category> CategoryDelete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var response = await _categoryRepository.DeleteAsync(category);
            return response;
        }

        [HttpPost]
        [Route("ProductCreate")]
        public async Task<IActionResult> ProductCreate([FromForm] IFormFile imageFile, [FromForm] string productData)
        {
            var product = JsonConvert.DeserializeObject<Product>(productData);

            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }

            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomName = Guid.NewGuid().ToString() + extension;

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "vue-project/src/img");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var path = Path.Combine(folderPath, randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                product.Image = randomName;
            }

            var response = await _productRepository.CreateAsync(product);
            return Ok(response);
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
        public async Task<IActionResult> ProductEdit([FromForm] IFormFile imageFile, [FromForm] string productData)
        {
            var product = JsonConvert.DeserializeObject<Product>(productData);

            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }

            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomName = Guid.NewGuid().ToString() + extension;

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "vue-project/src/img");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var path = Path.Combine(folderPath, randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                product.Image = randomName;
            }
            else
            {
                product.Image = "";
            }
            var response = await _productRepository.UpdateAsync(product);
            return Ok(response);
        }

        [HttpDelete]
        [Route("ProductDelete/{id}")]
        public async Task<Product> ProductDelete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var response = await _productRepository.DeleteAsync(product);
            return response;
        }

        [HttpGet]
        [Route("ProductsByCategory/{id}")]
        public async Task<List<Product>> ProductsByCategory(int id)
        {
            var response = await _productRepository.ProductsByCategory(id);
            return response;
        }

        [HttpGet]
        [Route("AllProduct")]
        public async Task<List<Product>> AllProduct()
        {
            var response = await _productRepository.GetAllAsync();
            return response;
        }

        [HttpGet]
        [Route("GetSettings/{id}")]
        public async Task<Settings> GetSettings(int id)
        {
            var response = await _settingsRepository.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        [Route("SaveSettings")]
        public async Task<Settings> SaveSettings([FromForm] IFormFile imageFile, [FromForm] string settingsModel)
        {
            var settings = JsonConvert.DeserializeObject<Settings>(settingsModel);

            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomName = Guid.NewGuid().ToString() + extension;

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "vue-project/src/img");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var path = Path.Combine(folderPath, randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                settings.BannerImage = randomName;

            }

            var response = await _settingsRepository.UpdateAsync(settings);
            return response;

        }

    }
}
