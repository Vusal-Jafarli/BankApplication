using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapplication
{
    public class BankCard
    {

        public BankCard()
        {
            bankName = "";
            fullName = "";
            pan = "";
            pin = "";
            cvv = "";
            balance = 0;
            expiredDate = DateTime.MinValue;
            Emeliyyatlar = "";
        }
        public BankCard(string bankName, string fullname, string pan, string pin, string cvv, float balance, DateTime date)
        {
            BankName = bankName;
            FullName = fullname;
            Pan = pan;
            Pin = pin;
            Cvv = cvv;
            Balance = balance;
            ExpiredDate = date;
            Emeliyyatlar = "";
        }


        private string bankName;
        public string BankName
        {
            get { return bankName; }
            set
            {
                if (value.Length > 0)
                    bankName = value;
                else
                    throw new ArgumentException("Bank Name is wrong.");
            }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (value.Length > 0)
                    fullName = value;
                else
                    throw new ArgumentException("Full Name is wrong.");
            }
        }

        private string pan;
        public string Pan
        {
            get { return pan; }
            set
            {
                if (value.Length > 15)
                    pan = value;
                else
                    throw new ArgumentException($"{FullName} - PAN is wrong.");
            }
        }

        private string? pin;
        public string? Pin
        {
            get { return pin; }
            set
            {
                if (value.Length == 4)
                    pin = value;
                else
                    throw new ArgumentException("Wrong PIN size");
            }
        }

        private string cvv;
        public string Cvv
        {
            get { return cvv; }
            set
            {
                if (value.Length == 3)
                    cvv = value;
                else
                    throw new ArgumentException("Wrong CVV size");
            }

        }

        private DateTime expiredDate;
        public DateTime ExpiredDate
        {
            get { return expiredDate; }
            set { expiredDate = value; }
        }

        private float balance;
        public float Balance
        {
            get { return balance; }
            set
            {
                if (balance >= 0)
                    balance = value;
                else
                    throw new ArgumentException("Balance is wrong.");
            }
        }

        private string emeliyyatlar;

        public string Emeliyyatlar
        {
            get { return emeliyyatlar; }
            set
            {

                emeliyyatlar = value;

            }
        }

        public override string ToString()
        {
            string card = bankName + "\n" + fullName + "\n" + Pan + "\n" + Pin + "\n" + Cvv + "\n"
                + Balance.ToString() + "\n" + ExpiredDate.ToString();
            return card;
        }
    }
}

