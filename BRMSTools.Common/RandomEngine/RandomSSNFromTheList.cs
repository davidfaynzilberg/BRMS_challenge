using System;
using System.Collections.Generic;
using System.Text;

namespace BRMSTools.Common.RandomEngine
{
    public static class RandomSSNFromTheList
    {
        public static string GetRandomSSN()
        {
            string[] arrayItems = new string[] { "123456789", "234567891", "345678912", "456789123", "567891234", "678912345", "789123456", "891234567", "912345678" };
            return arrayItems[new Random().Next(0, 9)];
        }
    }
}
