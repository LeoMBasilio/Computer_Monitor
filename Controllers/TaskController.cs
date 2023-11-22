using Computer_Monitor.Models;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace Computer_Monitor.Controllers
{

    // BUgado no momento
    internal class TaskController
    {
        internal async Task TaskPool()
        {
            try
            {
                int pingmax = 0, pingmin = 0;
                Informacoes informacoes = new Informacoes();


                string host = "10.127.216.2";//para onde voce vai quere fazer o ping
                int timeout = 4000;

                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(host, timeout);

                if (reply.Status == IPStatus.Success)
                {
                    if (reply.RoundtripTime < pingmin)
                    {
                        pingmin = (int)reply.RoundtripTime;
                        informacoes.pingMin = pingmin;
                    }
                    else if (reply.RoundtripTime > pingmax)
                    {
                        pingmax = (int)reply.RoundtripTime;
                        informacoes.pingMax = pingmax;
                    }
                    else
                    {
                        pingmin = (int)reply.RoundtripTime;
                        informacoes.pingMin = pingmin;
                    }
                }

                ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();

                if (connectionProfile != null)
                {
                    NetworkAdapter adapter = connectionProfile.NetworkAdapter;

                    if (adapter != null)
                    {
                        Utils.Notify notify = new Utils.Notify();
                        notify.Notificacao(adapter.NetworkAdapterId.ToString());
                        notify.Notificacao(adapter.IanaInterfaceType.ToString());
                    }
                }
            }
            catch
            {

            }
        }
    }
}
