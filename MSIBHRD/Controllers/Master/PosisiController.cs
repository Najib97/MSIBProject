using Microsoft.AspNetCore.Mvc;
using MSIBHRD.Models;
using MSIBHRD.Models.EF;
using System.Reflection;

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

        public IActionResult GetDataPelamar(string id)
        {
            var model = new Models.Master.Posisi.PosisiVM.GetDataPelamar(_context, Convert.ToInt32(id));
            return PartialView(strViewPath + "_DataPelamar", model);
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
                if (input.IdPosisi <= 0)
                {
                    throw new Exception("ID POSISI TIDAK DITEMUKAN");
                }
                if (string.IsNullOrEmpty(input.NewRow.NamaPelamar))
                {
                    throw new Exception("NAMA TIDAK BOLEH KOSONG");
                }

                var checkIfPositiExist = _context.MPosisis.Where(x => x.IdPosisi == input.IdPosisi).Any();
                if (checkIfPositiExist)
                {
                    int idPelamar = 0;
                    int? getMaxId = _context.MPelamars
                        .Select(x => new { Value = x.IdPelamar })
                        .AsEnumerable()
                        .Max(x => (int?)x.Value) ?? 0;

                    idPelamar = getMaxId.Value + 1;

                    var addToDb = new MPelamar()
                    {
                        IdPelamar = idPelamar,
                        IdPosisi = input.IdPosisi,
                        NamaPelamar = input.NewRow.NamaPelamar
                    };

                    _context.MPelamars.Add(addToDb);
                    _context.SaveChanges();

                    responseBase.Status = StatusEnum.Success;
                    responseBase.Message = "Data Berhasil Ditambahkan";
                }
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
