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
    public partial class Extrablatt : PhoneApplicationPage
    {
        public Extrablatt()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Extrablatt_Loaded);
        }


        // wenn die Extrablatt geladen wird, wird folgendes getan:
        void Extrablatt_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin Extrablatt = new Pushpin();
            Extrablatt.Location = new GeoCoordinate(49.41071, 8.69865);
            myMap.Center = Extrablatt.Location;
            Extrablatt.Background = new SolidColorBrush(Colors.Black);
            Extrablatt.Content = "Extrablatt";
            Extrablatt.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(Extrablatt);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Extrablatt";
            phone.PhoneNumber = "+4962218935340";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.cafe-extrablatt.com/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "heidelberg@cafe-extrablatt.de  ";
            email.Body = "";
            email.Show();
        }
    }
}