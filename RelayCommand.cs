using System;
using System.Windows.Input;

namespace WPF.MVVM
{
    // klasa umożlwiająca łatwe budowanie koemnd
    public class RelayCommand<T> : ICommand
    {
        // do przechowywania akcji, która ma się wykonać
        readonly Action<T> _execute = null;

        // do przechowywania odpowiedzi, czy ta komenda jest dostępna
        readonly Predicate<T> _canExecute = null;

        // zdarzenie emitowane, jeśli dostępność komendy się zmienia
        public event EventHandler CanExecuteChanged;

        // konstruktor - przekazujemy akcję, któa ma być wykonana 
        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        // konstruktor - przekazujemy akcję, któa ma być wykonana i predykat CanExecute
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            // wykonanie komendy
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            // odpowiedź na pytanie, czy taka komenda jest dostęona
            _canExecute = canExecute;
        }

        // wykonanie metody _canEcevute i zwrócenie tego, co ona zwróci
        public bool CanExecute(object parameter)
        {
            // jeśeli metoda _canExecute nie została dostarczona - komenda jest zawsze dostępna
            return _canExecute?.Invoke(((T)parameter)) ?? true;
        }

        // wykonanie dostarczonej metody
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        // wyemitowanie zdarzenia, że zmieniła się dostępność komendy
        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
