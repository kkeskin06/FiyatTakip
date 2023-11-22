using GoraYazilim.DataAccess.Interface;
using GoraYazilim.DataAccess.Models;
using GoraYazilim.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.DataAccess
{
    public class FiyatlandirmaDao : IFiyatlandirmaDao
    {
        private readonly PriceTrackingContext _context;

        public FiyatlandirmaDao(PriceTrackingContext context)
        {
            _context = context;
        }

        public async Task Add(DtoFiyatlandirma dto)
        {
            //var fiyatlandirmas = await _context.Fiyatlandirmas.ToListAsync();
            //foreach (var item in fiyatlandirmas)
            //{
            //    var tt = await _context.Uruns.Where(x => x.UrunId == item.UrunId).ToListAsync();
            //    item.Maliyet = tt.Sum(x => x.UrunFiyat);                
            //} 
            var deger = await _context.Uruns.Where(x => x.UrunId == dto.UrunId).FirstOrDefaultAsync();
            

            var fiyatlandirma = new Models.Fiyatlandirma
            {
                Maliyet = deger.UrunFiyat,
                TabanFiyat = dto.TabanFiyat,
                ListeFiyat = dto.ListeFiyat,
                CozumOrtagiFiyat = dto.CozumOrtagiFiyat,
                ParakendeSatisFiyat = dto.ParakendeSatisFiyat,
                BayiiSatisfiyati = dto.BayiiSatisfiyati,
                FiyatBaslangicTarihi = dto.FiyatBaslangicTarihi,
                FiyatDegisimTarihi = dto.FiyatDegisimTarihi,
                SaticiId = dto.SaticiId,
                UrunId = dto.UrunId,                
            };
            var fiyatlandirma2 = new Models.Fiyatlandirma
            {
                Maliyet = deger.UrunFiyat,
                TabanFiyat = (((deger.UrunFiyat)) + ((deger.UrunFiyat) * (fiyatlandirma.TabanFiyat) / 100)),
                ListeFiyat = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.ListeFiyat) / 100,
                CozumOrtagiFiyat = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.CozumOrtagiFiyat) / 100,
                ParakendeSatisFiyat = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.ParakendeSatisFiyat) / 100,
                BayiiSatisfiyati = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.BayiiSatisfiyati) / 100,
                FiyatBaslangicTarihi = fiyatlandirma.FiyatBaslangicTarihi,
                FiyatDegisimTarihi = fiyatlandirma.FiyatDegisimTarihi,
                SaticiId = fiyatlandirma.SaticiId,
                UrunId = fiyatlandirma.UrunId,

            };
            _context.Fiyatlandirmas.Add(fiyatlandirma2);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var fiyatlandirma = _context.Fiyatlandirmas.Find(id);

            if (fiyatlandirma != null)
            {
                _context.Fiyatlandirmas.Remove(fiyatlandirma);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DtoFiyatlandirma> Find(int id)
        {
            var dto = new DtoFiyatlandirma();

            var fiyatlandirma = await _context.Fiyatlandirmas.FindAsync(id);

            if (fiyatlandirma != null)
            {
                dto.FiyatmandirmaId = fiyatlandirma.FiyatmandirmaId;
                dto.Maliyet = fiyatlandirma.Maliyet;
                dto.TabanFiyat = fiyatlandirma.TabanFiyat;
                dto.ListeFiyat = fiyatlandirma.ListeFiyat;
                dto.CozumOrtagiFiyat = fiyatlandirma.CozumOrtagiFiyat;
                dto.ParakendeSatisFiyat = fiyatlandirma.ParakendeSatisFiyat;
                dto.BayiiSatisfiyati = fiyatlandirma.BayiiSatisfiyati;
                dto.FiyatBaslangicTarihi = fiyatlandirma.FiyatBaslangicTarihi;
                dto.FiyatDegisimTarihi = fiyatlandirma.FiyatDegisimTarihi;
                dto.SaticiId = fiyatlandirma.SaticiId;
                dto.UrunId = fiyatlandirma.UrunId;

            }
            else
            {
                throw new Exception($"Fiyatlandirma with ID = {id} was not found.");
            }

            return dto;
        }

        public async Task<List<DtoFiyatlandirma>> GetAll()
        {
            var dtos = new List<DtoFiyatlandirma>();

            var fiyatlandirmas = await _context.Fiyatlandirmas.ToListAsync();           


            dtos.AddRange(fiyatlandirmas.Select(Fiyatlandirma => new DtoFiyatlandirma()
            {
                FiyatmandirmaId = Fiyatlandirma.FiyatmandirmaId,
                Maliyet = Fiyatlandirma.Maliyet,
                TabanFiyat = Fiyatlandirma.TabanFiyat,
                ListeFiyat = Fiyatlandirma.ListeFiyat ,
                CozumOrtagiFiyat = Fiyatlandirma.CozumOrtagiFiyat ,
                ParakendeSatisFiyat = Fiyatlandirma.ParakendeSatisFiyat ,
                BayiiSatisfiyati = Fiyatlandirma.BayiiSatisfiyati,
                FiyatBaslangicTarihi = Fiyatlandirma.FiyatBaslangicTarihi,
                FiyatDegisimTarihi = Fiyatlandirma.FiyatDegisimTarihi,
                SaticiId = Fiyatlandirma.SaticiId,
                UrunId = Fiyatlandirma.UrunId,


            }).ToList());

            return dtos;
        }

        public async Task<List<DtoFiyatlandirma>> GetById(int id)
        {
            var dtos = new List<DtoFiyatlandirma>();

            var fiyatlandirmas = await _context.Fiyatlandirmas.ToListAsync();

            dtos.AddRange(fiyatlandirmas.Where(x=> x.UrunId == id).Select(Fiyatlandirma => new DtoFiyatlandirma()
            {
                FiyatmandirmaId = Fiyatlandirma.FiyatmandirmaId,
                Maliyet = Fiyatlandirma.Maliyet,
                TabanFiyat = Fiyatlandirma.TabanFiyat,
                ListeFiyat = Fiyatlandirma.ListeFiyat,
                CozumOrtagiFiyat = Fiyatlandirma.CozumOrtagiFiyat,
                ParakendeSatisFiyat = Fiyatlandirma.ParakendeSatisFiyat,
                BayiiSatisfiyati = Fiyatlandirma.BayiiSatisfiyati,
                FiyatBaslangicTarihi = Fiyatlandirma.FiyatBaslangicTarihi,
                FiyatDegisimTarihi = Fiyatlandirma.FiyatDegisimTarihi,
                SaticiId = Fiyatlandirma.SaticiId,
                UrunId = Fiyatlandirma.UrunId,


            }).ToList());

            return dtos;
        }
        public async Task<List<DtoFiyatlandirma>> GetBySaticiId(int id)
        {
            var dtos = new List<DtoFiyatlandirma>();

            var fiyatlandirmas = await _context.Fiyatlandirmas.ToListAsync();

            dtos.AddRange(fiyatlandirmas.Where(x => x.SaticiId == id).Select(Fiyatlandirma => new DtoFiyatlandirma()
            {
                FiyatmandirmaId = Fiyatlandirma.FiyatmandirmaId,
                Maliyet = Fiyatlandirma.Maliyet,
                TabanFiyat = Fiyatlandirma.TabanFiyat,
                ListeFiyat = Fiyatlandirma.ListeFiyat,
                CozumOrtagiFiyat = Fiyatlandirma.CozumOrtagiFiyat,
                ParakendeSatisFiyat = Fiyatlandirma.ParakendeSatisFiyat,
                BayiiSatisfiyati = Fiyatlandirma.BayiiSatisfiyati,
                FiyatBaslangicTarihi = Fiyatlandirma.FiyatBaslangicTarihi,
                FiyatDegisimTarihi = Fiyatlandirma.FiyatDegisimTarihi,
                SaticiId = Fiyatlandirma.SaticiId,
                UrunId = Fiyatlandirma.UrunId,


            }).ToList());

            return dtos;
        }

        public async Task Update(DtoFiyatlandirma dto)
        {
            var fiyatlandirma = new Fiyatlandirma
            {
                FiyatmandirmaId = dto.FiyatmandirmaId,
                Maliyet = dto.Maliyet,
                TabanFiyat = dto.TabanFiyat,
                ListeFiyat = dto.ListeFiyat,
                CozumOrtagiFiyat = dto.CozumOrtagiFiyat,
                ParakendeSatisFiyat = dto.ParakendeSatisFiyat,
                BayiiSatisfiyati = dto.BayiiSatisfiyati,
                FiyatBaslangicTarihi = dto.FiyatBaslangicTarihi,
                FiyatDegisimTarihi = dto.FiyatDegisimTarihi,
                SaticiId = dto.SaticiId,
                UrunId = dto.UrunId,
            };
            //var deger = await _context.Uruns.Where(x => x.UrunId == dto.UrunId).FirstOrDefaultAsync();


            //var fiyatlandirma = new Models.Fiyatlandirma

            //{
            //    FiyatmandirmaId = dto.FiyatmandirmaId,
            //    Maliyet = deger.UrunFiyat,
            //    TabanFiyat = dto.TabanFiyat,
            //    ListeFiyat = dto.ListeFiyat,
            //    CozumOrtagiFiyat = dto.ListeFiyat,
            //    ParakendeSatisFiyat = dto.ParakendeSatisFiyat,
            //    BayiiSatisfiyati = dto.BayiiSatisfiyati,
            //    FiyatBaslangicTarihi = dto.FiyatBaslangicTarihi,
            //    FiyatDegisimTarihi = dto.FiyatDegisimTarihi,
            //    SaticiId = dto.SaticiId,
            //    UrunId = dto.UrunId,
            //};
            //var fiyatlandirma2 = new Models.Fiyatlandirma

            //{
            //    FiyatmandirmaId = fiyatlandirma.FiyatmandirmaId,
            //    Maliyet = deger.UrunFiyat,
            //    TabanFiyat = (((deger.UrunFiyat)) + ((deger.UrunFiyat) * (fiyatlandirma.TabanFiyat) / 100)),
            //    ListeFiyat = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.ListeFiyat) / 100,
            //    CozumOrtagiFiyat = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.CozumOrtagiFiyat) / 100,
            //    ParakendeSatisFiyat = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.ParakendeSatisFiyat) / 100,
            //    BayiiSatisfiyati = fiyatlandirma.Maliyet + (fiyatlandirma.Maliyet * fiyatlandirma.BayiiSatisfiyati) / 100,
            //    FiyatBaslangicTarihi = fiyatlandirma.FiyatBaslangicTarihi,
            //    FiyatDegisimTarihi = fiyatlandirma.FiyatDegisimTarihi,
            //    SaticiId = fiyatlandirma.SaticiId,
            //    UrunId = fiyatlandirma.UrunId,

            //};

            _context.Entry(fiyatlandirma).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
