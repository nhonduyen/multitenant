using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitenant.Core.Interfaces;

namespace Multitenant.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var products= await _service.GetAllAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var productDetails = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _service.CreateAsync(request.Name, request.Description, request.Rate, cancellationToken));
        }
    }

    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
    }
}
