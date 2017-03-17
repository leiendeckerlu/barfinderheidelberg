using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace DatenErkundungen
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// Eine Auflistung für ItemViewModel-Objekte.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Beispielwert für die Laufzeiteigenschaft";
        /// <summary>
        /// ViewModel-Beispieleigenschaft. Diese Eigenschaft wird in der Ansicht verwendet, um den Wert unter Verwendung einer Bindung anzuzeigen.
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Erstellt einige ItemViewModel-Objekte und fügt diese zur Items-Auflistung hinzu.
        /// </summary>
        public void LoadData()
        {
            // MEINE BAR-DATEN
            this.Items.Add(new ItemViewModel() { LineOne = "Brauhaus Vetter", LineTwo = "wer das beste Bier Heidelbergs sucht, wird hier fündig werden" });
            this.Items.Add(new ItemViewModel() { LineOne = "Cocktailcafé Regie", LineTwo = "Cocktails zu bester Musik (Klassiker)" });
            this.Items.Add(new ItemViewModel() { LineOne = "Destille", LineTwo = "kleine Kneipe, meistens sehr voll, „halbe Meter“ empfehlenswert" });
            this.Items.Add(new ItemViewModel() { LineOne = "Extrablatt Markt", LineTwo = "billige Cocktails, täglich nach 21 Uhr nur 4,50€" });
            this.Items.Add(new ItemViewModel() { LineOne = "Extrablatt", LineTwo = "leckere & günstige Pizzabrötchen 1,95€" });
            this.Items.Add(new ItemViewModel() { LineOne = "Gekco", LineTwo = "Freitag Abend's Shots für 1€ & gute Tapasplatten" });
            this.Items.Add(new ItemViewModel() { LineOne = "Goldener Reichsapfel", LineTwo = "super Ort um Sportereignisse aller Art zu verfolgen" });
            this.Items.Add(new ItemViewModel() { LineOne = "Grey Stones", LineTwo = "richtig gute Burger, super Kaffee und modernes Ambiente" });
            this.Items.Add(new ItemViewModel() { LineOne = "Hard Rock Café", LineTwo = "Cocktails & Burger jederzeit zu empfehlen" });
            this.Items.Add(new ItemViewModel() { LineOne = "Havana", LineTwo = "zwar nicht ganz billig, dafür gute Musik, sehr gute Cocktails und tolles Ambiente" });
            this.Items.Add(new ItemViewModel() { LineOne = "Jinx Bar & Club", LineTwo = "endle Einrichtung" });
            this.Items.Add(new ItemViewModel() { LineOne = "Lino's Bar", LineTwo = "kreative Cocktails & hausgemachte Snacks" });
            this.Items.Add(new ItemViewModel() { LineOne = "MaxBar", LineTwo = "typisch Franzözische Kaffespezialitäten, szenig, im Sommer sitzt man draußen auf dem Marktplatz" });
            this.Items.Add(new ItemViewModel() { LineOne = "MEDOCS", LineTwo = "gemütliche Bar, zentral am Bismarkplatz gelegen" });
            this.Items.Add(new ItemViewModel() { LineOne = "Mel's Bar", LineTwo = "typische Studentenbar, lange Öffnungszeiten" });
            this.Items.Add(new ItemViewModel() { LineOne = "Metropol", LineTwo = "Billardtische, Fernseher, Cocktails" });
            this.Items.Add(new ItemViewModel() { LineOne = "Nectar Bar", LineTwo = "tolle Atmosphäre im Sommer!" });
            this.Items.Add(new ItemViewModel() { LineOne = "O'Reillys Irish Pub", LineTwo = "gepflegtes Bier und  klasse Karaokeabende" });
            this.Items.Add(new ItemViewModel() { LineOne = "Schmidts", LineTwo = "So-Do 17-24 Uhr & Fr-Sa 17-20, ab 24 Uhr Cocktails 5€" });
            this.Items.Add(new ItemViewModel() { LineOne = "Shooter Stars", LineTwo = "gute Auswahl an Getränken zu angemessenen Preisen" });
            this.Items.Add(new ItemViewModel() { LineOne = "SKYlouge", LineTwo = "nicht ganz billig, dafür super coole Location!" });
            this.Items.Add(new ItemViewModel() { LineOne = "Sonderbar ", LineTwo = "über 15 Biere, über 25 Absinths, über 30 Rums, über 150 Whiskys" });
            this.Items.Add(new ItemViewModel() { LineOne = "Vater Rhein", LineTwo = "Spaghetti für 1,80€" });
            this.Items.Add(new ItemViewModel() { LineOne = "Café Villa", LineTwo = "Cocktails mit ordentlich Schuss, nach 20 Uhr nur 4€" });
            this.Items.Add(new ItemViewModel() { LineOne = "Info & Einstellungen", LineTwo = "Alles über die App und Ihr Feedback" });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}