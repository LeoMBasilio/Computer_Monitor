using Computer_Monitor.Controllers;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace Computer_Monitor
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UsuarioControler usuarioControler = new UsuarioControler();

            bool result = await usuarioControler.Login(inUser.Text, inPwd.Password, rbTerms.IsChecked.Value);

            if (true)
            {
                Utils.Notify notify = new Utils.Notify();

                //notify.Notificacao("Login efetuado com sucesso!");

                //add uma forma de minimizar a janela

                TaskController taskController = new TaskController();
                await taskController.TaskPool();
            }
        }
    }
}
