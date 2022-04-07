using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TokaWeb.API.Context;
using TokaWeb.API.DTOs;
using TokaWeb.API.Interface;
using TokaWeb.API.Models;

namespace TokaWeb.API.Services
{
    public class PersonasService:  IPersonas
    {
        private readonly AppDbContext context;

        public PersonasService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<PersonasFisicas> GetPersonaFisicaByIDAsync(int IdPersonaFisica)
        {
            PersonasFisicas personas = new PersonasFisicas();
            using (context)
            {
                try
                {
                    personas = context.Tb_PersonasFisicas.FirstOrDefault(x=>x.IdPersonaFisica == IdPersonaFisica);
                }
                catch (Exception e)
                {
                    throw new Exception("Error");

                }
            }
            return personas;

        }
        public async Task<List<PersonasFisicas>> GetPersonasFisicasAsync()
        {
            List<PersonasFisicas> personas = new List<PersonasFisicas>();
            using (context)
            {
                try
                {
                    personas = context.Tb_PersonasFisicas.ToList();
                }
                catch (Exception e)
                {
                    throw new Exception("Error");

                }
            }
            return personas;

        }
        public async Task<bool> DeleteAsync(int IdPersonaFisica)
        {
            bool respuesta = false;
            PersonasFisicas persona = new PersonasFisicas();

            using (context)
            {
                try
                {
                    persona = context.Tb_PersonasFisicas.FirstOrDefault(p => p.IdPersonaFisica == IdPersonaFisica);
                    if (persona != null)
                    {
                        persona.Activo = false;
                        context.Tb_PersonasFisicas.Update(persona);
                        context.SaveChanges();
                        //eliminar permanente
                        //context.Tb_PersonasFisicas.Remove(persona); 
                        respuesta = true;

                    }
                    else
                    {
                        //no existe
                    }
                }
                catch (Exception e)
                {
                    respuesta = false;
                    throw new Exception(e.Message);

                }
            }

            return respuesta;

        }
        public async Task<bool> UpdateAsync(int IdPersonaFisica, DTOsPersonasFisicas pp)
        {
            bool respuesta = false;
            PersonasFisicas persona = new PersonasFisicas();

            using (context)
            {
                try
                {
                    persona = context.Tb_PersonasFisicas.FirstOrDefault(p=>p.IdPersonaFisica == IdPersonaFisica);
                    if (persona != null)
                    {
                        // actualizamos
                        //var nuevaPersona = new PersonasFisicas();
                        persona.Nombre = pp.Nombre;
                        persona.ApellidoPaterno = pp.ApellidoPaterno;
                        persona.ApellidoMaterno = pp.ApellidoMaterno;
                        persona.FechaNacimiento = pp.FechaNacimiento;
                        persona.FechaActualizacion = pp.FechaActualizacion;
                        persona.Rfc = pp.Rfc;
                        persona.Activo = true;
                        context.Tb_PersonasFisicas.Update(persona);
                        context.SaveChanges();
                        respuesta = true;

                    }
                    else { 
                        //no existe
                    }
                }
                catch (Exception e)
                {
                    respuesta = false;
                    throw new Exception(e.Message);

                }
            }

            return respuesta;

        }
        public async Task<bool> SaveAsync(DTOsPersonasFisicas pp) {
            bool respuesta = false; 
             using (context)
            {
                try
                {
                    var total = context.Tb_PersonasFisicas.Count();
                    var persona = new PersonasFisicas();
                   // persona.IdPersonaFisica = total == 0 ? 1 : total +1; // si no hay registos asginara el registro con id 1
                    persona.Nombre = pp.Nombre;
                    persona.FechaRegistro = DateTime.Now;
                    persona.ApellidoPaterno = pp.ApellidoPaterno;
                    persona.ApellidoMaterno = pp.ApellidoMaterno;
                    persona.FechaNacimiento = pp.FechaNacimiento;
                    persona.Rfc = pp.Rfc;
                    persona.Activo = pp.Activo;
                    context.Tb_PersonasFisicas.Add(persona);
                    context.SaveChanges();
                    respuesta = true;
                    //personas = context.Tb_PersonasFisicas.ToList();
                }
                catch (Exception e)
                {
                    respuesta = false;
                    throw new Exception(e.Message);

                }
            }

            return respuesta;
        }
    }
}
