using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StringCheckLibrary;
using EmployeeLibraryTests;

namespace StringCheckLibrary
{
    class StringCheck
    {
        /// <summary>
        /// Имя , фамилия отчество  не могут быть длинее  50 символов , только буквы пробел и дефис
        /// </summary>
        /// <param name="stringName"></param>
        /// <returns> true/false </returns>
        public bool CheckName(string stringName)
        {
            string regex = @"^(([а-я])|(\s)|(\-))+$";
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
}
