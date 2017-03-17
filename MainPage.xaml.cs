using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Devices.Sensors;

namespace DatenErkundungen
{
    public partial class MainPage : PhoneApplicationPage
    {
        // shake to shuffle
        Accelerometer accelerometer = new Accelerometer();
        Random zufallsgenerator = new Random();


        // Konstruktor
        public MainPage()
        {
            InitializeComponent();
            //shake to shuffle
           accelerometer.Start();
           accelerometer.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(accelerometer_ReadingChanged);

            // Datenkontext des Listenfeldsteuerelements auf die Beispieldaten festlegen
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        //shake to shuffle, später dann auch noch in MapPage implementieren!!!
        void accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            //double X, Y, Z;
            if ((e.Y > 1.5 || e.Y < -1.5) && (e.X > 0.5 || e.X < -0.5))
            {

                accelerometer.ReadingChanged -= accelerometer_ReadingChanged;

                int zufallszahl;
                zufallszahl = zufallsgenerator.Next(0, 23);


                switch (zufallszahl)
                {
                    case 0:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/BrauhausVetters.xaml", UriKind.Relative));
                        });
                        break;
                    case 1:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/CocktailcafeRegie.xaml", UriKind.Relative));
                        });
                        break;
                    case 2:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Destille.xaml", UriKind.Relative));
                        });
                        break;
                    case 3:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/ExtrablattMarkt.xaml", UriKind.Relative));
                        });
                        break;
                    case 4:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Extrablatt.xaml", UriKind.Relative));
                        });
                        break;
                    case 5:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Gekco.xaml", UriKind.Relative));
                        });
                        break;
                    case 6:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/GoldenerReichsapfel.xaml", UriKind.Relative));
                        });
                        break;
                    case 7:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/GreyStones.xaml", UriKind.Relative));
                        });
                        break;
                    case 8:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/HardRockCafe.xaml", UriKind.Relative));
                        });
                        break;
                    case 9:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Havana.xaml", UriKind.Relative));
                        });
                        break;
                    case 10:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Jinx.xaml", UriKind.Relative));
                        });
                        break;
                    case 11:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Linos.xaml", UriKind.Relative));
                        });
                        break;
                    case 12:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/MaxBar.xaml", UriKind.Relative));
                        });
                        break;
                    case 13:
                    Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Medocs.xaml", UriKind.Relative));
                        });
                        break;
                    case 14:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Mels.xaml", UriKind.Relative));
                        });
                        break;
                    case 15:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Metropol.xaml", UriKind.Relative));
                        });
                        break;
                    case 16:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/NectarBar.xaml", UriKind.Relative));
                        });
                        break;
                    case 17:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/OReillys.xaml", UriKind.Relative));
                        });
                        break;
                    case 18:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Schmidts.xaml", UriKind.Relative));
                        });
                        break;
                    case 19:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Shooters.xaml", UriKind.Relative));
                        });
                        break;
                    case 20:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Skylouge.xaml", UriKind.Relative));
                        });
                        break;
                    case 21:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Sonderbar.xaml", UriKind.Relative));
                        });
                        break;
                    case 22:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/VaterRhein.xaml", UriKind.Relative));
                        });
                        break;
                    case 23:
                        Dispatcher.BeginInvoke(() =>
                        {
                            NavigationService.Navigate(new Uri("/Bars/Villa.xaml", UriKind.Relative));
                        });
                        break;
                }


            }



          } 
            //throw new NotImplementedException();

        

        // Auswahländerung für ListBox behandeln
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Nichts ausführen, wenn der Auswahlindex -1 (keine Auswahl) ist
            if (MainListBox.SelectedIndex == -1)
            {
                return;
            }

            // Achtung sehr gute Idee: anstatt if else it switch&cases arbeiten, besser?!
            else
            {
                switch (MainListBox.SelectedIndex)
                {
                    case 0:
                        NavigationService.Navigate(new Uri("/Bars/BrauhausVetters.xaml", UriKind.Relative));
                        break;
                    case 1:
                        NavigationService.Navigate(new Uri("/Bars/CocktailcafeRegie.xaml", UriKind.Relative));
                        break;
                    case 2:
                        NavigationService.Navigate(new Uri("/Bars/Destille.xaml", UriKind.Relative));
                        break;
                    case 3:
                        NavigationService.Navigate(new Uri("/Bars/ExtrablattMarkt.xaml", UriKind.Relative));
                        break;
                    case 4:
                        NavigationService.Navigate(new Uri("/Bars/Extrablatt.xaml", UriKind.Relative));
                        break;
                    case 5:
                        NavigationService.Navigate(new Uri("/Bars/Gekco.xaml", UriKind.Relative));
                        break;
                    case 6:
                        NavigationService.Navigate(new Uri("/Bars/GoldenerReichsapfel.xaml", UriKind.Relative));
                        break;
                    case 7:
                        NavigationService.Navigate(new Uri("/Bars/GreyStones.xaml", UriKind.Relative));
                        break;
                    case 8:
                        NavigationService.Navigate(new Uri("/Bars/HardRockCafe.xaml", UriKind.Relative));
                        break;
                    case 9:
                        NavigationService.Navigate(new Uri("/Bars/Havana.xaml", UriKind.Relative));
                        break;
                    case 10:
                        NavigationService.Navigate(new Uri("/Bars/Jinx.xaml", UriKind.Relative));
                        break;
                    case 11:
                        NavigationService.Navigate(new Uri("/Bars/Linos.xaml", UriKind.Relative));
                        break;
                    case 12:
                        NavigationService.Navigate(new Uri("/Bars/MaxBar.xaml", UriKind.Relative));
                        break;
                    case 13:
                        NavigationService.Navigate(new Uri("/Bars/Medocs.xaml", UriKind.Relative));
                        break;
                    case 14:
                        NavigationService.Navigate(new Uri("/Bars/Mels.xaml", UriKind.Relative));
                        break;
                    case 15:
                        NavigationService.Navigate(new Uri("/Bars/Metropol.xaml", UriKind.Relative));
                        break;
                    case 16:
                        NavigationService.Navigate(new Uri("/Bars/NectarBar.xaml", UriKind.Relative));
                        break;
                    case 17:
                        NavigationService.Navigate(new Uri("/Bars/OReillys.xaml", UriKind.Relative));
                        break;
                    case 18:
                        NavigationService.Navigate(new Uri("/Bars/Schmidts.xaml", UriKind.Relative));
                        break;
                    case 19:
                        NavigationService.Navigate(new Uri("/Bars/Shooters.xaml", UriKind.Relative));
                        break;
                    case 20:
                        NavigationService.Navigate(new Uri("/Bars/Skylouge.xaml", UriKind.Relative));
                        break;
                    case 21:
                        NavigationService.Navigate(new Uri("/Bars/Sonderbar.xaml", UriKind.Relative));
                        break;
                    case 22:
                        NavigationService.Navigate(new Uri("/Bars/VaterRhein.xaml", UriKind.Relative));
                        break;
                    case 23:
                        NavigationService.Navigate(new Uri("/Bars/Villa.xaml", UriKind.Relative));
                        break;
                    case 24:
                        NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
                        break;
                }

            }







            MainListBox.SelectedIndex = -1;



            /*
            if (MainListBox.SelectedIndex !=  -1) ///////////////////////////// YES! 2 in code ist laufzeit 3 in ui
            {
               
                //NavigationService.Navigate(new Uri("/Bars/Bar"+MainListBox.SelectedIndex+".xaml", UriKind.Relative));
                NavigationService.Navigate(new Uri("/Testpage.xaml", UriKind.Relative));

            }
            else //else if mit allen spezifischen bar-pages und else zum catchen am ende lassen(dynamisch)
            {
                // Zur neuen Seite navigieren
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));
            }
            // Auswahlindex auf -1 (keine Auswahl) zurücksetzen
*/
        }


        // Daten für die ViewModel-Elemente laden
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
    }
}