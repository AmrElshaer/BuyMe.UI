using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.IntegrationEvents
{
    public class EmployeeCreatedEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
