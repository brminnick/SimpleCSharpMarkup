using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleCSharpMarkup
{
    public class MainViewModel : INotifyPropertyChanged
    {
        ICommand? _buttonTapped;
        int _tappedCount;

        public ICommand ButtonTapped => _buttonTapped ??= new Command(() => TappedCount++);

        public int TappedCount
        {
            get => _tappedCount;
            set => SetProperty(ref _tappedCount, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void SetProperty<T>(ref T backingStore, T value, Action? onChanged = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
