using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringCheckLibrary
{
    public class StringCheck
    {
        /// <summary>
        /// проверка на русские буквы пробел и дефис , строка не должна превышать 50 символов
        /// </summary>
        /// <param name="stringName"></param>
        /// <returns>true/false</returns>
        public bool CheckName(string stringName)

        {
            if (stringName.Length > 50)
            {
                return false;
            }
            else
            {
                string regex = @"^(([а-я])|(\s)|(\-)|([ё]))+$";
                string regexWhiteSpace = @"^((\s)|(\-))+$";
                if (Regex.Match(stringName, regexWhiteSpace, RegexOptions.IgnoreCase).Success)
                {
                    return false;
                }
                else
                {
                    if (Regex.Match(stringName, regex, RegexOptions.IgnoreCase).Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        //public bool CheckEmail(string stringEmail)
        //{
        //    string regex = @"^(\w+\@[a-z_]+\.[a-z]{2,3})$";
        //    if(Regex.Match(stringEmail, regex,RegexOptions.IgnoreCase).Success)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
