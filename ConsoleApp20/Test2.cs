using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{

    class SalesOrder
    {
        private readonly string name;
        private readonly string phone;
        private readonly string email;
        private readonly string adress;
        private readonly string postal;
        private readonly string city;
        private readonly int  age;

        public SalesOrder(string name, string fax, string phone, string email, string Address, int postal, string team, string City, int age  )
        {
            this.name = name;
            this.phone = phone;
            
        }

    }

    class SalesOrderBuilder
    {
        private string name;
        private int postalCode;
        private string city;
        private string phone = null;
        private string fax = null;
        private string email;
        private int age;
        private string street;
        private string team;


        public SalesOrderBuilder WithTeam(string team)
        {
            this.team = team;
            return this;
        }
        public SalesOrderBuilder WithStreetAddress(string address)
        {
            this.street = address;
            return this;
        }

        public SalesOrderBuilder WithPhone(string phone)
        {
            this.phone = phone;
            return this;
        }
        public SalesOrderBuilder WithEmail(string email)
        {
            this.email = email;
            return this;
        }
        public SalesOrderBuilder WithFax(string fax)
        {
            this.fax = fax;
            return this;
        }

        public SalesOrderBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public SalesOrderBuilder WithPostalAddress(int postalCode, string city)
        {
            this.postalCode = postalCode;
            this.city = city;
            return this;
        }
        public SalesOrderBuilder WithAge(int age)
        {
            this.age = age;
            return this;
        }

        public SalesOrder Build()
        {
            var salesOrder = new SalesOrder(this.name, this.fax,this.phone,
                this.email,
                this.street, this.postalCode, this.team, this.city, this.age);
            return salesOrder;
        }
    }


    class Test2
    {


        public static void Run()
        {
            var salesOrder = new SalesOrderBuilder()
                                    .WithPostalAddress(13211, "Stockholm")
                                    .WithName("Sudden")
                                    .WithEmail("aaaa@aaa.com")
                                    .WithStreetAddress("testgatan 123")
                                    .WithPhone("08-121212")
                                    .WithAge(49)
                                    .Build();
        }
    }
}
