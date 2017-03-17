using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Devices.Sensors;
using System.IO.IsolatedStorage;


namespace DatenErkundungen
{
    public partial class InfoPage : PhoneApplicationPage
    {

        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings; 
        bool zwischenwert; // dass zwischenwert public ist, gefällt mir nicht!!!
        string GpsGenauigkeit; // hier genauso wenig!!!

        public InfoPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(InfoPage_Loaded);

        }

        // was passiert wenn die seite geladen wird?
        void InfoPage_Loaded(object sender, RoutedEventArgs e)
        {

        
            
            // gps an oder aus?
            if (IsolatedStorageSettings.ApplicationSettings.Contains("GpsAllowed"))
            {
                
                zwischenwert = Convert.ToBoolean(settings["GpsAllowed"]);
                toggleSwitch1.IsChecked = zwischenwert;
            }



            // lese gps genauigkeit aus

            if (zwischenwert == true)
            {
                toggleSwitch1.Content = "AN";
                if (IsolatedStorageSettings.ApplicationSettings.Contains("GpsDetail"))
                {
                    
                    GpsGenauigkeit = Convert.ToString(settings["GpsDetail"]);

                    if (GpsGenauigkeit == "standard")
                    {
                        button5.IsEnabled = false;
                        button6.IsEnabled = true;
                    }
                    else if (GpsGenauigkeit == "hoch")
                    {
                        button5.IsEnabled = true;
                        button6.IsEnabled = false;
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

                    button5.IsEnabled = false;
                    button6.IsEnabled = true;

                }

            }
            else if (zwischenwert == false)
            {
                toggleSwitch1.Content = "AUS";
                button5.IsEnabled = false;
                button6.IsEnabled = false;

            }     
            //throw new NotImplementedException();
        }


        // sende eine email
       /* private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Feedback";
            email.To = "barfinderheidelberg@gmail.com";
            email.Body = "Feedback zur BarFinderHeidelberg-App:";
            email.Show();
        } */

        // gehe zum twitterfeed
       /* private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask feedbackbrowser = new WebBrowserTask();
            feedbackbrowser.URL = "http://www.twitter.com/barfinderheidelberg";
            feedbackbrowser.Show();
        } */

        // gehe zur feedbackseite
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarFeedback.xaml", UriKind.Relative));
        }

        // verwende gps: ja/nein?
        private void toggleSwitch1_Click(object sender, RoutedEventArgs e)
        {

            if (!settings.Contains("GpsAllowed"))
            {
                settings.Add("GpsAllowed", toggleSwitch1.IsChecked);
            }
            else
            {
                settings["GpsAllowed"] = toggleSwitch1.IsChecked;
            }
            settings.Save();

            if (toggleSwitch1.IsChecked == true)
            {

                toggleSwitch1.Content = "AN";
                GpsGenauigkeit = Convert.ToString(settings["GpsDetail"]);

                if (GpsGenauigkeit == "standard")
                {
                    button5.IsEnabled = false;
                    button6.IsEnabled = true;
                }
                else if (GpsGenauigkeit == "hoch")
                {
                    button5.IsEnabled = true;
                    button6.IsEnabled = false;
                }

            }
            else if (toggleSwitch1.IsChecked == false)
            {
                toggleSwitch1.Content = "AUS";

                button5.IsEnabled = false;
                button6.IsEnabled = false;

            }

        }

        // gehe zur lizenzseite
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/LizenzPage.xaml", UriKind.Relative));
        }

        // gps genauigkeit default
        private void button5_Click(object sender, RoutedEventArgs e)
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
            MessageBox.Show("Die Genauigkeit ihrer Ortsinformationen wurde auf 'Standard' gesetzt. Die Änderungen werden nach einem Neustart der App wirksam.");
            button5.IsEnabled = false;
            button6.IsEnabled = true;

        }

        // gps genauigkeit high
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (!settings.Contains("GpsDetail"))
            {
                settings.Add("GpsDetail", "hoch");
            }
            else
            {
                settings["GpsDetail"] = "hoch";
            }
            settings.Save();
            MessageBox.Show("Die Genauigkeit ihrer Ortsinformationen wurde auf 'Hoch' gesetzt. Bitte beachten Sie, dass dies einen höheren Stromverbrauch zur Folge hat. Die Änderungen werden nach einem Neustart der App wirksam.");
            button5.IsEnabled = true;
            button6.IsEnabled = false;
        }
    }
}