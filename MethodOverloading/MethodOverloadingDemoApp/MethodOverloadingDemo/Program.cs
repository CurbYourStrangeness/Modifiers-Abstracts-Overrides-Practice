using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonModel("Jack", "Miller", "sombrabomba2019@gmail.com");
            Console.WriteLine(person.email);

            person.EmailGen();
            Console.WriteLine(person.email);
            
            Console.ReadLine();
        }

        public class PersonModel
        {
            public string fName { get; set; }

            public string lName { get; set; }

            public string email { get; set; }

            public int PhoneNum { get; set; }

            public long EmployeeId { get; set; }

            public string Domain { get; set; }

            public PersonModel(int phNum, long EmpId)
            {
                PhoneNum = phNum;

                EmployeeId = EmpId;
            }

            public PersonModel(string fname, string lname, string Email)
            {
                fName = fname;

                lName = lname;

                email = Email;
            }
        
            public void EmailGen()
            {
                EmailGen(false, "offworldstartups.com");
            }

            public void EmailGen(string domain)
            {
                EmailGen(false, domain);
            }

            public void EmailGen(bool initMethod, string domain)
            {
                if (initMethod)
                {
                    EmailGen();
                }
                else
                {
                    EmailGen(domain);
                }
            }
        }

        public class EmployeeModel
        {
            public int EmpId { get; set; }

            public int ManagerId { get; set; }

            public string MgrName { get; set; }

            public bool HasMgr { get; set; }

            public int WorkPhone { get; set; }

            public void SetMgrID()
            {
                HasMgr = true;

                SetMgrID(HasMgr, 999999999);

                SetMgrID("Yukari Yakumo");
            }

            public void SetMgrID(string MgrNme)
            {
                MgrName = MgrNme;
            }

            public void SetMgrID(bool HasMgr, int MgrID)
            {
                if (HasMgr)
                {
                    ManagerId = MgrID;
                }
                else
                {
                    ManagerId = 0;
                }
            }

        }

    }
}
