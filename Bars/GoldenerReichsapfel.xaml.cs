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
    public partial class GoldenerReichsapfel : PhoneApplicationPage
    {
        public GoldenerReichsapfel()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(GoldenerReichsapfel_Loaded);
        }


        // wenn die GoldenerReichsapfel geladen wird, wird folgendes getan:
        void GoldenerReichsapfel_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin GoldenerReichsapfel = new Pushpin();
            GoldenerReichsapfel.Location = new GeoCoordinate(49.41234, 8.70885);
            myMap.Center = GoldenerReichsapfel.Location;
            GoldenerReichsapfel.Background = new SolidColorBrush(Colors.Black);
            GoldenerReichsapfel.Content = "Goldener Reichsapfel";
            GoldenerReichsapfel.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(GoldenerReichsapfel);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "GoldenerReichsapfel";
            phone.PhoneNumber = "+496221485542";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.reichsapfel-lager.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@reichsapfel-lager.de";
            email.Body = "";
            email.Show();
        }
    }
}