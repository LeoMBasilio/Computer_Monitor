using Windows.UI.Notifications;

namespace Computer_Monitor.Utils
{
    internal class Notify
    {
        internal void Notificacao(string message)
        {
            var ToastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var ToastText = ToastXml.GetElementsByTagName("text");
            ToastText[0].AppendChild(ToastXml.CreateTextNode(message));

            var Toast = new ToastNotification(ToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(Toast);
        }
    }
}
