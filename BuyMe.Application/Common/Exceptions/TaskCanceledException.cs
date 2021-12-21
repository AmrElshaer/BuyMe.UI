using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Exceptions
{
    public class TaskCanceledException : Exception
    {
        public TaskCanceledException(string task):base($"${task} is canceled!")
        {

        }
    }
}
