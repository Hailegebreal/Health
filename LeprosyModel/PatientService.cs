using System;
using System.Threading.Tasks;
using AspNetCoreProject.LeprosyModelInterface;

namespace AspNetCoreProject.LeprosyModel
{
    public class PatientService : IPatientService
    {
        public PatientService()
        {
        }

      public  Task WriteMessage(string message){

            return Task.FromResult(0);
        }

    }
}
