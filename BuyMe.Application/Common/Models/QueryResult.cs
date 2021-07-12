using System.Collections.Generic;

namespace BuyMe.Application.Common.Models
{
    public class QueryResult<T>
    {
        public int count { get; set; }
        public IList<T> result { get; set; }
    }
}