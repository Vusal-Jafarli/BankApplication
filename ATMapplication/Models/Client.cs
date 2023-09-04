using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapplication.Models
{
    public class Client
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 2 && value.Length < 50)
                    name = value;
                else
                    throw new ArgumentException("Wrong Client Name");
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Length > 2 && value.Length < 50)
                    surname = value;
                else
                    throw new ArgumentException("Wrong Client surname");
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18)
                    age = value;
                else
                    throw new ArgumentException("Wrong Client age");
            }
        }

        private float salary;
        public float Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    throw new ArgumentException("Wrong Client salary");
            }
        }

        private BankCard bankAccaunt;
        public BankCard BankAccaunt
        {
            get { return bankAccaunt; }
            set { bankAccaunt = value; }
        }

        public Client()
        {
            name = "";
            surname = "";
            age = 0;
            salary = 0;
            bankAccaunt = new BankCard();
        }
        public Client(string name,string surname,int age,float salary,BankCard bankaccaunt)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;    
            BankAccaunt = bankaccaunt;
        }


    }
}
