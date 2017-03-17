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
using Microsoft.Phone.Tasks;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;

namespace DatenErkundungen
{
    public partial class Mels : PhoneApplicationPage
    {
        public Mels()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Mels_Loaded);
        }


        // wenn die Mels geladen wird, wird folgendes getan:
        void Mels_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Mels = new Pushpin();
            Mels.Location = new GeoCoordinate(49.40921, 8.69196);
            myMap.Center = Mels.Location;
            Mels.Background = new SolidColorBrush(Colors.Black);
            Mels.Content = "Mel's Bar";
            Mels.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Mels);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Mel's Bar";
            phone.PhoneNumber = "+4962216577447";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.mels-bar.com/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "blabla@blabla.com";
            email.Body = "";
            email.Show();
        }
    }
}