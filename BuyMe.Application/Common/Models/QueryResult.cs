using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Models
{
    public class QueryResult<T>
    {
        public int count { get; set; }
        public IList<T> result { get; set; }
    }
}
