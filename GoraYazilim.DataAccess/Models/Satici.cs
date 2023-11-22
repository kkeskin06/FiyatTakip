using System;
using System.Collections.Generic;

namespace GoraYazilim.DataAccess.Models;

public partial class Satici
{
    public int SaticiId { get; set; }

    public string? SaticiAdi { get; set; }

    public string? SaticiTelefon { get; set; }

    public string? SaticiAdres { get; set; }

    public string? SaticiMail { get; set; }

    public string? SaticiTuru { get; set; }

    public int? UrunId { get; set; }

    public virtual Urun? Urun { get; set; }

    public virtual ICollection<Fiyatlandirma> Fiyatlandirmas { get; } = new List<Fiyatlandirma>();
}
