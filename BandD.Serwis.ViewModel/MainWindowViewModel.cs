using BandD.Serwis.Model;

namespace BandD.Serwis.ViewModel
{
    public class MainWindowViewModel
    {
        public MailModel mailModel;

        public string mail { get; set; }

        public MainWindowViewModel()
        {
            mailModel = new MailModel();
            przekazDoModelu(mail);
        }

        private void przekazDoModelu(string mail)
        {
            mailModel.MailAddress = mail;
        }
    }
}
