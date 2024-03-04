using Microsoft.EntityFrameworkCore;
using MSIBHRD.Models.EF;

namespace MSIBHRD.Models.Master.Posisi
{
    public class PosisiVM
    {
        public class Index
        {
            public List<MPosisi> MPosisiList { get; set; } = new List<MPosisi>();
            public Index(ModelContext context)
            {
                var mPosisiList = context.MPosisis.ToList();
                if (mPosisiList.Count > 0)
                {
                    MPosisiList = mPosisiList;
                }
            }
        }

        public class Add
        {
            public MPosisi NewRow { get; set; } = new MPosisi();
            public Add(){}
        }

        public class Edit
        {
            public MPosisi PosisiRow { get; set; } = new MPosisi();
            public Edit(ModelContext context, int id)
            {
                var mPosisi = context.MPosisis.Where(x => x.IdPosisi == id).FirstOrDefault();
                if (mPosisi != null)
                {
                    PosisiRow = mPosisi;
                }
            }
        }

        public class GetDataPelamar
        {
            public MPosisi PosisiRow { get; set; } = new MPosisi();
            public GetDataPelamar(ModelContext context, int id)
            {
                var mPosisi = context.MPosisis
                    .Include(x => x.MPelamars)
                    .Where(x => x.IdPosisi == id)
                    .FirstOrDefault();

                if (mPosisi != null)
                {
                    PosisiRow = mPosisi;
                }
            }
        }

        public class InsertPelamar
        {
            public int IdPosisi { get; set; }
            public MPosisi PosisiRow { get; set; } = new MPosisi();
            public MPelamar NewRow { get; set; } = new MPelamar();
            public InsertPelamar()
            {
                
            }
            public InsertPelamar(ModelContext context, int id)
            {
                var mPosisi = context.MPosisis
                    .Include(x => x.MPelamars)
                    .Where(x => x.IdPosisi == id)
                    .FirstOrDefault();

                if (mPosisi != null)
                {
                    PosisiRow = mPosisi;
                }
            }
        }
    }
}
