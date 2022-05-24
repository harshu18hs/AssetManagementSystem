using AssetManagementSystem_WebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem_WebApi.Repositories
{
    public class HardwareRepository : IHardwareRepository
    {
        private readonly AssetDb _context;
        public HardwareRepository(AssetDb context)
        {
            _context = context;
            
        }
        public async Task<IEnumerable<Hardware>> Search(string Hardware_type)
        {
            IQueryable<Hardware> query = (IQueryable<Hardware>)Get();

            if (!string.IsNullOrEmpty(Hardware_type))
            {
                query = query.Where(x => x.Hardware_Type.Contains(Hardware_type));

            }
            return await query.ToListAsync();
        }
        public async Task<Hardware> Create(Hardware hardware)
        {
            _context.Hardwares.Add(hardware);
            await _context.SaveChangesAsync();
            return hardware;
        }

        public async Task Delete(int Model_No)
        {
            var hardwareToDelete = await _context.Hardwares.FindAsync(Model_No);
            _context.Hardwares.Remove(hardwareToDelete);
            await _context.SaveChangesAsync();
        }
       

       
        public async Task<IEnumerable<Hardware>> Get()
        {
            return await _context.Hardwares.ToListAsync();
        }

        public async Task<Hardware> Get(int Model_No)
        {
            return await _context.Hardwares.FindAsync(Model_No);
        }

        public async Task Update(Hardware hardware)
        {
            _context.Entry(hardware).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatchHardwaresAsync(int Model_No, JsonPatchDocument hardware)
        {
            var hardwareToUpdate = await _context.Hardwares.FindAsync(Model_No);
            if (hardwareToUpdate == null)
            {
                hardware.ApplyTo(hardwareToUpdate);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<Hardware>> IHardwareRepository.Search(string Hardware_type)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Hardware>> IHardwareRepository.Get()
        {
            throw new NotImplementedException();
        }

        Task<Hardware> IHardwareRepository.Create(Hardware hardware)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePatchHardwareAsync(int Model_No, JsonPatchDocument hardware)
        {
            throw new NotImplementedException();
        }

        internal static void ApplyTo(Hardware? hardwareToUpdate)
        {
            throw new NotImplementedException();
        }

    }
}
