using CRM_side_project.Application;
using CRM_side_project.Application.Product.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Controller
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        //// GET: ProductController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: ProductController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}


        // POST: ProductController/CreateProduct
        [HttpPost("Product")]
        public async ValueTask<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            return Ok(await _service.CreateProduct(request));
        }
        [HttpGet("Product/{id}")]
        public async ValueTask<IActionResult> GetProductById(long id)
        {
            return Ok(await _service.GetProductById(id));
        }
        [HttpGet("Product")]
        public async ValueTask<IActionResult> GetAllProduct()
        {
            return Ok(await _service.GetAllProduct());
        }
        [HttpPut("Product/{id}")]
        public async ValueTask<IActionResult> UpdateProduct(long id, [FromBody] UpdateProductRequest request)
        {
            return Ok(await _service.UpdateProduct(id, request));
        }
        [HttpDelete("Product/{id}")]
        public async ValueTask<IActionResult> DeleteProduct(long id)
        {
            return Ok(await _service.DeleteProduct(id));
        }

       

        #region Type
        // POST: ProductController/CreateType
        [HttpPost("type")]
        public async ValueTask<IActionResult> CreateType([FromBody] CreateTypeRequest request)
        {
            return Ok(await _service.CreateType(request));
        }
        [HttpGet("type/{id}")]
        public async ValueTask<IActionResult> GetTypeById(long id)
        {
            return Ok(await _service.GetTypeById(id));
        }
        [HttpGet("type")]
        public async ValueTask<IActionResult> GetAllType()
        {
            return Ok(await _service.GetAllType());
        }
        [HttpPut("type/{id}")]
        public async ValueTask<IActionResult> UpdateType(long id, [FromBody] UpdateTypeRequest request)
        {
            return Ok(await _service.UpdateType(id,request));
        }
        [HttpDelete("type/{id}")]
        public async ValueTask<IActionResult> DeleteType(long id)
        {
            return Ok(await _service.DeleteType(id));
        }
        #endregion
    }
}
