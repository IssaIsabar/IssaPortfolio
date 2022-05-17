using IssaPortfolio.Library;
using IssaPortfolio.Services.PortfolioService;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace IssaPortfolio.Services.PortfolioService
{
    public class PortfolioService
    {
        HttpClient client;
        Uri GetUri(string path) => new Uri($"https://localhost:44316{path}");
        public PortfolioService()
        {
            client = new HttpClient();
        }

        public async Task<List<PortfolioItem>?> GetAll()
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = GetUri("/api/PortfolioItem/getitems"),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // yay
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // kick user out
                }
                else
                {
                    // didnt work
                }

                var body = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<PortfolioItem>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task AddPortfolioItem(PortfolioItem portItem)
        {
            string jsonString = JsonSerializer.Serialize(portItem);
            if (!string.IsNullOrWhiteSpace(portItem.Name) && !string.IsNullOrWhiteSpace(portItem.Description) && !string.IsNullOrWhiteSpace(portItem.ImageUrl))
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = GetUri("/api/PortfolioItem/postportfolio"),
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
        }
        public async Task DeleteItem(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = GetUri("/api/PortfolioItem/deletePortfolio/" + id),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}

