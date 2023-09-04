using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapplication.Models
{
    public class Bank
    {
		private Client[] clients;	

		public Client[] Clients
		{
			get { return clients; }
			set { clients = value; }
		}

		public void show_card_balance(BankCard card)
		{
			Console.WriteLine(card.Balance.ToString());	
		}


        public Bank()
        {
			clients = new Client[0];  
        }

		public Bank(Client[] client) 
		{
			clients = client;
		}
    }
}
