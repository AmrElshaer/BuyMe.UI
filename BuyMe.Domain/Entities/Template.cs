using System.Collections.Generic;

namespace BuyMe.Domain.Entities
{
    public class Template
    {
        public Template()
        {
            Images = new HashSet<TemplateImages>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TemplateImages> Images { get; set; }
    }
}