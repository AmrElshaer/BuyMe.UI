using BuyMe.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class Company: AuditableEntity
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
            Currencies = new HashSet<Currency>();
            Branches = new HashSet<Branch>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Business { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
        public int? TemplateId { get; set; }
        public Template Template { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Currency> Currencies { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
