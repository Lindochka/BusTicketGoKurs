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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Route _currentRoute = new Route();
        public AddEditPage(Route selectedRoute)
        {
            InitializeComponent();

            if (selectedRoute != null)
            {
                _currentRoute = selectedRoute;
            }


                DataContext = _currentRoute;
                ComboSource.ItemsSource = BusTicketGoEntities.GetContext().City_Source.ToList();
                ComboDestination.ItemsSource = BusTicketGoEntities.GetContext().City_Destination.ToList();

            
        }

            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder errors = new StringBuilder();

             
                if (_currentRoute.Date == null)
                    errors.AppendLine("Введите дату");
                if (_currentRoute.Departure_time == null)
                    errors.AppendLine("Введите время отправления");
                if (_currentRoute.Arrival_time == null)
                    errors.AppendLine("Введите время прибытия");
                if (_currentRoute.Price == null)
                    errors.AppendLine("Введите цену");



                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                if (_currentRoute.route_ID == 0)
                    BusTicketGoEntities.GetContext().Route.Add(_currentRoute);
                BusTicketGoEntities.GetContext().SaveChanges();
                try
                {
                    BusTicketGoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusTicketGoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ComboSource.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();
                ComboDestination.ItemsSource = BusTicketGoEntities.GetContext().Route.ToList();
            }
        }
    }
} 

