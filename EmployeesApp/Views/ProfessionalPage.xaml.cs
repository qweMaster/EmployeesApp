using EmployeesLibrary;
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



namespace EmployeesApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ProfessionalPage.xaml
    /// </summary>
    public partial class ProfessionalPage : Page
    {
        public ProfessionalPage()
        {
            InitializeComponent();
        }

        private void EnterCODEButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Создание обьекта класса CheckINN
                CheckCode objectCode = new CheckCode();
                if (objectCode.CorrectFillCODE(EnterCODETextBox.Text) == true)
                {
                    //Вывод информации о регионе
                    MessegeTextBlock.Text = "окей";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
