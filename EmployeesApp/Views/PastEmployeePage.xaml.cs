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
using EmployeesApp.Models;


namespace EmployeesApp.Views
{
    /// <summary>
    /// Логика взаимодействия для PastEmployeePage.xaml
    /// </summary>
    public partial class PastEmployeePage : Page
    {
        Core db;
        public PastEmployeePage()
            
        {
            InitializeComponent();
            db = new Core();

            PastEmployeeListView.ItemsSource = db.context.PastEmployee.ToList();

        }

       

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = (Button)sender;
            PastEmployee item = selectedButton.DataContext as PastEmployee;
            // Worker_information item = EmployeeListView.SelectedItem as Worker_information;

            //проверка того, что пользователь выбрал строки для удаления
            Console.WriteLine(item.id_past_employee);


            //выполним удаление только в том случае, если пользователь даст согласие на удаление

            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                db.context.PastEmployee.Remove(item);
                db.context.SaveChanges();
              


                MessageBox.Show("Информация удалена");

                //обновление DataGrid

                PastEmployeeListView.ItemsSource = db.context.PastEmployee.ToList();

            }
        }
    }
}
