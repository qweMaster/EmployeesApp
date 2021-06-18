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
using EmployeesApp;
using EmployeesApp.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace EmployeesApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AllEmployeePage.xaml
    /// </summary>
    public partial class AllEmployeePage : Page
    {
        Core db;
        public AllEmployeePage()
        {

            InitializeComponent();
            db = new Core();
           
            EmployeeListView.ItemsSource = db.context.Worker_information.ToList();






        }

        private void ForButton_Click(object sender, RoutedEventArgs e)
        {
      
            //по копке считываем какого сотрудника выбрали

            Button selectedButton=(Button)sender;
            Worker_information item= selectedButton.DataContext as Worker_information;
            //List<Worker_information> arrUsers =db.context.Worker_information.ToList();

            /*создаем файл Excel*/

            var aplication = new Excel.Application();

            aplication.Visible = true;

            /*количество листов*/

            aplication.SheetsInNewWorkbook = 1;

            /*добавляем рабочую книгу*/

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            /*создаем лист*/

            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.Name = "ИмяЛиста"; //имя листа нужно вводить латинскими буквами
            
            /*заголовки вывод в Excel (в первую строку)*/

            worksheet.Cells[1][1] = "ЛИЧНАЯ КАРТОЧКА";

            worksheet.Cells[1][2] = "государственного (муниципального) служащего";
            worksheet.Cells[1][4] = "I. ОБЩИЕ СВЕДЕНИЯ";
            worksheet.Cells[6][6] = "Трудовой договор";
            worksheet.Cells[8][6] = "Номер";
            worksheet.Cells[8][7] = "Дата";
            worksheet.Cells[1][8] = "1.Фамилия";
            worksheet.Cells[10][8] = "Имя";
            worksheet.Cells[15][8] = "Отчество";
            worksheet.Cells[1][12] = "2.Дата рождения";
            worksheet.Cells[1][15] = "3.Место рождения";
            worksheet.Cells[19][10] = "Код";
            worksheet.Cells[18][10] = "по ОКАТО";
            worksheet.Cells[18][11] = "по ОКИН";
            worksheet.Cells[18][12] = "по ОКИН";
            worksheet.Cells[18][13] = "по ОКИН";
            worksheet.Cells[18][14] = "по ОКИН";
            worksheet.Cells[1][17] = "4.Гражданство";
            worksheet.Cells[1][18] = "5.Знание иностранного языка";
            worksheet.Cells[1][24] = "6.Образование";
            worksheet.Cells[1][26] = "Наименование образовательного учреждения";
            worksheet.Cells[6][26] = "Документ об образовании, о квалификации";
            worksheet.Cells[6][27] = "или наличии специальных знаний";
            worksheet.Cells[6][28] = "Наименование";
            worksheet.Cells[7][28] = "Серия";
            worksheet.Cells[8][28] = "Номер";
            worksheet.Cells[10][26] = "Год";
            worksheet.Cells[10][27] = "Окончания";
            worksheet.Cells[1][30] = "Квалификация по документу об образовании";
            worksheet.Cells[6][30] = "Направление или специальность по документу";
            worksheet.Cells[10][30] = "Код по ОКСО";



            worksheet.Cells[1][35] = "Наименование образовательного учреждения";
            worksheet.Cells[6][35] = "Документ об образовании, о квалификации";
            worksheet.Cells[6][36] = "или наличии специальных знаний";
            worksheet.Cells[6][38] = "Наименование";
            worksheet.Cells[7][38] = "Серия";
            worksheet.Cells[8][38] = "Номер";
            worksheet.Cells[10][36] = "Год";
            worksheet.Cells[10][37] = "Окончания";
            worksheet.Cells[1][40] = "Квалификация по документу об образовании";
            worksheet.Cells[6][40] = "Направление или специальность по документу";
            worksheet.Cells[10][40] = "Код по ОКСО";
            worksheet.Cells[10][43] = "Код по ОКИН";
            worksheet.Cells[1][43] = "Послевузовское профессиональное образование";




            worksheet.Cells[1][58] = "Наименование образовательного,";
            worksheet.Cells[1][59] = "научного учреждения";
            worksheet.Cells[6][58] = "Документ об образовании,";
            worksheet.Cells[6][59] = "номер, дата выдачи";
            worksheet.Cells[8][58] = "Год";
            worksheet.Cells[8][59] = "Окончания";
            worksheet.Cells[6][62] = "Направление или специальность по документу";
            worksheet.Cells[1][65] = "7.Ученая степень";
            worksheet.Cells[8][65] = "Код по ОКСО";
            worksheet.Cells[8][66] = "Код по ОКИН";








            worksheet.Cells[5][8] = item.surname;
            worksheet.Cells[13][8] = item.name;
            worksheet.Cells[17][8] = item.patronymic;












            /*вывод данных из массива в Excel*/

            int rowIndex = 2;  //номер строки для вывода данных из массива

          
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            try {

                Button selectedButton = (Button)sender;
                Worker_information item = selectedButton.DataContext as Worker_information;
                // Worker_information item = EmployeeListView.SelectedItem as Worker_information;

                //проверка того, что пользователь выбрал строки для удаления
                Console.WriteLine(item.id_worker_information);


                //выполним удаление только в том случае, если пользователь даст согласие на удаление

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    //удаляем выбранную строку
                    PastEmployee objectEmployee = new PastEmployee()

                    {
                        name = item.name,
                        surname = item.surname,
                        patronymic = item.patronymic,
                        education = item.education,
                        address = item.address,
                        post = item.post,
                    };


                    db.context.PastEmployee.Add(objectEmployee);
                    db.context.SaveChanges();
                    db.context.Worker_information.Remove(item);



                    db.context.SaveChanges();

                    MessageBox.Show("Информация удалена");

                    //обновление DataGrid

                    EmployeeListView.ItemsSource = db.context.Worker_information.ToList();
                }
            } catch
            {
                MessageBox.Show(" Очистите трудовую книжку работника :", " Критический сбор в работе приложения ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            { 

                }












        }
            

        
            

        private void For3Button_Click(object sender, RoutedEventArgs e)
        {

            //по копке считываем какого сотрудника выбрали

            Button selectedButton = (Button)sender;
            Worker_information item = selectedButton.DataContext as Worker_information;
            //List<Worker_information> arrUsers =db.context.Worker_information.ToList();

            /*создаем файл Excel*/

            var aplication = new Excel.Application();

            aplication.Visible = true;

            /*количество листов*/

            aplication.SheetsInNewWorkbook = 1;

            /*добавляем рабочую книгу*/

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            /*создаем лист*/

            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.Name = "ИмяЛиста"; //имя листа нужно вводить латинскими буквами

            /*заголовки вывод в Excel (в первую строку)*/
            worksheet.Cells[5][1] = "ШТАТНОЕ РАСПИСАНИЕ";
            worksheet.Cells[9][1] = "Номер документа";
            worksheet.Cells[11][1] = "Дата составления";
            worksheet.Cells[4][4] = "На период";
            worksheet.Cells[1][6] = "Структурное подразделение";
            worksheet.Cells[1][7] = "Наименование";
            worksheet.Cells[3][7] = "Код";
            worksheet.Cells[5][6] = "Должность (специальность, профессия), разряд, класс (категория) квалификации";
            worksheet.Cells[14][6] = "Количество штатных единиц";
            worksheet.Cells[18][6] = "Тарифная ставка (оклад) и пр., руб.";
            worksheet.Cells[22][6] = "Надбавки, руб.";
            worksheet.Cells[24][6] = "Всего в месяц, руб.";
            worksheet.Cells[26][6] = "Примечание";
            worksheet.Cells[14][14] = "Итого";
            worksheet.Cells[1][18] = "Руководитель кадровой службы";
            worksheet.Cells[6][18] = "Должность";
            worksheet.Cells[10][18] = "Личная подпись";
            worksheet.Cells[14][18] = "Расшифровка подписи";

            worksheet.Cells[1][22] = "Главный бухгалтер";
           
            worksheet.Cells[6][22] = "Личная подпись";
            worksheet.Cells[10][22] = "Расшифровка подписи";

           



        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = (Button)sender;
            Worker_information item = selectedButton.DataContext as Worker_information;
            Properties.Settings.Default.userSelected = item.id_worker_information;
            Properties.Settings.Default.Save();
            this.NavigationService.Navigate(new EditPage());


        }
    }

}
