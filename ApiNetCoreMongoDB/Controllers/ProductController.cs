using ApiNetCoreMongoDB.Models;
using ApiNetCoreMongoDB.Service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace ApiNetCoreMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var id = await _productService.Create(product);
            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.Get(ObjectId.Parse(id));

            return new JsonResult(product);
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _productService.Get();

            return new JsonResult(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product product)
        {
            var result = await _productService.Update(ObjectId.Parse(id), product);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productService.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
