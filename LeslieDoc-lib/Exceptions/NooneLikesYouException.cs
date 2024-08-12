using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeslieDoc.Exceptions
{
    internal class NooneLikesYouException : Exception
    {
        public NooneLikesYouException(string message) : base(message)
        {
            
        }
    }
}
