using Computer_Monitor.Controllers;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
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
                var ToastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var ToastText = ToastXml.GetElementsByTagName("text");
                ToastText[0].AppendChild(ToastXml.CreateTextNode("Login efetuado com sucesso!"));

                var Toast = new ToastNotification(ToastXml);
                ToastNotificationManager.CreateToastNotifier().Show(Toast);

                ApplicationView view = ApplicationView.GetForCurrentView();
                if (view.IsViewModeSupported(ApplicationViewMode.CompactOverlay))
                {
                    view.TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay);
                }
            }
        }
    }
}
