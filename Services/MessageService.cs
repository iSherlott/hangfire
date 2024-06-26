namespace Highfire.Services
{
    public class MessageService 
    {
        private readonly HttpClient _httpClient;
        private readonly string _httpBinUrl;
        public MessageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpBinUrl = configuration["URL:HTTPBIN"];
        }
        public void SendEmail(string recipient, string subject, string body)
        {
            Console.WriteLine($"Enviando email para {recipient}: {subject}");
            Console.WriteLine($"Body {body}");
        }

        public async Task ProcessQueueMessage(string message)
        {
            var response = await _httpClient.GetAsync(_httpBinUrl + "/5");
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(message);
        }
    }
}
