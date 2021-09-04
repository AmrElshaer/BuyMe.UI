using BuyMe.Domain.Common;
using System;

namespace BuyMe.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}