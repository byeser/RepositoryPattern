using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Service;
using Project.DTO;
namespace Project.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductService _productService;

        public ActionResult Index()
        {
            if(_productService == null)
                _productService = new ProductService();

            IEnumerable<ProductListDTO> productList = _productService.ProductList();

            return View(productList);
        }

        public JsonResult ProductAdd(ProductAddDTO entity)
        {
            try
            {
                if (_productService == null)
                    _productService = new ProductService();

                ProductListDTO productList = _productService.ProductAdd(entity);
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public JsonResult ProductEdit(ProductUpdateDTO entity)
        {
            try
            {
                if (_productService == null)
                    _productService = new ProductService();

                ProductListDTO productList = _productService.ProductEdit(entity);
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool ProductDelete(int id)
        {
            try
            {
                if (_productService == null)
                    _productService = new ProductService();

                var item = _productService.ProductDelete(id);
                return item;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }   
}