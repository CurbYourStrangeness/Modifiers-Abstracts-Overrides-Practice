using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            "Trump wins reelection 2020".ConsolePrint();
            EntrepeneurSuite handle = new EntrepeneurSuite();

            Person perc = new Person();

            perc.SetDefaultAge(999999999).PrintInfo();

            handle.BoolStaffSize().SetStaffSize(999999999);
            
            Console.ReadLine();
        }               
    }

    public class EntrepeneurSuite
    {
        public List<string> BusinessGoals { get; set; }

        public int InventorySize { get; set; }

        public int StaffSize { get; set; }

        public bool StaffSizeLargerThanTen { get; set; }
    }

    public class Person
    {
        public string fName { get; set; }

        public string lName { get; set; }

        public int Age { get; set; }
    }

    public static class ExtensionSamps
    {
        public static void ConsolePrint(this string messge)
        {
            Console.WriteLine(messge);
        }

        public static EntrepeneurSuite BoolStaffSize(this EntrepeneurSuite suiteO)
        {
            suiteO.StaffSizeLargerThanTen = true;
            return suiteO;
        }

        public static EntrepeneurSuite SetStaffSize(this EntrepeneurSuite suiteA, int size)
        {
            suiteA.StaffSize = size;
            return suiteA;
        }

        public static Person SetDefaultAge(this Person perc, int age)
        {
            perc.Age = age;
            return perc;
        }

        public static void PrintInfo(this Person perc)
        {
            Console.WriteLine(perc.Age);
        }

    }
}
