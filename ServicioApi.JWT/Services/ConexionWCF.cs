using Microsoft.AspNetCore.Http;
using ServicioApi.BusinessObjects.Seguridad;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ServicioApi.JWT.Services
{
    public class ConexionWCF
    {
        private readonly HttpClient _httpClient;
        IConfiguration configuration;
        public ConexionWCF(HttpClient httpClient, IConfiguration _configuration)
        {
            _httpClient = httpClient;
            configuration = _configuration;
        }

        public async Task<String> loginConexion(String Usuario, string Password)
        {
            string baseUrl = configuration["ServicioWCF"]!;
            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("La URL del servicio WCF no está configurada.");

            // Construir la query string con las propiedades del objeto Usuario
            var compiledParameters = String.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl+"/ping");
                client.Timeout = TimeSpan.FromMinutes(10);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Usuario}:{Password}"))
                );

                // Si necesitas un endpoint adicional, agrégalo aquí, por ejemplo: "/api/login"
                string endpoint = "ping"; // O "/api/login" si corresponde

                var response = client.GetAsync($"{endpoint}{compiledParameters}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    String? result = JsonConvert.DeserializeObject<String>(json);
                    return result!;
                }
                else
                {
                    return default!;
                }
            }
        }
    }
}
