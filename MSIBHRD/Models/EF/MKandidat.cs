using System;
using System.Collections.Generic;

namespace MSIBHRD.Models.EF;

public partial class MKandidat
{
    public int IdKandidat { get; set; }

    public string NamaKandidat { get; set; } = null!;

    public DateOnly? TanggalLahir { get; set; }

    public int? IdDepartemen { get; set; }

    public virtual MDeparteman? IdDepartemenNavigation { get; set; }

    public virtual ICollection<THasilInterview> THasilInterviews { get; set; } = new List<THasilInterview>();
}
