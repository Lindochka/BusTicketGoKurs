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
    /// Логика взаимодействия для RouteForUserPage.xaml
    /// </summary>
    public partial class RouteForUserPage : Page
    {
        public RouteForUserPage()
        {
            InitializeComponent();
            DGridRoute.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TicketingPage((sender as Button).DataContext as Ticket));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusTicketGoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRoute.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();
            }
        }
    }
}
