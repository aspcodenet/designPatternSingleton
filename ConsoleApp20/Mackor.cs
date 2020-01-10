using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    //Decorator Schoolbook example
    interface IMackaComponent
    {
        int Pris();
    }

    class Gurka : IMackaComponent
    {
        IMackaComponent stapladPa;

        public Gurka(IMackaComponent comp)
        {
            stapladPa = comp;
        }

        public int Pris()
        {
            int pris = 3;
            if (stapladPa != null)
                pris += stapladPa.Pris();
            return pris;
        }
    }


    class Tomat : IMackaComponent
    {
        IMackaComponent stapladPa;

        public Tomat(IMackaComponent comp)
        {
            stapladPa = comp;
        }

        public int Pris()
        {
            int pris = 5;
            if (stapladPa != null)
                pris += stapladPa.Pris();
            return pris;
        }
    }


    class VittBrod : IMackaComponent
    {
        public VittBrod()
        {
        }

        public int Pris()
        {
            int pris = 10;
            return pris;
        }

    }


    class Macka
    {
        public Macka(string typeOfBread)
        {
            TypeOfBread = typeOfBread;
        }
        public string TypeOfBread { get; set; }
        public bool Gurka { get; set; }
        public bool Tomat { get; set; }
        public bool Ost { get; set; }
        public bool Skinka { get; set; }

        public int Pris()
        {            
            int  total  = 20; //bread
            if (Gurka)
                total += 3;
            if (Tomat)
                total += 5;
            if (Ost)
                total += 6;
            if (Skinka)
                total += 10;
            return total;
        }
    }
    class Mackor
    {
        static public void Run()
        {

            IMackaComponent comp = new VittBrod();
            Console.WriteLine("Gurka?");
            bool add = Console.ReadLine() == "J";
            if (add)
                comp = new Gurka(comp);

            Console.WriteLine("Tomat?");
            add = Console.ReadLine() == "J";
            if (add)
                comp = new Tomat(comp);




            int price = comp.Pris();
            Console.WriteLine($"Pris:{price}");
        }
    }
}
