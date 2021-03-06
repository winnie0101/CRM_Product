using CRM_side_project.Application.Product.Contract;
using CRM_side_project.DAL.Repository.Common;
using CRM_side_project.DAL.Repository.Models;
using CRM_side_project.Models;
using CrmSysCRM_side_projecttemApi.DAL.Repository.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.DAL.Repository
{
    public interface IProductRepository
    {
        #region Product
        ValueTask<int> CreateProduct(long id, object value);
        ValueTask<Product> GetProductById(long id);
        ValueTask<Product> GetProductByName(string name);
        ValueTask<Product> UGetProductByName(string name, long id);
        IQueryable<GetAllProductResponse> GetAllProduct();
        Task<int> UpdateProduct(long id, UpdateProductRequest request);
        Task<int> DeleteProduct(long id);

        //關鍵字查詢
        Task<PagingSearchingResult<ProductDetail>> GetProducts(PagingSearching searching);

        //匯出csv
        Task<ExportSearchingResult<ExportProduct>> ExportGetProducts(ExportSearching searching);
        #endregion

        #region Type

        ValueTask<int> CreateType(long id, object value);
        ValueTask<ProductType> GetTypeById(long id);
        ValueTask<ProductType> GetTypeByName(string name);
        ValueTask<ProductType> UGetTypeByName(string name, long id);
        IQueryable<GetAllTypeResponse> GetAllType();
        Task<int> UpdateType(long id, UpdateTypeRequest request);
        Task<int> DeleteType(long id);
        #endregion
    }
}
