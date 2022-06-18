using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitenant.Example.Application.Abstractions;
using Multitenant.Example.Application.ViewModels;

namespace Multitenant.Example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _productService.GetAllAsnyc());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
            => Ok(await _productService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductVM createProductVM)
            => Ok(await _productService.CreateAsync(createProductVM.Name, createProductVM.Description, createProductVM.Rate));
    }
}
