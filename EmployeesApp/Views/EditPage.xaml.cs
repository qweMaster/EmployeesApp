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
using EmployeesApp.Views;


namespace EmployeesApp.Views

{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        Worker_information infoGroup;
        Core db;
        private Button sender ;

        public EditPage()

        {
            InitializeComponent();
            db = new Core();

           
          
            
            Console.WriteLine(Properties.Settings.Default.userSelected);
            PostWorkerListView.ItemsSource = db.context.DataAccept.Where(x => x.id_worker== Properties.Settings.Default.userSelected).ToList();
            

        }

        private void MainInfoButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RedEditPage());
        }

        

       

        private void PostWorkerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            

            


            DataAccept objectEmployee1 = new DataAccept()
            {
                post = PostTextBox.Text,
                date_accept = SyearsTextBox.Text,
                date_dis = PoyearsTextBox.Text,
                id_worker= Properties.Settings.Default.userSelected
            };

            db.context.DataAccept.Add(objectEmployee1);
            db.context.SaveChanges();

            MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            PostWorkerListView.ItemsSource = db.context.DataAccept.Where(x => x.id_worker == Properties.Settings.Default.userSelected).ToList();


           
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {



            if (PostWorkerListView.SelectedItem != null)
            {
                DataAccept item = PostWorkerListView.SelectedItem as DataAccept;
                Console.WriteLine(item.date_dis);
                var resultMessageBox = MessageBox.Show("Вы уверены что хотите удалить?", "Удалить", MessageBoxButton.YesNo);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    db.context.DataAccept.Remove(item);
                    db.context.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    PostWorkerListView.ItemsSource = db.context.DataAccept.Where(x => x.id_worker == Properties.Settings.Default.userSelected).ToList();
                }
            }
        }
          
                }
                
            }

        


        
    


