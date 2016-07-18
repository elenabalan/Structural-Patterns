using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyDatabaseWork proxyDatabaseWork = new ProxyDatabaseWork();

            proxyDatabaseWork.Insert(new Person());
            proxyDatabaseWork.Delete(452);
            proxyDatabaseWork.SelectNameContains("*aras*");

            Console.ReadKey();
        }
    }

    class Person
    {
        string name;
        string surname;
        DateTime birthday;
    }

    interface IDatabaseQuery
    {
        void Insert(Person person);
        void Delete(int idPerson);
        List<Person> SelectNameContains(string str);
        List<Person> SelectSurnameContains(string str);
        List<Person> SelectAgeIsGreaterThan(int years);
    }

    class DatabaseWork : IDatabaseQuery
    {
        // Acest RealSubject are grija sa deschide si sa inchide conexiunea la BD
        public void Insert(Person person)
        {
            Console.WriteLine("INSERT unui rind");
        }

        public void Delete(int idPerson)
        {
            Console.WriteLine("DELETE unui rind");
        }

        public List<Person> SelectNameContains(string str)
        {
            Console.WriteLine("SELECT dupa parametrii specificati pentru Name");
            return null;
        }

        public List<Person> SelectSurnameContains(string str)
        {
            Console.WriteLine("SELECT dupa parametrii specificati pentru Surname");
            return null;
        }

        public List<Person> SelectAgeIsGreaterThan(int years)
        {
            Console.WriteLine("SELECT dupa parametrii specificati pentru Virsta");
            return null;
        }
    }

    class ProxyDatabaseWork : IDatabaseQuery
    {
        private DatabaseWork _bdQuery = new DatabaseWork();
        public void Insert(Person person)
        {
            _bdQuery.Insert(person);
        }

        public void Delete(int idPerson)
        {
            _bdQuery.Delete(idPerson);
        }

        public List<Person> SelectNameContains(string str)
        {
            return _bdQuery.SelectNameContains(str);
        }

        public List<Person> SelectSurnameContains(string str)
        {
            return _bdQuery.SelectSurnameContains(str);
        }

        public List<Person> SelectAgeIsGreaterThan(int years)
        {
            return _bdQuery.SelectAgeIsGreaterThan(years);
        }
    }
}
