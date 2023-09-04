using ATMapplication;
using ATMapplication.Models;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

void print(string[] arr, int row, Client giris_edilen_client)
{
    Console.WriteLine(" ------------------------");
    Console.WriteLine("|                        |");
    Console.Write($"|      {giris_edilen_client.BankAccaunt.BankName}");
    for (int j = 0; j < 18 - ((giris_edilen_client.BankAccaunt.BankName).ToString().Length); j++) { Console.Write(" "); }
    Console.WriteLine("|");
    Console.WriteLine("|                        |");
    Console.WriteLine("|                        |");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write("|      ");
        if (i == row)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write(arr[i]);
        Console.ForegroundColor = ConsoleColor.White;
        for (int j = 0; j < 18 - (arr[i].Length); j++) { Console.Write(" "); }
        Console.WriteLine("|");
    }
    Console.WriteLine("|                        |");
    Console.WriteLine("|                        |");
    Console.WriteLine("|                        |");
    Console.WriteLine(" ------------------------");
}
string balance(BankCard card)
{
    return card.Balance.ToString();
}


#region Menyular

string[] giris_menu = new string[4];
giris_menu[0] = "Balans";
giris_menu[1] = "Nagd Pul";
giris_menu[2] = "Card to Card";
giris_menu[3] = "Cixis";


string[] nagd_pul = new string[5];
nagd_pul[0] = "10 Azn";
nagd_pul[1] = "20 Azn";
nagd_pul[2] = "50 Azn";
nagd_pul[3] = "100 Azn";
nagd_pul[4] = "Diger";

#endregion

#region Bank Kartlari
BankCard card1 = new BankCard("Kapital Bank", "Vusal Jafarli", "4169738881121658", "1107", "345", 1230, new DateTime(2025, 12, 5));
BankCard card2 = new BankCard("ATB Bank", "Huseyn Huseynov", "4098738881121632", "0011", "215", 100, new DateTime(2023, 12, 11));
BankCard card3 = new BankCard("Yapi Kredi Bank", "Hikmet Mirzeyev", "5057388811216582", "1974", "122", 10000, new DateTime(2026, 1, 15));
BankCard card4 = new BankCard("UniBank", "Cavid Jafarli", "4098812811216589", "1098", "990", 10, new DateTime(2024, 1, 1));
BankCard card5 = new BankCard("Kapital Bank", "Yusif Humbetli", "4169738875466567", "4648", "123", 2700, new DateTime(2024, 10, 8));
#endregion

#region Clients
Client client1 = new Client("Vusal", "Jafarli", 19, 1200, card1);
Client client2 = new Client("Huseyn", "Huseynov", 18, 1300, card2);
Client client3 = new Client("Hikmet", "Mirzeyev", 23, 890, card3);
Client client4 = new Client("Cavid", "Ceferli", 21, 1900, card4);
Client client5 = new Client("Yusif", "Humbetli", 19, 650, card5);
#endregion

#region Clients List
List<Client> clients = new List<Client>() {
new Client("Vusal", "Jafarli", 19, 1200, card1),
new Client("Huseyn", "Huseynov", 18, 1300, card2),
new Client("Hikmet", "Mirzeyev", 23, 890, card3),
new Client("Cavid", "Ceferli", 21, 1900, card4),
new Client("Yusif", "Humbetli", 19, 650, card5)
};
#endregion

esas_menyu:
Console.Clear();
string? pin;
Client? giris_eden_client = null;
Console.WriteLine("\n\t   --Giris--");
Console.Write("\n\tPIN daxil edin: "); pin = Console.ReadLine();
Console.Clear();
Console.WriteLine(pin);

foreach (var item in clients)
{
    if (item.BankAccaunt.Pin == pin)
    {
        giris_eden_client = item;
        break;
    }
}

if (giris_eden_client is null)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Bu PIN koda aid kart tapilmadi");
    Console.ForegroundColor = ConsoleColor.White;

}
else
{
    Console.Clear();

    Console.WriteLine($"\n\t{giris_eden_client.Name} {giris_eden_client.Surname}");
    Thread.Sleep(1000);
    int row_giris = 0;
    dynamic temp;
    while (true)
    {
    Start:
        Console.Clear();
        print(giris_menu, row_giris, giris_eden_client);
        temp = Console.ReadKey(true);

        if (temp.Key == ConsoleKey.UpArrow)
        {
            if (row_giris == 0)
                row_giris = 3;
            else
                row_giris -= 1;
        }
        else if (temp.Key == ConsoleKey.DownArrow)
        {
            if (row_giris == 3)
                row_giris = 0;
            else
                row_giris += 1;
        }
        else if (temp.Key == ConsoleKey.Enter)
        {
            if (row_giris == 0)//Balance
            {
                Console.Clear();
                Console.WriteLine(" ------------------------");
                Console.WriteLine("|                        |");
                Console.Write($"|      {giris_eden_client.BankAccaunt.BankName}");
                for (int j = 0; j < 18 - ((giris_eden_client.BankAccaunt.BankName).ToString().Length); j++) { Console.Write(" "); }
                Console.WriteLine("|");
                Console.WriteLine("|                        |");
                Console.WriteLine("|                        |");
                Console.Write("|   ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" Balance: {balance(giris_eden_client.BankAccaunt)}AZN");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < 8 - (balance(giris_eden_client.BankAccaunt).ToString().Length); j++) { Console.Write(" "); }
                Console.WriteLine("|");
                Console.WriteLine("|                        |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|                        |");
                Console.WriteLine(" ------------------------");
                Console.ReadKey(true);
            }
            else if (row_giris == 1)//Nagd Pul
            {
                int row_nagd_pul = 0;
                while (true)
                {
                    Console.Clear();
                    print(nagd_pul, row_nagd_pul, giris_eden_client);
                    temp = Console.ReadKey(true);

                    if (temp.Key == ConsoleKey.UpArrow)
                    {
                        if (row_nagd_pul == 0)
                            row_nagd_pul = 4;
                        else
                            row_nagd_pul -= 1;
                    }
                    else if (temp.Key == ConsoleKey.DownArrow)
                    {
                        if (row_nagd_pul == 4)
                            row_nagd_pul = 0;
                        else
                            row_nagd_pul += 1;
                    }
                    else if (temp.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        if (row_nagd_pul == 4)
                        {
                            string daxil_edilen_mebleg = "";
                            Console.Write("Meblegi daxil edin: "); daxil_edilen_mebleg = Console.ReadLine();
                            if (Convert.ToSingle(daxil_edilen_mebleg) > giris_eden_client.BankAccaunt.Balance)
                            {

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Balansda kifayet qeder mebleg yoxdur.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("     \nPulu götürün.");
                                Thread.Sleep(500); Console.Write(".");
                                Thread.Sleep(500); Console.Write(".");
                                Thread.Sleep(500); Console.Write(".");
                                Thread.Sleep(500); Console.Write(".");
                                Thread.Sleep(500); Console.Write(".");
                                giris_eden_client.BankAccaunt.Balance -= Convert.ToSingle(daxil_edilen_mebleg);
                                string emeliyyat = DateTime.Now.ToString() + "  " + "Nagd pul  " + daxil_edilen_mebleg.ToString() + "Azn" + "\n";
                                giris_eden_client.BankAccaunt.Emeliyyatlar += emeliyyat;
                                goto Start;
                            }
                        }
                        int? cixaris_mebleg = null;
                        Console.Write("     \nPulu götürün.");
                        Thread.Sleep(500); Console.Write(".");
                        Thread.Sleep(500); Console.Write(".");
                        Thread.Sleep(500); Console.Write(".");
                        Thread.Sleep(500); Console.Write(".");
                        Thread.Sleep(500); Console.Write(".");
                        if (row_nagd_pul == 0)
                        {
                            if (giris_eden_client.BankAccaunt.Balance >= 10)
                            {
                                giris_eden_client.BankAccaunt.Balance -= 10;
                                cixaris_mebleg = 10;
                            }
                        }
                        else if (row_nagd_pul == 1)
                        {
                            if (giris_eden_client.BankAccaunt.Balance >= 20)
                            {
                                giris_eden_client.BankAccaunt.Balance -= 20;
                                cixaris_mebleg = 20;
                            }
                        }
                        else if (row_nagd_pul == 2)
                        {
                            if (giris_eden_client.BankAccaunt.Balance >= 50)
                            {
                                giris_eden_client.BankAccaunt.Balance -= 50;
                                cixaris_mebleg = 50;
                            }
                        }
                        else if (row_nagd_pul == 3)
                        {
                            if (giris_eden_client.BankAccaunt.Balance >= 100)
                            {
                                giris_eden_client.BankAccaunt.Balance -= 100;
                                cixaris_mebleg = 100;
                            }
                        }
                        string emeliyyat1 = DateTime.Now.ToString() + "  " + "Nagd pul  " + cixaris_mebleg.ToString() + "Azn" + "\n";
                        giris_eden_client.BankAccaunt.Emeliyyatlar += emeliyyat1;
                        goto Start;
                    }
                }
            }
            else if (row_giris == 2)//Card to Card
            {
                Client? kocurme_edilen_client = null;
                string? kocurme_pin = null;
                Console.Clear();
                Console.Write("Kocurme edilen kartin PIN kodunu daxil edin: "); kocurme_pin = Console.ReadLine();

                foreach (var item in clients)
                {
                    if (item.BankAccaunt.Pin == kocurme_pin && kocurme_pin != giris_eden_client.BankAccaunt.Pin)
                    {
                        kocurme_edilen_client = item;
                        break;
                    }
                }
                Console.Clear();
                if (kocurme_edilen_client is null)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tBu PIN koda aid kart tapilmadi");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    goto esas_menyu;
                }
                float? gonderilen_mebleg;
                Console.Write("Meblegi daxil edin: "); gonderilen_mebleg = Convert.ToSingle(Console.ReadLine()); Console.Clear();

                if (gonderilen_mebleg > giris_eden_client.BankAccaunt.Balance)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Balansda kifayet qeder mebleg yoxdur.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    break;
                }
                else
                {

                    Console.WriteLine(" ------------------------");
                    Console.WriteLine("           ODENIS        \n");
                    Console.WriteLine($"Mexaric: {giris_eden_client.Name} {giris_eden_client.Surname}");
                    Console.Write($"Medaxil: {kocurme_edilen_client.Name[0]}{kocurme_edilen_client.Name[1]}*** ");
                    Console.WriteLine($"  {kocurme_edilen_client.Surname[0]}{kocurme_edilen_client.Surname[1]}**** ");
                    Console.WriteLine($"Mebleg: {gonderilen_mebleg} AZN ");
                    Console.WriteLine($"Tarix: {DateTime.Now}");
                    Console.WriteLine(" ------------------------");
                    string emeliyyat = DateTime.Now.ToString() + "  " + "Card to Card  " + kocurme_edilen_client.BankAccaunt.Pan.ToString() + "   " + gonderilen_mebleg.ToString() + "AZN  " + "\n";
                    giris_eden_client.BankAccaunt.Emeliyyatlar += emeliyyat;
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            else if (row_giris == 3) { break; }
        }
    }
    Console.Clear();
    Console.WriteLine("\n\tEmeliyyatlar");
    Console.WriteLine(giris_eden_client.BankAccaunt.Emeliyyatlar);
}

