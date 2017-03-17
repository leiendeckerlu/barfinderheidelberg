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
    public partial class MaxBar : PhoneApplicationPage
    {
        public MaxBar()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MaxBar_Loaded);
        }


        // wenn die MaxBar geladen wird, wird folgendes getan:
        void MaxBar_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin MaxBar = new Pushpin();
            MaxBar.Location = new GeoCoordinate(49.41237, 8.71032);
            myMap.Center = MaxBar.Location;
            MaxBar.Background = new SolidColorBrush(Colors.Black);
            MaxBar.Content = "Maxbar";
            MaxBar.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(MaxBar);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Maxbar";
            phone.PhoneNumber = "+49622124419";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.Max-bar-heidelberg.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "matthieu@max-bar-heidelberg.de";
            email.Body = "";
            email.Show();
        }
    }
}