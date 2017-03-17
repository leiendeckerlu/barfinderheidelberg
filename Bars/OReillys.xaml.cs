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
    public partial class OReillys : PhoneApplicationPage
    {
        public OReillys()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(OReillys_Loaded);
        }


        // wenn die OReillys geladen wird, wird folgendes getan:
        void OReillys_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin OReillys = new Pushpin();
            OReillys.Location = new GeoCoordinate(49.41372, 8.69325);
            myMap.Center = OReillys.Location;
            OReillys.Background = new SolidColorBrush(Colors.Black);
            OReillys.Content = "O'Reillys Irish Pub";
            OReillys.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(OReillys);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "O'Reillys Irish Pus";
            phone.PhoneNumber = "+496221410140";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://oreillys.nl/heidelberg/";
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