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
    public class KategoriDao : IKategoriDao
    {
        private readonly PriceTrackingContext _context;

        public KategoriDao(PriceTrackingContext context)
        {
            _context = context;
        }

        public async Task Add(DtoKategori dto)
        {
            var kategori = new Models.Kategori
            {
                KategoriAdi = dto.KategoriAdi,
                KategoriBilgisi = dto.KategoriBilgisi,
            };

            _context.Kategoris.Add(kategori);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var kategori = _context.Kategoris.Find(id);
            if(kategori == null)
            {
                throw new NotImplementedException();
            }

            _context.Kategoris.Remove(kategori);
            await _context.SaveChangesAsync();
        }

        public async Task<DtoKategori> Find(int id)
        {
            var dto = new DtoKategori();
            var kategori = await _context.Kategoris.FindAsync(id);

            if(kategori != null)
            {
                dto.KategoriId = kategori.KategoriId;
                dto.KategoriAdi = kategori.KategoriAdi;
                dto.KategoriBilgisi = kategori.KategoriBilgisi;
            }
            else
            {
                throw new Exception($"Kategori with ID = {id} was not found.");
            }
            return dto;
        }

        public async Task<List<DtoKategori>> GetAll()
        {
            var Dtos = new List<DtoKategori>();
            var kategories = await _context.Kategoris.ToListAsync();

            Dtos.AddRange(kategories.Select(Kategori => new DtoKategori()
            {
                KategoriId = Kategori.KategoriId,
                KategoriAdi = Kategori.KategoriAdi,
                KategoriBilgisi = Kategori.KategoriBilgisi,
                
            }).ToList());

            return Dtos;
        }

        public async Task Update(DtoKategori dto)
        {
            var kategori = new Kategori
            {
                KategoriId = dto.KategoriId,
                KategoriAdi = dto.KategoriAdi,
                KategoriBilgisi = dto.KategoriBilgisi,
            };
            _context.Entry(kategori).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
