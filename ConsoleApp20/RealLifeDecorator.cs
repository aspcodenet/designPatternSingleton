using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    interface IEmailSender
    {
        void SendEmail(string from, string to, string subject, string message);
    }
    class GmailSender : IEmailSender
    {
        public void SendEmail(string from, string to, string subject, string message)
        {
            Console.WriteLine("Sending through gmail");
        }
    }

    class MailLogger : IEmailSender
    {
        private readonly IEmailSender nextInLine;

        public MailLogger(IEmailSender nextInLine)
        {
            this.nextInLine = nextInLine;
        }
        public void SendEmail(string from, string to, string subject, string message)
        {
            System.IO.File.AppendAllText("maillog.txt", $"{from} {to} {subject} {message}");
            nextInLine.SendEmail(from,to,subject,message);
        }
    }



    class MailBiller : IEmailSender
    {
        private readonly IEmailSender nextInLine;

        public MailBiller(IEmailSender nextInLine)
        {
            this.nextInLine = nextInLine;
        }
        public void SendEmail(string from, string to, string subject, string message)
        {
            decimal price = 12;
            if(DateTime.Now.Hour > 18)
                price = 5;
            // hhjksdkahjsda

            nextInLine.SendEmail(from, to, subject, message);
        }
    }



    //            System.IO.File.AppendAllText("maillog.txt", $"{from} {to} {subject} {message}");
    //            System.IO.File.AppendAllText("transactions.txt", $"{from} sent an email {pris}");



    interface IHockey
    {
        string GetBestPlayer();
    }

    class HockeyDBService : IHockey
    {
        public string GetBestPlayer()
        {
            System.Threading.Thread.Sleep(5000);
            return "Mats Sundin";
        }
    }


    class CachedHockeyDBService : IHockey
    {
        DateTime lastFetched;
        public CachedHockeyDBService(IHockey nextInLine)
        {
            this.nextInLine = nextInLine;
        }
        static string bestPlayer;
        private readonly IHockey nextInLine;

        public string GetBestPlayer()
        {
            //if(har det gått mer än 5 timmar)
            //bestPlayer = "";
            if (string.IsNullOrEmpty(bestPlayer))
            {
                lastFetched = DateTime.Now;
                bestPlayer = nextInLine.GetBestPlayer();
            }
            return bestPlayer;
        }
    }

    interface ITaxCalculationStrategy
    {
        decimal Tax(int Salary);
    }

    class SwedenTaxCalculation : ITaxCalculationStrategy
    {
        public decimal Tax(int Salary)
        {
            if (Salary > 50000)
                return Salary * 0.6m;
            if (Salary > 40000)
                return Salary * 0.5m;
            if (Salary > 30000)
                return Salary * 0.2m;
            return Salary * 0.1m;
        }
    }

    class NorwayTaxCalculation : ITaxCalculationStrategy
    {
        public decimal Tax(int Salary)
        {
            if (Salary > 50000)
                return Salary * 0.4m;
            if (Salary > 40000)
                return Salary * 0.3m;
            if (Salary > 30000)
                return Salary * 0.2m;
            return Salary * 0.1m;
        }
    }



    class Person
    {
        public string Namn { get; set; }
        public void ChangeName(string n)
        {

        }
        public void MarryTo(Person p)
        {

        }

        public string Country { get; set; }
        public int Salary { get; set; }
        public decimal Tax()
        {
            ITaxCalculationStrategy strategy = null;
            if (Country == "SE")
            {
                strategy = new SwedenTaxCalculation();
            }
            if (Country == "NO")
            {
                strategy = new NorwayTaxCalculation();
            }
            return strategy.Tax(Salary);

        }
    }

    class RealLifeDecorator
    {
        public static void Run()
        {
            IHockey hockey = new HockeyDBService();
            hockey = new CachedHockeyDBService(hockey);



            for (int i = 0; i < 10; i++)
            {
                string player = hockey.GetBestPlayer();
                Console.WriteLine($"Best is {player}");
            }



            IEmailSender a = new GmailSender();
            IEmailSender b = new MailLogger(a);
            IEmailSender sender = new MailBiller(b);





            sender.SendEmail("stefan@hej.com", "stefan@hopp.com", "Viktigt meddelande", "Lunch snart");
        }
    }
}
