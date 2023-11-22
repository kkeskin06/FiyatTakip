using System;
using System.Collections.Generic;

namespace GoraYazilim.Entity;

public partial class DtoAltUrun
{
    public int AlturunId { get; set; }

    public string? AlturunAdi { get; set; }

    public decimal? AlturunFiyat { get; set; }

    public int? UrunId { get; set; }

    public virtual DtoUrun Urun { get; set; }
}
