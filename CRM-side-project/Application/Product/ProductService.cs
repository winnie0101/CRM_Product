using CRM_side_project.Application.Common;
using CRM_side_project.Application.Product.Contract;
using CRM_side_project.DAL.Repository;
using CRM_side_project.Handler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Application
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IGenerateId _generate;
        public ProductService(IProductRepository repository
                            , IGenerateId generate)
        {
            _repository = repository;
            _generate = generate;
        }
        #region product
        public async ValueTask<BasicResponse<bool>> CreateProduct(CreateProductRequest request)
        {

            var name = await _repository.GetProductByName(request.ProductName);
            if (name != null)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "這個product name 已存在", data = false };
            }
            var typeId = await _repository.GetTypeById(request.TypeId);
            if (typeId == null)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "type 不存在 請先新增", data = false };
            }
            var result = await _repository.CreateProduct(_generate.GetId(), request);
            if (result == 0)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "create product failed", data = false };
            }
            return new BasicResponse<bool>() { code = 0000, desc = "create product success", data = true };
        }

        public async ValueTask<BasicResponse<object>> GetProductById(long id)
        {
            var result = await _repository.GetProductById(id);
            if(result==null)
            {
                return new BasicResponse<object>()
                {
                    code = 9999,
                    desc = "Product not found",
                    data = null
                };
            }
            return new BasicResponse<object>()
            {
                code = 0000,
                desc = "success",
                data = result
            };
        }
        public async ValueTask<BasicResponse<IEnumerable<GetAllProductResponse>>> GetAllProduct()
        {
            var data = _repository.GetAllProduct();
            var result = new BasicResponse<IEnumerable<GetAllProductResponse>>()
            {
                code = 0000,
                desc = "success",
                data = data
            };
            return result;
        }
        public async ValueTask<BasicResponse<bool>> UpdateProduct(long id, UpdateProductRequest request)
        {
            try
            {
                var data = await _repository.GetProductById(id);
                if(data == null)
                {
                    return new BasicResponse<bool>() { code = 9999, desc = "product not found", data = false };
                }

                var name =await _repository.UGetProductByName(request.ProductName,request.ProductId);
                if(name!= null)
                {
                    return new BasicResponse<bool>() { code = 9999, desc = "product name 已經存在", data = false };
                }

                var typeName = await _repository.GetTypeById(request.TypeId);
                if(typeName == null)
                {
                    return new BasicResponse<bool>() { code = 9999, desc = "type 不存在 請先新增", data = false };
                }
                var result = await _repository.UpdateProduct(id, request);
            }
            catch(DbUpdateException de)
            {
                return new BasicResponse<bool>() { code = 9999, desc = $"存取發生錯誤{de.Message}", data = false };
            }
            return new BasicResponse<bool>() { code = 0000, desc = "update product success", data = true };
        }
        public async ValueTask<BasicResponse<bool>> DeleteProduct(long id)
        {
            var delete = await _repository.GetProductById(id);
            if(delete==null)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "product not found", data = false };
            }
            await _repository.DeleteProduct(id);
            return new BasicResponse<bool>() { code = 0000, desc = "delete product success", data = true };
        }

        #endregion

        #region Type
        public async ValueTask<BasicResponse<bool>> CreateType(CreateTypeRequest request)
        {
            var name = await _repository.GetTypeByName(request.TypeName);
            if(name!=null)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "這個 type name 已存在", data = false };
            }
            var result = await _repository.CreateType(_generate.GetId(), request);
            if(result == 0)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "create Type Failed", data = false };
            }
            return new BasicResponse<bool>() { code = 0000, desc = "create Type success", data = true };
        }
        public async ValueTask<BasicResponse<object>> GetTypeById(long id)
        {
            var result = await _repository.GetTypeById(id);
            if (result == null)
            {
                return new BasicResponse<object>()
                {
                    code = 9999,
                    desc = "type not found",
                    data = null
                };
            }
            return new BasicResponse<object>()
            {
                code = 0000,
                desc = "success",
                data = result
            };
        }
        public async ValueTask<BasicResponse<IEnumerable<GetAllTypeResponse>>> GetAllType()
        {
            var data =  _repository.GetAllType();
            var result = new BasicResponse<IEnumerable<GetAllTypeResponse>>()
            {
                code = 0000,
                desc = "success",
                data = data
            };
            return result;
        }
        public async ValueTask<BasicResponse<bool>> UpdateType(long id, UpdateTypeRequest request)
        {
            try
            {
                var data = await _repository.GetTypeById(id);
                if(data==null)
                {
                    return new BasicResponse<bool>() { code = 9999, desc = "type not found", data = false };
                }
                var name = await _repository.UGetTypeByName(request.TypeName, request.TypeId);
                if (name != null)
                {
                    return new BasicResponse<bool>() { code = 9999, desc = "type name 已經存在", data = false };
                } 

                var result = await _repository.UpdateType(id, request);
            }
            catch(DbUpdateException de)
            {
                return new BasicResponse<bool>() { code = 9999, desc = $"存取發生錯誤{de.Message}", data = false };
            }
            return new BasicResponse<bool>() { code = 0000, desc = "update type success", data = true };
        }
        public async ValueTask<BasicResponse<bool>> DeleteType(long id)
        {
            var delete = await _repository.GetTypeById(id);
            if(delete==null)
            {
                return new BasicResponse<bool>() { code = 9999, desc = "type not found", data = false };
            }
            await _repository.DeleteType(id);
            return new BasicResponse<bool>() { code = 0000, desc = "delete type success", data = true };

        }
        #endregion
    }
}
