using Microsoft.AspNetCore.Mvc;
using MSIBHRD.Models;
using MSIBHRD.Models.EF;
using System.Reflection.Metadata;

namespace MSIBHRD.Controllers.Master
{
	public class DepartmentController : Controller
	{
		private readonly ModelContext _context;
        string strViewPath = string.Empty;
        public DepartmentController(ModelContext context)
        {
            _context = context;
            strViewPath = string.Concat("../Master/", GetType().Name.Replace("Controller", ""), "/");
        }
        public IActionResult Index()
		{
			var model =  new Models.Master.Department.DepartmentVM.Index(_context);
			return View(strViewPath + "Index", model);
		}
        public IActionResult Add()
        {
            return PartialView(strViewPath + "_Add", new Models.Master.Department.DepartmentVM.Add());
        }
        [HttpPost]
        public IActionResult SimpanBaru(Models.Master.Department.DepartmentVM.Add model)
        {
            ResponseBase response = new() { Status = StatusEnum.Success };
            try
            {
                if (string.IsNullOrEmpty(model.NewRow.NamaDepartemen))
                {
                    response.Status = StatusEnum.Error;
                    response.Message = "Nama Harus Diisi";
                    return Json(response);
                }
                int id = 0;
                int? idDepartment = _context.MDepartemen.DefaultIfEmpty().Max(x => (int?)x.IdDepartemen);

                if (idDepartment.HasValue)
                {
                    id = idDepartment.Value + 1;
                }
                else
                {
                    id = 1;
                }
                _context.MDepartemen.Add(new MDeparteman
                {
                    IdDepartemen = id,
                    NamaDepartemen = model.NewRow.NamaDepartemen
                });
                _context.SaveChanges();
                response.Message = "Data Berhasil Tersimpan";
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Error;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            }
            return Json(response);
        }
        public IActionResult Edit(int id = -1)
        {
            try
            {
                //var idkey = Convert.ToInt32(id.DecryptString<SurabayaTaxLib.Lib.DataPegawai.Bidang>());
                Models.Master.Department.DepartmentVM.Edit model;

                TempData["TEMP_EDIT"] = id;
                model = new Models.Master.Department.DepartmentVM.Edit(_context,id);
                return PartialView(strViewPath + "_Edit", model);
            }
            catch (Exception ex)
            {
                ResponseBase response = new();
                response.Status = StatusEnum.Error;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                return Json(response);
            }

        }
        [HttpPost]
        public IActionResult Update(Models.Master.Department.DepartmentVM.Edit model)
        {
            ResponseBase response = new() { Status = StatusEnum.Success };

            try
            {
                var idkey = Convert.ToInt32(TempData["TEMP_EDIT"]);
                
                var checkData = _context.MDepartemen.First(x=> x.IdDepartemen == idkey);
                if (checkData != null)
                {
                    checkData.NamaDepartemen = model.DepartmentRow.NamaDepartemen;
                }
                _context.SaveChanges();
                response.Message = "Data berhasil diubah";
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Error;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                TempData.Keep("TEMP_EDIT");
            }

            return Json(response);
        }
    }
}
