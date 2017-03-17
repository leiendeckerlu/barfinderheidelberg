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
    public partial class GreyStones : PhoneApplicationPage
    {
        public GreyStones()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(GreyStones_Loaded);
        }


        // wenn die GreyStones geladen wird, wird folgendes getan:
        void GreyStones_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin GreyStones = new Pushpin();
            GreyStones.Location = new GeoCoordinate(49.41246, 8.70955);
            myMap.Center = GreyStones.Location;
            GreyStones.Background = new SolidColorBrush(Colors.Black);
            GreyStones.Content = "Grey Stones";
            GreyStones.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(GreyStones);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Grey Stones";
            phone.PhoneNumber = "+4962215880280 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.grey-stones.de/";
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