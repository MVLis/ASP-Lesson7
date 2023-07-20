using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using ASP_Lesson7.Models;

namespace ASP_Lesson7.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static Dictionary<int, Product> _products=new ()
    {
        {++_indexCounter,new Product {Name="Книга",Description = "Чистый код",Count = 1,Price = 25.30}},
        {++_indexCounter,new Product {Name="Клавиатура",Description = "Механическая",Count = 3,Price = 200.00}},
        {++_indexCounter,new Product {Name="Кружка",Description = "Серая",Count = 5,Price = 15.50}},
        {++_indexCounter,new Product {Name="Наушники",Description = "Steelseries",Count = 2,Price = 149.99}},
        {++_indexCounter,new Product {Name="Книга",Description = "Гарри Поттер",Count = 7,Price = 30.11}} 
    };
    
    private static int _indexCounter;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var  model = new IndexModel { Products=_products };
        return View(model);
    }
    
   [HttpPost("create-product")]
   public IActionResult CreateProduct([FromForm]Product newProduct)
   {
       _products.Add(++_indexCounter,newProduct);
       return RedirectToAction("Index");
   }

   [HttpGet("get-product")]
   public IActionResult GetProduct(int id)
   {
       var  product=_products[id];
       var model = new IndexModel
       {
           Products = _products,
           Product = product,
           CurrentId = id
       };
       return View(model);
   }
   
   [HttpPost("update-product")]
   public IActionResult UpdateProduct(int id,[FromForm]Product product)
   {
       _products[id] = product;
       return RedirectToAction("Index");
   }
   
   [HttpPost("delete-product")]
   public IActionResult DeleteProduct(int id)
   {
       _products.Remove(id);
       return RedirectToAction("Index");
   }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}