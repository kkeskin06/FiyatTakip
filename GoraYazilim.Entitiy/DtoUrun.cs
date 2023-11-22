using System;
using System.Collections.Generic;
namespace GoraYazilim.Entity;

public partial class DtoUrun
{
    public int UrunId { get; set; }

    public string? UrunAdi { get; set; }

    public string? UrunMarkasi { get; set; }

    public string? UrunKodu { get; set; }

    public decimal? UrunFiyat { get; set; }

    public int? KategoriId { get; set; }

    public virtual DtoKategori Kategori { get; set; }

    public virtual ICollection<DtoAltUrun> AltUruns { get; } = new List<DtoAltUrun>();

    public virtual ICollection<DtoFiyatlandirma> Fiyatlandirmas { get; } = new List<DtoFiyatlandirma>();

    public virtual ICollection<DtoSatici> Saticis { get; } = new List<DtoSatici>();
}
