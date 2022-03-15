using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class PurchaseType
    {
        public PurchaseType()
        {

        }
        public PurchaseType(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public void Update(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
