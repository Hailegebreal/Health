using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreProject.LeprosyModel;

namespace AspNetCoreProject.GQLeprosyModel
{
    public interface IQLPatientRepository
    {

        Task<Contact> Get(int id);
        Task<Contact> GetRandom();
        Task<List<Contact>> All();
        Task<Contact> Add(Contact player);


    }
}
