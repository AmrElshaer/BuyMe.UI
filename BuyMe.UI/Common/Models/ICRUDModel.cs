using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UI.Common.Models
{
    public interface ICRUDModel<T>
    {
         string action { get; set; }

         string table { get; set; }

         string keyColumn { get; set; }

         object key { get; set; }

         T value { get; set; }

         List<T> added { get; set; }

         List<T> changed { get; set; }

         List<T> deleted { get; set; }

         IDictionary<string, object> @params { get; set; }
    }
}
