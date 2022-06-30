using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutoin.Infrastructure
{
    public static class ExtensionsForGuardClauses
    {
        public static string IsFoundOrNot(this IGuardClause guardClause, string input, string parameterName)
        {
            if (input?.ToLower() == "foo")
                throw new ArgumentException("Should not have been foo!", parameterName);
            return input;
        }

        //Usage of the extension Method
        //public void SomeMethod(string something)
        //{
        //    Guard.Against.IsFoundOrNot(something, nameof(something));
        //}

        //public static bool IsFoundOrNot(this Guard guard,string text)
        //{ 
        //    if (text.Length == 0) return false; // should throw exception
        //    if (string.IsNullOrEmpty(text))return false;
        //    return true;
        //}
    }
}
