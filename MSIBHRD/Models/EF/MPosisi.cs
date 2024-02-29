using System;
using System.Collections.Generic;

namespace MSIBHRD.Models.EF;

public partial class MPosisi
{
    public int IdPosisi { get; set; }

    public string NamaPosisi { get; set; } = null!;

    public virtual ICollection<MPelamar> MPelamars { get; set; } = new List<MPelamar>();
}
