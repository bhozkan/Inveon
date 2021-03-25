using InveonService.DbContexts;
using InveonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonService.Business
{
    public class ProductBusiness
    {
        private readonly InveonContext inveonContext;

        public ProductBusiness(InveonContext _inveonContext)
        {
            inveonContext = _inveonContext;
        }

        public List<Product> GetProducts()
        {
            return inveonContext.Products.Where(x=> x.ProductIsActive == true).ToList();
        }

        public Product GetProduct(Product product)
        {
            return inveonContext.Products.Where(x=> x.Id == product.Id && x.ProductIsActive == true).FirstOrDefault();
        }

        public bool AddProduct(Product addProduct)
        {
            Product product = new Product {
                ProductBarcode = addProduct.ProductBarcode,
                ProductIsActive = true,
                ProductImageUrl = addProduct.ProductImageUrl,
                ProductName = addProduct.ProductName,
                ProductPrice = addProduct.ProductPrice,
                ProductUnit = addProduct.ProductUnit,
                ProductDescryption = addProduct.ProductDescryption
                
            };

            inveonContext.Products.Add(product);

            try
            {
                inveonContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product EditProduct(Product editProduct)
        {
            Product product = inveonContext.Products.Where(x => x.Id == editProduct.Id).FirstOrDefault();

            product.ProductBarcode = editProduct.ProductBarcode;
            product.ProductImageUrl = editProduct.ProductImageUrl;
            product.ProductName = editProduct.ProductName;
            product.ProductPrice = editProduct.ProductPrice;
            product.ProductUnit = editProduct.ProductUnit;
            product.ProductDescryption = editProduct.ProductDescryption;


            inveonContext.Products.Update(product);

            try
            {
                inveonContext.SaveChanges();
                return (product);
            }
            catch (Exception)
            {
                return editProduct;
            }
      
        }

        public bool DeleteProduct(Product editProduct)
        {
            Product product = inveonContext.Products.Where(x => x.Id == editProduct.Id).FirstOrDefault();

            product.ProductIsActive = false;
            

            inveonContext.Products.Update(product);

            try
            {
                inveonContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



    }
}
