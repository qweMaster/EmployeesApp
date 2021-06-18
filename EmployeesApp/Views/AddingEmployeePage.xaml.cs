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
using System.IO;
using System.Windows.Shapes;
using EmployeesApp.Models;
using StringCheckLibrary;

namespace EmployeesApp
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AddingEmployeePage : Page
    {
        Core db = new Core();
        List<string> professionTitle;
        public AddingEmployeePage()
        {
            InitializeComponent();
            ShowProfession();
        }
       void ShowProfession() {
            //Форматирование списка профессий
            professionTitle = new List<string>();
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



            }
           
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            

            try


            {
                Worker_information objectEmployee = new Worker_information()
                {
                   name  = NameTextBox.Text,
                    surname = SurnameTextBox.Text,
                    patronymic = PatronymicTextBox.Text,
                    education = EducationTextBox.Text,
                    address = AddressTextBox.Text,
                    post = ProfessionComboBox.Text,
                };

                db.context.Worker_information.Add(objectEmployee);
                db.context.SaveChanges();

                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

                

            }
            catch
            {

                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void ProfessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            StringCheck obj = new StringCheck();
            bool resultLastName = obj.CheckName(SurnameTextBox.Text);
            bool resultName = obj.CheckName(NameTextBox.Text);
            bool resultPatronomyc = obj.CheckName(PatronymicTextBox.Text);
            bool resultEducation = obj.CheckName(EducationTextBox.Text);
            bool resultAddress = obj.CheckName(AddressTextBox.Text);
            
            if (resultLastName == true && resultName == true && resultPatronomyc == true)
            {
                MessageBox.Show("Данные в порядке");
            }
            else
            {
                MessageBox.Show("Данные не корректны");
            }

        }
    }
}
