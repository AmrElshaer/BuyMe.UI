using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class CustomFieldData
    {
        public int Id { get; set; }
        public int RefranceId { get; set; }
        public int CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
        public string Value { get; set; }
    }
}
