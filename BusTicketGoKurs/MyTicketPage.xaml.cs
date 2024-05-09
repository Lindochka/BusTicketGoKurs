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
    /// Логика взаимодействия для MyTicketPage.xaml
    /// </summary>
    public partial class MyTicketPage : Page
    {
        public MyTicketPage()
        {
            InitializeComponent();

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusTicketGoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridTicket.ItemsSource = BusTicketGoEntities.GetContext().Ticket.ToList();
            }
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TicketingPage((sender as Button).DataContext as Ticket));

        }
    }
}
