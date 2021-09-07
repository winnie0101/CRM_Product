using CRM_side_project.Application;
using CRM_side_project.Application.Common;
using CRM_side_project.Application.Product.Contract;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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

        

        // POST: ProductController/CreateProduct
        [HttpPost]
        public async ValueTask<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            return Ok(await _service.CreateProduct(request));
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetProductById(long id)
        {
            return Ok(await _service.GetProductById(id));
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllProduct()
        {
            return Ok(await _service.GetAllProduct());
        }
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateProduct(long id, [FromBody] UpdateProductRequest request)
        {
            return Ok(await _service.UpdateProduct(id, request));
        }
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteProduct(long id)
        {
            return Ok(await _service.DeleteProduct(id));
        }

        //關鍵字查詢
        [HttpPost("GetProducts")]
        public async ValueTask<IActionResult> GetProducts([FromBody] PagingRequest request)
        {
            return Ok(await _service.GetProducts(request));
        }

        //匯出csv
        [HttpPost("Export")]
        public async ValueTask<IActionResult> Export([FromBody] ExportRequest request)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var data = _service.ExportGetProducts(request).Result.data;
            byte[] result;
            using (var memoryStream = new MemoryStream())
            {
                using(var streamWriter= new StreamWriter(memoryStream,Encoding.UTF8))
                {
                    using(var csvWriter = new CsvWriter(streamWriter,CultureInfo.CurrentCulture))
                    {
                        csvWriter.WriteRecords(data);
                        streamWriter.Flush();
                        result = memoryStream.ToArray();
                    }
                }

            }
            return new FileStreamResult(new MemoryStream(result), "text/csv") { FileDownloadName = "filename.csv" };
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
