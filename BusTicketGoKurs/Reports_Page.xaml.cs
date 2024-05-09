using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;

namespace BusTicketGoKurs
{
    /// <summary>
    /// Логика взаимодействия для Reports_Page.xaml
    /// </summary>
    public partial class Reports_Page : System.Windows.Controls.Page
    {
        private int insuranceTypeID;
        private static string selectedPolicy; public Reports_Page()
        {
            InitializeComponent();
            sals.ItemsSource = BusTicketGoEntities.GetContext().Ticket.ToList();
            DGridUser.ItemsSource = BusTicketGoEntities.GetContext().User.ToList();


        }

        private void Button_ExportWord_1(object sender, RoutedEventArgs e)
        {
            Word.Application word = new Word.Application();
            word.Visible = false; // Установка свойства Visible в false
            Word.Document document = word.Documents.Add();

            Word.Paragraph para = document.Content.Paragraphs.Add();
            para.Range.Text = "Отчет";

            Word.Table table = document.Tables.Add(para.Range, sals.Items.Count + 1, sals.Columns.Count);
            table.Borders.Enable = 1;

            for (int j = 0; j < sals.Columns.Count; j++)
            {
                table.Cell(1, j + 1).Range.Text = sals.Columns[j].Header.ToString();
            }

            for (int i = 0; i < sals.Items.Count; i++)
            {
                for (int j = 0; j < sals.Columns.Count; j++)
                {
                    TextBlock b = sals.Columns[j].GetCellContent(sals.Items[i]) as TextBlock;
                    table.Cell(i + 2, j + 1).Range.Text = b.Text;
                }
            }

            // Запрос у пользователя пути и названия файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                document.SaveAs2(filePath); // Сохранение файла по указанному пути
                document.Close(); // Закрытие документа
                word.Quit(); // Закрытие приложения Word
            }
        }

        private void Button_ExportExcel_1(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = false; // Установка свойства Visible в false
            Workbook workbook = excel.Workbooks.Add();
            Worksheet worksheet = workbook.ActiveSheet;
            if (sals != null)
            {
                for (int j = 0; j < sals.Columns.Count; j++)
                {
                    worksheet.Cells[2, j + 1] = sals.Columns[j].Header.ToString();
                }

                for (int i = 0; i < sals.Items.Count; i++)
                {
                    for (int j = 0; j < sals.Columns.Count; j++)
                    {
                        TextBlock b = sals.Columns[j].GetCellContent(sals.Items[i]) as TextBlock;
                        worksheet.Cells[i + 2, j + 1] = b.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("datagridkolvo не инициализирован или равен null.");
                worksheet.Cells[1, 1] = "Отчет";
            }

            // Запрос у пользователя пути и названия файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath); // Сохранение файла по указанному пути
                workbook.Close(); // Закрытие книги Excel
                excel.Quit(); // Закрытие приложения Excel
            }
        }

        private void Button_ExportWord_2(object sender, RoutedEventArgs e)
        {
            Word.Application word = new Word.Application();
            word.Visible = false; // Установка свойства Visible в false
            Word.Document document = word.Documents.Add();

            Word.Paragraph para = document.Content.Paragraphs.Add();
            para.Range.Text = "Отчет";

            Word.Table table = document.Tables.Add(para.Range, DGridUser.Items.Count + 1, DGridUser.Columns.Count);
            table.Borders.Enable = 1;

            for (int j = 0; j < DGridUser.Columns.Count; j++)
            {
                table.Cell(1, j + 1).Range.Text = DGridUser.Columns[j].Header.ToString();
            }

            for (int i = 0; i < DGridUser.Items.Count; i++)
            {
                for (int j = 0; j < DGridUser.Columns.Count; j++)
                {
                    TextBlock b = DGridUser.Columns[j].GetCellContent(DGridUser.Items[i]) as TextBlock;
                    table.Cell(i + 2, j + 1).Range.Text = b.Text;
                }
            }

            // Запрос у пользователя пути и названия файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                document.SaveAs2(filePath); // Сохранение файла по указанному пути
                document.Close(); // Закрытие документа
                word.Quit(); // Закрытие приложения Word
            }
        }


        private void Button_ExportExcel_2(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = false; // Установка свойства Visible в false
            Workbook workbook = excel.Workbooks.Add();
            Worksheet worksheet = workbook.ActiveSheet;
            if (sals != null)
            {
                for (int j = 0; j < DGridUser.Columns.Count; j++)
                {
                    worksheet.Cells[2, j + 1] = DGridUser.Columns[j].Header.ToString();
                }

                for (int i = 0; i < DGridUser.Items.Count; i++)
                {
                    for (int j = 0; j < DGridUser.Columns.Count; j++)
                    {
                        TextBlock b = DGridUser.Columns[j].GetCellContent(DGridUser.Items[i]) as TextBlock;
                        worksheet.Cells[i + 2, j + 1] = b.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("datagridkolvo не инициализирован или равен null.");
                worksheet.Cells[1, 1] = "Отчет";
            }

            // Запрос у пользователя пути и названия файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath); // Сохранение файла по указанному пути
                workbook.Close(); // Закрытие книги Excel
                excel.Quit(); // Закрытие приложения Excel
            }

        }

  
    }
}


