using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Rake
{
   public static class RakeDatatable
    {
        public static DataTable dt = new DataTable();
        public static DataTable dtSummary = new DataTable();
        public static DataTable dtTax = new DataTable();
        public static DataTable dtGSTTax = new DataTable();
        public static DateTime submitDate = new DateTime();
        public static string type = string.Empty;
        public static string bill = string.Empty;
        public static string shipmentNo = string.Empty;
        public static string financialYear = string.Empty;
        public static string GcPath = string.Empty;


       public static string ConvertNumbertoWords(long number)
       {
           return ConvertNumbertoWordsremove(number) + " ONLY.";
       }

       private static string ConvertNumbertoWordsremove(long number)
       {
           //if (number == 0) return "ZERO"; if (number < 0) return "minus " + ConvertNumbertoWordsremove(Math.Abs(number)); string words = ""; if ((number / 1000000) > 0) { words += ConvertNumbertoWordsremove(number / 100000) + " LAKES "; number %= 1000000; }
           //if ((number / 1000) > 0) { words += ConvertNumbertoWordsremove(number / 1000) + " THOUSAND "; number %= 1000; }
           //if ((number / 100) > 0) { words += ConvertNumbertoWordsremove(number / 100) + " HUNDRED "; number %= 100; }      //if ((number / 10) > 0)      //{      // words += ConvertNumbertoWords(number / 10) + " RUPEES ";      // number %= 10;      //}
           //if (number > 0) { if (words != "") words += "AND "; var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" }; var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" }; if (number < 20) words += unitsMap[number]; else { words += tensMap[number / 10]; if ((number % 10) > 0) words += " " + unitsMap[number % 10]; } }
           //return words;

           if (number == 0) return "ZERO";
           if (number < 0) return "minus " + ConvertNumbertoWordsremove(Math.Abs(number));
           string words = "";
           if ((number / 10000000) > 0)
           {
               words += ConvertNumbertoWordsremove(number / 10000000) + " CRORE ";
               number %= 10000000;
           }
           if ((number / 100000) > 0)
           {
               words += ConvertNumbertoWordsremove(number / 100000) + " LAKH ";
               number %= 100000;
           }
           if ((number / 1000) > 0)
           {
               words += ConvertNumbertoWordsremove(number / 1000) + " THOUSAND ";
               number %= 1000;
           }
           if ((number / 100) > 0)
           {
               words += ConvertNumbertoWordsremove(number / 100) + " HUNDRED ";
               number %= 100;
           }
           //if ((number / 10) > 0)  
           //{  
           // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
           // number %= 10;  
           //}  
           if (number > 0)
           {
               if (words != "") words += "AND ";
               var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
               var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
               if (number < 20) words += unitsMap[number];
               else
               {
                   words += tensMap[number / 10];
                   if ((number % 10) > 0) words += " " + unitsMap[number % 10];
               }
           }
           return words;
       }
        
    }
}
