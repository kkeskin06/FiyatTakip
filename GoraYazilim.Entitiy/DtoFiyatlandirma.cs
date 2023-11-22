using System;
using System.Collections.Generic;

namespace GoraYazilim.Entity;

public partial class DtoFiyatlandirma
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

    public virtual DtoUrun? Urun { get; set; }

    public int? SaticiId { get; set; }

    public virtual DtoSatici? Satici { get; set; }

}
