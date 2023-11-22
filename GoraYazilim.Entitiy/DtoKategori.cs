using System;
using System.Collections.Generic;

namespace GoraYazilim.Entity;

public partial class DtoKategori
{
    public int KategoriId { get; set; }

    public string? KategoriAdi { get; set; }

    public string? KategoriBilgisi { get; set; }

    public virtual ICollection<DtoUrun> Uruns { get; } = new List<DtoUrun>();
}
