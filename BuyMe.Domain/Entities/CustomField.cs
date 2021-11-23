using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
