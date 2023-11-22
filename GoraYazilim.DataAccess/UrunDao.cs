using GoraYazilim.DataAccess.Interface;
using GoraYazilim.DataAccess.Models;
using GoraYazilim.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GoraYazilim.DataAccess
{
    public class UrunDao : IUrunDao
    {
        private readonly PriceTrackingContext _context;
        
        public UrunDao(PriceTrackingContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task Add(DtoUrun dto)
        {
           
            var urunss = new Models.Urun
            {
                UrunAdi = dto.UrunAdi,
                UrunFiyat = dto.UrunFiyat,
                UrunMarkasi = dto.UrunMarkasi,
                UrunKodu = dto.UrunKodu,
                KategoriId = dto.KategoriId,
            };

            _context.Uruns.Add(urunss);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var uruns = _context.Uruns.Find(id);

            if(uruns != null)
            {
                _context.Uruns.Remove(uruns);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DtoUrun> Find(int id)
        {
            var dto = new DtoUrun();

            var uruns = await _context.Uruns.FindAsync(id);

            if(uruns != null)
            {
                dto.UrunId = uruns.UrunId;
                dto.UrunAdi = uruns.UrunAdi;
                dto.UrunFiyat = uruns.UrunFiyat;
                dto.UrunMarkasi = uruns.UrunMarkasi;
                dto.UrunKodu = uruns.UrunKodu;
                dto.KategoriId = uruns.KategoriId;
            }
            else
            {
                throw new Exception($"Urun with ID = {id} was not found.");
            }
            return dto;
        }

        public async Task<List<DtoUrun>> GetAll()
        {
           
            var dtos = new List<DtoUrun>();

            var uruns = await _context.Uruns.ToListAsync();

            //foreach (var item in uruns)
            //{                
            //    var tt = await _context.AltUruns.Where(x => x.UrunId == item.UrunId).ToListAsync();
            //    item.UrunFiyat = tt.Sum(x => x.AlturunFiyat);
            //}
            //foreach (var item in uruns)
            //{
            //    var tt = await _context.AltUruns.Where(x => x.UrunId == item.UrunId).ToListAsync();
            //    var toplam = 0M;
            //    foreach (var item2 in tt)
            //    {
            //        decimal.TryParse(item2.AlturunFiyat, out decimal tutar);
            //        toplam += tutar;
            //    }
            //    item.UrunFiyat = toplam.ToString();
            //}

            //uruns.ForEach(u => u.UrunFiyat = u.AltUruns.Where(t => t.UrunId == u.UrunId).ToList().Sum(x => x.AlturunFiyat));

            dtos.AddRange(uruns.Select(Urun => new DtoUrun()
            {
                UrunId= Urun.UrunId,
                UrunAdi=Urun.UrunAdi,
                UrunFiyat= Urun.UrunFiyat,
                UrunMarkasi=Urun.UrunMarkasi,
                UrunKodu=Urun.UrunKodu,
                KategoriId=Urun.KategoriId,              
            }).ToList());
           
            
            return dtos;
                     
           
        }

        public async Task Update(DtoUrun dto)
        {
            var uruns = new Urun
            {
                UrunId = dto.UrunId,
                UrunAdi = dto.UrunAdi,
                UrunFiyat=dto.UrunFiyat,
                UrunKodu = dto.UrunKodu,
                UrunMarkasi = dto.UrunMarkasi,
                KategoriId=dto.KategoriId,
            };

            _context.Entry(uruns).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}