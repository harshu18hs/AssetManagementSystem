using AssetManagementSystem_WebApi.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem_WebApi.Repositories
{
    public interface IHardwareRepository
    {

        Task<IEnumerable<Hardware>> Search(string Hardware_type);
        Task<IEnumerable<Hardware>> Get();
        Task<Hardware> Get(int Model_No);
        Task <Hardware> Create(Hardware hardware);
        Task Update(Hardware hardware);
        Task Delete(int Model_No);

        Task UpdatePatchHardwareAsync(int Model_No,JsonPatchDocument hardware);
       
      


    }
}
