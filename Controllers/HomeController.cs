using ASP.Net_MVC_page_with_form.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Collections.Generic;

namespace ASP.Net_MVC_page_with_form.Controllers
{
    public class HomeController : Controller
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { No = 0, Code = "", Name = "", Sub_Total = 0, Unit_price = 0 },
            new Product { No = 1, Code = "DEL1109", Name = "DELL Laptop", Sub_Total = 50000.00M, Unit_price = 50000 },
            new Product { No = 2, Code = "LOGI3224", Name = "Logitec mouse", Sub_Total = 1000.00M, Unit_price = 500 },
            new Product { No = 3, Code = "LOGI4343", Name = "Logitec Keyboard", Sub_Total = 1500.00M, Unit_price = 1500 }
        };

        private static Order order = new Order();

        public ActionResult Index()
        {
            ViewBag.Products = new SelectList(Products, "Code", "Name");
            return View(order);
        }

        [HttpPost]
        public ActionResult AddToCart(string productCode, int quantity)
        {
            Product product = Products.FirstOrDefault(p => p.Code == productCode);
            if (product != null && quantity > 0)
            {
                CartItem item = new CartItem { Product = product, Quantity = quantity, No = product.No };
                order.CartItems.Add(item);
            }
            ViewBag.Products = new SelectList(Products, "Code", "Name");
            return View("Index", order);
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int index)
        {
            if (index >= 0 && index < order.CartItems.Count)
            {
                order.CartItems.RemoveAt(index);
            }
            ViewBag.Products = new SelectList(Products, "Code", "Name");
            return View("Index", order);
        }

        [HttpPost]
        public IActionResult Index(Order formData)
        {
            if (HttpContext.Request.Method == "POST")
            {
                if (string.IsNullOrEmpty(formData.ShippingAddress.Name) ||
                    string.IsNullOrEmpty(formData.ShippingAddress.Address) ||
                    string.IsNullOrEmpty(formData.ShippingAddress.Address2) ||
                    string.IsNullOrEmpty(formData.ShippingAddress.City) ||
                    string.IsNullOrEmpty(formData.ShippingAddress.Mobile))
                {
                    ModelState.AddModelError("", "Please fill in all fields.");
                }
                else
                {
                    // Process the form data (e.g., save to a database).
                    return Json(new { success = true, message = "Form submitted successfully!" });
                }
            }

            ViewBag.Products = new SelectList(Products, "Code", "Name");
            return View(order);
        }

        [HttpGet]
        public IActionResult GetProductDetails(string productCode)
        {
            Product product = Products.FirstOrDefault(p => p.Code == productCode);
            if (product != null)
            {
                return Json(new { unitPrice = product.Unit_price });
            }
            return Json(null);
        }
    }
  }
