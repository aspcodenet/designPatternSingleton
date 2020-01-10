using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        //Singleton
        //Vissa objekt = menade att finnas flera. Employee
        //Andra - menade att bara finnas EN,
        // ex TaxRules

        public class Employee
        {
            public string Name { get; set; }
            public int Salary { get; set; }
        }

        public class TaxRules
        {
            public string Version { get; set; }

            private TaxRules()
            {
                Version = "12334";
                fsfdsfdsfds = new
                    List<string>();
                for (int i = 0; i < 1000000; i++)
                    fsfdsfdsfds.Add(i.ToString());
            }

            private static TaxRules _theOnlyInstance = null;
            public static TaxRules GetInstance()
            {
                if (_theOnlyInstance == null)
                    _theOnlyInstance = new TaxRules();
                return _theOnlyInstance;
            }

            List<string> fsfdsfdsfds;

           

           
            public int CalculateTax(Employee person)
            {
                if (person.Name.StartsWith("S"))
                    return 0;
                if (person.Salary > 10000)
                    return Convert.ToInt32(person.Salary * 0.5);
                return Convert.ToInt32(person.Salary * 0.4);

            }
            
        }


        static void Main(string[] args)
        {
            Test2.Run();
            RealLifeDecorator.Run();
            Mackor.Run();



            var emp = new Employee { Name= "Stefan Holmberg sdadsadassdadadas", Salary = 342};
            var emp2 = new Employee { Name = "Stefan Holmberg sdadsadassdadadas", Salary = 342 };

            emp2.Name = "423234";
            Console.WriteLine(emp.Name);

            //Hur kan vi kolla ifall två objekt är EXAKT samma
            //inte samma  värden






            //utan pekar på SAMMA objekt på heapen
            //1. sätt ett värde på den ena. Den andra ska då uppdateras
            //2. Skapa en Guid
            //3. ReferenceEquals








            bool f = Object.ReferenceEquals(emp, emp2);
            if (f)
                Console.WriteLine("lika");
            else
                Console.WriteLine("not lika");


            var tax1 = TaxRules.GetInstance();
            var tax2 = TaxRules.GetInstance();
            tax1.Version = "a";
            Console.WriteLine(tax2.Version);



            f = Object.ReferenceEquals(tax1, tax2);
            if (f)
                Console.WriteLine("lika");
            else 
                Console.WriteLine("not lika");

        }
    }
}
