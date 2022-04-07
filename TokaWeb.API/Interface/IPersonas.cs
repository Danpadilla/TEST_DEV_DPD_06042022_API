using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokaWeb.API.DTOs;
using TokaWeb.API.Models;

namespace TokaWeb.API.Interface
{
    public interface IPersonas
    {
        Task<List<PersonasFisicas>> GetPersonasFisicasAsync();
        Task<bool> SaveAsync(DTOsPersonasFisicas pp);
        Task<PersonasFisicas> GetPersonaFisicaByIDAsync(int IdPersonaFisica);
        Task<bool> UpdateAsync(int IdPersonaFisica,DTOsPersonasFisicas pp);
        Task<bool> DeleteAsync(int IdPersonaFisica);


    }
}
