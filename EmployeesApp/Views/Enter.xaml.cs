using EmployeesApp.Controller;
using EmployeesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Page
    {
          Core db = new Core();
        public Enter()

        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            string password = PasswordTextBox.Password.Trim();
            string login = LoginTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            if ((email.Contains("@") && email.Contains(".")))
            {

             

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("otdelkadrovarm@gmail.com", "ZXCMASTER");
                // кому отправляем
                MailAddress to = new MailAddress(email);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Вы вошли в АРМ отдел кадров";
                // текст письма
                //TODO написать норм разметку для письма
                m.Body = "<h4>Здравствуйте, " + login + "</h4>";
                           // + "<p><font-size: 18px>Логин: " + login + "</p>" + "<p><font-size = 18>Пароль: " + password + "</p>"
                            //+ "<p><font-size: 18px>Если вы не делали запрос на отправку данных, ответье на это письмо: " + "<span><font-size:22px; color: red>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("otdelkadrovarm@gmail.com", "otdelkadrov");
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(m);
                }
                catch
                {

                }
            }
            try
            {
                UsersController objUser = new UsersController();
                bool resultEnt = objUser.Entrance(LoginTextBox.Text, PasswordTextBox.Password);
                if (resultEnt == false)

                {
                    MessageBoxResult result = MessageBox.Show("Неверный данные администратора");
                    if (result == MessageBoxResult.Yes)
                    {

                       
                    }
                }
                else
                {
                   
                    Properties.Settings.Default.userLoginString = LoginTextBox.Text;
                    Properties.Settings.Default.Save();
                    var result = db.context.Users.Where(x => x.login == Properties.Settings.Default.userLoginString).First();
                    Console.WriteLine("Роль: " + result.role);
                   

                    this.NavigationService.Navigate(new AllEmployeePage());

                    
                }
            }
            catch
            {
                MessageBox.Show("неверный логин или пароль");
                return;
            }
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
