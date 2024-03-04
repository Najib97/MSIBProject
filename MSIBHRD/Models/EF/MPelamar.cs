using System;
using System.Collections.Generic;

namespace MSIBHRD.Models.EF;

public partial class MPelamar
{
    public int IdPelamar { get; set; }

    public string NamaPelamar { get; set; } = null!;

    public int? IdPosisi { get; set; }

    public virtual MPosisi? IdPosisiNavigation { get; set; }

    public virtual ICollection<THasilInterview> THasilInterviews { get; set; } = new List<THasilInterview>();
}
