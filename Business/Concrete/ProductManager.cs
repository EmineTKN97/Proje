using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _IProductDal;

        public ProductManager(IProductDal ProductDal)
        {
            _IProductDal = ProductDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _IProductDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_IProductDal.GetProductDetails());
        }


        IDataResult<List<Product>> IProductService.GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(p => p.CategoryId == id));
        }

        //Ürünün detayına inmek istediğimde kullanılır.
        IDataResult<Product> IProductService.GetById(int productİd)
        {
            return new SuccessDataResult<Product>(_IProductDal.Get(p => p.ProductId == productİd));
        }


        IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }
    }
}


