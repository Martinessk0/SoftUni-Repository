using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        private static List<Person> familyList = new List<Person>();

        public void AddMember(string name,int age)
        {
            Person person = new Person(name, age);
            familyList.Add(person);
        }

        public Person GetOldestMember()
        {
            return familyList.OrderByDescending(ag => ag.Age).First();
        }
    }
}
