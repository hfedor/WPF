using System;
using WPF.MVVM;
using WPF.Models;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;

namespace WPF.ViewModels
{
    // widok modelu dla listy utworów
    public class SongsViewModel : IViewModel, INotifyPropertyChanged
    {
        // model listy utworów
        private SongsModel SongsModel { get; }

        // obiekt pośredniczący między listą utworów, a widokiem, umożliwiający filtrowanie listy.
        private readonly CollectionViewSource collectionViewSource;

        // zdarzenie zmiany właściwości modelu
        public event PropertyChangedEventHandler PropertyChanged;

        // interface widoku kolekcji - listy utworów
        public ICollectionView Songs { get; }

        // obiekt trzymający zaznaczony utwór
        private Song selectedSong;
        public Song SelectedSong
        {
            // pobieranie wybranego utworu
            get { return selectedSong; }

            // ustawianie wybranego utworu
            set
            {
                // zapamiętujemy, który student został zaznaczony
                selectedSong = value;

                // informujemy, że dostępność metody edycji utwóru mogła się zmienić
                EditCommand.NotifyCanExecuteChanged();

                // informujemy, że dostępność metody usunięcia utwóru mogła się zmienić
                DeleteCommand.NotifyCanExecuteChanged();

                // ???
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSong)));
            }
        }

        // tekst po którym filtrowana jest lista utworów
        private string filterText = "";
        
        public string FilterText
        {
            // pobieranie wartości teskstu do filtracji
            get { return filterText; }

            // ustawianie wartości tekstu do filtracji
            set
            {
                filterText = value;

                // aktalizacjia listy utworów z uwzględnieniem filtra
                UpdateFilter();

                // ???
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterText)));
            }
        }

        // aktalizacjia listy utworów z uwzględnieniem filtra
        private void UpdateFilter()
        {
            collectionViewSource.View.Refresh();
        }

        // filtruje listę utworów w oparciu o zadaną wartość tekstu i nazy, wykonawcy, lub gatunku muzycznego utworu.
        bool FilterSong(Song song)
        {
            return  song.Title.Contains(FilterText) || // filtracja po nazwie utworu
                    song.Artist.Contains(FilterText) || // filtracja po wykonawcy utworu
                    song.Genre.Contains(FilterText); // filtracja po gatunku muzycznym utworu
        }

        // akcja zamykania
        public Action Close { get; set; }

        // obiekt reprezentujący komendę dodającą utwór do listy
        private RelayCommand<object> addCommand;

        // nie da się utworzyć dynamicznie, więc jeśli addCOmand == null komenda jest tworzona i dodawana do niej jest metoda execute tej koemndy
        public RelayCommand<object> AddCommand => (addCommand = addCommand ?? new RelayCommand<object>(o => AddSong()));

        // obiekt reprezentujący komendę edytującą wybrany utwór z listy
        private RelayCommand<object> editCommand;

        // nie da się utworzyć dynamicznie, więc jeśli editCOmand == null komenda jest tworzona i dodawana do niej jest metoda execute tej koemndy i inforamcja o tym, czy komenda jest dostępna, sprawdzana na podstawie tego, czy wybrano utwór z listy
        public RelayCommand<object> EditCommand => (editCommand = editCommand ?? new RelayCommand<object>(o => EditSong(SelectedSong), o => SelectedSong != null));

        // obiekt reprezentujący komendę usuwającą wybrany utwór z listy
        private RelayCommand<object> deleteCommand;

        // nie da się utworzyć dynamicznie, więc jeśli deleteCOmand == null komenda jest tworzona i dodawana do niej jest metoda execute tej koemndy i inforamcja o tym, czy komenda jest dostępna, sprawdzana na podstawie tego, czy wybrano utwór z listy
        public RelayCommand<object> DeleteCommand => (deleteCommand = deleteCommand ?? new RelayCommand<object>(o => DeleteSong(SelectedSong), o => SelectedSong != null));

        // obiekt reprezentujący komendę otwierającą nowe ogno z listą utworów
        private RelayCommand<object> newWindowCommand;

        // nie da się utworzyć dynamicznie, więc jeśli newwindowCOmand == null komenda jest tworzona i dodawana do niej jest metoda execute tej koemndy
        public RelayCommand<object> NewWindowCommand => (newWindowCommand = newWindowCommand ?? new RelayCommand<object>(o => NewWindow()));

        // konstruktor
        public SongsViewModel(SongsModel songsModel)
        {
            SongsModel = songsModel;

            // wstawienie do elementu proxy utworów z listy
            collectionViewSource = new CollectionViewSource
            {
                Source = SongsModel.Songs
            };

            // filtracja widoku elementu proxy 
            collectionViewSource.View.Filter = (o) => FilterSong((Song)o);

            // wstawiamy do kolekcji widok emitowany przez element pośredniczący między kolekcją, a widokiem (obiekt proxy)
            Songs = collectionViewSource.View;
        }

        // metoda otwierająca nowe okno wyświetlające listę utworó
        public void NewWindow()
        {
            SongsViewModel songsViewModel = new SongsViewModel(SongsModel);
            ((App)Application.Current).WindowService.Show(songsViewModel);
        }

        // dodawanie utworu do listy
        public void AddSong()
        {
            // utworzenie okna dodawania/edycji utworu i przekazujemy model
            SongViewModel songViewModel = new SongViewModel(SongsModel, null);

            // wyświetlenie okna dodawania/edycji utworu
            ((App)Application.Current).WindowService.ShowDialog(songViewModel);
        }

        // edycja utworu
        public void EditSong(Song song)
        {
            if (song != null)
            {
                // utworzenie okna dodawania/edycji utworu i przekazujemy model oraz referencje do obiektu, który ma podlegać edycji 
                SongViewModel songViewModel = new SongViewModel(SongsModel, song);

                // wyświetlenie okna dodawania/edycji utworu
                ((App)Application.Current).WindowService.ShowDialog(songViewModel);
            }
        }

        // usuwanie utworu z listy
        public void DeleteSong(Song song)
        {
            if (song != null)
                // usuwamy utwór z modelu 
                SongsModel.Songs.Remove(song);
        }
    }
}
