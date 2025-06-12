﻿using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models;
using System.Text.Json;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        //Lista Personas sin filtros

        [HttpGet]
        public List<PersonaCLS> listarPersona()
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();

            try
            {
                using (DbAba4c6BdveterinariaContext bd = new DbAba4c6BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " +
                                 persona.Appaterno + " " +
                                 persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("yyyy-MM-dd")

                             }).ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
        }


        //Nombre completo
        [HttpGet("{nombrecompleto}")]
        public List<PersonaCLS> listarPersona(string nombrecompleto)
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();

            try
            {
                using (DbAba4c6BdveterinariaContext bd = new DbAba4c6BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             && (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(nombrecompleto)
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToShortDateString()

                             }).ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {

                return lista;
            }
        }



        //Recuperar Persona por ID

        [HttpGet("recuperarPersona/{id}")]
        public PersonaCLS recuperarPersona(int id)
        {
            PersonaCLS oPersonaCLS = new PersonaCLS();

            try
            {
                using (DbAba4c6BdveterinariaContext bd = new DbAba4c6BdveterinariaContext())
                {
                    oPersonaCLS = (from persona in bd.Personas
                                   where persona.Bhabilitado == 1
                                   && persona.Iidpersona == id
                                   select new PersonaCLS
                                   {
                                       iidpersona = persona.Iidpersona,
                                       nombre = persona.Nombre,
                                       appaterno = persona.Appaterno,
                                       apmaterno = persona.Apmaterno,
                                       correo = persona.Correo,
                                       fechanacimiento = (DateTime)persona.Fechanacimiento,
                                       fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                       persona.Fechanacimiento.Value.ToString("yyyy-MM-dd"),
                                       iidsexo = (int)persona.Iidsexo

                                   }).First();
                }
                return oPersonaCLS;
            }
            catch (Exception ex)
            {

                return oPersonaCLS;
            }
        }
    }
}
