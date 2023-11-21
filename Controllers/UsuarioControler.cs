using Computer_Monitor.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Computer_Monitor.Controllers
{
    public class UsuarioControler
    {

        public async Task<bool> Login(string inUser, string inPwd, bool rbTerms)
        {
            Usuarios usuarios = new Usuarios();

            if (!String.IsNullOrEmpty(inUser) || !String.IsNullOrEmpty(inPwd))
            {
                usuarios.usuario = inUser;
                usuarios.senha = inPwd;
                usuarios.terms = rbTerms;

                bool result = await GetUsers(usuarios);

                return result;
            }
            return false;

        }

        private async Task<bool> GetUsers(Usuarios usuarios)
        {
            string ApiUrl = "http://localhost:5000/api/usuarios";
            HttpClient client = new HttpClient();

            string jsonContent = JsonConvert.SerializeObject(usuarios);

            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                var user = JsonConvert.DeserializeObject<Usuarios>(json);

                if (user.usuario == usuarios.usuario && user.session != usuarios.session)
                {
                    return true;
                }
                return false;
            }
            return false;

        }

    }
}