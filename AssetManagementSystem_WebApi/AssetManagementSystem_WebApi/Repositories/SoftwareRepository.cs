using AssetManagementSystem_WebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem_WebApi.Repositories
{
    public class SoftwareRepository : ISoftwareRepository
    {
        private readonly AssetDb _context;
        public SoftwareRepository(AssetDb context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<Software>> Search(string Software_Name)
        {
            IQueryable<Software> query = (IQueryable<Software>)Get();

            if (!string.IsNullOrEmpty(Software_Name) )
            {
                query = query.Where(x => x.Software_Name.Contains(Software_Name));

            }
            return await query.ToListAsync();
        }
        public async Task<Software> Create(Software software)
        {
            _context.Softwares.Add(software);
            await _context.SaveChangesAsync();
            return software;
        }

        public async Task Delete(int Software_Id)
        {
            var SoftwareToDelete = await _context.Softwares.FindAsync(Software_Id);
            _context.Softwares.Remove(SoftwareToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Software>> Get()
        {
            return await _context.Softwares.ToListAsync();
        }

        public async Task<Software> Get(int Software_Id)
        {
            return await _context.Softwares.FindAsync(Software_Id);
        }

        public async Task Update(Software software)
        {
            _context.Entry(software).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePatchSoftwaresAsync(int Software_Id, JsonPatchDocument software)
        {
            var softwareToUpdate = await _context.Softwares.FindAsync(Software_Id);
            if (softwareToUpdate == null)
            {
                software.ApplyTo(softwareToUpdate);
                await _context.SaveChangesAsync();
            }

        }
    }
}
