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
    public partial class Skylouge : PhoneApplicationPage
    {
        public Skylouge()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Skylouge_Loaded);
        }


        // wenn die Skylouge geladen wird, wird folgendes getan:
        void Skylouge_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Skylouge = new Pushpin();
            Skylouge.Location = new GeoCoordinate(49.40685, 8.68544);
            myMap.Center = Skylouge.Location;
            Skylouge.Background = new SolidColorBrush(Colors.Black);
            Skylouge.Content = "SKYlouge";
            Skylouge.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Skylouge);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "SKYlouge";
            phone.PhoneNumber = "+496221434968 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.skylounge-heidelberg.de/turm/start.html";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@skylounge-heidelberg.de";
            email.Body = "";
            email.Show();
        }
    }
}