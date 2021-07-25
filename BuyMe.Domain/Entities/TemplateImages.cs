using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class TemplateImages
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
