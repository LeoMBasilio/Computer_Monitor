using Computer_Monitor.Models;

using Newtonsoft.Json;
using System;
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
            string apiUrl = "http://localhost:5000/api/usuarios";

            Utils.RequestsApi requestsApi = new Utils.RequestsApi();

            var user = JsonConvert.DeserializeObject<Usuarios>(await requestsApi.ApiPost(usuarios, apiUrl));

            if (user.usuario == usuarios.usuario && user.session != usuarios.session)
            {
                usuarios.session = true;
                return true;
            }
            return false;


        }

    }
}