using System;
using System.Collections.Generic;

namespace GoraYazilim.Entity;

public partial class DtoSatici
{
    public int SaticiId { get; set; }

    public string? SaticiAdi { get; set; }

    public string? SaticiTelefon { get; set; }

    public string? SaticiAdres { get; set; }

    public string? SaticiMail { get; set; }

    public string? SaticiTuru { get; set; }

    public int? UrunId { get; set; }

    public virtual DtoUrun? Urun { get; set; }

    public virtual ICollection<DtoFiyatlandirma> Fiyatlandirmas { get; } = new List<DtoFiyatlandirma>();
}
