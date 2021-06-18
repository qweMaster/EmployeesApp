using EmployeesApp.Models;
using EmployeesApp.Views;
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

namespace EmployeesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core db =  new Core() ;
        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.userLoginString = "";
            Properties.Settings.Default.Save();
            AddingButton.Visibility = Visibility.Collapsed;
           
            
            PastButton.Visibility = Visibility.Collapsed;
         
            AllEmployee.Visibility = Visibility.Collapsed;
            if (Properties.Settings.Default.userLoginString!="")
            {
                var result = db.context.Users.Where(x => x.login == Properties.Settings.Default.userLoginString).First();
                Console.WriteLine("Роль: " + result.role);
                switch (result.role)
                {
                    case 1:
                        AddingButton.Visibility = Visibility.Collapsed;
                     
                        
                        PastButton.Visibility = Visibility.Collapsed;
                 
                        AllEmployee.Visibility = Visibility.Collapsed;
                        PastButton.Visibility = Visibility.Collapsed;

                        break;
                    case 2:
                        AddingButton.Visibility = Visibility.Visible;
                        
                        
                        PastButton.Visibility = Visibility.Visible;
                       
                        AllEmployee.Visibility = Visibility.Visible;
                        EnterButton.Visibility = Visibility.Visible;
                        break;

                }
            }
           

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            
            
            
            
        }
        // Переходы на новые страницы по клику на кнопки
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddingEmployeePage());
        }

        /// <summary>
        /// скрытие кнопок управление если пользователь заходит под аккаунтом обычного сотрудника
        /// если под аккаунтом администратора то все кнопки видны 
        /// ....
        /// метод используется для того что бы программа не запоминала пользователя после её закрытия 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.userLoginString != "")
            {
                var result = db.context.Users.Where(x => x.login == Properties.Settings.Default.userLoginString).First();
                Console.WriteLine("Роль: " + result.role);
                switch (result.role)
                {
                    case 1:
                        AddingButton.Visibility = Visibility.Collapsed;
                       
                        
                        PastButton.Visibility = Visibility.Collapsed;
                      
                        AllEmployee.Visibility = Visibility.Collapsed;
                        break;
                    case 2:
                        AddingButton.Visibility = Visibility.Visible;
                    
                        
                        PastButton.Visibility = Visibility.Visible;
                        
                        AllEmployee.Visibility = Visibility.Visible;
                        EnterButton.Visibility = Visibility.Visible;
                        break;

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        

       

        private void PastButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PastEmployeePage());
        }

        private void AllEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllEmployeePage());
        }

      

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Enter());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.userLoginString = "";
            Properties.Settings.Default.Save();
        }
    }
}
