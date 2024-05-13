using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SDIManagementSystem.Business
{
    public static class Validator
    {
        public static bool ValidateNumber(string valueToCheck)
        {
            return Regex.IsMatch(valueToCheck, "^[0-9]+$");
        }
    }
}
