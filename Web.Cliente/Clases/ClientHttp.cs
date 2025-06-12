﻿using CapaEntidad;
using System.Text.Json;

namespace Web.Cliente.Clases
{
    public class ClientHttp

        
    {
        //Litar Personas sin filtro
        public static async Task<List<T>> GetAll<T>(IHttpClientFactory _httpClientFactory, string urlbase, string rutaapi)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                cliente.BaseAddress = new Uri(urlbase);
                string cadena = await cliente.GetStringAsync(rutaapi);
                List<T> lista = JsonSerializer.Deserialize<List<T>>(cadena);
                return lista;
            }

            catch (Exception ex) 
            {
                return new List<T>();
            }

        }

        //Litar Personas con filtro
        public static async Task<T> Get<T>(IHttpClientFactory _httpClientFactory, string urlbase, string rutaapi)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                cliente.BaseAddress = new Uri(urlbase);
                string cadena = await cliente.GetStringAsync(rutaapi);
                T lista = JsonSerializer.Deserialize<T>(cadena);
                return lista;
            }

            catch (Exception ex)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }

        }

    }
}
