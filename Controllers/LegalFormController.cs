﻿// Controllers/EntrepriseController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace Gestion_des_entreprises_dans_la_registre_de_commerce_de_Suisse
{

    [ApiController]
    [Route("")]
    public class LegalFormController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly ApiCredentials _apiCredentials;

        public LegalFormController(IHttpClientFactory clientFactory, IOptions<ApiSettings> apiSettings, IOptions<ApiCredentials> apiCredentials)
        {
            _clientFactory = clientFactory;
            _apiSettings = apiSettings.Value;
            _apiCredentials = apiCredentials.Value;
        }

        [HttpGet("api/v1/legalForm")]
        public async Task<IEnumerable<LegalForm>> Get()
        {
            var client = _clientFactory.CreateClient();

            // Utiliser les informations d'authentification provenant de la configuration
            var authenticationBytes = Encoding.ASCII.GetBytes($"{_apiCredentials.Username}:{_apiCredentials.Password}");
            var base64Authentication = Convert.ToBase64String(authenticationBytes);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Authentication);

            // Construire l'URL complète en concaténant la base URL et le chemin de l'endpoint
            var apiUrl = $"{_apiSettings.BaseUrl}{"api/v1/legalForm"}";

            // Faire la requête à l'API avec les informations d'authentification
            var response = await client.GetFromJsonAsync<IEnumerable<LegalForm>>(apiUrl);

            if (response == null)
            {
                return new List<LegalForm>(); // Liste vide en cas d'erreur
            }

            return response;
        }
    }
}