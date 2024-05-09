using BusTicketGoKurs;
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
    /// Логика взаимодействия для TicketingPage.xaml
    /// </summary>
    public partial class TicketingPage : Page
    {
        private Ticket _currentTicket = new Ticket();
        public TicketingPage(Ticket selectedTicket)
        {
            InitializeComponent();
            if (selectedTicket != null)
            {
                _currentTicket = selectedTicket;
            }


            DataContext = _currentTicket;

        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            

            if (_currentTicket.Surname == null)
                errors.AppendLine("Введите Фамилию");
            if (_currentTicket.Name == null)
                errors.AppendLine("Введите Имя");
            if (_currentTicket.Patronymic == null)
                errors.AppendLine("Введите Отчество");
            if (_currentTicket.BurthDate == null)
                errors.AppendLine("Введите дату рождения");
            if (_currentTicket.PassportNum == null)
                errors.AppendLine("Введите паспортные данные");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            // Сохранение информации о билете


            if (_currentTicket == null )
            {
                MessageBox.Show("Ошибка входа");

            }
            else
            {
                // Переход на следующую страницу
                Manager.MainFrame.Navigate(new MyTicketPage());

            }


            ;


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusTicketGoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            }
        }

    }
}

