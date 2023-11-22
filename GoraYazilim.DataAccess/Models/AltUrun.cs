using System;
using System.Collections.Generic;

namespace GoraYazilim.DataAccess.Models;

public partial class AltUrun
{
    public int AlturunId { get; set; }

    public string? AlturunAdi { get; set; }

    public decimal? AlturunFiyat { get; set; }

    public int? UrunId { get; set; }

    public virtual Urun Urun { get; set; }
}
