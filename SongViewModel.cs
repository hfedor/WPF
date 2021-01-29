using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM;
using WPF.Models;
using System.Windows.Controls;
using System.Globalization;

namespace WPF.ViewModels
{
    // wyświetlenie danych studenta w celu ich modyfikacji, lub dodania nowego studenta
    public class SongViewModel : IViewModel
    {
        // lista utworów
        private SongsModel SongsModel { get; }

        // utwór
        private Song Song { get; }

        // zamykanie okna
        public Action Close { get; set; }

        // nazwa utworu
        public string Title { get; set; }

        // wykonawca utworu
        public string Artist { get; set; }

        // gatunek muzyczny
        public string Genre { get; set; }

        // data nagrania utworu
        public DateTime RecordingDate { get; set; }

        // powiązanie, z wykożystaniem szablonu 'RelayCommand' komendy 'OKCommand', z wywołaniem funkji 'ok'
        public RelayCommand<SongViewModel> OkCommand { get; } = new RelayCommand<SongViewModel>
            (
                (songViewModel) => { songViewModel.Ok(); }
            );

        // powiązanie, z wykożystaniem szablonu 'RelayCommand' komendy 'CancelCommand', z wywołaniem funkji 'Cancel'
        public RelayCommand<SongViewModel> CancelCommand { get; } = new RelayCommand<SongViewModel>
            (
                (songViewModel) => { songViewModel.Cancel(); }
            );

        // konstruktor
        public SongViewModel(SongsModel songsModel, Song song)
        {
            SongsModel = songsModel;
            Song = song;
            if (Song != null)
            {
                Title = Song.Title;
                Artist = Song.Artist;
                Genre = Song.Genre;
                RecordingDate = Song.RecordingDate;
            }

            //TitleBackground = "#FF626262";
        }

        // funkcja wywoływana po kliknięciu przycisku 'OK'
        public void Ok()
        {
            if (Song == null)
            // jeśli dodawanie nowego utworu
            {
                Song song = new Song(Title, Artist, Genre, RecordingDate);
                SongsModel.Songs.Add(song);
            }
            else
            // jeśli edycja już istniejącego utworu
            {
                Song.Title = Title;
                Song.Artist = Artist;
                Song.Genre = Genre;
                Song.RecordingDate = RecordingDate;
            }
            Close?.Invoke();
        }

        // zamykanie widoku w przypadku anulowania
        public void Cancel() => Close?.Invoke();
    }
}
