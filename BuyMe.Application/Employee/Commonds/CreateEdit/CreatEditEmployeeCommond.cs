﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Employee.Commonds.CreateEdit
{
    public class CreatEditEmployeeCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
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
        public string UserId { get; set; }
        public int? CompanyId { get; set; }

    }
}
