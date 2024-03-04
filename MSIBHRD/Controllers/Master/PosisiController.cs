using Microsoft.AspNetCore.Mvc;
using MSIBHRD.Models;
using MSIBHRD.Models.EF;

namespace MSIBHRD.Controllers.Master
{
    public class PosisiController : Controller
    {
        private readonly ModelContext _context;
        string strViewPath = string.Empty;
        public PosisiController(ModelContext context)
        {
            _context = context;
            strViewPath = string.Concat("../Master/", GetType().Name.Replace("Controller", ""), "/");
        }

        public IActionResult Index()
        {
            var model = new Models.Master.Posisi.PosisiVM.Index(_context);
            return View(strViewPath + "Index", model);
        }

        public IActionResult Add()
        {
            var model = new Models.Master.Posisi.PosisiVM.Add();
            return PartialView(strViewPath + "_Add",model);
        }

        public IActionResult Edit(string id)
        {
            var model = new Models.Master.Posisi.PosisiVM.Edit(_context, Convert.ToInt32(id));
            return PartialView(strViewPath + "_Edit",model);
        }

        public IActionResult InsertPelamar(string id) 
        {
            var model = new Models.Master.Posisi.PosisiVM.InsertPelamar(_context, Convert.ToInt32(id));
            return PartialView(strViewPath + "_InsertPelamar", model);
        }

        [HttpPost]
        public IActionResult UpdatePelamar(Models.Master.Posisi.PosisiVM.InsertPelamar input)
        {
            ResponseBase responseBase = new ResponseBase();
            try
            {
                //wes jumatan sek HEHEHEHEHEHE
            }
            catch (Exception ex)
            {
                responseBase.Status = StatusEnum.Error;
                responseBase.Message = "ERROR BRO";
            }

            return Json(responseBase);
        }
    }
}
