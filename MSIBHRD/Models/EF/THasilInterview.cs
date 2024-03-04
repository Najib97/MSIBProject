using System;
using System.Collections.Generic;

namespace MSIBHRD.Models.EF;

public partial class THasilInterview
{
    public int IdHasil { get; set; }

    public int? IdPelamar { get; set; }

    public int? IdKandidat { get; set; }

    public DateOnly? TanggalInterview { get; set; }

    public string? Hasil { get; set; }

    public virtual MKandidat? IdKandidatNavigation { get; set; }

    public virtual MPelamar? IdPelamarNavigation { get; set; }
}
