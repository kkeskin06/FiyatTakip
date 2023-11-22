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
    public class SaticiDao : ISaticiDao
    {
        private readonly PriceTrackingContext _context;

        public SaticiDao(PriceTrackingContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task Add(DtoSatici dto)
        {
            var saticis = new Models.Satici
            {

                SaticiAdi = dto.SaticiAdi,
                SaticiAdres = dto.SaticiAdres,
                SaticiMail = dto.SaticiMail,
                SaticiTelefon = dto.SaticiTelefon,
                SaticiTuru = dto.SaticiTuru,
                UrunId = dto.UrunId,

            };

            _context.Saticis.Add(saticis);
            await _context.SaveChangesAsync(); 

        }

        public async Task Delete(int id)
        {
            var saticis = _context.Saticis.Find(id);

            if (saticis != null)
            {
                _context.Saticis.Remove(saticis);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DtoSatici> Find(int id)
        {
            var dto = new DtoSatici();

            var saticis = await _context.Saticis.FindAsync(id);

            if (saticis != null)
            {
                dto.SaticiId = saticis.SaticiId;
                dto.SaticiAdi = saticis.SaticiAdi;
                dto.SaticiAdres = saticis.SaticiAdres;
                dto.SaticiMail = saticis.SaticiMail;
                dto.SaticiTelefon = saticis.SaticiTelefon;
                dto.SaticiTuru = saticis.SaticiTuru;
               
                dto.UrunId = saticis.UrunId;

            }
            else
            {
                throw new Exception($"Satisi with ID = {id} was not found.");
            }

            return dto;
        }

        public async Task<List<DtoSatici>> GetAll()
        {
            var Dtos = new List<DtoSatici>();

            var saticis = await _context.Saticis.ToListAsync();

            Dtos.AddRange(saticis.Select(Satici => new DtoSatici()
            {
                SaticiId=Satici.SaticiId,
                SaticiAdi=Satici.SaticiAdi,
                SaticiAdres=Satici.SaticiAdres,
                SaticiMail=Satici.SaticiMail,
                SaticiTelefon=Satici.SaticiTelefon,
                SaticiTuru = Satici.SaticiTuru,
                UrunId=Satici.UrunId,
            }).ToList());



            return Dtos;
        }

        public async Task<List<DtoSatici>> GetById(int id)
        {
            var Dtos = new List<DtoSatici>();

            var saticis = await _context.Saticis.ToListAsync();

            Dtos.AddRange(saticis.Where(s => s.UrunId == id).Select(Satici => new DtoSatici()
            {
                SaticiId = Satici.SaticiId,
                SaticiAdi = Satici.SaticiAdi,
                SaticiAdres = Satici.SaticiAdres,
                SaticiMail = Satici.SaticiMail,
                SaticiTelefon = Satici.SaticiTelefon,
                SaticiTuru = Satici.SaticiTuru,            
                UrunId = Satici.UrunId,
            }).ToList());



            return Dtos;
        }

        public async Task Update(DtoSatici dto)
        {
            var satici = new Satici
            { SaticiId = dto.SaticiId,
                SaticiAdi = dto.SaticiAdi,
                SaticiMail = dto.SaticiMail,
                SaticiAdres = dto.SaticiAdres,
                SaticiTelefon = dto.SaticiTelefon,
                SaticiTuru = dto.SaticiTuru,              
                UrunId=dto.UrunId,
            };
            _context.Entry(satici).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
