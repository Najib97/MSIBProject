using System;
using System.Collections.Generic;

namespace MSIBHRD.Models.EF;

public partial class MDeparteman
{
    public int IdDepartemen { get; set; }

    public string NamaDepartemen { get; set; } = null!;

    public virtual ICollection<MKandidat> MKandidats { get; set; } = new List<MKandidat>();
}
