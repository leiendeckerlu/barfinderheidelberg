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
    public partial class Schmidts : PhoneApplicationPage
    {
        public Schmidts()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Schmidts_Loaded);
        }


        // wenn die Schmidts geladen wird, wird folgendes getan:
        void Schmidts_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Schmidts = new Pushpin();
            Schmidts.Location = new GeoCoordinate(49.41192, 8.70914);
            myMap.Center = Schmidts.Location;
            Schmidts.Background = new SolidColorBrush(Colors.Black);
            Schmidts.Content = "Schmidts";
            Schmidts.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Schmidts);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Schmidts";
            phone.PhoneNumber = "+4962216549065";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.schmidts-hd.de/";
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