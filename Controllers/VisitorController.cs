using _DotNETCore_7_ADO_Sp_.Contexts;
using _DotNETCore_7_ADO_Sp_.Models;
using _DotNETCore_7_ADO_Sp_.VService;
using Microsoft.AspNetCore.Mvc;

namespace _DotNETCore_7_ADO_Sp_.Controllers
{
    public class VisitorController : Controller
    {

        private readonly IVisitor_Service _visitorService;
        

        public VisitorController(IVisitor_Service _visitorService)
        {
           this._visitorService = _visitorService;
            
        }
        public IActionResult Index()
        {
            // var listData= vs.GetAllData();
            var listData = _visitorService.GetVisitorsList();
            return View(listData);
        }

        [HttpGet]
        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Create( Visitor v)
        {
            if(ModelState.IsValid)
            {
                var data = _visitorService.AddProduct(v);
                return RedirectToAction("Index",data);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = _visitorService.GetVisitorById(Id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Visitor v)
        {
            if (ModelState.IsValid)
            {
                var data = _visitorService.UpdateProduct(v);
                if (data > 0)
                {

                return RedirectToAction("Index", data);
                }
                return View();
            }

            return View();
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var data = _visitorService.GetVisitorById(Id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Details(Visitor v)
        {
            var data = _visitorService.GetVisitorById(v.Id);
            return RedirectToAction("Index", data);

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = _visitorService.GetVisitorById(Id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Visitor v)
        {
            var data = _visitorService.DeleteProduct(v.Id);
            return RedirectToAction("Index",data);
        }
    }
}
