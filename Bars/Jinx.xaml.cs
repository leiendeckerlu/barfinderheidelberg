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
    public partial class Jinx : PhoneApplicationPage
    {
        public Jinx()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Jinx_Loaded);
        }


        // wenn die Jinx geladen wird, wird folgendes getan:
        void Jinx_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Jinx = new Pushpin();
            Jinx.Location = new GeoCoordinate(49.41212, 8.70776);
            myMap.Center = Jinx.Location;
            Jinx.Background = new SolidColorBrush(Colors.Black);
            Jinx.Content = "Jinx Bar & Club";
            Jinx.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Jinx);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Jinx Bar & Club";
            phone.PhoneNumber = "+4962215997494";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.jinx-heidelberg.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@jinx-heidelberg.de";
            email.Body = "";
            email.Show();
        }
    }
}