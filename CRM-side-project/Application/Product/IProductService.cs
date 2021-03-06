using CRM_side_project.Application.Common;
using CRM_side_project.Application.Product.Contract;
using CRM_side_project.DAL.Repository.Models;
using CrmSysCRM_side_projecttemApi.DAL.Repository.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Application
{
    public interface IProductService
    {
        #region Product
        ValueTask<BasicResponse<bool>> CreateProduct(CreateProductRequest request);
        ValueTask<BasicResponse<object>> GetProductById(long id);
        ValueTask<BasicResponse<IEnumerable<GetAllProductResponse>>> GetAllProduct();
        ValueTask<BasicResponse<bool>> UpdateProduct(long id, UpdateProductRequest request);
        ValueTask<BasicResponse<bool>> DeleteProduct(long id);

        //關鍵字查詢
        ValueTask<PagingResponse<IEnumerable<ProductDetail>>> GetProducts(PagingRequest request);

        //匯出csv
        ValueTask<ExportResponse<IEnumerable<ExportProduct>>> ExportGetProducts(ExportRequest request);
        #endregion

        #region Type
        ValueTask<BasicResponse<bool>> CreateType(CreateTypeRequest request);
        ValueTask<BasicResponse<object>> GetTypeById(long id);
        ValueTask<BasicResponse<IEnumerable<GetAllTypeResponse>>> GetAllType();
        ValueTask<BasicResponse<bool>> UpdateType(long id, UpdateTypeRequest request);
        ValueTask<BasicResponse<bool>> DeleteType(long id);
        #endregion
    }
}
