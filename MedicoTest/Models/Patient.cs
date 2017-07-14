using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoTest.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
