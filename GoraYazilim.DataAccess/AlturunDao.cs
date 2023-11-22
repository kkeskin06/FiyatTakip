using GoraYazilim.DataAccess.Interface;
using GoraYazilim.DataAccess.Models;
using GoraYazilim.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.DataAccess
{
    public class AlturunDao : IAlturunDao
    {
        private readonly PriceTrackingContext _context;

        public AlturunDao(PriceTrackingContext context)
        {
            _context = context;
        }

        public async Task Add(DtoAltUrun dto)
        {         
            var alturun = new Models.AltUrun
            {
                AlturunAdi = dto.AlturunAdi,
                AlturunFiyat = dto.AlturunFiyat,
                UrunId = dto.UrunId
            };

            _context.AltUruns.Add(alturun);
            await _context.SaveChangesAsync();

            var urun = await _context.Uruns.Where(x => x.UrunId == dto.UrunId).FirstOrDefaultAsync();
            urun.UrunFiyat = _context.AltUruns.Where(x => x.UrunId == urun.UrunId).Sum(x => x.AlturunFiyat);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var alturun = _context.AltUruns.Find(id);

            if(alturun != null)
            {
                _context.AltUruns.Remove(alturun);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DtoAltUrun> Find(int id)
        {
            var dto = new DtoAltUrun();

            var alturun = await _context.AltUruns.FindAsync(id);

            if(alturun != null)
            {
                dto.AlturunId = alturun.AlturunId;
                dto.AlturunAdi = alturun.AlturunAdi;
                dto.AlturunFiyat = alturun.AlturunFiyat;
                dto.UrunId = alturun.UrunId;
            }
            else
            {
                throw new Exception($"Alturun iwth ID = {id} wa not found.");
            }
            return dto;
        }

        public async Task<List<DtoAltUrun>> GetAll()
        {
            var dtos = new List<DtoAltUrun>();

            var alturuns = await _context.AltUruns.ToListAsync();

            dtos.AddRange(alturuns.Select(AltUrun => new DtoAltUrun()
            {
                AlturunId=AltUrun.AlturunId,
                AlturunAdi=AltUrun.AlturunAdi,
                AlturunFiyat=AltUrun.AlturunFiyat,
                UrunId=AltUrun.UrunId,
                

        }).ToList());

            return dtos;
        }

        public async Task<List<DtoAltUrun>> GetById(int id)
        {
            var dtos = new List<DtoAltUrun>();
            var alturuns = await _context.AltUruns.ToListAsync();

            dtos.AddRange(alturuns.Where(x => x.UrunId == id).Select(AltUrun => new DtoAltUrun()
            {
                AlturunId = AltUrun.AlturunId,
                AlturunAdi = AltUrun.AlturunAdi,
                AlturunFiyat = AltUrun.AlturunFiyat,
                UrunId = AltUrun.UrunId,
                


            }).ToList());
            
            return dtos;
        }

        public async Task Update(DtoAltUrun dto)
        {
            var alturuns = new AltUrun
            {
                AlturunId = dto.AlturunId,
                AlturunAdi = dto.AlturunAdi,
                AlturunFiyat = dto.AlturunFiyat,
                UrunId = dto.UrunId
            };
            _context.Entry(alturuns).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var urun = await _context.Uruns.Where(x => x.UrunId == dto.UrunId).FirstOrDefaultAsync();
            urun.UrunFiyat = _context.AltUruns.Where(x => x.UrunId == urun.UrunId).Sum(x => x.AlturunFiyat);
            await _context.SaveChangesAsync();
        }
    }
}
