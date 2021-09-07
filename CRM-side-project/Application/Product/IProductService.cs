using CRM_side_project.Application.Common;
using CRM_side_project.Application.Product.Contract;
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
