using System;
using System.ComponentModel;

namespace WPF.Models
{
    // Klasa na model danych reprezentujący utwór muzyczny.
    // Implementuje interfejs 'NotifyPropertyChanged' - propaguje infromacje o zmianach danych.
    public class Song : INotifyPropertyChanged
    {
        // zdarzenie informujące o zmianach danych
        public event PropertyChangedEventHandler PropertyChanged;

        // atrybut na nazwę utworu
        private string title;

        public string Title
        {
            // zwara wartośc atrybutu 'title'
            get { return title; }
            // ustawia wartośc atrybutu 'title' na zadaną wartość i emituje zdarzenie, informujące o zmainie właściwości
            set { title = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title")); }
        }

        // atrybut na wykonawcę utworu
        private string artist;

        public string Artist
        {
            // zwara wartośc atrybutu 'artist'
            get { return artist; }
            // ustawia wartośc atrybutu 'artist' na zadaną wartość i emituje zdarzenie, informujące o zmainie właściwości
            set { artist = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Artist")); }
        }

        // atrybut na gatunek muzyczny utworu
        private string genre;

        public string Genre
        {
            // zwara wartośc atrybutu 'genre'
            get { return genre; }
            // ustawia wartośc atrybutu 'genre' na zadaną wartość i emituje zdarzenie, informujące o zmainie właściwości
            set { genre = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Artist")); }
        }

        // atrybut na datę nagrania utworu
        private DateTime recording_date;

        public DateTime RecordingDate
        {
            // zwara wartośc atrybutu 'recording_date'
            get { return recording_date; }
            // ustawia wartośc atrybutu 'recording_date' na zadaną wartość i emituje zdarzenie, informujące o zmainie właściwości
            set { recording_date = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Artist")); }
        }

        // konstruktor
        public Song(string title, string artist, string genre, DateTime recording_date)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            RecordingDate = recording_date;
        }
    }
}
