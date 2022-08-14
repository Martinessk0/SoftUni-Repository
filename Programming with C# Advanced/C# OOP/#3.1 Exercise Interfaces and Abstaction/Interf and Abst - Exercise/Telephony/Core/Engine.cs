using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Engine
    {
        private Smartphone smartphone;
        private List<string> phoneNumbers;
        private List<string> urls;

        public Engine()
        {
            smartphone = new Smartphone();
            phoneNumbers = new List<string>();
            urls = new List<string>();
        }

        public void Run()
        {
            phoneNumbers = Console.ReadLine().Split().ToList();
            urls = Console.ReadLine().Split().ToList();

            CallPhoneNumbers();
            BrowseUrls();
        }

        private void BrowseUrls()
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void CallPhoneNumbers()
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Calling(phoneNumber));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
