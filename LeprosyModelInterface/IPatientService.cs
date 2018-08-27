using System;
using System.Threading.Tasks;

namespace AspNetCoreProject.LeprosyModelInterface
{
    public interface IPatientService
    {
        Task WriteMessage(string message);

    }
}
