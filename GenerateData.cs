using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class GenerateData
    {
        public string Date { get; private set; }
        public string LatinSymbols { get; private set; }
        public string RussianSymbols { get; private set; }
        public int RandomIntNumber { get; private set; }
        public double RandomDoubleNumber { get; private set; }

        public GenerateData(Random rnd) 
        {
            Date = GenerateRandomDateLastFiveYear(rnd);
            LatinSymbols = GenerateRandomTenLatianSymbols(rnd, 10);
            RussianSymbols = GenerateRandomTenRussianSymbols(rnd, 10);
            RandomIntNumber = GenerateRandomIntNumberWithinRange(rnd, 1, 100000000);
            RandomDoubleNumber = GenerateRandomDoubleNumberWithinRange(rnd, 1, 20);
        }

        private string GenerateRandomDateLastFiveYear(Random random)
        {
            DateTime currentDate = DateTime.Now;
            int randomDays = random.Next(0, 365 * 5);
            DateTime randomDate = currentDate.AddDays(-randomDays);
            return randomDate.ToString("dd.MM.yyyy");
        }

        private string GenerateRandomTenLatianSymbols(Random random, int length)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string((Enumerable.Repeat(alphabet, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()));
        }

        private string GenerateRandomTenRussianSymbols(Random random, int length)
        {
            const string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            return new string((Enumerable.Repeat(alphabet, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()));
        }

        private int GenerateRandomIntNumberWithinRange(Random random, int min, int max)
        {
            int number = random.Next(min, max);
            if (number % 2 == 0)
                return number;
            else
                return number;
        }

        private double GenerateRandomDoubleNumberWithinRange(Random random, int min, int max)
        {
            return min + (max - min) * random.NextDouble();
        }
    }
}
