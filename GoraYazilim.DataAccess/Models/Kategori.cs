using System;
using System.Collections.Generic;

namespace GoraYazilim.DataAccess.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public string? KategoriAdi { get; set; }

    public string? KategoriBilgisi { get; set; }

    public virtual ICollection<Urun> Uruns { get; } = new List<Urun>();
}
