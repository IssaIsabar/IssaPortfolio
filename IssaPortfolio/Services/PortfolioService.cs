using IssaPortfolio.Library;
using IssaPortfolio.Services.PortfolioService;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
        //public async Task<List<PortfolioItem>?> LoadPortfolioItems()
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            return await client.GetFromJsonAsync<List<PortfolioItem>>("https://localhost:7142/api/PortfolioItem/getitems");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Message :{0} ", e.Message);
        //    }
        //    return null;
        //}
        public async Task AddPortfolioItem(string name, string desc, string imgUrl)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(imgUrl))
            {
                var item = new PortfolioItem(name, desc, imgUrl);

                using (var _http = new HttpClient())
                {
                    await _http.PostAsJsonAsync("https://localhost:7142/api/PortfolioItem/postportfolio", item);
                }
            }
        }
        public async Task DeleteItem(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:44316/api/PortfolioItem/deletePortfolio/" + id),
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

