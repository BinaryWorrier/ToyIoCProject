using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyIoCProject.App
{
    internal interface IClock
    {
        DateTime Now { get; }
    }

    internal class UTCClock : IClock
    {
        public UTCClock()
        {
            Console.WriteLine("Creating UTCClock");
        }
        public DateTime Now => DateTime.UtcNow;
    }
}
