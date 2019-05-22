using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public string Telephone { get; set; }


        //EmployeeType-Employee (1-M))
        public virtual EmployeeType EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }


        //Gender-Employee (1-M)
        public virtual Gender Gender { get; set; }
        public int  GenderId { get; set; }

        //Title-Employee (1-M)
        public virtual Title Title { get; set; }
        public int TitleId { get; set; }

        //Nationality-Employee (1-M)
        public virtual Nationality Nationality { get; set; }
        public int NationalityId { get; set; }

        //Driver-Employee
        public Driver Driver { get; set;  }


    }
}

