using Contracts.ViewContract;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WebAppL {
    public class APIclient {
        private static readonly HttpClient apiClient = new();
        public static TutorViewModel? Tutor { get; set; } = null;
		public static UniversityEmployeeViewModel? UniversityEmployee { get; set; } = null;


		public static void connect(IConfiguration configuration) {
            apiClient.BaseAddress = new Uri(configuration["IPAddress"]);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T? GetRequest<T>(string requestUrl) {
            var response = apiClient.GetAsync(requestUrl);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            if (response.Result.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<T>(result);
            }
            else {
                 throw new Exception(result);
            }
        }

        public static void PostRequest<T>(string requestUrl, T model) {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = apiClient.PostAsync(requestUrl, data);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            //ошибка....
            if (!response.Result.IsSuccessStatusCode) { 
                throw new Exception(result);
            }
        }

        public static void ListPostRequest<T, U>(string requestUrl, T model, U info, int? helperValue) {
            var list = new List<string>() {
                JsonConvert.SerializeObject(model),
                JsonConvert.SerializeObject(info),
                JsonConvert.SerializeObject(helperValue)
            };

            var json = JsonConvert.SerializeObject(list);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = apiClient.PostAsync(requestUrl, data);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            if (!response.Result.IsSuccessStatusCode) {
                throw new Exception(result);
            }
        }
    }
}
