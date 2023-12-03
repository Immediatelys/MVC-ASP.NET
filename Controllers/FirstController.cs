using ASP_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_controler_view;

public class FirstController : Controller
{
    private readonly ILogger<FirstController> _longer;

    private readonly ProductService _productService;

    public FirstController(ILogger<FirstController> logger, ProductService productService)
    {
        _longer = logger;
        _productService = productService;
    }
    public string Index()
    {

        // this.HttpContext
        // this.Response
        // this.Request
        // this.RouteData

        //properties
        // this.User
        // this.ModelState
        // this.ViewData
        // this.Url
        // this.TempData

        _longer.LogInformation("Info");
        return "FirstController";
    }


    public object Anything() => DateTime.Now;

    // Kiểu trả về                 | Phương thức
    // ------------------------------------------------
    // ContentResult               | Content()
    // EmptyResult                 | new EmptyResult()
    // FileResult                  | File()
    // ForbidResult                | Forbid()
    // JsonResult                  | Json()
    // LocalRedirectResult         | LocalRedirect()
    // RedirectResult              | Redirect()
    // RedirectToActionResult      | RedirectToAction()
    // RedirectToPageResult        | RedirectToRoute()
    // RedirectToRouteResult       | RedirectToPage()
    // PartialViewResult           | PartialView()
    // ViewComponentResult         | ViewComponent()
    // StatusCodeResult            | StatusCode()
    // ViewResult                  | View()

    public IActionResult Readme()
    {
        var content = @"
            Hello, everything
            ...


            Xuanthulab.NET
        ";

        return Content(content, "text/plain");
    }

    public IActionResult Bird()
    {
        string filePath = Path.Combine(Startup.ContentRootPath, "Files", "bird.jpg");
        var bytes = System.IO.File.ReadAllBytes(filePath);
        return File(bytes, "image/jpeg");
    }

    public IActionResult IphonePro()
    {
        return Json(new
        {
            producname = "IphonePro",
            price = 10000
        });
    }

    public IActionResult Privacy()
    {
        var url = Url.Action("Privacy", "Home");
        _longer.LogInformation("Chuyen huong den Privacy");
        return LocalRedirect(url);
    }

    public IActionResult Google()
    {
        var url = "https://www.google.com/";
        _longer.LogInformation("Chuyen huong den Privacy");
        return Redirect(url);
    }

    // ViewResult | View()
    public IActionResult HelloView(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            userName = "Khach";
        }
        // View() -> Razor Engine , doc .cshtml (tempalte)
        // View() -> /View/First/cshtml (tempalte)
        //----------------------------------------------------------------
        // View(template) -template đường dẫn tuyệt đối tới .cshtml
        // View(template, model)
        // return View("/MyView/hello1.cshtml", userName);

        //Voi trg hop file cshtml nam trong view
        // return View("hello2", userName);

        //mo razor page trung ten vs action
        return View();
    }

    [TempData]
    public string StatusMessage { get; set; }
    public IActionResult ViewProduct(int? id)
    {
        var product = _productService.Where(p => p.Id == id).FirstOrDefault();
        if (product == null)
        {
            // TempData["StatusMessage"] = "San pham truy cap khong co";
            StatusMessage = "San pham truy cap khong co";

            return Redirect(Url.Action("Index", "Home"));
        }
        // truyen du lieu qua model
        //Model
        // return View(product);


        // truyen du lieu qua tempData


        //truyen dữ liêu qua ViewDate
        this.ViewData["product"] = product;
        ViewData["Title"] = product.Name;
        return View("viewProduct2");
    }


}