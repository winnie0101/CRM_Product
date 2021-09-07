using CRM_side_project.Application.Product.Contract;
using CRM_side_project.Contexts;
using CRM_side_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.DAL.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly CRMsideprojectContext _crmDbContext;
        public ProductRepository(CRMsideprojectContext crmDbContext)
        {
            _crmDbContext = crmDbContext;
        }

        #region Product
        public async ValueTask<int> CreateProduct(long id, object value)
        {
            var entity = new Product
            {
                ProductId = id,
                IsDeleted = false,
                CreatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                CreatedUser = $"{Environment.MachineName}\\{Environment.UserName}",
                UpdatedDateTime= DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                UpdatedUser =$"{Environment.MachineName}\\{Environment.UserName}"
        };
            await _crmDbContext.Products.AddAsync(entity);
            _crmDbContext.Entry(entity).CurrentValues.SetValues(value);
            return await _crmDbContext.SaveChangesAsync();
        }

        public async ValueTask<Product> GetProductById(long id)
        {
            return await this._crmDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }
        public async ValueTask<Product> GetProductByName(string name)
        {
            return await _crmDbContext.Products.FirstOrDefaultAsync(x => x.ProductName == name);
        }
        public async ValueTask<Product> UGetProductByName(string name, long id)
        {
            var findName = from x in _crmDbContext.Products
                           where x.ProductName == name && x.ProductId != id
                           select x;
            return await findName.FirstOrDefaultAsync();
        }

        public IQueryable<GetAllProductResponse> GetAllProduct()
        {
            var data = _crmDbContext.Products.Select(x => new GetAllProductResponse
            {
                ProductId=x.ProductId,
                ProductName=x.ProductName,
                TypeId=x.TypeId,
                Price=x.Price,
                Discount=x.Discount,
                CreatedDateTime=x.CreatedDateTime,
                CreatedUser=x.CreatedUser,
                Description=x.Description,
                IsDeleted=x.IsDeleted,
                IsEnabled=x.IsEnabled,
                Rowversion=x.Rowversion,
                UpdatedDateTime=x.UpdatedDateTime,
                UpdatedTimes=x.UpdatedTimes,
                UpdatedUser=x.UpdatedUser
            });
            return data;
        }
        public async Task<int> UpdateProduct(long id, UpdateProductRequest request)
        {
            var entity =await _crmDbContext.Products.FindAsync(id);
            entity.UpdatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            entity.UpdatedUser = $"{Environment.MachineName}\\{Environment.UserName}";
            entity.UpdatedTimes = Convert.ToByte(Convert.ToInt16(entity.UpdatedTimes.ToString()) % 255 + 1);
            _crmDbContext.Entry(entity).CurrentValues.SetValues(request);
            return await _crmDbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteProduct(long id)
        {
            var delete = await _crmDbContext.Products.FindAsync(id);
            delete.IsDeleted = true;
            delete.UpdatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            delete.UpdatedUser = $"{Environment.MachineName}\\{Environment.UserName}";
            delete.UpdatedTimes = Convert.ToByte(Convert.ToInt16(delete.UpdatedTimes.ToString()) % 255 + 1);
            //_crmDbContext.Products.Remove(delete);
            _crmDbContext.Entry(delete).CurrentValues.SetValues(delete);
            return await _crmDbContext.SaveChangesAsync();
        }

        #endregion

        #region Type
        public async ValueTask<int> CreateType(long id, object value)
        {
            var entity = new ProductType
            {
                TypeId = id,
                IsDeleted = false,
                CreatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                CreatedUser = $"{Environment.MachineName}\\{Environment.UserName}",
                UpdatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                UpdatedUser = $"{Environment.MachineName}\\{Environment.UserName}"
            };
            await _crmDbContext.ProductTypes.AddAsync(entity);
            _crmDbContext.Entry(entity).CurrentValues.SetValues(value);
            return await _crmDbContext.SaveChangesAsync();
        }

        public async ValueTask<ProductType> GetTypeById(long id)
        {
            return await _crmDbContext.ProductTypes.FirstOrDefaultAsync(x => x.TypeId == id);
        }
        public async ValueTask<ProductType> GetTypeByName(string name)
        {
            return await _crmDbContext.ProductTypes.FirstOrDefaultAsync(x => x.TypeName == name);
        }
        public async ValueTask<ProductType> UGetTypeByName(string name, long id)
        {
            var findName = from x in _crmDbContext.ProductTypes
                           where x.TypeName == name && x.TypeId != id
                           select x;
            return await findName.FirstOrDefaultAsync();
        }

        public IQueryable<GetAllTypeResponse> GetAllType()
        {
            var data = _crmDbContext.ProductTypes.Select(x => new GetAllTypeResponse
            {
               
                TypeId = x.TypeId,
                TypeName=x.TypeName,
                CreatedDateTime = x.CreatedDateTime,
                CreatedUser = x.CreatedUser,
                IsDeleted = x.IsDeleted,
                Rowversion = x.Rowversion,
                UpdatedDateTime = x.UpdatedDateTime,
                UpdatedTimes = x.UpdatedTimes,
                UpdatedUser = x.UpdatedUser
            });
            return data;
        }
        public async Task<int> UpdateType(long id, UpdateTypeRequest request)
        {
            var entity = await _crmDbContext.ProductTypes.FindAsync(id);
            entity.UpdatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            entity.UpdatedUser = $"{Environment.MachineName}\\{Environment.UserName}";
            entity.UpdatedTimes = Convert.ToByte(Convert.ToInt16(entity.UpdatedTimes.ToString()) % 255 + 1);

            _crmDbContext.Entry(entity).CurrentValues.SetValues(request);
            return await _crmDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteType(long id)
        {
            var delete = await _crmDbContext.ProductTypes.FindAsync(id);
            delete.IsDeleted = true;
            delete.UpdatedDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            delete.UpdatedUser = $"{Environment.MachineName}\\{Environment.UserName}";
            delete.UpdatedTimes = Convert.ToByte(Convert.ToInt16(delete.UpdatedTimes.ToString()) % 255 + 1);
            //_crmDbContext.ProductTypes.Remove(delete);
            _crmDbContext.Entry(delete).CurrentValues.SetValues(delete);
            return await _crmDbContext.SaveChangesAsync();
        }
        #endregion
    }


}
