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
    public partial class NectarBar : PhoneApplicationPage
    {
        public NectarBar()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(NectarBar_Loaded);
        }


        // wenn die NectarBar geladen wird, wird folgendes getan:
        void NectarBar_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin NectarBar = new Pushpin();
            NectarBar.Location = new GeoCoordinate(49.41345, 8.71067);
            myMap.Center = NectarBar.Location;
            NectarBar.Background = new SolidColorBrush(Colors.Black);
            NectarBar.Content = "Nectar Bar";
            NectarBar.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(NectarBar);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Nectar Bar";
            phone.PhoneNumber = "+4962217286051";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.mynectar.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "contact@mynectar.de";
            email.Body = "";
            email.Show();
        }
    }
}