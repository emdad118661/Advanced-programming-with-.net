using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Controllers
{
    public class CartController : Controllers
    {
        // GET: Cart
        public ActionResult Cart()
        {
            if (Session["order"] == null)
            {
                return RedirectToAction("Index", "Product");
            }
            var cart = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["order"]);
            return View(cart);
        }
        public ActionResult AddToCart(int Id)
        {
            if (Session["order"] == null)
            {
                Product p = new Product();
                Database db = new Database();
                p = db.Products.Get(Id);
                List<Product> products = new List<Product>();
                products.Add(p);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["order"] = json;
                return RedirectToAction("Index", "Product");
            }

            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["order"]);
                Product p = new Product();
                Database db = new Database();
                p = db.Products.Get(Id);
                d.Add(p);
                string json = new JavaScriptSerializer().Serialize(d);
                Session["order"] = json;
                return RedirectToAction("Index", "Product");
            }
        }
}

