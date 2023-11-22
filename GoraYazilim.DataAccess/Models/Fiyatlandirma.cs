using System;
using System.Collections.Generic;

namespace GoraYazilim.DataAccess.Models;

public partial class Fiyatlandirma
{
    public int FiyatmandirmaId { get; set; }

    public decimal? Maliyet { get; set; }

    public decimal? TabanFiyat { get; set; }

    public decimal? ListeFiyat { get; set; }

    public decimal? CozumOrtagiFiyat { get; set; }

    public decimal? ParakendeSatisFiyat { get; set; }
    public decimal? BayiiSatisfiyati { get; set; }

    public DateTime? FiyatBaslangicTarihi { get; set; }

    public DateTime? FiyatDegisimTarihi { get; set; }

    public int? UrunId { get; set; }

    public virtual Urun? Urun { get; set; }
    public int? SaticiId { get; set; }

    public virtual Satici? Satici { get; set; }

}
