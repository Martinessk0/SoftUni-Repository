using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsableWWW
    {
        
        public string Calling(string phoneNumber)
        {
            if (!phoneNumber.All(p => char.IsDigit(p))) 
            {
                throw new ArgumentException(ExceptionMessages.InvalidPhoneNumbersException);
            }
            return phoneNumber.Length > 7 ? $"Calling... {phoneNumber}" : $"Dialing... {phoneNumber}";
        }

        public string Browse(string website)
        {
            if (website.Any(w => char.IsDigit(w)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlsException);
            }
            return $"Browsing: {website}!";
        }
    }
}
