using System;
using System.Collections.ObjectModel;

namespace WPF.Models
{
    // model listy utworów
    public class SongsModel
   {
        // lista utworów - kolekcja obserwowalna - implementuje wzorzec obserwatora
        // zmiana atrybutów elementów kolekcji ędzie syganlizowana
        public ObservableCollection<Song> Songs { get; private set; } = new ObservableCollection<Song>();
            
        // konstruktor
        public SongsModel()
        {
            // dodawanie elementów do listy
            Songs.Add(new Song("Starway to Heaven", "Led Zeppelin", "Rock&Roll", new DateTime(2020, 1, 1)));
            Songs.Add(new Song("Starway to Heaven", "Led Zeppelin", "Rock&Roll", new DateTime(2020, 1, 1)));
            Songs.Add(new Song("Starway to Heaven", "Led Zeppelin", "Rock&Roll", new DateTime(2020, 1, 1)));
        }
   }
}
