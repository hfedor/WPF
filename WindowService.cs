using System.Windows;

namespace WPF.MVVM
{
    // klasa odpowiadająca za powiązanie viewmodelu z widokiem
    public class WindowService : IWindowService
    {
        // wyświetlanie okna niemodalnego
        public void Show(IViewModel viewModel)
        {
            // powołujemy obiekt, który ma reprezentować okno
            Window window = new Window();

            // dostosowanie wielkości okna do kontrolki znajdującej się w oknie
            window.SizeToContent = SizeToContent.WidthAndHeight;

            // ustawiamy właściwośc kontent na dane, które mają być wyświetlana wewnątrz tego okna - 
            window.Content = viewModel;

            // powiązanie metody viewmodel'u Close z zamknięciem okna
            viewModel.Close = window.Close;

            // wyświetlamy obiekt reprezentujący okno
            window.Show();
        }

        // wyświetlanie okna modalnego
        public void ShowDialog(IViewModel viewModel)
        {
            // powołujemy obiekt, który ma reprezentować okno
            Window window = new Window();

            // dostosowanie wielkości okna do kontrolki znajdującej się w oknie
            window.SizeToContent = SizeToContent.WidthAndHeight;

            // ustawiamy właściwośc kontent na dane, które mają być wyświetlana wewnątrz tego okna - 
            window.Content = viewModel;

            // powiązanie metody viewmodel'u Close z zamknięciem okna
            viewModel.Close = window.Close;

            // wyświetlamy obiekt reprezentujący okno w trybie dialogowym
            window.ShowDialog();
        }
    }
}
