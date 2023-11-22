using System;
using System.Collections.Generic;

namespace GoraYazilim.DataAccess.Models;

public partial class Urun
{
    public int UrunId { get; set; }

    public string? UrunAdi { get; set; }

    public string? UrunMarkasi { get; set; }

    public string? UrunKodu { get; set; }

    public decimal? UrunFiyat { get; set; }

    public int? KategoriId { get; set; }

    public virtual ICollection<AltUrun> AltUruns { get; } = new List<AltUrun>();

    public virtual ICollection<Fiyatlandirma> Fiyatlandirmas { get; } = new List<Fiyatlandirma>();

    public virtual Kategori Kategori { get; set; }

    public virtual ICollection<Satici> Saticis { get; } = new List<Satici>();
}
