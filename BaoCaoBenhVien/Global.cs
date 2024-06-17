




using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;



using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace MyFs
{

    static class Global
    {


        public static int Random_Index(int length_of_array)
        {
            Random rd = new Random();
            return rd.Next(0, length_of_array - 1);
        }
        public static string RandomStringNumber(int length)
        {
            int max = 1;
            int min = 0;
            for (int i = 0; i < length; i++)
            {
                max *= 10;

            }
            min = max / 10;



            return new Random().Next(min, max).ToString();
        }

       
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
      








    }
}
