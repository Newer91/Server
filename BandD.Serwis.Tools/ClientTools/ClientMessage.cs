using System.Windows;

namespace BandD.Serwis.Tools.ClientTools
{
    public static class ClientMessage
    {
        public static void ServerErrorMessage()
        {
            MessageBox.Show("Wystąpił nieoczekiwany błąd. Skontaktuj się z producentem oprogramowania w celu uzyskania większej liczby szczegółów.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
