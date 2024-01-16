using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

ProductTest();
//CategoryTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    foreach (var product in productManager.GetProductDetails())
    {
        Console.WriteLine(product.ProductName+ "/" + product.CategoryName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new(new EFCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);

    }
}