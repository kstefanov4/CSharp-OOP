using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrawseable
    {
        public Smartphone()
        {

        }
        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return number.Length > 7 ? $"Calling... {number}" : $"Dialing... {number}";
        }
        public string Brawse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        
    }
}
