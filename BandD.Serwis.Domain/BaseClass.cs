using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BandD.Serwis.Domain
{
    public abstract class BaseClass : INotifyPropertyChanged
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
    }
}
