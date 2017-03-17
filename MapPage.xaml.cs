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
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using System.IO.IsolatedStorage;


namespace DatenErkundungen
{
    public partial class MapPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        GeoCoordinateWatcher watcher;
        Pushpin zentrum = new Pushpin();
        Pushpin myPlace = new Pushpin();



        // Konstruktor
        public MapPage()
        {
            InitializeComponent();


            this.Loaded += new RoutedEventHandler(MainPage_Loaded); // siehe hier drunter für start bei app-launch


        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            // checkt ob die app zum ersten mal ausgeführt wird oder nicht
            int IntRuntimes = 0;
            if (!settings.Contains("AppRuntimes"))
            {

                MessageBox.Show("Diese App verwendet Ihre Ortsinformationen um Ihren momentanen Standort auf eine Karte anzuzeigen. Standardmäßig ist der Ortsdienst deaktiviert. Sie können die Benutzung Ihrer Ortsinformationen unter 'Listen Ansicht'->'Info & Einstellungen' ein- und ausschalten.");

                IntRuntimes = IntRuntimes + 1;
                settings.Add("AppRuntimes", IntRuntimes);
            }
            else if (settings.Contains("AppRuntimes"))
            {
                
                IntRuntimes = Convert.ToInt16(settings["AppRuntimes"]);
                IntRuntimes = IntRuntimes + 1;
                settings["AppRuntimes"] = IntRuntimes;
            }
            settings.Save();


            // checkt ob der ortsdienst verwendet werden darf
            if (IsolatedStorageSettings.ApplicationSettings.Contains("GpsAllowed"))
            {
                bool zwischenwert;
                zwischenwert = Convert.ToBoolean(settings["GpsAllowed"]);

                if (zwischenwert == false)
                {
                    button2.IsEnabled = false;
                }
                else if (zwischenwert == true)
                {
                    button2.IsEnabled = true;
                }

            }
            else if (!IsolatedStorageSettings.ApplicationSettings.Contains("GpsAllowed"))
            {
                if (!settings.Contains("GpsAllowed"))
                {
                    settings.Add("GpsAllowed", "false");
                }
                else
                {
                    settings["GpsAllowed"] = "false";
                }
                settings.Save();
                button2.IsEnabled = false;
            }

            // referenzpushpin nur zu berechnungen
            Pushpin nullpunkt = new Pushpin();
            nullpunkt.Location = new GeoCoordinate(00.00000, 00.00000);

            ///////////////////////////

            Pushpin pinX = new Pushpin();
            pinX.Location = new GeoCoordinate(49.40957, 8.69319); // pinX in Heidelberg - Bisi?
            pinX.Background = new SolidColorBrush(Colors.Red);
            pinX.Content = "ZENTRUM";
            pinX.FontSize = 18;
            //myMap.Center = pinX.Location;
            //myMap.Children.Add(pinX);
           
            //mapcenter gleich bei pagewechsel
            if(myMap.Center == nullpunkt.Location)
            {
                myMap.Center = pinX.Location;
            }
            else if (nullpunkt.Location != zentrum.Location && pinX.Location != zentrum.Location)
            {
                myMap.Center = zentrum.Location;
            }


           // zoomlevel gleich bei pagewechsel
            if(myMap.ZoomLevel == 1)
            {
                 myMap.ZoomLevel = 14; // ZOOMLEVEL AM AUSGANGSPUNKT BEI APP-START! >10 & <15
               
            }
            else if (myMap.ZoomLevel > 14 && myMap.ZoomLevel < 14)
            {
                myMap.ZoomLevel = myMap.ZoomLevel;
                myMap.Center = zentrum.Location;
            }


            /////////////////////////////MY OWN DATA/////////////////////////////////////


            Pushpin Havana = new Pushpin();
            Havana.Location = new GeoCoordinate(49.41259, 8.7003);
            Havana.Background = new SolidColorBrush(Colors.Black);
            Havana.Content = "Havana";
            Havana.FontSize = 18;
            myMap.Children.Add(Havana);
            Havana.MouseLeftButtonUp += new MouseButtonEventHandler(Havana_MouseLeftButtonUp);
            ////
            Pushpin Gekco = new Pushpin();
            Gekco.Location = new GeoCoordinate(49.40921, 8.69196);
            Gekco.Background = new SolidColorBrush(Colors.Black);
            Gekco.Content = "Gekco";
            Gekco.FontSize = 18;
            myMap.Children.Add(Gekco);
            Gekco.MouseLeftButtonUp += new MouseButtonEventHandler(Gekco_MouseLeftButtonUp);
            ////
            Pushpin Linos = new Pushpin();
            Linos.Location = new GeoCoordinate(49.40860, 08.6903);
            Linos.Background = new SolidColorBrush(Colors.Black);
            Linos.Content = "Lino's";
            Linos.FontSize = 18;
            myMap.Children.Add(Linos);
            Linos.MouseLeftButtonUp += new MouseButtonEventHandler(Linos_MouseLeftButtonUp);
            ////
            Pushpin CocktailcafeRegie = new Pushpin();
            CocktailcafeRegie.Location = new GeoCoordinate(49.41108, 8.7036);
            CocktailcafeRegie.Background = new SolidColorBrush(Colors.Black);
            CocktailcafeRegie.Content = "Cocktailcafé Regie";
            CocktailcafeRegie.FontSize = 18;
            myMap.Children.Add(CocktailcafeRegie);
            CocktailcafeRegie.MouseLeftButtonUp += new MouseButtonEventHandler(CocktailcafeRegie_MouseLeftButtonUp);
            ////
            Pushpin Shooters = new Pushpin();
            Shooters.Location = new GeoCoordinate(49.41159, 8.7077);
            Shooters.Background = new SolidColorBrush(Colors.Black);
            Shooters.Content = "Shooters";
            Shooters.FontSize = 18;
            myMap.Children.Add(Shooters);
            Shooters.MouseLeftButtonUp += new MouseButtonEventHandler(Shooters_MouseLeftButtonUp);
            ////
            Pushpin OReillys = new Pushpin();
            OReillys.Location = new GeoCoordinate(49.41372, 8.69325);
            OReillys.Background = new SolidColorBrush(Colors.Black);
            OReillys.Content = "O'Reilly's Irish Pub";
            OReillys.FontSize = 18;
            myMap.Children.Add(OReillys);
            OReillys.MouseLeftButtonUp += new MouseButtonEventHandler(OReillys_MouseLeftButtonUp);
            ////
            Pushpin Jinx = new Pushpin();
            Jinx.Location = new GeoCoordinate(49.41212, 8.70776);
            Jinx.Background = new SolidColorBrush(Colors.Black);
            Jinx.Content = "Jinx Bar&Club";
            Jinx.FontSize = 18;
            myMap.Children.Add(Jinx);
            Jinx.MouseLeftButtonUp += new MouseButtonEventHandler(Jinx_MouseLeftButtonUp);
            ////
            Pushpin GoldenerReichsapfel = new Pushpin();
            GoldenerReichsapfel.Location = new GeoCoordinate(49.41234, 8.70885);
            GoldenerReichsapfel.Background = new SolidColorBrush(Colors.Black);
            GoldenerReichsapfel.Content = "Goldener Reichsapfel";
            GoldenerReichsapfel.FontSize = 18;
            myMap.Children.Add(GoldenerReichsapfel);
            GoldenerReichsapfel.MouseLeftButtonUp += new MouseButtonEventHandler(GoldenerReichsapfel_MouseLeftButtonUp);
            ////
            Pushpin Extrablatt = new Pushpin();
            Extrablatt.Location = new GeoCoordinate(49.41071, 8.69865);
            Extrablatt.Background = new SolidColorBrush(Colors.Black);
            Extrablatt.Content = "Extrablatt";
            Extrablatt.FontSize = 18;
            myMap.Children.Add(Extrablatt);
            Extrablatt.MouseLeftButtonUp += new MouseButtonEventHandler(Extrablatt_MouseLeftButtonUp);
            ////////////////////////////////////////////////////////////////VOM 10.05.2011
            Pushpin HardRockCafe= new Pushpin();
            HardRockCafe.Location = new GeoCoordinate(49.41163, 8.70707);
            HardRockCafe.Background = new SolidColorBrush(Colors.Black);
            HardRockCafe.Content = "Hard Rock Café";
            HardRockCafe.FontSize = 18;
            myMap.Children.Add(HardRockCafe);
            HardRockCafe.MouseLeftButtonUp += new MouseButtonEventHandler(HardRockCafe_MouseLeftButtonUp);
            ////
            Pushpin ExtrablattMarkt = new Pushpin();
            ExtrablattMarkt.Location = new GeoCoordinate(49.41178, 8.70830);
            ExtrablattMarkt.Background = new SolidColorBrush(Colors.Black);
            ExtrablattMarkt.Content = "Extrablatt Markt";
            ExtrablattMarkt.FontSize = 18;
            myMap.Children.Add(ExtrablattMarkt);
            ExtrablattMarkt.MouseLeftButtonUp += new MouseButtonEventHandler(ExtrablattMarkt_MouseLeftButtonUp);
            ////
            Pushpin MaxBar = new Pushpin();
            MaxBar.Location = new GeoCoordinate(49.41237, 8.71032);
            MaxBar.Background = new SolidColorBrush(Colors.Black);
            MaxBar.Content = "MaxBar";
            MaxBar.FontSize = 18;
            myMap.Children.Add(MaxBar);
            MaxBar.MouseLeftButtonUp += new MouseButtonEventHandler(MaxBar_MouseLeftButtonUp);
            ////
            Pushpin GreyStones = new Pushpin();
            GreyStones.Location = new GeoCoordinate(49.41246, 8.70955);
            GreyStones.Background = new SolidColorBrush(Colors.Black);
            GreyStones.Content = "Grey Stones";
            GreyStones.FontSize = 18;
            myMap.Children.Add(GreyStones);
            GreyStones.MouseLeftButtonUp += new MouseButtonEventHandler(GreyStones_MouseLeftButtonUp);
            ////
            Pushpin Mels = new Pushpin();
            Mels.Location = new GeoCoordinate(49.41255, 8.71087);
            Mels.Background = new SolidColorBrush(Colors.Black);
            Mels.Content = "Mel's Bar";
            Mels.FontSize = 18;
            myMap.Children.Add(Mels);
            Mels.MouseLeftButtonUp += new MouseButtonEventHandler(Mels_MouseLeftButtonUp);
            ////
            Pushpin Destille = new Pushpin();
            Destille.Location = new GeoCoordinate(49.41209, 8.70748);
            Destille.Background = new SolidColorBrush(Colors.Black);
            Destille.Content = "Destille";
            Destille.FontSize = 18;
            myMap.Children.Add(Destille);
            Destille.MouseLeftButtonUp += new MouseButtonEventHandler(Destille_MouseLeftButtonUp);
            ////
            Pushpin Villa = new Pushpin();
            Villa.Location = new GeoCoordinate(49.41193, 8.70898);
            Villa.Background = new SolidColorBrush(Colors.Black);
            Villa.Content = "Café Villa";
            Villa.FontSize = 18;
            myMap.Children.Add(Villa);
            Villa.MouseLeftButtonUp += new MouseButtonEventHandler(Villa_MouseLeftButtonUp);
            ////
            Pushpin Schmidts = new Pushpin();
            Schmidts.Location = new GeoCoordinate(49.41192, 8.70914);
            Schmidts.Background = new SolidColorBrush(Colors.Black);
            Schmidts.Content = "Schmidts";
            Schmidts.FontSize = 18;
            myMap.Children.Add(Schmidts);
            Schmidts.MouseLeftButtonUp += new MouseButtonEventHandler(Schmidts_MouseLeftButtonUp);
            ////
            Pushpin SKYlouge = new Pushpin();
            SKYlouge.Location = new GeoCoordinate(49.40685, 8.68544);
            SKYlouge.Background = new SolidColorBrush(Colors.Black);
            SKYlouge.Content = "SKYlouge";
            SKYlouge.FontSize = 18;
            myMap.Children.Add(SKYlouge);
            SKYlouge.MouseLeftButtonUp += new MouseButtonEventHandler(SKYlouge_MouseLeftButtonUp);
            ////
            Pushpin Medocs = new Pushpin();
            Medocs.Location = new GeoCoordinate(49.41032, 8.69351);
            Medocs.Background = new SolidColorBrush(Colors.Black);
            Medocs.Content = "MEDOCS";
            Medocs.FontSize = 18;
            myMap.Children.Add(Medocs);
            Medocs.MouseLeftButtonUp += new MouseButtonEventHandler(Medocs_MouseLeftButtonUp);
            ////
            Pushpin BrauhausVetters = new Pushpin();
            BrauhausVetters.Location = new GeoCoordinate(49.41254, 8.70971);
            BrauhausVetters.Background = new SolidColorBrush(Colors.Black);
            BrauhausVetters.Content = "Brauhaus Vetter";
            BrauhausVetters.FontSize = 18;
            myMap.Children.Add(BrauhausVetters);
            BrauhausVetters.MouseLeftButtonUp += new MouseButtonEventHandler(BrauhausVetters_MouseLeftButtonUp);
            ////
            Pushpin Sonderbar = new Pushpin();
            Sonderbar.Location = new GeoCoordinate(49.41223, 8.70739);
            Sonderbar.Background = new SolidColorBrush(Colors.Black);
            Sonderbar.Content = "Sonderbar";
            Sonderbar.FontSize = 18;
            myMap.Children.Add(Sonderbar);
            Sonderbar.MouseLeftButtonUp += new MouseButtonEventHandler(Sonderbar_MouseLeftButtonUp);
            ////
            Pushpin VaterRhein = new Pushpin();
            VaterRhein.Location = new GeoCoordinate(49.41182, 8.69749);
            VaterRhein.Background = new SolidColorBrush(Colors.Black);
            VaterRhein.Content = "Vater Rhein";
            VaterRhein.FontSize = 18;
            myMap.Children.Add(VaterRhein);
            VaterRhein.MouseLeftButtonUp += new MouseButtonEventHandler(VaterRhein_MouseLeftButtonUp);
            ////
            Pushpin NectarBar = new Pushpin();
            NectarBar.Location = new GeoCoordinate(49.41345, 8.71067);
            NectarBar.Background = new SolidColorBrush(Colors.Black);
            NectarBar.Content = "Nectar Bar";
            NectarBar.FontSize = 18;
            myMap.Children.Add(NectarBar);
            NectarBar.MouseLeftButtonUp += new MouseButtonEventHandler(NectarBar_MouseLeftButtonUp);
            /////////////////////////////////////////////////////////////

            // wenn keine gps genauigkeitsinfos festgelegt sind, wird der standard verwendet
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("GpsDetail"))
            {
                    if (!settings.Contains("GpsDetail"))
                    {
                        settings.Add("GpsDetail", "standard");
                    }
                    else
                    {
                        settings["GpsDetail"] = "standard";
                    }
                    settings.Save();
             }



            ///////////////////////////////////////////////////////////
            // das hier müsste dann aber auch unter die button-funktion "Wo bin ich?"

            /* bool started = watcher.TryStart(true, TimeSpan.FromMilliseconds(60000)); //synchron auf real device

             if (started)
             {
                 if (watcher.Status == GeoPositionStatus.Ready)
                 {
                     MessageBox.Show("Location data is available!");
                 }
                 else
                 {
                     MessageBox.Show("Location data ist not currently available. Please try again.");
                 }
             }
             else
             {
                 MessageBox.Show("The location service could not be started.!");
             } */
        }

        void NectarBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/NectarBar.xaml", UriKind.Relative));
        }

        void VaterRhein_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/VaterRhein.xaml", UriKind.Relative));
        }

        void Sonderbar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Sonderbar.xaml", UriKind.Relative));
        }

        void BrauhausVetters_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/BrauhausVetters.xaml", UriKind.Relative));
        }

        void Medocs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Medocs.xaml", UriKind.Relative));
        }

        void SKYlouge_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Skylouge.xaml", UriKind.Relative));
        }

        void Schmidts_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Schmidts.xaml", UriKind.Relative));
        }

        void Villa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Villa.xaml", UriKind.Relative));
        }

        void Destille_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Destille.xaml", UriKind.Relative));
        }

        void Mels_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Mels.xaml", UriKind.Relative));
        }

        void GreyStones_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/GreyStones.xaml", UriKind.Relative));
        }

        void MaxBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/MaxBar.xaml", UriKind.Relative));
        }

        void ExtrablattMarkt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/ExtrablattMarkt.xaml", UriKind.Relative));
        }

        void HardRockCafe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/HardRockCafe.xaml", UriKind.Relative));
        }

        void Extrablatt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Extrablatt.xaml", UriKind.Relative));
        }

        void GoldenerReichsapfel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/GoldenerReichsapfel.xaml", UriKind.Relative));
        }

        void Jinx_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Jinx.xaml", UriKind.Relative));
        }

        void OReillys_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Oreillys.xaml", UriKind.Relative));
        }

        void Shooters_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Shooters.xaml", UriKind.Relative));
        }

        void CocktailcafeRegie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/CocktailcafeRegie.xaml", UriKind.Relative));
        }

        void Linos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Linos.xaml", UriKind.Relative));
        }

        void Gekco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Gekco.xaml", UriKind.Relative));
        }

        void Havana_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/Bars/Havana.xaml", UriKind.Relative));
        }

        // bewege den pushpin meines standortes
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
           // latitudeTextBlock.Text = "Latitude: " + e.Position.Location.Latitude.ToString("0.000");
           // longitudeTextBlock.Text = "Longitude: " + e.Position.Location.Longitude.ToString("0.000");
           myPlace.Location = e.Position.Location;
           myPlace.Background = new SolidColorBrush(Colors.Red);
           myPlace.Content = "Mein Standort";


            
            
           /* if (myMap.Children.Contains(myPlace) == false)
             {

                 myPlace.Location = e.Position.Location;
                 myPlace.Background = new SolidColorBrush(Colors.Red);
                 myPlace.Content = "Mein Standort";
                 myMap.Children.Add(myPlace);
             }
             else if (myMap.Children.Contains(myPlace) == true)
             { 
                 if (myPlace.Location != e.Position.Location)
                 {
                     myMap.Children.Remove(myPlace);

                     myPlace.Location = e.Position.Location;
                     myPlace.Background = new SolidColorBrush(Colors.Red);
                     myPlace.Content = "Mein StandortXXX";
                     myMap.Children.Add(myPlace);
                 }
             } */


            if (myMap.Children.Contains(myPlace) == false)
            {
                myMap.Children.Add(myPlace);
            }


           /* 
           if (myMap.Children.Contains(myPlace))
            {
                myMap.Children.Remove(myPlace);

                GeoCoordinate co = watcher.Position.Location;
                myPlace.Location = watcher.Position.Location;
                myPlace.Background = new SolidColorBrush(Colors.Red);
                myPlace.Content = "Mein Standort";
                myPlace.Location = e.Position.Location;

                myMap.Children.Add(myPlace);
            }
            else if (!myMap.Children.Contains(myPlace))
            {
                myPlace.Location = e.Position.Location;
                myPlace.Background = new SolidColorBrush(Colors.Red);
                myPlace.Content = "Mein Standort";
                myPlace.Location = e.Position.Location;
                myMap.Children.Add(myPlace);
            } */



            //myMap.Children.Re
            //myMap.Children.Add(myPlace); // muss diese zeile vllt weg um keine marker zu bekommen?
            //myMap.Center = e.Position.Location; // map auf aktuell position zentrieren
        }

        // status informationen zu gps
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {

           /* if (e.Status == GeoPositionStatus.Ready)
            {
                // Use the Position property of the GeoCoordinateWatcher object to get the current location.

            }*/

            switch (e.Status)
             {
                 case GeoPositionStatus.Disabled:

                     if (watcher.Permission == GeoPositionPermission.Denied)
                     {
                         MessageBox.Show("Sie müssen der App erlauben auf Ihren Ortsdienst zugreifen zu können");
                         //statusTextBlock.Text = "You have this App access to location!";
                     }
                     else
                     {
                         MessageBox.Show("Der Ortsdienst scheint auf Ihrem Gerät nicht zu funktionieren");
                         //statusTextBlock.Text = "Location is not functioning on your Device!";
                     }
                     break;

                 case GeoPositionStatus.Initializing:
                     //startLocationButton.IsEnabled = false;
                     break;

                 case GeoPositionStatus.NoData:
                    //MessageBox.Show("Es stehen momentan keine Ortsdaten zur Verfügung. Bitte warten Sie einen Moment und versuchen Sie es dann nocheinmal");
                    //statusTextBlock.Text = "Location Data is not available!";
                    //stopLocationButton.IsEnabled = true;
                     break;

                 case GeoPositionStatus.Ready:
                     // GeoCoordinate co = watcher.Position.Location;
                       //Stop the Location Service to conserve battery power.
                      //  watcher.Stop();
                      //MessageBox.Show("Ihre Ortsdaten werden abgerufen!");
                      //statusTextBlock.Text = "Location Data is available!";
                      //stopLocationButton.IsEnabled = true;
                     break;
             } 
        }

        //Gehe zur Listenansicht
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            zentrum.Location = myMap.Center;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        //Zeige meine Position auf der Karte
        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (watcher == null)
            {

                // DEFAULT ODER HIGH????
                if (IsolatedStorageSettings.ApplicationSettings.Contains("GpsDetail"))
                {
                    string GpsGenauigkeit;
                    GpsGenauigkeit = Convert.ToString(settings["GpsDetail"]);


                    if (GpsGenauigkeit == "standard")
                    {

                        watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);

                    }
                    else if (GpsGenauigkeit == "hoch")
                    {

                        watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

                    }

                }
                else if (!IsolatedStorageSettings.ApplicationSettings.Contains("GpsDetail"))
                {

                    if (!settings.Contains("GpsDetail"))
                    {
                        settings.Add("GpsDetail", "standard");
                    }
                    else
                    {
                        settings["GpsDetail"] = "standard";
                    }
                    settings.Save();

                    watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);    
                }


                watcher.MovementThreshold = 10;

                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);

                //watcher.Start(); //asynchron in emulator



                // das hier müsste dann aber auch unter die button-funktion "Wo bin ich?"
                
                bool started = watcher.TryStart(true, TimeSpan.FromMilliseconds(60000)); //synchron auf real device

                 if (started)
                 {
                     if (watcher.Status == GeoPositionStatus.Ready)
                     {
                        // MessageBox.Show("Location data is available!");
                     }
                     else
                     {
                        // MessageBox.Show("Location data ist not currently available. Please try again later.");
                     }
                 }
                 else
                 {
                     MessageBox.Show("The location service could not be started.!");
                 } 
        



            }
        }



    }
}