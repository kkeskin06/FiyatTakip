using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess.Interface;
using GoraYazilim.Entity;

namespace GoraYazilim.Business
{
    public class KategoriBc : IKategoriBc
    {
        private readonly IKategoriDao kategoriDao;

        public KategoriBc(IKategoriDao kategoriDao)
        {
            this.kategoriDao = kategoriDao;
        }

        public async Task Add(DtoKategori dto)
        {
            await kategoriDao.Add(dto);
        }

        public async Task Delete(int id)
        {
           await kategoriDao.Delete(id);
        }

        public async Task<DtoKategori> Find(int id)
        {
           return  await kategoriDao.Find(id);
        }

        public async Task<List<DtoKategori>> GetAll()
        {
            return await kategoriDao.GetAll();
        }

        public async Task Update(DtoKategori dto)
        {
            await kategoriDao.Update(dto);
        }
    }
}