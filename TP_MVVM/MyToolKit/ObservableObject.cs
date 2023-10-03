

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyToolKit;


public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string property = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    protected virtual void SetProperty<T>(T member, T value, Action<T> action, [CallerMemberName] string property = null)
    {
        if (EqualityComparer<T>.Default.Equals(member, value))
            return;
        action(value);
        OnPropertyChanged(property);
    }
}

