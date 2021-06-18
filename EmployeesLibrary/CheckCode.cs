using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EmployeesLibrary
{
    public class CheckCode
    {
        /// <summary>
        /// проверяет на правильность заполнения кода
        /// </summary>
        /// <param name="code">
        /// строка кода сотрудника
        /// </param>
        /// <returns>
        /// выводит истину если код введен правильно
        /// выводит сообщение если код введен не верно
        /// </returns>
        public bool CorrectFillCODE(string code)


        {
            //проверка того, что все символы - цифры
            for (int i = 0; i < code.Length; i++)

            {

                if (!Char.IsDigit(code[i]))


                    throw new Exception("введены недопустимые символы");
            }
            //проверка на длину строки кода
            if (code.Length != 5)
            {
                throw new Exception("код состоит из 5 символов");
            }
            //проверка корректности первых 5 символов
            if (!CorrectCode(code))
            {
                throw new Exception("Неправильный код профессии");
            }
          

            return true;
        }

        //проверка на совпадение контрольных цифр
        public bool CorrectCode(string code)
        {
         
            //Определяем полный путь к проекту
            string folderPath = Directory.GetCurrentDirectory();
            folderPath = folderPath.Replace("\\bin\\Debug", "\\Resources\\");
            using (StreamReader reader = new StreamReader(folderPath + "Prof.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Данные в первом столбце
                    string valueInTwoColumn = line.Split(';')[0];
                    if (valueInTwoColumn == code)
                    {
                       
                        return true;
                    }
                }
            }
            return false;
          
        }
    }



    }


