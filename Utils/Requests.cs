using Computer_Monitor.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Computer_Monitor.Utils
{

    internal class RequestsApi
    {
        internal async Task<string> ApiPost(Usuarios usuarios, string url)
        {
            try
            {
                HttpClient client = new HttpClient();

                string jsonContent = JsonConvert.SerializeObject(usuarios);

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return json;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private async Task<string> ApiGet(string user, string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(user))
                {
                    string filter = "?usuario=" + user + "&session=true";
                    url = url + "/" + filter;
                }

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    return json;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        internal async Task ApiPut(object obj, string url)
        {
            try
            {
                HttpClient client = new HttpClient();

                string jsonContent = JsonConvert.SerializeObject(obj);

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Notify notify = new Notify();
                    notify.Notificacao("Erro ao atualizar o usuário!, servidor pode estar ofline\n" +
                                        "entre em contato com o suporte");
                }
            }
            catch
            {

            }
        }

    }
}