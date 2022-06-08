using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class StringExtenstions
    {
        public static DateTime ToDate(this string date)
        {
            //Correct format should be 2020-04-30
            string[] values = date.Split("-");

            if (values.Length != 3)
                throw new Exception("Bad date format");

            int[] numberValues = new int[3];
            int index = 0;

            foreach (string v in values)
            {
                int parseResult;
                if (int.TryParse(v, out parseResult))
                {
                    numberValues[index] = parseResult;
                }
                else
                {
                    throw new Exception($"Cannot parse {v} to string.");
                }

                index++;
            }

            return new DateTime(numberValues[0], numberValues[1], numberValues[2]);
        }
    }
}
