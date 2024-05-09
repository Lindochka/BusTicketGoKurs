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
    /// Логика взаимодействия для RoutePage.xaml
    /// </summary>
    public partial class RoutePage : Page
    {
        public RoutePage()
        {
            InitializeComponent();
            DGridRoute.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var routeForRemoving = DGridRoute.SelectedItems.Cast<Route>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {routeForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    BusTicketGoEntities.GetContext().Route.RemoveRange(routeForRemoving);
                    BusTicketGoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridRoute.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusTicketGoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRoute.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Route));
        }
    }
}
