using Microsoft.Extensions.Options;
using Movies.Domain.Entities;
using Movies.Persistence.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services
{
    public class IMDBApiService : IIMDBApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMDBApiConfig _imdbApiConfig;

        public IMDBApiService(HttpClient httpClient, IOptions<IMDBApiConfig> imdbApiConfig)
        {
            _httpClient = httpClient;
            _imdbApiConfig = imdbApiConfig.Value;
        }

        public async Task<Movie> SearchMovies(string expression)
        {
            var apiUrl = $"{_imdbApiConfig.ApiBaseUrl}/API/SearchMovie/{_imdbApiConfig.ApiKey}/{expression}";
           
            // Send HTTP request to IMDB API
            var response = await _httpClient.GetStringAsync(apiUrl);

            // Deserialize JSON response
            var imdbResponse = JsonConvert.DeserializeObject<Movie>(response);

            return imdbResponse;
        }
    }
}
