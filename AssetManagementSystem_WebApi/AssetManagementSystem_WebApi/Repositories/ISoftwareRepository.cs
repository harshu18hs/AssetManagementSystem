using AssetManagementSystem_WebApi.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace AssetManagementSystem_WebApi.Repositories
{
    public interface ISoftwareRepository
    {
        Task<IEnumerable<Software>> Search(string Software_Name);
        Task<IEnumerable<Software>> Get();
        Task<Software> Get(int Software_Id);
        Task<Software> Create(Software software);
        Task Update(Software software);
        Task Delete(int Software_Id);
        Task UpdatePatchSoftwaresAsync(int Software_Id, JsonPatchDocument software);


    }
}
