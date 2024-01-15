using Business.Abstract;
using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
       
            IProductDal _IProductDal;

            public ProductManager(IProductDal ProductDal)
            {
                _IProductDal = ProductDal;
            }

            public List<Product> GetAll()
            {
                return _IProductDal.GetAll();
            }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _IProductDal.GetAll(p => p.CategoryId == id);
         
        }

    
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _IProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

        }
    }
    }


