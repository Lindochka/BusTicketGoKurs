using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusTicketGoKurs
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private Route selectedRoute;

        public AdminPage()
        {
            InitializeComponent();
            
        }
        private void FindRouteButton_Click(object sender, RoutedEventArgs e)
        {

        //    using (var db = new UserEntities())

          //  {
            //    List<User> users = UserEntities.GetContext().User.ToList();
              //  if (users != Administrator)
                //{
                  //  //Application.Current.MainWindow.Close();
                    //Manager.MainFrame.Navigate(new AdminPage());

              //  }
               // else
                //{
                  //  //Application.Current.MainWindow.Close();
                    //Manager.MainFrame.Navigate(new UserPage());



                //}
            // }


            
  
            
                 // Переход на следующую страницу
                 Manager.MainFrame.Navigate(new RoutePage());
            
            
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reports_Page());
        }
    }
}