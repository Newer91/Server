using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BandD.Serwis.ViewModel.Class
{
    public abstract class BaseViewClass : INotifyPropertyChanged
    {
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                Debug.Fail("Invalid property name: " + propertyName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            VerifyPropertyName(name);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public class ActiveItem
        {
            public bool? Value { get; set; }
            public string Name { get; set; }

            public ObservableCollection<ActiveItem> getActiveList()
            {
                return new ObservableCollection<ActiveItem>()
                {
                     new ActiveItem { Name = "Wszystkie", Value =null},
                     new ActiveItem {Name= "Tak", Value=true },
                     new ActiveItem {Name= "Nie", Value = false }
                };
            }
        }
    }
}
