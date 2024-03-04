using MSIBHRD.Models.EF;

namespace MSIBHRD.Models.Master.Department
{
    public class DepartmentVM
    {
        public class Index
        {
            private readonly ModelContext _context;
            public List<MDeparteman> DepartemenList { get; set; } = new List<MDeparteman>();
            public Index(ModelContext context)
            {
                _context = context;
                DepartemenList = context.MDepartemen.ToList();
            }
        }
        public class Add
        {
            public MDeparteman NewRow { get; set; } = new();
            public Add()
            {

            }
        }
        public class Edit
        {
            private readonly ModelContext _context;
            public MDeparteman DepartmentRow { get; set; } = new();
            public Edit(ModelContext context, int id)
            {
                _context = context;
                DepartmentRow = context.MDepartemen.FirstOrDefault(x => x.IdDepartemen == id);
            }
            public Edit()
            {

            }
        }
    }
}
