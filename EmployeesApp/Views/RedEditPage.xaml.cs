using EmployeesApp.Models;
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
using System.IO;


namespace EmployeesApp.Views
{
    /// <summary>
    /// Логика взаимодействия для RedEditPage.xaml
    /// </summary>
    public partial class RedEditPage : Page
    {
        Core db;
        Worker_information infoGroup;

        public RedEditPage()
        {
            InitializeComponent();
            db = new Core();
            Console.WriteLine(Properties.Settings.Default.userSelected);
            Worker_information arr= db.context.Worker_information.Where(x => x.id_worker_information == Properties.Settings.Default.userSelected).First();
            this.DataContext = arr;
            Console.WriteLine(arr.education);
            //Форматирование списка профессий
            List<string> professionTitle = new List<string>();
            string folderPath = Directory.GetCurrentDirectory();
            folderPath = folderPath.Replace("\\bin\\Debug", "\\Resources\\");
            using (StreamReader reader = new StreamReader(folderPath + "Prof.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //данные в третьем столбце
                    string valueInTwoColumn = line.Split(';')[2];
                    professionTitle.Add(valueInTwoColumn);

                }
                //вывод списка профессий в открывающийся список
                ProfessionComboBox.ItemsSource = professionTitle;
                //ProfessionComboBox.ItemsSource = db.context.Worker_information.ToList();
                //ProfessionComboBox.DisplayMemberPath = "post";
                //ProfessionComboBox.SelectedValuePath = "id_worker";
            }


        }
            public void AddButton_Click(object sender, RoutedEventArgs e)
            {
                try
                {


                    
                    db.context.SaveChanges();

                    MessageBox.Show("Информация сохранена",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                }
                catch
                {
                    MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        
    } 
}
    

