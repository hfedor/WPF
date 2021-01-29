using System.Windows;
using WPF.Models;

namespace WPF
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Serwis - umożliwiąjący wyświetlenie ViewModel'u.
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();

        // powoływanie modelu
        private SongsModel SongsModel { get; } = new SongsModel();

        // metoda aplikacji
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // powołujemy ViewModel przekazujący referencję do modelu
            WPF.ViewModels.SongsViewModel songsViewModel = new WPF.ViewModels.SongsViewModel(SongsModel);
            
            // wyświetlenie przez serwis ViewModel'u.
            WindowService.Show(songsViewModel);
        }
    }
}
