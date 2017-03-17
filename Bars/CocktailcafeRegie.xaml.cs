using System;
using System.Collections.Generic;
using System.Device.Location;
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
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Tasks;

namespace DatenErkundungen
{
    public partial class CocktailcafeRegie : PhoneApplicationPage
    {
        public CocktailcafeRegie()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(CocktailcafeRegie_Loaded);
        }


        // wenn die CocktailcafeRegie geladen wird, wird folgendes getan:
        void CocktailcafeRegie_Loaded(object sender, RoutedEventArgs e)
        {


            Pushpin CocktailcafeRegie = new Pushpin();
            CocktailcafeRegie.Location = new GeoCoordinate(49.41102, 8.70368);
            myMap.Center = CocktailcafeRegie.Location;
            CocktailcafeRegie.Background = new SolidColorBrush(Colors.Black);
            CocktailcafeRegie.Content = "Cocktailcafé Regie";
            CocktailcafeRegie.FontSize = 18;
            myMap.ZoomLevel = 15;
            
            myMap.Children.Add(CocktailcafeRegie);
            
            //throw new NotImplementedException();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phone = new PhoneCallTask();
            phone.DisplayName = "Cocktailcafé Regie";
            phone.PhoneNumber = "+496221652226 ";
            phone.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.URL = "http://www.regie-heidelberg.de/";
            browser.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Anfrage";
            email.To = "info@regie-heidelberg.de ";
            email.Body = "";
            email.Show();
        }
    }
}