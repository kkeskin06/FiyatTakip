using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess;
using GoraYazilim.DataAccess.Interface;
using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.Business
{
    public class SaticiBc : ISaticiBc
    {
        private readonly ISaticiDao saticiDao;

        public SaticiBc(ISaticiDao saticiDao)
        {
            this.saticiDao = saticiDao;
        }
        public async Task Add(DtoSatici dto)
        {
            await saticiDao.Add(dto);
        }

        public async Task Delete(int id)
        {
            await saticiDao.Delete(id);
        }

        public async Task<DtoSatici> Find(int id)
        {
            return await saticiDao.Find(id);
        }

        public async Task<List<DtoSatici>> GetAll()
        {
            return await saticiDao.GetAll();
        }

        public async Task<List<DtoSatici>> GetById(int id)
        {
            return await saticiDao.GetById(id);
        }

        public async Task Update(DtoSatici dto)
        {
            await saticiDao.Update(dto);
        }

    }
}
