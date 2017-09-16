using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DTO;
using Project.ORM;
using Project.Repository;

namespace Project.Service
{
    public class ProductService
    {
        public ProductRepository _productRepository;

        public IEnumerable<ProductListDTO> ProductList()
        {
            if (_productRepository == null)
                _productRepository = new ProductRepository();

            IEnumerable<ProductListDTO> productList = _productRepository.GetByExpression(x => x.CategoryID != null).Select(s => new ProductListDTO
            {
                ProductID = s.ProductID,
                ProductName = s.ProductName,
                CategoryID = s.CategoryID,
                CategoryName = s.Categories.CategoryName,
                SupplierID = s.SupplierID,
                SupplierName = s.Suppliers.CompanyName,
                Discontinued = s.Discontinued,
                PhotoPath = s.PhotoPath,
                QuantityPerUnit = s.QuantityPerUnit,
                ReorderLevel = s.ReorderLevel,
                UnitPrice = s.UnitPrice,
                UnitsInStock = s.UnitsInStock,
                UnitsOnOrder = s.UnitsOnOrder,

            }).ToList();

            return productList;
        }

        public ProductListDTO ProductAdd(ProductAddDTO entity)
        {
            if (_productRepository == null)
                _productRepository = new ProductRepository();

            try
            {
                Products product = new Products();
                product.ProductName = entity.ProductName;
                product.CategoryID = entity.CategoryID;
                product.SupplierID = entity.SupplierID;
                product.Discontinued = entity.Discontinued;
                product.PhotoPath = entity.PhotoPath;
                product.QuantityPerUnit = entity.QuantityPerUnit;
                product.ReorderLevel = entity.ReorderLevel;
                product.UnitPrice = entity.UnitPrice;
                product.UnitsInStock = entity.UnitsInStock;
                product.UnitsOnOrder = entity.UnitsOnOrder;
                var item = _productRepository.Add(product);

                if (item != null)
                {
                    return GetProductByID(item.ProductID);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public ProductListDTO ProductEdit(ProductUpdateDTO entity)
        {
            if (_productRepository == null)
                _productRepository = new ProductRepository();

            try
            {
                Products product = _productRepository.GetDataById(entity.ProductID);
                product.ProductID = entity.ProductID;
                product.ProductName = entity.ProductName;
                product.CategoryID = entity.CategoryID;
                product.SupplierID = entity.SupplierID;
                product.Discontinued = entity.Discontinued;
                product.PhotoPath = entity.PhotoPath;
                product.QuantityPerUnit = entity.QuantityPerUnit;
                product.ReorderLevel = entity.ReorderLevel;
                product.UnitPrice = entity.UnitPrice;
                product.UnitsInStock = entity.UnitsInStock;
                product.UnitsOnOrder = entity.UnitsOnOrder;
                var item = _productRepository.Update(product);

                if (item != null)
                {
                    return GetProductByID(item.ProductID);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ProductDelete(int id)
        {
            if (_productRepository == null)
                _productRepository = new ProductRepository();
            try
            {
                Products product = _productRepository.GetDataById(id);
                _productRepository.Delete(product);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public ProductListDTO GetProductByID(int id)
        {
            if (_productRepository == null)
                _productRepository = new ProductRepository();

            var product = _productRepository.GetDataById(id);

            if (product != null)
            {
                return new ProductListDTO
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    CategoryID = product.CategoryID,
                    CategoryName = product.Categories.CategoryName,
                    SupplierID = product.SupplierID,
                    SupplierName = product.Suppliers.CompanyName,
                    Discontinued = product.Discontinued,
                    PhotoPath = product.PhotoPath,
                    QuantityPerUnit = product.QuantityPerUnit,
                    ReorderLevel = product.ReorderLevel,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    UnitsOnOrder = product.UnitsOnOrder,

                };
            }
            else
            {
                return null;
            }
        }
    }
}
